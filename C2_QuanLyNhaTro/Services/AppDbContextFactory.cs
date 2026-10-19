using C2_QuanLyNhaTro.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace C2_QuanLyNhaTro.Services;

/// <summary>
/// Cấu hình kết nối CSDL đọc từ appsettings.json, có fallback mặc định.
/// </summary>
public static class AppDbContextFactory
{
    private const string DefaultConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=QL_NhaTro;Integrated Security=true;TrustServerCertificate=true;";

    public static string ConnectionString { get; private set; } = DefaultConnectionString;

    static AppDbContextFactory()
    {
        try
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            var connStr = config.GetConnectionString("QL_NhaTro");
            if (!string.IsNullOrWhiteSpace(connStr))
            {
                ConnectionString = connStr;
            }
        }
        catch
        {
            // Dùng chuỗi kết nối mặc định nếu không đọc được file cấu hình
            ConnectionString = DefaultConnectionString;
        }
    }

    public static QL_NhaTroContext Create()
    {
        var options = new DbContextOptionsBuilder<QL_NhaTroContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        return new QL_NhaTroContext(options);
    }
}
