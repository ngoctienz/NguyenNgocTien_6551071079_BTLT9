using C5_QuanLyDatTour.Models.EF;
using C5_QuanLyDatTour.Models.Entities;
using C5_QuanLyDatTour.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace C5_QuanLyDatTour
{
    public partial class FormDatTour : Form
    {
        private ApplicationDbContext _context = null!;
        private decimal _currentTyGia = 1m;
        private bool _isLoadingTourDetails = false;

        public FormDatTour()
        {
            InitializeComponent();
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            this.Load += Form1_Load;

            // Events Tab Tour
            dgvTour.SelectionChanged += dgvTour_SelectionChanged;
            btnThemTour.Click += btnThemTour_Click;
            btnSuaTour.Click += btnSuaTour_Click;
            btnXoaTour.Click += btnXoaTour_Click;
            btnLamMoiTour.Click += btnLamMoiTour_Click;
            btnTimTour.Click += btnTimTour_Click;
            btnTatCaTour.Click += btnTatCaTour_Click;

            // Events Tab Khách hàng
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            btnThemKH.Click += btnThemKH_Click;
            btnSuaKH.Click += btnSuaKH_Click;
            btnXoaKH.Click += btnXoaKH_Click;
            btnLamMoiKH.Click += btnLamMoiKH_Click;
            btnTimKH.Click += btnTimKH_Click;
            btnTatCaKH.Click += btnTatCaKH_Click;

            // Events Tab Đặt tour
            cboTour.SelectedIndexChanged += async (s, e) => await cboTour_SelectedIndexChanged();
            nudSoNguoi.ValueChanged += (s, e) => CalculateTongTien();
            btnDatTour.Click += async (s, e) => await btnDatTour_Click();
            btnTimDatTour.Click += (s, e) => FilterDatTours();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                _context = new ApplicationDbContext();
                
                // Đảm bảo database và seed dữ liệu nếu trống
                EnsureDatabaseSeeded();

                // Nạp dữ liệu các tab
                LoadTours();
                LoadKhachHangs();
                LoadDatTourTabControls();
                LoadDatTours();

                // Mặc định chọn tab Đặt tour giống ảnh mẫu
                tabControlMain.SelectedTab = tabDatTour;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi tạo Form1 và kết nối CSDL");
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}\nVui lòng kiểm tra chuỗi kết nối trong appsettings.json!", 
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Seed Dữ Liệu Mẫu
        private void EnsureDatabaseSeeded()
        {
            try
            {
                // Kiểm tra xem database có bảng Tour chưa, nếu chưa có tour nào thì thêm sẵn 5 tour và khách hàng
                if (!_context.Tours.Any())
                {
                    var tours = new List<Tour>
                    {
                        new Tour { TenTour = "Bangkok - Pattaya 5N4Đ", DiemDen = "Thái Lan", NgoaiTe = "THB", GiaNgoaiTe = 9500m, NgayKhoiHanh = new DateOnly(2026, 8, 15), SoChoToiDa = 30 },
                        new Tour { TenTour = "Seoul - Nami - Everland 5N4Đ", DiemDen = "Hàn Quốc", NgoaiTe = "KRW", GiaNgoaiTe = 850000m, NgayKhoiHanh = new DateOnly(2026, 8, 20), SoChoToiDa = 25 },
                        new Tour { TenTour = "Tokyo - Núi Phú Sĩ 6N5Đ", DiemDen = "Nhật Bản", NgoaiTe = "JPY", GiaNgoaiTe = 165000m, NgayKhoiHanh = new DateOnly(2026, 8, 25), SoChoToiDa = 20 },
                        new Tour { TenTour = "Khám phá New York - Washington 7N6Đ", DiemDen = "Mỹ", NgoaiTe = "USD", GiaNgoaiTe = 2450m, NgayKhoiHanh = new DateOnly(2026, 9, 10), SoChoToiDa = 15 },
                        new Tour { TenTour = "Nha Trang - Biển đảo 4N3Đ", DiemDen = "Nha Trang", NgoaiTe = "VND", GiaNgoaiTe = 3500000m, NgayKhoiHanh = new DateOnly(2026, 7, 1), SoChoToiDa = 40 }
                    };
                    _context.Tours.AddRange(tours);
                    _context.SaveChanges();
                }

                if (!_context.KhachHangs.Any())
                {
                    var khs = new List<KhachHang>
                    {
                        new KhachHang { HoTen = "Lê Văn An", SoDienThoai = "0912345678", Email = "an.le@gmail.com" },
                        new KhachHang { HoTen = "Phạm Minh Hùng", SoDienThoai = "0981122334", Email = "hung.pham@yahoo.com" },
                        new KhachHang { HoTen = "Trần Thị Mai", SoDienThoai = "0987654321", Email = "mai.tran@gmail.com" },
                        new KhachHang { HoTen = "Hoàng Thu Thảo", SoDienThoai = "0903456789", Email = "thao.hoang@hotmail.com" },
                        new KhachHang { HoTen = "Vũ Đức Thịnh", SoDienThoai = "0978999888", Email = "thinh.vu@gmail.com" },
                        new KhachHang { HoTen = "Đặng Thị Lan", SoDienThoai = "0932111222", Email = "lan.dang@gmail.com" }
                    };
                    _context.KhachHangs.AddRange(khs);
                    _context.SaveChanges();
                }

                if (!_context.DatTours.Any())
                {
                    var tourNhaTrang = _context.Tours.FirstOrDefault(t => t.TenTour.Contains("Nha Trang")) ?? _context.Tours.First();
                    var tourBangkok = _context.Tours.FirstOrDefault(t => t.TenTour.Contains("Bangkok")) ?? _context.Tours.First();
                    var tourSeoul = _context.Tours.FirstOrDefault(t => t.TenTour.Contains("Seoul")) ?? _context.Tours.First();

                    var khList = _context.KhachHangs.ToList();
                    if (khList.Count >= 6)
                    {
                        var datTours = new List<DatTour>
                        {
                            new DatTour { MaKh = khList[0].MaKh, MaTour = tourNhaTrang.MaTour, SoNguoi = 4, NgayDat = new DateTime(2022, 7, 1, 9, 0, 0), TyGia = 1.0m, TongTienVnd = 14000000m },
                            new DatTour { MaKh = khList[1].MaKh, MaTour = tourNhaTrang.MaTour, SoNguoi = 2, NgayDat = new DateTime(2022, 7, 2, 10, 30, 0), TyGia = 1.0m, TongTienVnd = 7000000m },
                            new DatTour { MaKh = khList[2].MaKh, MaTour = tourBangkok.MaTour, SoNguoi = 3, NgayDat = new DateTime(2022, 7, 3, 15, 0, 0), TyGia = 778m, TongTienVnd = 22173000m },
                            new DatTour { MaKh = khList[3].MaKh, MaTour = tourNhaTrang.MaTour, SoNguoi = 5, NgayDat = new DateTime(2022, 7, 4, 11, 15, 0), TyGia = 1.0m, TongTienVnd = 17500000m },
                            new DatTour { MaKh = khList[4].MaKh, MaTour = tourSeoul.MaTour, SoNguoi = 2, NgayDat = new DateTime(2022, 7, 5, 14, 0, 0), TyGia = 20.0m, TongTienVnd = 34000000m },
                            new DatTour { MaKh = khList[5].MaKh, MaTour = tourNhaTrang.MaTour, SoNguoi = 1, NgayDat = new DateTime(2022, 7, 6, 16, 30, 0), TyGia = 1.0m, TongTienVnd = 3500000m }
                        };
                        _context.DatTours.AddRange(datTours);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Không thể seed dữ liệu mẫu vào CSDL (có thể dữ liệu đã tồn tại)");
            }
        }
        #endregion

        #region TAB 1: Quản lý Tour
        private void LoadTours(string? keyword = null)
        {
            dgvTour.Rows.Clear();
            var query = _context.Tours.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(t => t.TenTour.ToLower().Contains(kw) || t.DiemDen.ToLower().Contains(kw));
            }

            var tours = query.OrderByDescending(t => t.MaTour).ToList();
            foreach (var t in tours)
            {
                dgvTour.Rows.Add(
                    t.MaTour,
                    t.TenTour,
                    t.DiemDen,
                    t.NgoaiTe.Trim(),
                    t.GiaNgoaiTe.ToString("N2"),
                    t.NgayKhoiHanh.ToString("dd/MM/yyyy"),
                    t.SoChoToiDa
                );
            }
        }

        private void dgvTour_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTour.SelectedRows.Count == 0) return;

            var row = dgvTour.SelectedRows[0];
            if (row.Cells[0].Value == null) return;

            int maTour = Convert.ToInt32(row.Cells[0].Value);
            var tour = _context.Tours.Find(maTour);
            if (tour != null)
            {
                txtMaTour.Text = tour.MaTour.ToString();
                txtTenTour.Text = tour.TenTour;
                txtDiemDen.Text = tour.DiemDen;
                cboNgoaiTe.SelectedItem = tour.NgoaiTe.Trim();
                nudGiaNgoaiTe.Value = tour.GiaNgoaiTe;
                dtpNgayKhoiHanh.Value = tour.NgayKhoiHanh.ToDateTime(TimeOnly.MinValue);
                nudSoChoToiDa.Value = tour.SoChoToiDa;
            }
        }

        private void btnThemTour_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenTour.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tour!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTour.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiemDen.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemDen.Focus();
                return;
            }
            if (cboNgoaiTe.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ngoại tệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNgoaiTe.Focus();
                return;
            }

            var tour = new Tour
            {
                TenTour = txtTenTour.Text.Trim(),
                DiemDen = txtDiemDen.Text.Trim(),
                NgoaiTe = cboNgoaiTe.SelectedItem.ToString()!.Trim(),
                GiaNgoaiTe = nudGiaNgoaiTe.Value,
                NgayKhoiHanh = DateOnly.FromDateTime(dtpNgayKhoiHanh.Value),
                SoChoToiDa = (int)nudSoChoToiDa.Value
            };

            _context.Tours.Add(tour);
            _context.SaveChanges();

            MessageBox.Show("Thêm tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.Information("Thêm tour mới: {TenTour} ({NgoaiTe})", tour.TenTour, tour.NgoaiTe);

            LoadTours();
            LoadDatTourTabControls();
            btnLamMoiTour_Click(null, EventArgs.Empty);
        }

        private void btnSuaTour_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTour.Text, out int maTour))
            {
                MessageBox.Show("Vui lòng chọn một tour cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tour = _context.Tours.Find(maTour);
            if (tour == null) return;

            tour.TenTour = txtTenTour.Text.Trim();
            tour.DiemDen = txtDiemDen.Text.Trim();
            tour.NgoaiTe = cboNgoaiTe.SelectedItem?.ToString()?.Trim() ?? tour.NgoaiTe;
            tour.GiaNgoaiTe = nudGiaNgoaiTe.Value;
            tour.NgayKhoiHanh = DateOnly.FromDateTime(dtpNgayKhoiHanh.Value);
            tour.SoChoToiDa = (int)nudSoChoToiDa.Value;

            _context.SaveChanges();

            MessageBox.Show("Cập nhật thông tin tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.Information("Cập nhật tour Mã={MaTour}, Tên={TenTour}", tour.MaTour, tour.TenTour);

            LoadTours();
            LoadDatTourTabControls();
        }

        private void btnXoaTour_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTour.Text, out int maTour))
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_context.DatTours.Any(d => d.MaTour == maTour))
            {
                MessageBox.Show("Không thể xóa tour này vì đã có khách hàng đặt tour!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tour '{txtTenTour.Text}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var tour = _context.Tours.Find(maTour);
                if (tour != null)
                {
                    _context.Tours.Remove(tour);
                    _context.SaveChanges();

                    MessageBox.Show("Đã xóa tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Information("Đã xóa tour Mã={MaTour}", maTour);

                    LoadTours();
                    LoadDatTourTabControls();
                    btnLamMoiTour_Click(null, EventArgs.Empty);
                }
            }
        }

        private void btnLamMoiTour_Click(object? sender, EventArgs e)
        {
            txtMaTour.Text = "(Tự động)";
            txtTenTour.Clear();
            txtDiemDen.Clear();
            cboNgoaiTe.SelectedIndex = 0;
            nudGiaNgoaiTe.Value = 0;
            dtpNgayKhoiHanh.Value = DateTime.Today;
            nudSoChoToiDa.Value = 30;
            dgvTour.ClearSelection();
        }

        private void btnTimTour_Click(object? sender, EventArgs e)
        {
            LoadTours(txtTimTour.Text);
        }

        private void btnTatCaTour_Click(object? sender, EventArgs e)
        {
            txtTimTour.Clear();
            LoadTours();
        }
        #endregion

        #region TAB 2: Quản lý Khách Hàng
        private void LoadKhachHangs(string? keyword = null)
        {
            dgvKhachHang.Rows.Clear();
            var query = _context.KhachHangs.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(k => k.HoTen.ToLower().Contains(kw) || k.SoDienThoai.Contains(kw));
            }

            var list = query.OrderByDescending(k => k.MaKh).ToList();
            foreach (var k in list)
            {
                dgvKhachHang.Rows.Add(
                    k.MaKh,
                    k.HoTen,
                    k.SoDienThoai,
                    k.Email ?? ""
                );
            }
        }

        private void dgvKhachHang_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0) return;

            var row = dgvKhachHang.SelectedRows[0];
            if (row.Cells[0].Value == null) return;

            int maKh = Convert.ToInt32(row.Cells[0].Value);
            var kh = _context.KhachHangs.Find(maKh);
            if (kh != null)
            {
                txtMaKH.Text = kh.MaKh.ToString();
                txtHoTen.Text = kh.HoTen;
                txtSoDienThoai.Text = kh.SoDienThoai;
                txtEmail.Text = kh.Email ?? "";
            }
        }

        private void btnThemKH_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            var kh = new KhachHang
            {
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            _context.KhachHangs.Add(kh);
            _context.SaveChanges();

            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.Information("Thêm khách hàng: {HoTen} - {SoDienThoai}", kh.HoTen, kh.SoDienThoai);

            LoadKhachHangs();
            LoadDatTourTabControls();
            btnLamMoiKH_Click(null, EventArgs.Empty);
        }

        private void btnSuaKH_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int maKh))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kh = _context.KhachHangs.Find(maKh);
            if (kh == null) return;

            kh.HoTen = txtHoTen.Text.Trim();
            kh.SoDienThoai = txtSoDienThoai.Text.Trim();
            kh.Email = txtEmail.Text.Trim();

            _context.SaveChanges();

            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.Information("Cập nhật khách hàng Mã={MaKH}, Tên={HoTen}", kh.MaKh, kh.HoTen);

            LoadKhachHangs();
            LoadDatTourTabControls();
        }

        private void btnXoaKH_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int maKh))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_context.DatTours.Any(d => d.MaKh == maKh))
            {
                MessageBox.Show("Không thể xóa khách hàng này vì đã có dữ liệu đặt tour liên kết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{txtHoTen.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var kh = _context.KhachHangs.Find(maKh);
                if (kh != null)
                {
                    _context.KhachHangs.Remove(kh);
                    _context.SaveChanges();

                    MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Information("Đã xóa khách hàng Mã={MaKH}", maKh);

                    LoadKhachHangs();
                    LoadDatTourTabControls();
                    btnLamMoiKH_Click(null, EventArgs.Empty);
                }
            }
        }

        private void btnLamMoiKH_Click(object? sender, EventArgs e)
        {
            txtMaKH.Text = "(Tự động)";
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            dgvKhachHang.ClearSelection();
        }

        private void btnTimKH_Click(object? sender, EventArgs e)
        {
            LoadKhachHangs(txtTimKH.Text);
        }

        private void btnTatCaKH_Click(object? sender, EventArgs e)
        {
            txtTimKH.Clear();
            LoadKhachHangs();
        }
        #endregion

        #region TAB 3: Đặt Tour & Gọi API Tỷ Giá
        private class ComboboxItem
        {
            public string Text { get; set; } = string.Empty;
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        private void LoadDatTourTabControls()
        {
            _isLoadingTourDetails = true;
            try
            {
                // Nạp danh sách Khách hàng vào cboKhachHang
                cboKhachHang.Items.Clear();
                var khachHangs = _context.KhachHangs.AsNoTracking().OrderBy(k => k.HoTen).ToList();
                foreach (var k in khachHangs)
                {
                    cboKhachHang.Items.Add(new ComboboxItem
                    {
                        Text = $"{k.HoTen} - {k.SoDienThoai}",
                        Value = k.MaKh
                    });
                }
                if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;

                // Nạp danh sách Tour vào cboTour
                cboTour.Items.Clear();
                var tours = _context.Tours.AsNoTracking().OrderBy(t => t.TenTour).ToList();
                foreach (var t in tours)
                {
                    cboTour.Items.Add(new ComboboxItem
                    {
                        Text = t.TenTour,
                        Value = t.MaTour
                    });
                }
                if (cboTour.Items.Count > 0) cboTour.SelectedIndex = 0;
            }
            finally
            {
                _isLoadingTourDetails = false;
            }

            // Gọi cập nhật tỷ giá cho tour đầu tiên
            if (cboTour.Items.Count > 0)
            {
                _ = cboTour_SelectedIndexChanged();
            }
        }

        private async Task cboTour_SelectedIndexChanged()
        {
            if (_isLoadingTourDetails || cboTour.SelectedItem == null) return;

            var selectedTourItem = cboTour.SelectedItem as ComboboxItem;
            if (selectedTourItem == null) return;

            int maTour = selectedTourItem.Value;
            var tour = _context.Tours.AsNoTracking().FirstOrDefault(t => t.MaTour == maTour);
            if (tour == null) return;

            string ngoaiTe = tour.NgoaiTe.Trim().ToUpper();
            lblGiaNgoaiTeValue.Text = $"{tour.GiaNgoaiTe:N0} {ngoaiTe}";

            // Tính số chỗ còn lại: SoChoToiDa trừ tổng số người đã đặt tour đó
            int tongDaDat = _context.DatTours.Where(d => d.MaTour == maTour).Sum(d => (int?)d.SoNguoi) ?? 0;
            int soChoConLai = tour.SoChoToiDa - tongDaDat;

            if (soChoConLai <= 0)
            {
                nudSoNguoi.Maximum = 0;
                nudSoNguoi.Value = 0;
                nudSoNguoi.Enabled = false;
                btnDatTour.Enabled = false;
                lblTongTienVND.Text = "HẾT CHỖ";
                lblTyGiaHomNay.Text = "Tour đã hết chỗ!";
                lblNguonTyGia.Text = $"Còn 0/{tour.SoChoToiDa} chỗ";
                return;
            }
            else
            {
                nudSoNguoi.Enabled = true;
                btnDatTour.Enabled = true;
                nudSoNguoi.Maximum = soChoConLai;
                if (nudSoNguoi.Value < 1 || nudSoNguoi.Value > soChoConLai)
                {
                    nudSoNguoi.Value = Math.Min(3, soChoConLai);
                }
            }

            // Lấy tỷ giá từ API
            lblTyGiaHomNay.Text = "Đang lấy tỷ giá...";
            lblNguonTyGia.Text = "Đang kết nối API...";

            try
            {
                var tyGiaResult = await TyGiaService.LayTyGiaAsync(ngoaiTe);
                _currentTyGia = tyGiaResult.TyGia;

                if (ngoaiTe == "VND")
                {
                    lblTyGiaHomNay.Text = "1 VND = 1 VND";
                }
                else
                {
                    lblTyGiaHomNay.Text = $"1 {ngoaiTe} = {_currentTyGia:N0} VND";
                }

                lblNguonTyGia.Text = $"Tỷ giá lấy từ: {tyGiaResult.Nguon}";
            }
            catch (Exception ex)
            {
                _currentTyGia = 1m;
                lblTyGiaHomNay.Text = "Lỗi lấy tỷ giá";
                lblNguonTyGia.Text = "API không phản hồi";
                MessageBox.Show(ex.Message, "Lỗi tỷ giá API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CalculateTongTien();
        }

        private void CalculateTongTien()
        {
            if (cboTour.SelectedItem is not ComboboxItem selectedTourItem) return;

            var tour = _context.Tours.AsNoTracking().FirstOrDefault(t => t.MaTour == selectedTourItem.Value);
            if (tour == null) return;

            decimal tongTien = tour.GiaNgoaiTe * nudSoNguoi.Value * _currentTyGia;
            lblTongTienVND.Text = $"{Math.Round(tongTien, 0):N0} đ";
        }

        private async Task btnDatTour_Click()
        {
            if (cboKhachHang.SelectedItem is not ComboboxItem selectedKhItem)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTour.SelectedItem is not ComboboxItem selectedTourItem)
            {
                MessageBox.Show("Vui lòng chọn tour!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTour = selectedTourItem.Value;
            var tour = _context.Tours.Find(maTour);
            if (tour == null) return;

            // Kiểm tra số chỗ còn lại: không vượt quá số chỗ còn lại = SoChoToiDa trừ tổng số người đã đặt tour đó
            int tongDaDat = _context.DatTours.Where(d => d.MaTour == maTour).Sum(d => (int?)d.SoNguoi) ?? 0;
            int soChoConLai = tour.SoChoToiDa - tongDaDat;
            int soNguoiDat = (int)nudSoNguoi.Value;

            if (soNguoiDat <= 0)
            {
                MessageBox.Show("Số người đặt phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soNguoiDat > soChoConLai)
            {
                MessageBox.Show($"Đặt tour thất bại! Tour chỉ còn {soChoConLai} chỗ trống (bạn đang đặt {soNguoiDat} người).", 
                    "Vượt quá số chỗ còn lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền tại thời điểm đặt
            decimal tongTien = Math.Round(tour.GiaNgoaiTe * soNguoiDat * _currentTyGia, 0);

            var datTour = new DatTour
            {
                MaKh = selectedKhItem.Value,
                MaTour = tour.MaTour,
                SoNguoi = soNguoiDat,
                NgayDat = DateTime.Now,
                TyGia = _currentTyGia, // Lưu tỷ giá tại thời điểm đặt để tỷ giá sau này đổi đơn cũ không bị đổi
                TongTienVnd = tongTien
            };

            _context.DatTours.Add(datTour);
            _context.SaveChanges();

            Log.Information("Đặt tour thành công: MãĐơn={MaDat}, KH={KH}, Tour={Tour}, Số người={SoNguoi}, Tỷ giá={TyGia}, Tổng={TongTien:N0} đ",
                datTour.MaDat, selectedKhItem.Text, tour.TenTour, soNguoiDat, _currentTyGia, tongTien);

            MessageBox.Show($"Đặt tour thành công!\nMã đặt: DT{datTour.MaDat:D3}\nTổng tiền: {tongTien:N0} đ (Tỷ giá áp dụng: {_currentTyGia:N0})", 
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại danh sách đặt tour và trạng thái số chỗ
            LoadDatTours();
            await cboTour_SelectedIndexChanged();
        }

        private void LoadDatTours(string? keyword = null, int thangKhoiHanh = 0)
        {
            dgvDatTour.Rows.Clear();

            var query = _context.DatTours
                .Include(d => d.MaKhNavigation)
                .Include(d => d.MaTourNavigation)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(d => d.MaKhNavigation.HoTen.ToLower().Contains(kw) || d.MaTourNavigation.TenTour.ToLower().Contains(kw));
            }

            if (thangKhoiHanh > 0)
            {
                query = query.Where(d => d.MaTourNavigation.NgayKhoiHanh.Month == thangKhoiHanh || d.NgayDat.Month == thangKhoiHanh);
            }

            var list = query.OrderByDescending(d => d.MaDat).ToList();
            decimal tongDoanhThu = 0;

            foreach (var d in list)
            {
                tongDoanhThu += d.TongTienVnd;

                string tyGiaDisplay = d.TyGia == 1m ? "1" : $"{d.TyGia:N0}";
                string ngoaiTe = d.MaTourNavigation?.NgoaiTe?.Trim() ?? "";
                if (ngoaiTe != "VND" && !string.IsNullOrEmpty(ngoaiTe) && d.TyGia != 1m)
                {
                    tyGiaDisplay = $"{d.TyGia:N0} {ngoaiTe}/VND";
                }

                dgvDatTour.Rows.Add(
                    $"DT{d.MaDat:D3}",
                    d.MaKhNavigation?.HoTen ?? "",
                    d.MaTourNavigation?.TenTour ?? "",
                    d.SoNguoi,
                    tyGiaDisplay,
                    $"{d.TongTienVnd:N0} đ",
                    d.NgayDat.ToString("dd/MM/yyyy HH:mm")
                );
            }

            lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} đ";
        }

        private void FilterDatTours()
        {
            string keyword = txtTimKiemDatTour.Text.Trim();
            int thang = cboThangKhoiHanh.SelectedIndex; // 0 là rỗng, 1 là Tháng 1...
            LoadDatTours(keyword, thang);
        }
        #endregion
    }
}
