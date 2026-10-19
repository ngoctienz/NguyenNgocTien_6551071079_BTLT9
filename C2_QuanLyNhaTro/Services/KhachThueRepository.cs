using C2_QuanLyNhaTro.Models.EF;
using C2_QuanLyNhaTro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace C2_QuanLyNhaTro.Services;

public sealed class KhachThueDto
{
    public int MaKhach { get; set; }
    public string HoTen { get; set; } = "";
    public string GioiTinh { get; set; } = "";
    public DateOnly NgaySinh { get; set; }
    public string SoDienThoai { get; set; } = "";
    public string TenPhong { get; set; } = "";
    public decimal GiaThue { get; set; }
    public string QueQuan { get; set; } = "";
    public bool DaDangKyTamTru { get; set; }
    public int MaPhong { get; set; }
    public int MaTinh { get; set; }
    public string TenTinh { get; set; } = "";
    public int MaPhuongXa { get; set; }
    public string TenPhuongXa { get; set; } = "";
}

public sealed class PhongTroDto
{
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = "";
    public decimal GiaThue { get; set; }
    public string TinhTrang { get; set; } = "";
    public int SoKhach { get; set; }
}

/// <summary>
/// Toàn bộ truy vấn CSDL của ứng dụng. Mỗi thao tác mở một context ngắn hạn
/// để dữ liệu luôn mới và không giữ kết nối khi form đang chờ API mạng.
/// </summary>
public static class KhachThueRepository
{
    public const string TinhTrangTrong = "Trống";
    public const string TinhTrangDangThue = "Đang thuê";

    public static List<KhachThueDto> LayDanhSach(string? tuKhoa, int? maPhong, int? maTinh)
    {
        using var db = AppDbContextFactory.Create();

        var query =
            from k in db.KhachThues.AsNoTracking()
            join p in db.PhongTros.AsNoTracking() on k.MaPhong equals p.MaPhong
            select new { k, p };

        tuKhoa = tuKhoa?.Trim();
        if (!string.IsNullOrEmpty(tuKhoa))
        {
            query = query.Where(x => x.k.HoTen.Contains(tuKhoa) || x.k.SoDienThoai.Contains(tuKhoa));
        }

        if (maPhong is > 0)
        {
            query = query.Where(x => x.k.MaPhong == maPhong);
        }

        if (maTinh is > 0)
        {
            query = query.Where(x => x.k.MaTinh == maTinh);
        }

        return query
            .OrderBy(x => x.p.TenPhong)
            .ThenBy(x => x.k.HoTen)
            .Select(x => new KhachThueDto
            {
                MaKhach = x.k.MaKhach,
                HoTen = x.k.HoTen,
                GioiTinh = x.k.GioiTinh,
                NgaySinh = x.k.NgaySinh,
                SoDienThoai = x.k.SoDienThoai,
                TenPhong = x.p.TenPhong,
                GiaThue = x.p.GiaThue,
                QueQuan = x.k.TenPhuongXa + " - " + x.k.TenTinh,
                DaDangKyTamTru = x.k.DaDangKyTamTru,
                MaPhong = x.k.MaPhong,
                MaTinh = x.k.MaTinh,
                TenTinh = x.k.TenTinh,
                MaPhuongXa = x.k.MaPhuongXa,
                TenPhuongXa = x.k.TenPhuongXa
            })
            .ToList();
    }

    public static List<PhongTroDto> LayDanhSachPhong()
    {
        using var db = AppDbContextFactory.Create();

        return db.PhongTros
            .AsNoTracking()
            .OrderBy(p => p.TenPhong)
            .Select(p => new PhongTroDto
            {
                MaPhong = p.MaPhong,
                TenPhong = p.TenPhong,
                GiaThue = p.GiaThue,
                TinhTrang = p.TinhTrang,
                SoKhach = p.KhachThues.Count
            })
            .ToList();
    }

    public static List<(int MaTinh, string TenTinh)> LayDanhSachTinhDaCo()
    {
        using var db = AppDbContextFactory.Create();

        return db.KhachThues
            .AsNoTracking()
            .Where(k => k.TenTinh != "")
            .Select(k => new { k.MaTinh, k.TenTinh })
            .Distinct()
            .OrderBy(x => x.TenTinh)
            .ToList()
            .Select(x => (x.MaTinh, x.TenTinh))
            .ToList();
    }

    public static KhachThue? LayTheoMa(int maKhach)
    {
        using var db = AppDbContextFactory.Create();

        return db.KhachThues
            .AsNoTracking()
            .Include(k => k.MaPhongNavigation)
            .FirstOrDefault(k => k.MaKhach == maKhach);
    }

    public static void Them(KhachThue khach)
    {
        using var db = AppDbContextFactory.Create();
        using var tran = db.Database.BeginTransaction();

        db.KhachThues.Add(khach);
        db.SaveChanges();

        CapNhatTinhTrang(db, khach.MaPhong);
        tran.Commit();
    }

    public static void Sua(KhachThue khach)
    {
        using var db = AppDbContextFactory.Create();
        using var tran = db.Database.BeginTransaction();

        var hienTai = db.KhachThues.FirstOrDefault(k => k.MaKhach == khach.MaKhach)
            ?? throw new InvalidOperationException("Khách thuê không còn tồn tại trong CSDL.");

        var maPhongCu = hienTai.MaPhong;

        hienTai.HoTen = khach.HoTen;
        hienTai.GioiTinh = khach.GioiTinh;
        hienTai.NgaySinh = khach.NgaySinh;
        hienTai.SoDienThoai = khach.SoDienThoai;
        hienTai.MaTinh = khach.MaTinh;
        hienTai.TenTinh = khach.TenTinh;
        hienTai.MaPhuongXa = khach.MaPhuongXa;
        hienTai.TenPhuongXa = khach.TenPhuongXa;
        hienTai.DaDangKyTamTru = khach.DaDangKyTamTru;
        hienTai.MaPhong = khach.MaPhong;

        db.SaveChanges();

        CapNhatTinhTrang(db, maPhongCu);
        if (khach.MaPhong != maPhongCu)
        {
            CapNhatTinhTrang(db, khach.MaPhong);
        }

        tran.Commit();
    }

    public static void Xoa(int maKhach)
    {
        using var db = AppDbContextFactory.Create();
        using var tran = db.Database.BeginTransaction();

        var khach = db.KhachThues.FirstOrDefault(k => k.MaKhach == maKhach);
        if (khach is null)
        {
            return;
        }

        var maPhong = khach.MaPhong;
        db.KhachThues.Remove(khach);
        db.SaveChanges();

        CapNhatTinhTrang(db, maPhong);
        tran.Commit();
    }

    /// <summary>Cập nhật trạng thái phòng: còn khách thì "Đang thuê", hết khách thì "Trống".</summary>
    private static void CapNhatTinhTrang(QL_NhaTroContext db, int maPhong)
    {
        var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
        if (phong is null)
        {
            return;
        }

        var conKhach = db.KhachThues.Any(k => k.MaPhong == maPhong);
        var tinhTrangMoi = conKhach ? TinhTrangDangThue : TinhTrangTrong;

        if (phong.TinhTrang != tinhTrangMoi)
        {
            phong.TinhTrang = tinhTrangMoi;
            db.SaveChanges();
            Log.Information("Phòng {MaPhong} chuyển trạng thái sang {TinhTrang}", maPhong, tinhTrangMoi);
        }
    }
}
