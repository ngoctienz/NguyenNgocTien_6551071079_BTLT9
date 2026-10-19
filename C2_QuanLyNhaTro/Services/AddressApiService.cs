using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Serilog;

namespace C2_QuanLyNhaTro.Services;

public sealed class ProvinceDto
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("code")] public int Code { get; set; }
    [JsonPropertyName("wards")] public List<WardDto>? Wards { get; set; }

    public override string ToString() => Name ?? "";
}

public sealed class WardDto
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("code")] public int Code { get; set; }
    [JsonPropertyName("province_code")] public int ProvinceCode { get; set; }

    public override string ToString() => Name ?? "";
}

/// <summary>Lỗi nghiệp vụ của tầng API địa chỉ; thông báo đã thân thiện sẵn.</summary>
public sealed class AddressApiException : Exception
{
    public AddressApiException(string message, Exception? inner = null) : base(message, inner) { }
}

/// <summary>
/// Gọi API hành chính Việt Nam (provinces.open-api.vn).
/// Mọi lỗi mạng / timeout / JSON đều bị chặn ở đây để form không bao giờ văng.
/// </summary>
public static class AddressApiService
{
    private const string OfflineMessage = "Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng";

    public static async Task<List<ProvinceDto>> GetProvincesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var data = await HttpClientProvider.Instance
                .GetFromJsonAsync<List<ProvinceDto>>("api/v2/", cancellationToken)
                .ConfigureAwait(false);

            return data ?? new List<ProvinceDto>();
        }
        catch (Exception ex) when (IsNetworkFailure(ex))
        {
            Log.Warning(ex, "Không tải được danh sách tỉnh/thành");
            throw new AddressApiException(OfflineMessage, ex);
        }
    }

    public static async Task<List<WardDto>> GetWardsAsync(int provinceCode, CancellationToken cancellationToken = default)
    {
        try
        {
            var data = await HttpClientProvider.Instance
                .GetFromJsonAsync<ProvinceDto>($"api/v2/p/{provinceCode}?depth=2", cancellationToken)
                .ConfigureAwait(false);

            return data?.Wards ?? new List<WardDto>();
        }
        catch (Exception ex) when (IsNetworkFailure(ex))
        {
            Log.Warning(ex, "Không tải được danh sách phường/xã của tỉnh {ProvinceCode}", provinceCode);
            throw new AddressApiException(OfflineMessage, ex);
        }
    }

    private static bool IsNetworkFailure(Exception ex) =>
        ex is HttpRequestException or TaskCanceledException or TimeoutException
        || ex.InnerException is HttpRequestException or TaskCanceledException;

    /// <summary>Lấy tên phường/xã đã nhập tay để tách phần tên và mã số khi API không dùng được.</summary>
    public static (int Code, string Name) SplitManualWard(string input)
    {
        var text = (input ?? string.Empty).Trim();
        var open = text.LastIndexOf('(');

        if (open > 0 && text.EndsWith(')'))
        {
            var inside = text[(open + 1)..^1].Trim();
            if (int.TryParse(inside, out var code))
            {
                return (code, text[..open].Trim());
            }
        }

        return (0, text);
    }
}
