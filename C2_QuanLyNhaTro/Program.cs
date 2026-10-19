using C2_QuanLyNhaTro.Services;
using Serilog;

namespace C2_QuanLyNhaTro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            CauHinhLog();

            Log.Information("Ứng dụng Quản lý nhà trọ khởi động");
            LoiToanCuc.DangKy();

            try
            {
                Application.Run(new FormKhachThue());
            }
            catch (Exception ex)
            {
                LoiToanCuc.XuLy(ex, "Main");
            }
            finally
            {
                Log.Information("Ứng dụng Quản lý nhà trọ kết thúc");
                Log.CloseAndFlush();
            }
        }

        /// <summary>Ghi log ra thư mục "logs" cạnh file exe; Serilog tự tạo thư mục nếu chưa có.</summary>
        private static void CauHinhLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(AppContext.BaseDirectory, "logs", "nhatro-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
