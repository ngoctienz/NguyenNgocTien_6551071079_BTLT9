using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace C5_QuanLyDatTour.Services
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; private set; }
        public static ExchangeRateSettings ExchangeRateSettings { get; private set; }
        public static string ConnectionString { get; private set; }

        static AppConfig()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            ExchangeRateSettings = new ExchangeRateSettings();
            Configuration.GetSection("ExchangeRate").Bind(ExchangeRateSettings);

            ConnectionString = Configuration.GetConnectionString("DefaultConnection") 
                ?? "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QL_DatTour;Integrated Security=True;Trust Server Certificate=True";

            ConfigureLogging();
        }

        private static void ConfigureLogging()
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    path: Path.Combine(logDirectory, "app-.log"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("=== Ứng dụng Quản lý đặt tour - Bình An v1.0.0 khởi động ===");
        }
    }
}
