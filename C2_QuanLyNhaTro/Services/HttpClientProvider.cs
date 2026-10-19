using Serilog;

namespace C2_QuanLyNhaTro.Services;/// <summary>
/// Một HttpClient dùng chung cho toàn ứng dụng, timeout 10 giây.
/// </summary>
public static class HttpClientProvider
{
    public static HttpClient Instance { get; } = Create();

    private static HttpClient Create()
    {
        return new HttpClient
        {
            BaseAddress = new Uri("https://provinces.open-api.vn/"),
            Timeout = TimeSpan.FromSeconds(10)
        };
    }
}
