using Microsoft.Extensions.Configuration;
using Serilog;

namespace C1_QuanLyChiTieu
{
    internal static class Program
    {
        /// <summary>Chuỗi kết nối đọc từ appsettings.json, dùng chung cho toàn ứng dụng.</summary>
        public static string ConnectionString { get; private set; } = string.Empty;

        // Môi trường: Development khi lập trình (Debug), Production khi phát hành (Release).
#if DEBUG
        private const string MoiTruong = "Development";
#else
        private const string MoiTruong = "Production";
#endif

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1) Đọc chuỗi kết nối từ appsettings.json (+ file ghi đè theo môi trường).
            try
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{MoiTruong}.json", optional: true, reloadOnChange: false)
                    .Build();

                ConnectionString = config.GetConnectionString("QL_ChiTieu")
                    ?? throw new InvalidOperationException("Thiếu 'ConnectionStrings:QL_ChiTieu' trong appsettings.json.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được cấu hình appsettings.json.\n\n" + ex.Message,
                    "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2) Khởi tạo Serilog: ghi file theo ngày vào thư mục Logs cạnh file .exe.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                Log.Information("Khởi động ứng dụng Sổ chi tiêu cá nhân (môi trường {MoiTruong})", MoiTruong);

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new FormChiTieu());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng dừng do lỗi không xử lý được");
                MessageBox.Show("Ứng dụng gặp lỗi và phải đóng. Xem chi tiết trong thư mục Logs.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.Information("Đóng ứng dụng");
                Log.CloseAndFlush();
            }
        }
    }
}
