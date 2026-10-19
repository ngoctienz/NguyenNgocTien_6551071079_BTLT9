using System;
using System.Collections.Generic;
using System.Globalization;

namespace C3_QuanLyDaNgoai.Services
{
    public static class LocalizationService
    {
        public static string CurrentLanguage { get; private set; } = "vi";

        public static CultureInfo CurrentCulture => CurrentLanguage == "en"
            ? new CultureInfo("en-US")
            : new CultureInfo("vi-VN");

        public static void SetLanguage(string lang)
        {
            CurrentLanguage = lang == "en" ? "en" : "vi";
        }

        public static string GetWeatherDescription(int code)
        {
            bool isEn = CurrentLanguage == "en";
            return code switch
            {
                0 => isEn ? "Clear sky" : "Trời quang",
                1 => isEn ? "Mainly clear" : "Trời quang, ít mây",
                2 => isEn ? "Partly cloudy" : "Có mây",
                3 => isEn ? "Overcast" : "Nhiều mây",
                45 or 48 => isEn ? "Foggy" : "Sương mù",
                51 or 53 or 55 => isEn ? "Light drizzle" : "Mưa phùn nhẹ",
                56 or 57 => isEn ? "Freezing drizzle" : "Mưa phùn buốt giá",
                61 or 63 or 65 => isEn ? "Rain" : "Mưa",
                66 or 67 => isEn ? "Freezing rain" : "Mưa buốt giá",
                80 or 81 or 82 => isEn ? "Light rain showers" : "Mưa rào nhẹ",
                95 or 96 or 99 => isEn ? "Thunderstorm" : "Dông sét",
                _ => isEn ? "Cloudy" : "Có mây"
            };
        }

        public static string FormatCurrency(decimal amount)
        {
            if (CurrentLanguage == "en")
            {
                return amount.ToString("C0", new CultureInfo("en-US"));
            }
            return string.Format(new CultureInfo("vi-VN"), "{0:N0}", amount);
        }

        public static string FormatDate(DateOnly date)
        {
            return CurrentLanguage == "en"
                ? date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                : date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
