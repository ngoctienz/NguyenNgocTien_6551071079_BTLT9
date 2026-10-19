using System.Globalization;
using C1_QuanLyChiTieu.Models.EF;
using C1_QuanLyChiTieu.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace C1_QuanLyChiTieu
{
    public partial class FormChiTieu : Form
    {
        // Định dạng số kiểu Việt Nam: 1.250.000
        private static readonly CultureInfo VnCulture = CultureInfo.GetCultureInfo("vi-VN");

        // Danh sách đang hiển thị trên lưới (khớp theo thứ tự dòng).
        private readonly List<ChiTieu> _danhSach = new();

        // Mã khoản chi đang chọn (null nếu chưa chọn).
        private int? _maDangChon;

        // Chống xử lý sự kiện khi đang nạp lại lưới.
        private bool _dangTai;

        public FormChiTieu()
        {
            InitializeComponent();

            DatBoLocMacDinh();
            XoaTrangNhap();
            GanSuKien();

            TaiDuLieu();
        }

        // Tạo DbContext từ chuỗi kết nối trong appsettings.json.
        private static QL_ChiTieuContext TaoContext()
        {
            var options = new DbContextOptionsBuilder<QL_ChiTieuContext>()
                .UseSqlServer(Program.ConnectionString)
                .Options;
            return new QL_ChiTieuContext(options);
        }

        private void GanSuKien()
        {
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTim.Click += (s, e) => TaiDuLieu();

            dgvChiTieu.SelectionChanged += DgvChiTieu_SelectionChanged;

            txtTimNoiDung.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    TaiDuLieu();
                }
            };

            cboLocLoaiChi.SelectedIndexChanged += (s, e) => TaiDuLieu();
        }

        // ==================== Nạp dữ liệu / lọc ====================

        private void TaiDuLieu()
        {
            _dangTai = true;
            try
            {
                List<ChiTieu> ketQua = TruyVan();

                _danhSach.Clear();
                _danhSach.AddRange(ketQua);

                dgvChiTieu.Rows.Clear();
                foreach (ChiTieu ct in ketQua)
                {
                    dgvChiTieu.Rows.Add(
                        ct.MaCt.ToString("D3"),
                        ct.NgayChi.ToString("dd/MM/yyyy", VnCulture),
                        ct.NoiDung,
                        ct.LoaiChi,
                        ct.SoTien.ToString("N0", VnCulture),
                        ct.GhiChu ?? string.Empty);
                }

                CapNhatTongChi();

                if (_danhSach.Count > 0)
                {
                    dgvChiTieu.ClearSelection();
                    dgvChiTieu.Rows[0].Selected = true;
                    dgvChiTieu.CurrentCell = dgvChiTieu.Rows[0].Cells[0];
                    HienThiLenForm(_danhSach[0]);
                }
                else
                {
                    _maDangChon = null;
                }
            }
            catch (Exception ex)
            {
                BaoLoi("tải danh sách chi tiêu", ex);
            }
            finally
            {
                _dangTai = false;
            }
        }

        // Truy vấn theo nội dung + loại chi + khoảng ngày.
        private List<ChiTieu> TruyVan()
        {
            using QL_ChiTieuContext ctx = TaoContext();
            IQueryable<ChiTieu> query = ctx.ChiTieus.AsNoTracking();

            string tuKhoa = txtTimNoiDung.Text.Trim();
            if (tuKhoa.Length > 0)
            {
                query = query.Where(c => c.NoiDung.Contains(tuKhoa));
            }

            string loai = cboLocLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
            if (loai != "Tất cả")
            {
                query = query.Where(c => c.LoaiChi == loai);
            }

            DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
            if (tuNgay > denNgay)
            {
                (tuNgay, denNgay) = (denNgay, tuNgay);
            }

            query = query.Where(c => c.NgayChi >= tuNgay && c.NgayChi <= denNgay);

            return query.OrderBy(c => c.NgayChi).ThenBy(c => c.MaCt).ToList();
        }

        private void CapNhatTongChi()
        {
            decimal tong = _danhSach.Sum(c => c.SoTien);
            lblTongChi.Text = $"Tổng chi: {tong.ToString("N0", VnCulture)} đ";
        }

        // ==================== Đồng bộ lưới <-> control ====================

        private void DgvChiTieu_SelectionChanged(object? sender, EventArgs e)
        {
            if (_dangTai || dgvChiTieu.CurrentRow is null)
            {
                return;
            }

            int index = dgvChiTieu.CurrentRow.Index;
            if (index >= 0 && index < _danhSach.Count)
            {
                HienThiLenForm(_danhSach[index]);
            }
        }

        private void HienThiLenForm(ChiTieu ct)
        {
            dtpNgayChi.Value = ct.NgayChi.ToDateTime(TimeOnly.MinValue);
            txtNoiDung.Text = ct.NoiDung;
            cboLoaiChi.SelectedItem = ct.LoaiChi;
            if (cboLoaiChi.SelectedIndex < 0)
            {
                cboLoaiChi.SelectedIndex = cboLoaiChi.Items.Count - 1; // "Khác"
            }

            nudSoTien.Value = ct.SoTien > nudSoTien.Maximum ? nudSoTien.Maximum : ct.SoTien;
            txtGhiChu.Text = ct.GhiChu ?? string.Empty;

            _maDangChon = ct.MaCt;
        }

        // ==================== CRUD ====================

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraHopLe(out DateOnly ngayChi, out decimal soTien))
            {
                return;
            }

            try
            {
                using QL_ChiTieuContext ctx = TaoContext();
                var moi = new ChiTieu
                {
                    NgayChi = ngayChi,
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = soTien,
                    GhiChu = RongThanhNull(txtGhiChu.Text)
                };

                ctx.ChiTieus.Add(moi);
                ctx.SaveChanges();

                Log.Information("Thêm khoản chi - MaCT={MaCT}, Ngày={NgayChi}, Loại={LoaiChi}, Số tiền={SoTien}",
                    moi.MaCt, moi.NgayChi, moi.LoaiChi, moi.SoTien);

                MessageBox.Show("Đã thêm khoản chi mới.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                BaoLoi("thêm khoản chi", ex);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (_maDangChon is null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Chưa chọn dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraHopLe(out DateOnly ngayChi, out decimal soTien))
            {
                return;
            }

            try
            {
                using QL_ChiTieuContext ctx = TaoContext();
                ChiTieu? ct = ctx.ChiTieus.Find(_maDangChon.Value);
                if (ct is null)
                {
                    MessageBox.Show("Khoản chi không còn tồn tại.", "Không tìm thấy",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TaiDuLieu();
                    return;
                }

                ct.NgayChi = ngayChi;
                ct.NoiDung = txtNoiDung.Text.Trim();
                ct.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
                ct.SoTien = soTien;
                ct.GhiChu = RongThanhNull(txtGhiChu.Text);
                ctx.SaveChanges();

                Log.Information("Sửa khoản chi - MaCT={MaCT}, Ngày={NgayChi}, Loại={LoaiChi}, Số tiền={SoTien}",
                    ct.MaCt, ct.NgayChi, ct.LoaiChi, ct.SoTien);

                MessageBox.Show("Đã cập nhật khoản chi.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                BaoLoi("sửa khoản chi", ex);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (_maDangChon is null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Chưa chọn dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult traLoi = MessageBox.Show(
                $"Bạn có chắc muốn xóa khoản chi \"{txtNoiDung.Text}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (traLoi != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using QL_ChiTieuContext ctx = TaoContext();
                ChiTieu? ct = ctx.ChiTieus.Find(_maDangChon.Value);
                if (ct is not null)
                {
                    ctx.ChiTieus.Remove(ct);
                    ctx.SaveChanges();

                    Log.Information("Xóa khoản chi - MaCT={MaCT}, Nội dung={NoiDung}, Số tiền={SoTien}",
                        ct.MaCt, ct.NoiDung, ct.SoTien);
                }

                XoaTrangNhap();
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                BaoLoi("xóa khoản chi", ex);
            }
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            DatBoLocMacDinh();
            XoaTrangNhap();
            TaiDuLieu();
        }

        // ==================== Kiểm tra & tiện ích ====================

        private bool KiemTraHopLe(out DateOnly ngayChi, out decimal soTien)
        {
            ngayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
            soTien = nudSoTien.Value;

            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                ThongBao("Nội dung không được để trống.", txtNoiDung);
                return false;
            }

            if (soTien <= 0)
            {
                ThongBao("Số tiền phải lớn hơn 0.", nudSoTien);
                return false;
            }

            if (ngayChi > DateOnly.FromDateTime(DateTime.Today))
            {
                ThongBao("Ngày chi không được lớn hơn ngày hôm nay.", dtpNgayChi);
                return false;
            }

            return true;
        }

        private static void ThongBao(string noiDung, Control control)
        {
            MessageBox.Show(noiDung, "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void XoaTrangNhap()
        {
            dtpNgayChi.Value = DateTime.Today;
            txtNoiDung.Clear();
            cboLoaiChi.SelectedIndex = 0;
            nudSoTien.Value = 0;
            txtGhiChu.Clear();

            _maDangChon = null;
            dgvChiTieu.ClearSelection();
        }

        private void DatBoLocMacDinh()
        {
            txtTimNoiDung.Clear();
            cboLocLoaiChi.SelectedItem = "Tất cả";

            DateTime homNay = DateTime.Today;
            dtpTuNgay.Value = new DateTime(homNay.Year, homNay.Month, 1);
            dtpDenNgay.Value = homNay;
        }

        private static string? RongThanhNull(string? giaTri)
        {
            return string.IsNullOrWhiteSpace(giaTri) ? null : giaTri.Trim();
        }

        // Ghi log Error + báo thông báo thân thiện khi lỗi CSDL.
        private static void BaoLoi(string hanhDong, Exception ex)
        {
            Log.Error(ex, "Lỗi CSDL khi {HanhDong}", hanhDong);
            MessageBox.Show(
                "Không thể truy cập cơ sở dữ liệu.\n\nVui lòng kiểm tra chuỗi kết nối trong appsettings.json " +
                "và bảo đảm SQL Server đang chạy.\n\nChi tiết: " + ex.Message,
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
