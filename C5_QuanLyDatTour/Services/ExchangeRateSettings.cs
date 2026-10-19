
namespace C5_QuanLyDatTour.Services
{
    public class ExchangeRateSettings
    {
        public string PrimaryUrl { get; set; } = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies/{code}.json";
        public string SecondaryUrl { get; set; } = "https://latest.currency-api.pages.dev/v1/currencies/{code}.json";
        public int TimeoutSeconds { get; set; } = 10;
        public int CacheDurationMinutes { get; set; } = 10;
    }
}
