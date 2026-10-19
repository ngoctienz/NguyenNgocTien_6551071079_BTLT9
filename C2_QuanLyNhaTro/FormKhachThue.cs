using C2_QuanLyNhaTro.Models.Entities;
using C2_QuanLyNhaTro.Services;
using Serilog;

namespace C2_QuanLyNhaTro;

public partial class FormKhachThue : Form
{
    private const string DangTai = "Đang tải...";

    private readonly List<PhongTroDto> _phongTrong = new();
    private readonly List<PhongTroDto> _tatCaPhong = new();
    private readonly System.Windows.Forms.Timer _timerTimKiem = new() { Interval = 350 };

    /// <summary>Cờ chặn sự kiện khi đang nạp dữ liệu vào ComboBox theo lập trình.</summary>
    private bool _dangNapTinh;
    private bool _dangNapPhuong;

    private bool _apiTinhKhaDung;
    private int _maTinhDaNapPhuong = -1;
    /// <summary>Tăng mỗi lần đổi tỉnh/khách để bỏ qua kết quả API trả về muộn.</summary>
    private int _phienDiaChi;

    private List<WardDto> _phuongXaCuaTinh = new();

    public FormKhachThue()
    {
        InitializeComponent();
        WireEvents();
    }

    private void WireEvents()
    {
        Load += FormKhachThue_Load;

        cboTinh.SelectedIndexChanged += CboTinh_SelectedIndexChanged;
        cboPhuongXa.SelectedIndexChanged += CboPhuongXa_SelectedIndexChanged;

        dgvKhachThue.SelectionChanged += DgvKhachThue_SelectionChanged;

        btnThem.Click += BtnThem_Click;
        btnSua.Click += BtnSua_Click;
        btnXoa.Click += BtnXoa_Click;
        btnLamMoi.Click += (_, _) => LamMoiForm();
        btnBoLoc.Click += (_, _) => BoLoc();
        btnTaiLaiDiaChi.Click += async (_, _) => await NapTinhThanhAsync();
        btnGayLoiThu.Click += (_, _) => GayLoiThuNghiemClick();

        // Nút "Gây lỗi thử" bị ẩn để cô Lan không bấm nhầm;
        // dùng Ctrl+Shift+E khi cần kiểm tra bộ xử lý lỗi toàn cục.
        KeyPreview = true;
        KeyDown += (_, e) =>
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.E)
            {
                GayLoiThuNghiemClick();
            }
        };

        _timerTimKiem.Tick += (_, _) =>
        {
            _timerTimKiem.Stop();
            TaiLuoi();
        };
        txtTimKiem.TextChanged += (_, _) => KhoiDongTimKiem();

        cboLocPhong.SelectedIndexChanged += (_, _) => TaiLuoi();
        cboLocTinh.SelectedIndexChanged += (_, _) => TaiLuoi();
    }

    private async void FormKhachThue_Load(object? sender, EventArgs e)
    {
        NapDuLieuCucBo();
        await NapTinhThanhAsync();
    }

    /// <summary>Nạp phòng, bộ lọc, lưới. Tách riêng để form vẫn dùng được khi CSDL lỗi.</summary>
    private void NapDuLieuCucBo()
    {
        try
        {
            NapPhong();
            NapBoLoc();
            LamMoiForm();
            TaiLuoi();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp dữ liệu ban đầu của FormKhachThue");
            HienLoiThanThien();
        }
    }

    // ------------------------------------------------------------------ dữ liệu địa chỉ

    private async Task NapTinhThanhAsync()
    {
        BatDauCho(cboTinh);

        try
        {
            var tinhs = await AddressApiService.GetProvincesAsync();
            if (tinhs.Count == 0)
            {
                throw new AddressApiException("API trả về danh sách tỉnh/thành rỗng.");
            }

            _dangNapTinh = true;
            cboTinh.DataSource = null;
            cboTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinh.DisplayMember = nameof(ProvinceDto.Name);
            cboTinh.ValueMember = nameof(ProvinceDto.Code);
            cboTinh.DataSource = tinhs;
            cboTinh.SelectedIndex = -1;
            _dangNapTinh = false;

            _apiTinhKhaDung = true;
            btnTaiLaiDiaChi.Visible = false;
            ThongBaoTrangThai($"Đã nạp {tinhs.Count} tỉnh/thành. Chọn 1 tỉnh để xem phường/xã.", false);

            // Người dùng có thể đã chọn một khách trong lúc danh sách đang tải.
            if (KhachDangChon() is { } dangChon)
            {
                NapDiaChiLenForm(dangChon);
            }
        }
        catch (AddressApiException ex)
        {
            Log.Warning(ex, "Không nạp được danh sách tỉnh/thành, chuyển sang nhập tay");
            _apiTinhKhaDung = false;
            ChoPhepNhapTayTinh();
        }
        finally
        {
            _dangNapTinh = false;
            KetThucCho(cboTinh);
        }
    }

    private async void CboTinh_SelectedIndexChanged(object? sender, EventArgs e)
    {
        try
        {
            if (_dangNapTinh || cboTinh.SelectedItem is not ProvinceDto tinh)
            {
                return;
            }

            await NapPhuongXaAsync(tinh.Code);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp phường/xã");
            HienLoiThanThien();
        }
    }

    private async Task NapPhuongXaAsync(int provinceCode)
    {
        var phien = ++_phienDiaChi;

        _phuongXaCuaTinh = new List<WardDto>();
        _maTinhDaNapPhuong = -1;
        _dangNapPhuong = true;
        cboPhuongXa.DataSource = null;
        cboPhuongXa.Items.Clear();
        _dangNapPhuong = false;

        BatDauCho(cboPhuongXa);

        try
        {
            var phuongs = await AddressApiService.GetWardsAsync(provinceCode);
            if (phien != _phienDiaChi)
            {
                return;
            }

            _dangNapPhuong = true;
            cboPhuongXa.Items.Clear();
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongXa.DisplayMember = nameof(WardDto.Name);
            cboPhuongXa.ValueMember = nameof(WardDto.Code);
            cboPhuongXa.DataSource = phuongs.Count > 0 ? phuongs : new List<WardDto>();
            cboPhuongXa.SelectedIndex = -1;
            _phuongXaCuaTinh = phuongs;
            _maTinhDaNapPhuong = provinceCode;
            _dangNapPhuong = false;

            ThongBaoTrangThai($"Đã nạp {phuongs.Count} phường/xã của {cboTinh.Text}.", false);
        }
        catch (AddressApiException ex)
        {
            Log.Warning(ex, "Không nạp được phường/xã của tỉnh {ProvinceCode}", provinceCode);
            if (phien == _phienDiaChi)
            {
                ChoPhepNhapTayPhuongXa();
            }
        }
        finally
        {
            if (phien == _phienDiaChi)
            {
                _dangNapPhuong = false;
                KetThucCho(cboPhuongXa);
            }
        }
    }

    private void CboPhuongXa_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNapPhuong || cboPhuongXa.SelectedItem is not WardDto phuong)
        {
            return;
        }

        ThongBaoTrangThai($"Quê quán: {phuong.Name} - {cboTinh.Text}", false);
    }

    /// <summary>API tỉnh không dùng được: cho gõ tay nhưng vẫn lưu được khách.</summary>
    private void ChoPhepNhapTayTinh()
    {
        _dangNapTinh = true;
        cboTinh.DataSource = null;
        cboTinh.Items.Clear();
        cboTinh.DropDownStyle = ComboBoxStyle.DropDown;
        foreach (var tinh in KhachThueRepository.LayDanhSachTinhDaCo())
        {
            cboTinh.Items.Add(tinh.TenTinh);
        }
        cboTinh.Text = "";
        _dangNapTinh = false;

        ChoPhepNhapTayPhuongXa();

        // Hiện nút để cô Lan thử lại khi mạng đã có.
        btnTaiLaiDiaChi.Visible = true;

        MessageBox.Show(this,
            "Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng.\n" +
            "Bạn vẫn có thể gõ tay Tỉnh/Thành và Phường/Xã để lưu khách bình thường.",
            "Thiếu kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ChoPhepNhapTayPhuongXa()
    {
        cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
        cboPhuongXa.Text = "";
        ThongBaoTrangThai("Chưa tải được Phường/Xã - hãy gõ tay.", true);
    }

    // ------------------------------------------------------------------ trạng thái chờ

    private void BatDauCho(ComboBox cbo)
    {
        cbo.Enabled = false;
        cbo.Items.Clear();
        cbo.Items.Add(DangTai);
        cbo.SelectedIndex = 0;
    }

    private void KetThucCho(ComboBox cbo)
    {
        if (cbo.Items.Count == 1 && Equals(cbo.Items[0], DangTai))
        {
            cbo.Items.Clear();
            cbo.Text = "";
        }
        cbo.Enabled = true;
    }

    private void ThongBaoTrangThai(string text, bool canhBao)
    {
        lblTrangThai.Text = text;
        lblTrangThai.ForeColor = canhBao ? Color.Firebrick : Color.Gray;
        lblTrangThai.Visible = true;
    }

    // ------------------------------------------------------------------ phòng

    private void NapPhong()
    {
        _tatCaPhong.Clear();
        _tatCaPhong.AddRange(KhachThueRepository.LayDanhSachPhong());

        _phongTrong.Clear();
        _phongTrong.AddRange(_tatCaPhong.Where(p => p.TinhTrang == KhachThueRepository.TinhTrangTrong));

        cboPhong.DataSource = null;
        cboPhong.DisplayMember = nameof(PhongTroDto.TenPhong);
        cboPhong.ValueMember = nameof(PhongTroDto.MaPhong);
        cboPhong.DataSource = _phongTrong.Select(MoTaPhong).ToList();
        cboPhong.SelectedIndex = -1;
    }

    private static PhongTroDto MoTaPhong(PhongTroDto p) => new()
    {
        MaPhong = p.MaPhong,
        TenPhong = $"{p.TenPhong} ({p.GiaThue:N0} đ)",
        GiaThue = p.GiaThue,
        TinhTrang = p.TinhTrang,
        SoKhach = p.SoKhach
    };

    private void NapBoLoc()
    {
        cboLocPhong.DisplayMember = nameof(PhongTroDto.TenPhong);
        cboLocPhong.ValueMember = nameof(PhongTroDto.MaPhong);
        cboLocPhong.DataSource = new List<PhongTroDto> { new() { MaPhong = 0, TenPhong = "(Tất cả)" } }
            .Concat(_tatCaPhong).ToList();
        cboLocPhong.SelectedIndex = 0;

        cboLocTinh.DisplayMember = nameof(PhongTroDto.TenPhong);
        cboLocTinh.ValueMember = nameof(PhongTroDto.MaPhong);
        cboLocTinh.DataSource = new List<PhongTroDto> { new() { MaPhong = 0, TenPhong = "(Tất cả)" } }
            .Concat(KhachThueRepository.LayDanhSachTinhDaCo()
                .Select(t => new PhongTroDto { MaPhong = t.MaTinh, TenPhong = t.TenTinh }))
            .ToList();
        cboLocTinh.SelectedIndex = 0;
    }

    private void KhoiDongTimKiem()
    {
        _timerTimKiem.Stop();
        _timerTimKiem.Start();
    }

    // ------------------------------------------------------------------ lưới

    private void TaiLuoi()
    {
        try
        {
            var maPhong = cboLocPhong.SelectedValue as int? ?? 0;
            var maTinh = cboLocTinh.SelectedValue as int? ?? 0;
            var giuLai = KhachDangChon()?.MaKhach;

            var danhSach = KhachThueRepository.LayDanhSach(txtTimKiem.Text, maPhong, maTinh);
            dgvKhachThue.DataSource = danhSach;

            if (giuLai is int ma)
            {
                ChonDongTheoMa(ma);
            }

            ThongBaoTrangThai($"Hiển thị {danhSach.Count} khách thuê.", false);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải danh sách khách thuê");
            HienLoiThanThien();
        }
    }

    private void ChonDongTheoMa(int maKhach)
    {
        foreach (DataGridViewRow row in dgvKhachThue.Rows)
        {
            if (row.DataBoundItem is KhachThueDto dto && dto.MaKhach == maKhach)
            {
                row.Selected = true;
                dgvKhachThue.CurrentCell = row.Cells[colHoTen.Index];
                return;
            }
        }
    }

    private void DgvKhachThue_SelectionChanged(object? sender, EventArgs e)
    {
        if (KhachDangChon() is not { } dto)
        {
            return;
        }

        try
        {
            NapKhachLenForm(dto);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp khách thuê lên form");
            HienLoiThanThien();
        }
    }

    private void NapKhachLenForm(KhachThueDto dto)
    {
        txtHoTen.Text = dto.HoTen;
        rdoNam.Checked = dto.GioiTinh == "Nam";
        rdoNu.Checked = dto.GioiTinh != "Nam";
        dtpNgaySinh.Value = dto.NgaySinh.ToDateTime(TimeOnly.MinValue);
        txtSoDienThoai.Text = dto.SoDienThoai;
        chkDaDangKyTamTru.Checked = dto.DaDangKyTamTru;

        NapPhongChoKhach(dto.MaPhong);
        NapDiaChiLenForm(dto);
    }

    /// <summary>Phòng đang sửa luôn phải có trong danh sách, kể cả khi đã "Đang thuê".</summary>
    private void NapPhongChoKhach(int maPhongCuaKhach)
    {
        var phongHienTai = _tatCaPhong.FirstOrDefault(p => p.MaPhong == maPhongCuaKhach);
        var danhSach = new List<PhongTroDto>();

        if (phongHienTai is not null)
        {
            var moTa = MoTaPhong(phongHienTai);
            moTa.TenPhong += " - đang chọn";
            danhSach.Add(moTa);
        }

        danhSach.AddRange(_phongTrong
            .Where(p => p.MaPhong != maPhongCuaKhach)
            .Select(MoTaPhong));

        cboPhong.DataSource = danhSach;
        cboPhong.SelectedValue = maPhongCuaKhach;
    }

    private async void NapDiaChiLenForm(KhachThueDto dto)
    {
        _dangNapTinh = true;
        var chonDuocTinh = _apiTinhKhaDung
            && cboTinh.DataSource is List<ProvinceDto> tinhs
            && tinhs.Any(t => t.Code == dto.MaTinh);

        if (chonDuocTinh)
        {
            cboTinh.SelectedValue = dto.MaTinh;
        }
        else
        {
            cboTinh.SelectedIndex = -1;
            cboTinh.Text = dto.TenTinh;
        }
        _dangNapTinh = false;

        if (!chonDuocTinh)
        {
            NapPhuongXaChoKhach(dto);
            return;
        }

        // Phường/xã của tỉnh này có thể chưa được nạp -> nạp rồi mới chọn được đúng mục.
        if (_maTinhDaNapPhuong != dto.MaTinh)
        {
            await NapPhuongXaAsync(dto.MaTinh);
        }

        if (KhachDangChon()?.MaKhach == dto.MaKhach)
        {
            NapPhuongXaChoKhach(dto);
        }
    }

    /// <summary>Chỉ chọn được phường/xã khi API của đúng tỉnh đó đã nạp xong.</summary>
    private void NapPhuongXaChoKhach(KhachThueDto dto)
    {
        var phuong = dto.MaPhuongXa > 0
            ? _phuongXaCuaTinh.FirstOrDefault(p => p.Code == dto.MaPhuongXa)
            : null;

        _dangNapPhuong = true;
        if (phuong is not null)
        {
            cboPhuongXa.SelectedValue = phuong.Code;
        }
        else
        {
            cboPhuongXa.SelectedIndex = -1;
            cboPhuongXa.Text = dto.TenPhuongXa;
        }
        _dangNapPhuong = false;
    }

    // ------------------------------------------------------------------ CRUD

    private void BtnThem_Click(object? sender, EventArgs e) => XuLyAnToan(() =>
    {
        if (DocForm(maKhach: null) is not { } khach)
        {
            return;
        }

        KhachThueRepository.Them(khach);
        Log.Information("Đã thêm khách {HoTen} vào phòng {MaPhong}", khach.HoTen, khach.MaPhong);

        ThongBao("Đã thêm khách \"{0}\". Phòng chuyển sang \"Đang thuê\".", khach.HoTen);
        LamMoiForm();
        TaiLuoi();
    });

    private void BtnSua_Click(object? sender, EventArgs e) => XuLyAnToan(() =>
    {
        if (KhachDangChon() is not { } dangChon)
        {
            CanhBaoChuaChonKhach();
            return;
        }

        if (DocForm(dangChon.MaKhach) is not { } khach)
        {
            return;
        }

        KhachThueRepository.Sua(khach);
        Log.Information("Đã cập nhật khách {MaKhach}", khach.MaKhach);

        ThongBao("Đã cập nhật thông tin khách thuê.", khach.HoTen);
        LamMoiForm();
        TaiLuoi();
    });

    private void BtnXoa_Click(object? sender, EventArgs e) => XuLyAnToan(() =>
    {
        if (KhachDangChon() is not { } dangChon)
        {
            CanhBaoChuaChonKhach();
            return;
        }

        var xacNhan = MessageBox.Show(this,
            $"Xóa khách \"{dangChon.HoTen}\" khỏi {dangChon.TenPhong}?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (xacNhan != DialogResult.Yes)
        {
            return;
        }

        KhachThueRepository.Xoa(dangChon.MaKhach);
        Log.Information("Đã xóa khách {MaKhach}", dangChon.MaKhach);

        ThongBao("Đã xóa khách thuê. Trạng thái phòng đã được cập nhật.", dangChon.HoTen);
        LamMoiForm();
        TaiLuoi();
    });

    private KhachThueDto? KhachDangChon() =>
        dgvKhachThue.CurrentRow?.DataBoundItem as KhachThueDto;

    private void CanhBaoChuaChonKhach() =>
        MessageBox.Show(this, "Hãy chọn một khách thuê trong danh sách.", "Chưa chọn khách",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    private void ThongBao(string dinhDang, string thamSo) =>
        MessageBox.Show(this, string.Format(dinhDang, thamSo), "Thành công",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    /// <summary>Đọc form thành entity KhachThue; trả null nếu dữ liệu chưa hợp lệ.</summary>
    private KhachThue? DocForm(int? maKhach)
    {
        if (BatBuocNhap(txtHoTen, "Vui lòng nhập họ tên khách thuê.") is false
            || BatBuocNhap(txtSoDienThoai, "Vui lòng nhập số điện thoại.") is false)
        {
            return null;
        }

        var ngaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date);
        if (ngaySinh >= DateOnly.FromDateTime(DateTime.Today))
        {
            MessageBox.Show(this, "Ngày sinh phải nhỏ hơn ngày hiện tại.", "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        if (cboPhong.SelectedValue is not int maPhong || maPhong <= 0)
        {
            MessageBox.Show(this, "Vui lòng chọn phòng cho khách.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        var (maTinh, tenTinh) = DocTinh();
        if (tenTinh.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng chọn hoặc nhập Tỉnh/Thành.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTinh.Focus();
            return null;
        }

        var (maPhuongXa, tenPhuongXa) = DocPhuongXa();
        if (tenPhuongXa.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng chọn hoặc nhập Phường/Xã.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhuongXa.Focus();
            return null;
        }

        return new KhachThue
        {
            MaKhach = maKhach ?? 0,
            HoTen = txtHoTen.Text.Trim(),
            GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
            NgaySinh = ngaySinh,
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            MaTinh = maTinh,
            TenTinh = tenTinh,
            MaPhuongXa = maPhuongXa,
            TenPhuongXa = tenPhuongXa,
            DaDangKyTamTru = chkDaDangKyTamTru.Checked,
            MaPhong = maPhong
        };
    }

    private bool BatBuocNhap(TextBox txt, string thongBao)
    {
        if (txt.Text.Trim().Length > 0)
        {
            return true;
        }

        MessageBox.Show(this, thongBao, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txt.Focus();
        return false;
    }

    private (int Ma, string Ten) DocTinh()
    {
        if (cboTinh.SelectedItem is ProvinceDto tinh)
        {
            return (tinh.Code, tinh.Name ?? "");
        }

        // Chế độ gõ tay: tái sử dụng mã số đã lưu trước đây nếu trùng tên tỉnh.
        var ten = cboTinh.Text.Trim();
        var daCo = KhachThueRepository.LayDanhSachTinhDaCo().FirstOrDefault(t => t.TenTinh == ten);
        return (daCo.TenTinh is null ? 0 : daCo.MaTinh, ten);
    }

    private (int Ma, string Ten) DocPhuongXa()
    {
        if (cboPhuongXa.SelectedItem is WardDto phuong)
        {
            return (phuong.Code, phuong.Name ?? "");
        }

        // Gõ tay khi mất mạng; nếu có dán kèm "(mã)" thì tách luôn mã.
        return AddressApiService.SplitManualWard(cboPhuongXa.Text);
    }

    private void LamMoiForm()
    {
        try
        {
            dgvKhachThue.ClearSelection();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            chkDaDangKyTamTru.Checked = false;

            NapPhong();
            XoaPhuongXaDaNap();

            if (_apiTinhKhaDung)
            {
                _dangNapTinh = true;
                cboTinh.SelectedIndex = -1;
                _dangNapTinh = false;
                ThongBaoTrangThai("Chọn Tỉnh/Thành để nạp danh sách Phường/Xã.", false);
            }
            else if (cboTinh.Enabled)
            {
                cboTinh.Text = "";
                ThongBaoTrangThai("Chưa tải được danh sách địa chỉ - hãy gõ tay Tỉnh/Thành và Phường/Xã.", true);
            }

            txtHoTen.Focus();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi làm mới form");
            HienLoiThanThien();
        }
    }

    private void XoaPhuongXaDaNap()
    {
        _dangNapPhuong = true;
        cboPhuongXa.DataSource = null;
        cboPhuongXa.Items.Clear();
        cboPhuongXa.Text = "";
        _phuongXaCuaTinh = new List<WardDto>();
        _dangNapPhuong = false;
    }

    private void BoLoc()
    {
        try
        {
            txtTimKiem.Text = "";
            if (cboLocPhong.Items.Count > 0)
            {
                cboLocPhong.SelectedIndex = 0;
            }
            if (cboLocTinh.Items.Count > 0)
            {
                cboLocTinh.SelectedIndex = 0;
            }
            TaiLuoi();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi bỏ lọc");
            HienLoiThanThien();
        }
    }

    // ------------------------------------------------------------------ lỗi

    /// <summary>Nút ẩn để kiểm tra bộ xử lý lỗi toàn cục.</summary>
    private static void GayLoiThuNghiemClick()
    {
        var duLieu = new[] { 1, 2, 3 };
        _ = duLieu[10];
    }

    private void XuLyAnToan(Action hanhDong)
    {
        try
        {
            hanhDong();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thao tác dữ liệu khách thuê");
            HienLoiThanThien();
        }
    }

    private void HienLoiThanThien()
    {
        MessageBox.Show(this, LoiToanCuc.ThongBaoThanThien,
            "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

