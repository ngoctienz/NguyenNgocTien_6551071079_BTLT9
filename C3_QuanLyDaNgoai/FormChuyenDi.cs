using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using C3_QuanLyDaNgoai.Models.EF;
using C3_QuanLyDaNgoai.Models.Entities;
using C3_QuanLyDaNgoai.Services;

namespace C3_QuanLyDaNgoai
{
    public partial class FormChuyenDi : Form
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        private ChuyenDi? _selectedChuyenDi = null;
        private int _currentWeatherCode = 80;
        private bool _isInitializing = true;
        private bool _isSearching = false;

        private readonly string[] _vehiclesVi = { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" };
        private readonly string[] _vehiclesEn = { "Motorbike", "Car", "Coach Bus", "Train" };

        public FormChuyenDi()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Setup DataGridView columns
            SetupGridColumns();

            // Hook event handlers
            cboNgonNgu.SelectedIndexChanged += CboNgonNgu_SelectedIndexChanged;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnXemThoiTiet.Click += async (s, e) => await CheckWeatherCurrentInputAsync();
            btnTim.Click += (s, e) => LoadDataGrid();
            txtTimKiem.TextChanged += (s, e) => { if (!_isSearching) LoadDataGrid(); };
            txtTimKiem.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; LoadDataGrid(); } };
            chkChuaHoanThanh.CheckedChanged += (s, e) => LoadDataGrid();

            dgvChuyenDi.SelectionChanged += DgvChuyenDi_SelectionChanged;

            picThoiTiet.Paint += PicThoiTiet_Paint;
            picIconCanhBao.Paint += PicIconCanhBao_Paint;

            // Load saved settings
            var settings = SettingsService.LoadSettings();
            LocalizationService.SetLanguage(settings.Language);

            cboNgonNgu.SelectedIndex = settings.Language == "en" ? 1 : 0;

            _isInitializing = false;

            // Apply language to UI
            ApplyLanguage();

            // Load trips from database
            LoadDataGrid();

            // Select initial trip to display preview
            if (dgvChuyenDi.Rows.Count > 0)
            {
                dgvChuyenDi.ClearSelection();
                dgvChuyenDi.Rows[0].Selected = true;
            }
        }

        private void SetupGridColumns()
        {
            dgvChuyenDi.AutoGenerateColumns = false;
            dgvChuyenDi.Columns.Clear();

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMa",
                HeaderText = "Mã",
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenChuyen",
                HeaderText = "Tên chuyến",
                Width = 180
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiaDiem",
                HeaderText = "Địa điểm",
                Width = 120
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayDi",
                HeaderText = "Ngày đi",
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoNguoi",
                HeaderText = "Số người",
                Width = 85,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNganSach",
                HeaderText = "Ngân sách",
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhuongTien",
                HeaderText = "Phương tiện",
                Width = 110
            });

            dgvChuyenDi.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colHoanThanh",
                HeaderText = "Hoàn thành",
                Width = 90
            });
        }

        private void CboNgonNgu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;

            string lang = cboNgonNgu.SelectedIndex == 1 ? "en" : "vi";
            LocalizationService.SetLanguage(lang);
            SettingsService.SaveSettings(new UserSettings { Language = lang });

            ApplyLanguage();
            LoadDataGrid();

            if (_selectedChuyenDi != null)
            {
                PopulateInputs(_selectedChuyenDi);
            }
        }

        private void ApplyLanguage()
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";

            // Form Title & Header
            Text = isEn ? "Weekend Picnic Planner" : "Kế hoạch dã ngoại cuối tuần";
            lblTieuDeChinh.Text = isEn ? "Weekend Picnic Planner" : "Kế hoạch dã ngoại cuối tuần";
            lblNgonNgu.Text = isEn ? "Language" : "Ngôn ngữ";

            // Trip Info section
            lblThongTinChuyenDi.Text = isEn ? "Trip Information" : "Thông tin chuyến đi";
            lblTenChuyen.Text = isEn ? "Trip Name" : "Tên chuyến";
            lblDiaDiem.Text = isEn ? "Destination" : "Địa điểm";
            lblNgayDi.Text = isEn ? "Departure" : "Ngày đi";
            lblSoNguoi.Text = isEn ? "People" : "Số người";
            lblNganSach.Text = isEn ? "Budget" : "Ngân sách";
            lblPhuongTien.Text = isEn ? "Transport" : "Phương tiện";
            chkDaHoanThanh.Text = isEn ? "Completed" : "Đã hoàn thành";

            // Buttons
            btnThem.Text = isEn ? "Add" : "Thêm";
            btnSua.Text = isEn ? "Update" : "Sửa";
            btnXoa.Text = isEn ? "Delete" : "Xóa";
            btnLamMoi.Text = isEn ? "Reset" : "Làm mới";
            btnXemThoiTiet.Text = isEn ? "Check Weather" : "Xem thời tiết";
            btnTim.Text = isEn ? "Search" : "Tìm";

            // Search box placeholder / text
            txtTimKiem.PlaceholderText = isEn ? "Search destination or trip name..." : "Tìm địa điểm...";
            chkChuaHoanThanh.Text = isEn ? "Incomplete trips only" : "Chỉ hiện chuyến chưa hoàn thành";

            // Vehicle combobox
            int currentVehIndex = cboPhuongTien.SelectedIndex >= 0 ? cboPhuongTien.SelectedIndex : 0;
            cboPhuongTien.Items.Clear();
            cboPhuongTien.Items.AddRange(isEn ? _vehiclesEn : _vehiclesVi);
            cboPhuongTien.SelectedIndex = currentVehIndex < cboPhuongTien.Items.Count ? currentVehIndex : 0;

            // Grid column headers
            if (dgvChuyenDi.Columns["colMa"] is DataGridViewColumn colMa) colMa.HeaderText = isEn ? "ID" : "Mã";
            if (dgvChuyenDi.Columns["colTenChuyen"] is DataGridViewColumn colTen) colTen.HeaderText = isEn ? "Trip Name" : "Tên chuyến";
            if (dgvChuyenDi.Columns["colDiaDiem"] is DataGridViewColumn colDia) colDia.HeaderText = isEn ? "Destination" : "Địa điểm";
            if (dgvChuyenDi.Columns["colNgayDi"] is DataGridViewColumn colNgay) colNgay.HeaderText = isEn ? "Date" : "Ngày đi";
            if (dgvChuyenDi.Columns["colSoNguoi"] is DataGridViewColumn colNguoi) colNguoi.HeaderText = isEn ? "People" : "Số người";
            if (dgvChuyenDi.Columns["colNganSach"] is DataGridViewColumn colSach) colSach.HeaderText = isEn ? "Budget" : "Ngân sách";
            if (dgvChuyenDi.Columns["colPhuongTien"] is DataGridViewColumn colTien) colTien.HeaderText = isEn ? "Transport" : "Phương tiện";
            if (dgvChuyenDi.Columns["colHoanThanh"] is DataGridViewColumn colHoan) colHoan.HeaderText = isEn ? "Completed" : "Hoàn thành";

            // Weather Warning
            lblCanhBao.Text = isEn
                ? "Bring a raincoat or consider rescheduling"
                : "Nên mang áo mưa hoặc cân nhắc dời lịch";
        }

        private void LoadDataGrid()
        {
            try
            {
                int? currentlySelectedId = _selectedChuyenDi?.MaChuyen;

                var query = _dbContext.ChuyenDis.AsQueryable();

                string keyword = txtTimKiem.Text.Trim();
                if (!string.IsNullOrEmpty(keyword) && keyword != "Tìm địa điểm..." && keyword != "Search destination...")
                {
                    query = query.Where(x => x.TenChuyen.Contains(keyword) || x.DiaDiem.Contains(keyword));
                }

                if (chkChuaHoanThanh.Checked)
                {
                    query = query.Where(x => !x.DaHoanThanh);
                }

                var list = query.OrderBy(x => x.NgayDi).ToList();

                dgvChuyenDi.Rows.Clear();
                foreach (var item in list)
                {
                    int rowIndex = dgvChuyenDi.Rows.Add(
                        item.MaChuyen,
                        item.TenChuyen,
                        item.DiaDiem,
                        LocalizationService.FormatDate(item.NgayDi),
                        item.SoNguoi,
                        LocalizationService.FormatCurrency(item.NganSach),
                        TranslateVehicle(item.PhuongTien),
                        item.DaHoanThanh
                    );
                    dgvChuyenDi.Rows[rowIndex].Tag = item;
                }

                if (currentlySelectedId.HasValue)
                {
                    SelectTripInGrid(currentlySelectedId.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectTripInGrid(int id)
        {
            foreach (DataGridViewRow row in dgvChuyenDi.Rows)
            {
                if (row.Tag is ChuyenDi item && item.MaChuyen == id)
                {
                    dgvChuyenDi.ClearSelection();
                    row.Selected = true;
                    dgvChuyenDi.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        private string TranslateVehicle(string rawVehicle)
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";
            int idx = Array.IndexOf(_vehiclesVi, rawVehicle);
            if (idx >= 0)
            {
                return isEn ? _vehiclesEn[idx] : _vehiclesVi[idx];
            }

            idx = Array.IndexOf(_vehiclesEn, rawVehicle);
            if (idx >= 0)
            {
                return isEn ? _vehiclesEn[idx] : _vehiclesVi[idx];
            }

            return rawVehicle;
        }

        private string GetStandardVehicle()
        {
            int idx = cboPhuongTien.SelectedIndex;
            if (idx >= 0 && idx < _vehiclesVi.Length)
            {
                return _vehiclesVi[idx];
            }
            return "Ô tô";
        }

        private void SetVehicleCombo(string rawVehicle)
        {
            int idx = Array.IndexOf(_vehiclesVi, rawVehicle);
            if (idx < 0) idx = Array.IndexOf(_vehiclesEn, rawVehicle);
            if (idx >= 0 && idx < cboPhuongTien.Items.Count)
            {
                cboPhuongTien.SelectedIndex = idx;
            }
            else if (cboPhuongTien.Items.Count > 0)
            {
                cboPhuongTien.SelectedIndex = 0;
            }
        }

        private async void DgvChuyenDi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvChuyenDi.SelectedRows.Count == 0) return;

            var row = dgvChuyenDi.SelectedRows[0];
            if (row.Tag is ChuyenDi trip)
            {
                _selectedChuyenDi = trip;
                PopulateInputs(trip);

                // Auto fetch weather for selected trip as specified in Task 5
                await FetchWeatherAsync(trip.DiaDiem, trip.NgayDi);
            }
        }

        private void PopulateInputs(ChuyenDi trip)
        {
            txtTenChuyen.Text = trip.TenChuyen;
            txtDiaDiem.Text = trip.DiaDiem;
            dtpNgayDi.Value = trip.NgayDi.ToDateTime(TimeOnly.MinValue);
            numSoNguoi.Value = trip.SoNguoi >= numSoNguoi.Minimum ? trip.SoNguoi : numSoNguoi.Minimum;
            txtNganSach.Text = LocalizationService.FormatCurrency(trip.NganSach);
            SetVehicleCombo(trip.PhuongTien);
            chkDaHoanThanh.Checked = trip.DaHoanThanh;
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            ResetInputs();
            dgvChuyenDi.ClearSelection();
            _selectedChuyenDi = null;
        }

        private void ResetInputs()
        {
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.Value = DateTime.Today;
            numSoNguoi.Value = 1;
            txtNganSach.Text = LocalizationService.FormatCurrency(0);
            if (cboPhuongTien.Items.Count > 0) cboPhuongTien.SelectedIndex = 0;
            chkDaHoanThanh.Checked = false;
        }

        private decimal ParseBudget(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            // Remove currency symbol, dots, commas, spaces
            string digits = Regex.Replace(input, @"[^\d]", "");
            if (decimal.TryParse(digits, out decimal val))
            {
                return val;
            }
            return 0;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";

            string tenChuyen = txtTenChuyen.Text.Trim();
            string diaDiem = txtDiaDiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenChuyen))
            {
                MessageBox.Show(isEn ? "Please enter trip name." : "Vui lòng nhập tên chuyến.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(isEn ? "Please enter destination." : "Vui lòng nhập địa điểm.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            DateOnly ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value);
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (ngayDi < today)
            {
                MessageBox.Show(isEn ? "Departure date cannot be in the past when adding new trip." : "Ngày đi không thể nhỏ hơn hôm nay khi thêm mới.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDi.Focus();
                return;
            }

            int soNguoi = (int)numSoNguoi.Value;
            if (soNguoi < 1)
            {
                MessageBox.Show(isEn ? "Number of people must be at least 1." : "Số người phải từ 1 trở lên.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoNguoi.Focus();
                return;
            }

            decimal nganSach = ParseBudget(txtNganSach.Text);
            if (nganSach < 0)
            {
                MessageBox.Show(isEn ? "Budget cannot be negative." : "Ngân sách không được âm.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNganSach.Focus();
                return;
            }

            try
            {
                var newTrip = new ChuyenDi
                {
                    TenChuyen = tenChuyen,
                    DiaDiem = diaDiem,
                    NgayDi = ngayDi,
                    SoNguoi = soNguoi,
                    NganSach = nganSach,
                    PhuongTien = GetStandardVehicle(),
                    DaHoanThanh = chkDaHoanThanh.Checked
                };

                _dbContext.ChuyenDis.Add(newTrip);
                _dbContext.SaveChanges();

                LoadDataGrid();
                SelectTripInGrid(newTrip.MaChuyen);

                MessageBox.Show(isEn ? "Trip added successfully!" : "Thêm chuyến đi thành công!",
                    isEn ? "Success" : "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm chuyến đi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";

            if (_selectedChuyenDi == null)
            {
                MessageBox.Show(isEn ? "Please select a trip to update." : "Vui lòng chọn một chuyến đi để cập nhật.",
                    isEn ? "Notice" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenChuyen = txtTenChuyen.Text.Trim();
            string diaDiem = txtDiaDiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenChuyen))
            {
                MessageBox.Show(isEn ? "Please enter trip name." : "Vui lòng nhập tên chuyến.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(isEn ? "Please enter destination." : "Vui lòng nhập địa điểm.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            int soNguoi = (int)numSoNguoi.Value;
            if (soNguoi < 1)
            {
                MessageBox.Show(isEn ? "Number of people must be at least 1." : "Số người phải từ 1 trở lên.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal nganSach = ParseBudget(txtNganSach.Text);
            if (nganSach < 0)
            {
                MessageBox.Show(isEn ? "Budget cannot be negative." : "Ngân sách không được âm.",
                    isEn ? "Validation Error" : "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var tripInDb = _dbContext.ChuyenDis.Find(_selectedChuyenDi.MaChuyen);
                if (tripInDb != null)
                {
                    tripInDb.TenChuyen = tenChuyen;
                    tripInDb.DiaDiem = diaDiem;
                    tripInDb.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value);
                    tripInDb.SoNguoi = soNguoi;
                    tripInDb.NganSach = nganSach;
                    tripInDb.PhuongTien = GetStandardVehicle();
                    tripInDb.DaHoanThanh = chkDaHoanThanh.Checked;

                    _dbContext.SaveChanges();
                    _selectedChuyenDi = tripInDb;

                    LoadDataGrid();
                    SelectTripInGrid(tripInDb.MaChuyen);

                    MessageBox.Show(isEn ? "Trip updated successfully!" : "Cập nhật chuyến đi thành công!",
                        isEn ? "Success" : "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";

            if (_selectedChuyenDi == null)
            {
                MessageBox.Show(isEn ? "Please select a trip to delete." : "Vui lòng chọn chuyến đi cần xóa.",
                    isEn ? "Notice" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                isEn ? $"Are you sure you want to delete '{_selectedChuyenDi.TenChuyen}'?" : $"Bạn có chắc chắn muốn xóa chuyến '{_selectedChuyenDi.TenChuyen}'?",
                isEn ? "Confirm Delete" : "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var tripInDb = _dbContext.ChuyenDis.Find(_selectedChuyenDi.MaChuyen);
                    if (tripInDb != null)
                    {
                        _dbContext.ChuyenDis.Remove(tripInDb);
                        _dbContext.SaveChanges();
                    }

                    _selectedChuyenDi = null;
                    ResetInputs();
                    LoadDataGrid();

                    MessageBox.Show(isEn ? "Trip deleted successfully!" : "Xóa chuyến đi thành công!",
                        isEn ? "Success" : "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CheckWeatherCurrentInputAsync()
        {
            string diaDiem = txtDiaDiem.Text.Trim();
            DateOnly ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value);

            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                bool isEn = LocalizationService.CurrentLanguage == "en";
                MessageBox.Show(isEn ? "Please enter destination first." : "Vui lòng nhập địa điểm trước.",
                    isEn ? "Notice" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaDiem.Focus();
                return;
            }

            await FetchWeatherAsync(diaDiem, ngayDi);
        }

        private async Task FetchWeatherAsync(string diaDiem, DateOnly ngayDi)
        {
            bool isEn = LocalizationService.CurrentLanguage == "en";
            string lang = isEn ? "en" : "vi";

            try
            {
                btnXemThoiTiet.Enabled = false;
                prgThoiTiet.Visible = true;
                lblTieuDeThoiTiet.Text = isEn
                    ? $"Checking weather for {diaDiem} ({LocalizationService.FormatDate(ngayDi)})..."
                    : $"Đang tải thời tiết cho {diaDiem} ({LocalizationService.FormatDate(ngayDi)})...";

                var result = await WeatherService.GetWeatherForecastAsync(diaDiem, ngayDi, lang);

                if (result.IsNetworkError)
                {
                    lblTieuDeThoiTiet.Text = isEn ? "Connection issue" : "Lỗi kết nối";
                    lblMoTaThoiTiet.Text = isEn ? "Network Error" : "Lỗi mạng";
                    lblNhietDo.Text = isEn ? "Could not reach weather server." : "Không thể kết nối đến máy chủ thời tiết.";
                    lblKhaNangMua.Text = isEn ? "Check your internet connection." : "Vui lòng kiểm tra lại đường truyền mạng.";
                    pnlCanhBao.Visible = false;
                    _currentWeatherCode = -1;
                    picThoiTiet.Invalidate();
                    return;
                }

                if (result.IsLocationNotFound)
                {
                    lblTieuDeThoiTiet.Text = isEn ? "Location not found" : "Không tìm thấy địa điểm";
                    lblMoTaThoiTiet.Text = isEn ? "Unknown place" : "Không xác định";
                    lblNhietDo.Text = isEn
                        ? $"Try unaccented name (e.g. Da Lat, Vung Tau)"
                        : $"Thử tên không dấu (ví dụ: Da Lat, Vung Tau)";
                    lblKhaNangMua.Text = "";
                    pnlCanhBao.Visible = false;
                    _currentWeatherCode = -1;
                    picThoiTiet.Invalidate();
                    return;
                }

                if (result.IsBeyond16Days)
                {
                    lblTieuDeThoiTiet.Text = isEn
                        ? $"Forecast for {diaDiem} ({LocalizationService.FormatDate(ngayDi)})"
                        : $"Dự báo thời tiết ngày {LocalizationService.FormatDate(ngayDi)} - {diaDiem}";
                    lblMoTaThoiTiet.Text = isEn ? "No forecast data" : "Chưa có dữ liệu dự báo";
                    lblNhietDo.Text = isEn
                        ? "Forecast is only available within 16 days"
                        : "Dự báo chỉ khả dụng trong vòng 16 ngày tới";
                    lblKhaNangMua.Text = "";
                    pnlCanhBao.Visible = false;
                    _currentWeatherCode = 1;
                    picThoiTiet.Invalidate();
                    return;
                }

                if (result.Success)
                {
                    string locationDisplay = result.ResolvedLocationName ?? diaDiem;
                    lblTieuDeThoiTiet.Text = isEn
                        ? $"Forecast for {LocalizationService.FormatDate(ngayDi)} - {locationDisplay}"
                        : $"Dự báo thời tiết ngày {LocalizationService.FormatDate(ngayDi)} - {locationDisplay}";

                    lblMoTaThoiTiet.Text = LocalizationService.GetWeatherDescription(result.WeatherCode);
                    lblNhietDo.Text = isEn
                        ? $"Temperature: {result.MinTemp:F0}°C - {result.MaxTemp:F0}°C"
                        : $"Nhiệt độ: {result.MinTemp:F0}°C - {result.MaxTemp:F0}°C";
                    lblKhaNangMua.Text = isEn
                        ? $"Rain probability: {result.PrecipitationProbability}%"
                        : $"Khả năng mưa: {result.PrecipitationProbability}%";

                    _currentWeatherCode = result.WeatherCode;
                    picThoiTiet.Invalidate();

                    // If rain probability >= 60%, highlight orange warning panel
                    if (result.PrecipitationProbability >= 60)
                    {
                        pnlCanhBao.Visible = true;
                        pnlCanhBao.BackColor = Color.FromArgb(255, 235, 208);
                        lblCanhBao.Text = isEn
                            ? "Bring a raincoat or consider rescheduling"
                            : "Nên mang áo mưa hoặc cân nhắc dời lịch";
                    }
                    else
                    {
                        pnlCanhBao.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMoTaThoiTiet.Text = isEn ? "Error" : "Có lỗi xảy ra";
                lblNhietDo.Text = ex.Message;
                lblKhaNangMua.Text = "";
                pnlCanhBao.Visible = false;
            }
            finally
            {
                prgThoiTiet.Visible = false;
                btnXemThoiTiet.Enabled = true;
            }
        }

        private void PicThoiTiet_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Weather code categories:
            // 0: Clear sky / Sun
            // 1-3: Partly cloudy / Overcast
            // 45, 48: Fog
            // 51-67, 80-82: Rain / Showers
            // 95-99: Thunderstorm

            if (_currentWeatherCode == 0)
            {
                // Draw Sun
                using var penSun = new Pen(Color.FromArgb(245, 140, 20), 3f);
                using var brushSun = new SolidBrush(Color.FromArgb(255, 190, 40));
                e.Graphics.FillEllipse(brushSun, 28, 28, 38, 38);
                e.Graphics.DrawEllipse(penSun, 28, 28, 38, 38);

                // Rays
                for (int i = 0; i < 8; i++)
                {
                    double angle = i * Math.PI / 4;
                    float x1 = 47 + (float)(24 * Math.Cos(angle));
                    float y1 = 47 + (float)(24 * Math.Sin(angle));
                    float x2 = 47 + (float)(32 * Math.Cos(angle));
                    float y2 = 47 + (float)(32 * Math.Sin(angle));
                    e.Graphics.DrawLine(penSun, x1, y1, x2, y2);
                }
            }
            else if (_currentWeatherCode == 45 || _currentWeatherCode == 48)
            {
                // Draw Fog lines
                using var penFog = new Pen(Color.FromArgb(90, 110, 130), 4f)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };
                e.Graphics.DrawLine(penFog, 20, 28, 75, 28);
                e.Graphics.DrawLine(penFog, 15, 42, 80, 42);
                e.Graphics.DrawLine(penFog, 22, 56, 72, 56);
                e.Graphics.DrawLine(penFog, 26, 70, 68, 70);
            }
            else
            {
                // Cloud outline
                using var penCloud = new Pen(Color.FromArgb(30, 30, 30), 3.5f) { LineJoin = LineJoin.Round };
                using var path = new GraphicsPath();
                path.AddArc(15, 28, 28, 28, 140, 130);
                path.AddArc(33, 14, 34, 34, 180, 150);
                path.AddArc(59, 24, 26, 26, 260, 120);
                path.AddLine(78, 50, 21, 50);
                path.CloseFigure();

                e.Graphics.DrawPath(penCloud, path);

                if (_currentWeatherCode >= 95)
                {
                    // Lightning bolt for Thunderstorm
                    using var brushBolt = new SolidBrush(Color.FromArgb(245, 170, 10));
                    PointF[] boltPoints =
                    {
                        new PointF(46, 52),
                        new PointF(38, 67),
                        new PointF(47, 67),
                        new PointF(42, 82),
                        new PointF(56, 63),
                        new PointF(48, 63)
                    };
                    e.Graphics.FillPolygon(brushBolt, boltPoints);
                }
                else if ((_currentWeatherCode >= 51 && _currentWeatherCode <= 67) ||
                         (_currentWeatherCode >= 80 && _currentWeatherCode <= 82))
                {
                    // Rain drops
                    using var penRain = new Pen(Color.FromArgb(30, 30, 30), 3.2f)
                    {
                        StartCap = LineCap.Round,
                        EndCap = LineCap.Round
                    };

                    e.Graphics.DrawLine(penRain, 32, 58, 29, 70);
                    e.Graphics.DrawLine(penRain, 48, 58, 45, 74);
                    e.Graphics.DrawLine(penRain, 64, 58, 61, 70);
                }
            }
        }

        private void PicIconCanhBao_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var brushBg = new SolidBrush(Color.FromArgb(245, 130, 32));
            e.Graphics.FillEllipse(brushBg, 2, 2, 22, 22);

            using var font = new Font("Segoe UI", 11, FontStyle.Bold, GraphicsUnit.Point);
            using var brushText = new SolidBrush(Color.White);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString("!", font, brushText, new RectangleF(2, 2, 22, 22), sf);
        }
    }
}
