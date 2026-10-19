using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace C3_QuanLyDaNgoai.Services
{
    public class WeatherResult
    {
        public bool Success { get; set; }
        public bool IsNetworkError { get; set; }
        public bool IsLocationNotFound { get; set; }
        public bool IsBeyond16Days { get; set; }
        public string? ResolvedLocationName { get; set; }
        public int WeatherCode { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public int PrecipitationProbability { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public static class WeatherService
    {
        // Singleton HttpClient with 8s timeout as specified in Task 7
        private static readonly HttpClient HttpClientInstance = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(8)
        };

        public static async Task<WeatherResult> GetWeatherForecastAsync(string location, DateOnly date, string lang = "vi")
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return new WeatherResult
                {
                    Success = false,
                    IsLocationNotFound = true,
                    ErrorMessage = "Vui lòng nhập địa điểm"
                };
            }

            try
            {
                // Step 1: Geocoding API
                var coords = await GetCoordinatesAsync(location.Trim(), lang);
                if (coords == null)
                {
                    // Fallback: try unaccented version
                    string unaccented = RemoveDiacritics(location.Trim());
                    if (!unaccented.Equals(location.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        coords = await GetCoordinatesAsync(unaccented, lang);
                    }
                }

                if (coords == null)
                {
                    return new WeatherResult
                    {
                        Success = false,
                        IsLocationNotFound = true
                    };
                }

                // Step 2: Forecast API
                string forecastUrl = string.Format(
                    CultureInfo.InvariantCulture,
                    "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16",
                    coords.Value.Latitude,
                    coords.Value.Longitude
                );

                using var response = await HttpClientInstance.GetAsync(forecastUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return new WeatherResult
                    {
                        Success = false,
                        IsNetworkError = true,
                        ErrorMessage = $"HTTP {response.StatusCode}"
                    };
                }

                string content = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(content);

                if (!doc.RootElement.TryGetProperty("daily", out var daily))
                {
                    return new WeatherResult { Success = false, IsBeyond16Days = true };
                }

                var times = daily.GetProperty("time");
                int timeCount = times.GetArrayLength();
                string targetDateStr = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                int targetIndex = -1;
                for (int i = 0; i < timeCount; i++)
                {
                    if (times[i].GetString() == targetDateStr)
                    {
                        targetIndex = i;
                        break;
                    }
                }

                if (targetIndex == -1)
                {
                    // Departure date is outside the 16-day forecast range
                    return new WeatherResult
                    {
                        Success = false,
                        IsBeyond16Days = true,
                        ResolvedLocationName = coords.Value.Name
                    };
                }

                int weatherCode = daily.GetProperty("weather_code")[targetIndex].GetInt32();
                double maxTemp = daily.GetProperty("temperature_2m_max")[targetIndex].GetDouble();
                double minTemp = daily.GetProperty("temperature_2m_min")[targetIndex].GetDouble();

                int rainProb = 0;
                if (daily.TryGetProperty("precipitation_probability_max", out var rainArray))
                {
                    var elem = rainArray[targetIndex];
                    if (elem.ValueKind == JsonValueKind.Number)
                    {
                        rainProb = elem.GetInt32();
                    }
                }

                return new WeatherResult
                {
                    Success = true,
                    ResolvedLocationName = coords.Value.Name,
                    WeatherCode = weatherCode,
                    MinTemp = minTemp,
                    MaxTemp = maxTemp,
                    PrecipitationProbability = rainProb
                };
            }
            catch (TaskCanceledException)
            {
                return new WeatherResult
                {
                    Success = false,
                    IsNetworkError = true,
                    ErrorMessage = "Kết nối quá thời gian chờ (Timeout 8s)"
                };
            }
            catch (HttpRequestException ex)
            {
                return new WeatherResult
                {
                    Success = false,
                    IsNetworkError = true,
                    ErrorMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new WeatherResult
                {
                    Success = false,
                    IsNetworkError = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        private static async Task<(double Latitude, double Longitude, string Name)?> GetCoordinatesAsync(string location, string lang)
        {
            string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(location)}&count=1&language={lang}";
            using var response = await HttpClientInstance.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("results", out var results) && results.GetArrayLength() > 0)
            {
                var first = results[0];
                double lat = first.GetProperty("latitude").GetDouble();
                double lon = first.GetProperty("longitude").GetDouble();
                string name = first.GetProperty("name").GetString() ?? location;
                return (lat, lon, name);
            }

            return null;
        }

        private static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC)
                .Replace("đ", "d").Replace("Đ", "D");
        }
    }
}
