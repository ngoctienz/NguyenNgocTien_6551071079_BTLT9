using System.Collections.Concurrent;
using System.Net.Http;
using System.Text.Json;
using Serilog;

namespace C5_QuanLyDatTour.Services
{
    public class TyGiaResult
    {
        public decimal TyGia { get; set; }
        public string Nguon { get; set; } = string.Empty;
        public bool IsFromCache { get; set; }
    }

    public static class TyGiaService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly ConcurrentDictionary<string, (decimal rate, string source, DateTime time)> _cache 
            = new ConcurrentDictionary<string, (decimal, string, DateTime)>();

        /// <summary>
        /// Lấy tỷ giá ngoại tệ ra VND theo cơ chế gọi API có dự phòng và bộ nhớ đệm (Cache 10 phút)
        /// </summary>
        /// <param name="ngoaiTe">Mã ngoại tệ: THB, KRW, JPY, USD...</param>
        /// <returns>Đối tượng TyGiaResult gồm tỷ giá và nguồn lấy tỷ giá</returns>
        public static async Task<TyGiaResult> LayTyGiaAsync(string ngoaiTe)
        {
            if (string.IsNullOrWhiteSpace(ngoaiTe) || ngoaiTe.Trim().Equals("VND", StringComparison.OrdinalIgnoreCase))
            {
                return new TyGiaResult
                {
                    TyGia = 1m,
                    Nguon = "Mặc định (VND)",
                    IsFromCache = false
                };
            }

            string code = ngoaiTe.Trim().ToLowerInvariant();
            var settings = AppConfig.ExchangeRateSettings;
            int cacheMinutes = settings.CacheDurationMinutes > 0 ? settings.CacheDurationMinutes : 10;

            // 1. Kiểm tra Cache bộ nhớ
            if (_cache.TryGetValue(code, out var cachedItem))
            {
                if ((DateTime.Now - cachedItem.time).TotalMinutes < cacheMinutes)
                {
                    Log.Information("Lấy tỷ giá {Code} từ Cache bộ nhớ thành công (còn hạn {Phut} phút). Tỷ giá: {Rate}", 
                        code.ToUpper(), (cacheMinutes - (DateTime.Now - cachedItem.time).TotalMinutes).ToString("F1"), cachedItem.rate);

                    return new TyGiaResult
                    {
                        TyGia = cachedItem.rate,
                        Nguon = $"{cachedItem.source} (cache)",
                        IsFromCache = true
                    };
                }
            }

            int timeoutSeconds = settings.TimeoutSeconds > 0 ? settings.TimeoutSeconds : 10;
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));

            // 2. Thử gọi địa chỉ chính (Primary URL)
            string primaryUrl = settings.PrimaryUrl.Replace("{code}", code);
            try
            {
                var response = await _httpClient.GetAsync(primaryUrl, cts.Token);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync(cts.Token);
                decimal rate = ParseExchangeRate(json, code);

                string sourceHost = GetHostName(primaryUrl);
                Log.Information("Lấy tỷ giá {Code} thành công từ địa chỉ chính: {Url}. Tỷ giá: {Rate}", 
                    code.ToUpper(), primaryUrl, rate);

                _cache[code] = (rate, sourceHost, DateTime.Now);

                return new TyGiaResult
                {
                    TyGia = rate,
                    Nguon = sourceHost,
                    IsFromCache = false
                };
            }
            catch (Exception ex)
            {
                // Ghi Warning theo đúng yêu cầu đề bài (9.3) kèm lý do
                Log.Warning("Gọi API tỷ giá chính thất bại tại {Url}. Lý do: {Reason}. Đang tự động chuyển sang địa chỉ dự phòng...", 
                    primaryUrl, ex.Message);
            }

            // 3. Thử gọi địa chỉ dự phòng (Secondary URL)
            string secondaryUrl = settings.SecondaryUrl.Replace("{code}", code);
            try
            {
                using var ctsSecondary = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));
                var response = await _httpClient.GetAsync(secondaryUrl, ctsSecondary.Token);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync(ctsSecondary.Token);
                decimal rate = ParseExchangeRate(json, code);

                string sourceHost = GetHostName(secondaryUrl);
                Log.Information("Lấy tỷ giá {Code} thành công từ địa chỉ DỰ PHÒNG: {Url}. Tỷ giá: {Rate}", 
                    code.ToUpper(), secondaryUrl, rate);

                _cache[code] = (rate, sourceHost, DateTime.Now);

                return new TyGiaResult
                {
                    TyGia = rate,
                    Nguon = sourceHost,
                    IsFromCache = false
                };
            }
            catch (Exception ex2)
            {
                // Cả hai địa chỉ đều lỗi mới báo người dùng
                Log.Error("Cả hai địa chỉ API tỷ giá cho {Code} đều thất bại! Địa chỉ dự phòng: {Url}, Lỗi: {Reason}", 
                    code.ToUpper(), secondaryUrl, ex2.Message);

                throw new InvalidOperationException($"Không thể lấy tỷ giá cho ngoại tệ '{ngoaiTe.ToUpper()}'. Cả địa chỉ chính và dự phòng đều gặp sự cố. Vui lòng kiểm tra kết nối mạng!");
            }
        }

        private static decimal ParseExchangeRate(string json, string code)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            if (root.TryGetProperty(code, out var currencyElement) &&
                currencyElement.TryGetProperty("vnd", out var vndElement))
            {
                return vndElement.GetDecimal();
            }

            throw new KeyNotFoundException($"Không tìm thấy tỷ giá '{code} -> vnd' trong dữ liệu API trả về.");
        }

        private static string GetHostName(string url)
        {
            try
            {
                var uri = new Uri(url);
                return uri.Host;
            }
            catch
            {
                return url;
            }
        }
    }
}
