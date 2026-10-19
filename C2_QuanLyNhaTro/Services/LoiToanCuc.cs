using Serilog;

namespace C2_QuanLyNhaTro.Services;

/// <summary>
/// Bộ xử lý lỗi toàn cục: mọi lỗi chưa bắt đều được ghi log kèm stack trace
/// và người dùng chỉ thấy một thông báo thân thiện, ứng dụng vẫn chạy tiếp.
/// </summary>
public static class LoiToanCuc
{
    public const string ThongBaoThanThien =
        "Đã xảy ra lỗi, thông tin đã được ghi lại. Bạn hãy thử lại thao tác vừa rồi.";

    public static void DangKy()
    {
        // Lỗi trong luồng UI đi qua Application.ThreadException.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => XuLy(e.Exception, "ThreadException");

        // Lỗi ở luồng nền không thể chặn, nhưng vẫn phải được ghi log.
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            XuLy(e.ExceptionObject as Exception, "UnhandledException");

        TaskScheduler.UnobservedTaskException += (_, e) =>
        {
            XuLy(e.Exception, "UnobservedTaskException");
            e.SetObserved();
        };
    }

    public static void XuLy(Exception? ex, string nguon)
    {
        Log.Error(ex, "Lỗi chưa được xử lý tại {Nguon}", nguon);

        try
        {
            MessageBox.Show(
                ThongBaoThanThien,
                "Có lỗi xảy ra",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch
        {
            // Nếu cả hộp thoại cũng lỗi thì không còn gì hữu ích để làm.
        }
    }
}
