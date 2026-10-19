using C5_QuanLyDatTour.Services;
using Serilog;

namespace C5_QuanLyDatTour
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Kích hoạt AppConfig để nạp cấu hình và khởi tạo Serilog
            _ = AppConfig.Configuration;

            // Bắt lỗi toàn cục cho luồng giao diện (UI Thread)
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi không xử lý trong UI Thread (ThreadException)");
                MessageBox.Show($"Đã xảy ra lỗi hệ thống: {e.Exception.Message}\nChi tiết xem trong file log.", 
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Bắt lỗi toàn cục cho các luồng nền (Non-UI Thread)
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Lỗi nghiêm trọng không xử lý (AppDomain.UnhandledException)");
                    MessageBox.Show($"Lỗi nghiêm trọng không thể phục hồi: {ex.Message}", 
                        "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            };

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FormDatTour());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng bị dừng đột ngột!");
            }
            finally
            {
                Log.Information("=== Ứng dụng Quản lý đặt tour kết thúc ===");
                Log.CloseAndFlush();
            }
        }
    }
}