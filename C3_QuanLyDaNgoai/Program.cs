using Microsoft.Extensions.Configuration;
using Serilog;

namespace C3_QuanLyDaNgoai
{
    internal static class Program
    {
        public static string ConnectionString { get; private set; } =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QL_DaNgoai;Integrated Security=True;Trust Server Certificate=True";

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
            // 1. Đọc cấu hình từ appsettings.json
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{MoiTruong}.json", optional: true, reloadOnChange: true)
                    .Build();

                var connStr = config.GetConnectionString("QL_DaNgoai");
                if (!string.IsNullOrWhiteSpace(connStr))
                {
                    ConnectionString = connStr;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được cấu hình appsettings.json: " + ex.Message,
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 2. Khởi tạo Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: Path.Combine(AppContext.BaseDirectory, "Logs", "dangoai-.log"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            // 3. Xử lý lỗi toàn cục
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi giao diện không xử lý (ThreadException)");
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + e.Exception.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Lỗi nghiêm trọng (AppDomain.UnhandledException)");
                }
            };

            try
            {
                Log.Information("Ứng dụng Kế hoạch dã ngoại khởi động (Môi trường: {MoiTruong})", MoiTruong);
                ApplicationConfiguration.Initialize();
                Application.Run(new FormChuyenDi());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng dừng đột ngột!");
                MessageBox.Show("Ứng dụng gặp lỗi và phải đóng. Chi tiết trong thư mục Logs.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.Information("Đóng ứng dụng Kế hoạch dã ngoại");
                Log.CloseAndFlush();
            }
        }
    }
}