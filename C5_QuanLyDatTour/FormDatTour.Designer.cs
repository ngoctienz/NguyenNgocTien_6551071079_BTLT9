namespace C5_QuanLyDatTour
{
    partial class FormDatTour
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tabControlMain = new TabControl();
            tabTour = new TabPage();
            dgvTour = new DataGridView();
            colTour_MaTour = new DataGridViewTextBoxColumn();
            colTour_TenTour = new DataGridViewTextBoxColumn();
            colTour_DiemDen = new DataGridViewTextBoxColumn();
            colTour_NgoaiTe = new DataGridViewTextBoxColumn();
            colTour_GiaNgoaiTe = new DataGridViewTextBoxColumn();
            colTour_NgayKhoiHanh = new DataGridViewTextBoxColumn();
            colTour_SoChoToiDa = new DataGridViewTextBoxColumn();
            pnlTourTop = new Panel();
            pnlTourSearch = new Panel();
            btnTatCaTour = new Button();
            btnTimTour = new Button();
            txtTimTour = new TextBox();
            grpThongTinTour = new GroupBox();
            btnLamMoiTour = new Button();
            btnXoaTour = new Button();
            btnSuaTour = new Button();
            btnThemTour = new Button();
            nudSoChoToiDa = new NumericUpDown();
            lblSoChoToiDa = new Label();
            dtpNgayKhoiHanh = new DateTimePicker();
            lblNgayKhoiHanh = new Label();
            nudGiaNgoaiTe = new NumericUpDown();
            lblGiaNgoaiTe_Tour = new Label();
            cboNgoaiTe = new ComboBox();
            lblNgoaiTe = new Label();
            txtDiemDen = new TextBox();
            lblDiemDen = new Label();
            txtTenTour = new TextBox();
            lblTenTour = new Label();
            txtMaTour = new TextBox();
            lblMaTour = new Label();
            tabKhachHang = new TabPage();
            dgvKhachHang = new DataGridView();
            colKH_MaKH = new DataGridViewTextBoxColumn();
            colKH_HoTen = new DataGridViewTextBoxColumn();
            colKH_SoDienThoai = new DataGridViewTextBoxColumn();
            colKH_Email = new DataGridViewTextBoxColumn();
            pnlKhachHangTop = new Panel();
            pnlKHSearch = new Panel();
            btnTatCaKH = new Button();
            btnTimKH = new Button();
            txtTimKH = new TextBox();
            grpThongTinKH = new GroupBox();
            btnLamMoiKH = new Button();
            btnXoaKH = new Button();
            btnSuaKH = new Button();
            btnThemKH = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaKH = new TextBox();
            lblMaKH = new Label();
            tabDatTour = new TabPage();
            lblTongDoanhThu = new Label();
            dgvDatTour = new DataGridView();
            colDT_Ma = new DataGridViewTextBoxColumn();
            colDT_KhachHang = new DataGridViewTextBoxColumn();
            colDT_Tour = new DataGridViewTextBoxColumn();
            colDT_SoNguoi = new DataGridViewTextBoxColumn();
            colDT_TyGia = new DataGridViewTextBoxColumn();
            colDT_TongTien = new DataGridViewTextBoxColumn();
            colDT_NgayDat = new DataGridViewTextBoxColumn();
            pnlDatTourSearch = new Panel();
            btnTimDatTour = new Button();
            cboThangKhoiHanh = new ComboBox();
            lblThangKhoiHanh = new Label();
            txtTimKiemDatTour = new TextBox();
            grpThongTinDatTour = new GroupBox();
            btnDatTour = new Button();
            lblTongTienVND = new Label();
            lblTongTienText = new Label();
            lblNguonTyGia = new Label();
            lblTyGiaHomNay = new Label();
            lblTyGiaText = new Label();
            lblGiaNgoaiTeValue = new Label();
            lblGiaNgoaiTeText = new Label();
            nudSoNguoi = new NumericUpDown();
            lblSoNguoi = new Label();
            cboTour = new ComboBox();
            lblTour = new Label();
            cboKhachHang = new ComboBox();
            lblKhachHang = new Label();
            tabControlMain.SuspendLayout();
            tabTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTour).BeginInit();
            pnlTourTop.SuspendLayout();
            pnlTourSearch.SuspendLayout();
            grpThongTinTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoChoToiDa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaNgoaiTe).BeginInit();
            tabKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            pnlKhachHangTop.SuspendLayout();
            pnlKHSearch.SuspendLayout();
            grpThongTinKH.SuspendLayout();
            tabDatTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatTour).BeginInit();
            pnlDatTourSearch.SuspendLayout();
            grpThongTinDatTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabTour);
            tabControlMain.Controls.Add(tabKhachHang);
            tabControlMain.Controls.Add(tabDatTour);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 9.5F);
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 2;
            tabControlMain.Size = new Size(1008, 641);
            tabControlMain.TabIndex = 0;
            // 
            // tabTour
            // 
            tabTour.Controls.Add(dgvTour);
            tabTour.Controls.Add(pnlTourTop);
            tabTour.Location = new Point(4, 30);
            tabTour.Name = "tabTour";
            tabTour.Padding = new Padding(8);
            tabTour.Size = new Size(1000, 607);
            tabTour.TabIndex = 0;
            tabTour.Text = "Tour";
            tabTour.UseVisualStyleBackColor = true;
            // 
            // dgvTour
            // 
            dgvTour.AllowUserToAddRows = false;
            dgvTour.AllowUserToDeleteRows = false;
            dgvTour.BackgroundColor = Color.White;
            dgvTour.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTour.Columns.AddRange(new DataGridViewColumn[] { colTour_MaTour, colTour_TenTour, colTour_DiemDen, colTour_NgoaiTe, colTour_GiaNgoaiTe, colTour_NgayKhoiHanh, colTour_SoChoToiDa });
            dgvTour.Dock = DockStyle.Fill;
            dgvTour.Location = new Point(8, 240);
            dgvTour.MultiSelect = false;
            dgvTour.Name = "dgvTour";
            dgvTour.ReadOnly = true;
            dgvTour.RowHeadersWidth = 30;
            dgvTour.RowTemplate.Height = 26;
            dgvTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTour.Size = new Size(984, 359);
            dgvTour.TabIndex = 1;
            // 
            // colTour_MaTour
            // 
            colTour_MaTour.HeaderText = "Mã tour";
            colTour_MaTour.MinimumWidth = 6;
            colTour_MaTour.Name = "colTour_MaTour";
            colTour_MaTour.ReadOnly = true;
            colTour_MaTour.Width = 80;
            // 
            // colTour_TenTour
            // 
            colTour_TenTour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTour_TenTour.HeaderText = "Tên tour";
            colTour_TenTour.MinimumWidth = 6;
            colTour_TenTour.Name = "colTour_TenTour";
            colTour_TenTour.ReadOnly = true;
            // 
            // colTour_DiemDen
            // 
            colTour_DiemDen.HeaderText = "Điểm đến";
            colTour_DiemDen.MinimumWidth = 6;
            colTour_DiemDen.Name = "colTour_DiemDen";
            colTour_DiemDen.ReadOnly = true;
            colTour_DiemDen.Width = 140;
            // 
            // colTour_NgoaiTe
            // 
            colTour_NgoaiTe.HeaderText = "Ngoại tệ";
            colTour_NgoaiTe.MinimumWidth = 6;
            colTour_NgoaiTe.Name = "colTour_NgoaiTe";
            colTour_NgoaiTe.ReadOnly = true;
            colTour_NgoaiTe.Width = 85;
            // 
            // colTour_GiaNgoaiTe
            // 
            colTour_GiaNgoaiTe.HeaderText = "Giá ngoại tệ";
            colTour_GiaNgoaiTe.MinimumWidth = 6;
            colTour_GiaNgoaiTe.Name = "colTour_GiaNgoaiTe";
            colTour_GiaNgoaiTe.ReadOnly = true;
            colTour_GiaNgoaiTe.Width = 120;
            // 
            // colTour_NgayKhoiHanh
            // 
            colTour_NgayKhoiHanh.HeaderText = "Ngày khởi hành";
            colTour_NgayKhoiHanh.MinimumWidth = 6;
            colTour_NgayKhoiHanh.Name = "colTour_NgayKhoiHanh";
            colTour_NgayKhoiHanh.ReadOnly = true;
            colTour_NgayKhoiHanh.Width = 120;
            // 
            // colTour_SoChoToiDa
            // 
            colTour_SoChoToiDa.HeaderText = "Số chỗ tối đa";
            colTour_SoChoToiDa.MinimumWidth = 6;
            colTour_SoChoToiDa.Name = "colTour_SoChoToiDa";
            colTour_SoChoToiDa.ReadOnly = true;
            // 
            // pnlTourTop
            // 
            pnlTourTop.Controls.Add(pnlTourSearch);
            pnlTourTop.Controls.Add(grpThongTinTour);
            pnlTourTop.Dock = DockStyle.Top;
            pnlTourTop.Location = new Point(8, 8);
            pnlTourTop.Name = "pnlTourTop";
            pnlTourTop.Size = new Size(984, 232);
            pnlTourTop.TabIndex = 0;
            // 
            // pnlTourSearch
            // 
            pnlTourSearch.Controls.Add(btnTatCaTour);
            pnlTourSearch.Controls.Add(btnTimTour);
            pnlTourSearch.Controls.Add(txtTimTour);
            pnlTourSearch.Dock = DockStyle.Bottom;
            pnlTourSearch.Location = new Point(0, 192);
            pnlTourSearch.Name = "pnlTourSearch";
            pnlTourSearch.Size = new Size(984, 40);
            pnlTourSearch.TabIndex = 1;
            // 
            // btnTatCaTour
            // 
            btnTatCaTour.Location = new Point(410, 5);
            btnTatCaTour.Name = "btnTatCaTour";
            btnTatCaTour.Size = new Size(75, 29);
            btnTatCaTour.TabIndex = 2;
            btnTatCaTour.Text = "Tất cả";
            btnTatCaTour.UseVisualStyleBackColor = true;
            // 
            // btnTimTour
            // 
            btnTimTour.Location = new Point(329, 5);
            btnTimTour.Name = "btnTimTour";
            btnTimTour.Size = new Size(75, 29);
            btnTimTour.TabIndex = 1;
            btnTimTour.Text = "Tìm kiếm";
            btnTimTour.UseVisualStyleBackColor = true;
            // 
            // txtTimTour
            // 
            txtTimTour.Location = new Point(3, 8);
            txtTimTour.Name = "txtTimTour";
            txtTimTour.PlaceholderText = "Tìm theo tên tour hoặc điểm đến...";
            txtTimTour.Size = new Size(320, 29);
            txtTimTour.TabIndex = 0;
            // 
            // grpThongTinTour
            // 
            grpThongTinTour.Controls.Add(btnLamMoiTour);
            grpThongTinTour.Controls.Add(btnXoaTour);
            grpThongTinTour.Controls.Add(btnSuaTour);
            grpThongTinTour.Controls.Add(btnThemTour);
            grpThongTinTour.Controls.Add(nudSoChoToiDa);
            grpThongTinTour.Controls.Add(lblSoChoToiDa);
            grpThongTinTour.Controls.Add(dtpNgayKhoiHanh);
            grpThongTinTour.Controls.Add(lblNgayKhoiHanh);
            grpThongTinTour.Controls.Add(nudGiaNgoaiTe);
            grpThongTinTour.Controls.Add(lblGiaNgoaiTe_Tour);
            grpThongTinTour.Controls.Add(cboNgoaiTe);
            grpThongTinTour.Controls.Add(lblNgoaiTe);
            grpThongTinTour.Controls.Add(txtDiemDen);
            grpThongTinTour.Controls.Add(lblDiemDen);
            grpThongTinTour.Controls.Add(txtTenTour);
            grpThongTinTour.Controls.Add(lblTenTour);
            grpThongTinTour.Controls.Add(txtMaTour);
            grpThongTinTour.Controls.Add(lblMaTour);
            grpThongTinTour.Dock = DockStyle.Top;
            grpThongTinTour.Location = new Point(0, 0);
            grpThongTinTour.Name = "grpThongTinTour";
            grpThongTinTour.Size = new Size(984, 186);
            grpThongTinTour.TabIndex = 0;
            grpThongTinTour.TabStop = false;
            grpThongTinTour.Text = "Thông tin tour";
            // 
            // btnLamMoiTour
            // 
            btnLamMoiTour.Location = new Point(690, 142);
            btnLamMoiTour.Name = "btnLamMoiTour";
            btnLamMoiTour.Size = new Size(88, 30);
            btnLamMoiTour.TabIndex = 17;
            btnLamMoiTour.Text = "Làm mới";
            btnLamMoiTour.UseVisualStyleBackColor = true;
            // 
            // btnXoaTour
            // 
            btnXoaTour.Location = new Point(596, 142);
            btnXoaTour.Name = "btnXoaTour";
            btnXoaTour.Size = new Size(88, 30);
            btnXoaTour.TabIndex = 16;
            btnXoaTour.Text = "Xóa";
            btnXoaTour.UseVisualStyleBackColor = true;
            // 
            // btnSuaTour
            // 
            btnSuaTour.Location = new Point(502, 142);
            btnSuaTour.Name = "btnSuaTour";
            btnSuaTour.Size = new Size(88, 30);
            btnSuaTour.TabIndex = 15;
            btnSuaTour.Text = "Sửa";
            btnSuaTour.UseVisualStyleBackColor = true;
            // 
            // btnThemTour
            // 
            btnThemTour.BackColor = Color.FromArgb(0, 128, 0);
            btnThemTour.ForeColor = Color.White;
            btnThemTour.Location = new Point(408, 142);
            btnThemTour.Name = "btnThemTour";
            btnThemTour.Size = new Size(88, 30);
            btnThemTour.TabIndex = 14;
            btnThemTour.Text = "Thêm";
            btnThemTour.UseVisualStyleBackColor = false;
            // 
            // nudSoChoToiDa
            // 
            nudSoChoToiDa.Location = new Point(596, 103);
            nudSoChoToiDa.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSoChoToiDa.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoChoToiDa.Name = "nudSoChoToiDa";
            nudSoChoToiDa.Size = new Size(182, 29);
            nudSoChoToiDa.TabIndex = 13;
            nudSoChoToiDa.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblSoChoToiDa
            // 
            lblSoChoToiDa.AutoSize = true;
            lblSoChoToiDa.Location = new Point(486, 105);
            lblSoChoToiDa.Name = "lblSoChoToiDa";
            lblSoChoToiDa.Size = new Size(103, 21);
            lblSoChoToiDa.TabIndex = 12;
            lblSoChoToiDa.Text = "Số chỗ tối đa:";
            // 
            // dtpNgayKhoiHanh
            // 
            dtpNgayKhoiHanh.Format = DateTimePickerFormat.Short;
            dtpNgayKhoiHanh.Location = new Point(596, 68);
            dtpNgayKhoiHanh.Name = "dtpNgayKhoiHanh";
            dtpNgayKhoiHanh.Size = new Size(182, 29);
            dtpNgayKhoiHanh.TabIndex = 11;
            // 
            // lblNgayKhoiHanh
            // 
            lblNgayKhoiHanh.AutoSize = true;
            lblNgayKhoiHanh.Location = new Point(486, 72);
            lblNgayKhoiHanh.Name = "lblNgayKhoiHanh";
            lblNgayKhoiHanh.Size = new Size(124, 21);
            lblNgayKhoiHanh.TabIndex = 10;
            lblNgayKhoiHanh.Text = "Ngày khởi hành:";
            // 
            // nudGiaNgoaiTe
            // 
            nudGiaNgoaiTe.DecimalPlaces = 2;
            nudGiaNgoaiTe.Location = new Point(596, 31);
            nudGiaNgoaiTe.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudGiaNgoaiTe.Name = "nudGiaNgoaiTe";
            nudGiaNgoaiTe.Size = new Size(182, 29);
            nudGiaNgoaiTe.TabIndex = 9;
            nudGiaNgoaiTe.ThousandsSeparator = true;
            // 
            // lblGiaNgoaiTe_Tour
            // 
            lblGiaNgoaiTe_Tour.AutoSize = true;
            lblGiaNgoaiTe_Tour.Location = new Point(486, 34);
            lblGiaNgoaiTe_Tour.Name = "lblGiaNgoaiTe_Tour";
            lblGiaNgoaiTe_Tour.Size = new Size(96, 21);
            lblGiaNgoaiTe_Tour.TabIndex = 8;
            lblGiaNgoaiTe_Tour.Text = "Giá ngoại tệ:";
            // 
            // cboNgoaiTe
            // 
            cboNgoaiTe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNgoaiTe.FormattingEnabled = true;
            cboNgoaiTe.Items.AddRange(new object[] { "THB", "KRW", "JPY", "USD" });
            cboNgoaiTe.Location = new Point(95, 139);
            cboNgoaiTe.Name = "cboNgoaiTe";
            cboNgoaiTe.Size = new Size(260, 29);
            cboNgoaiTe.TabIndex = 7;
            // 
            // lblNgoaiTe
            // 
            lblNgoaiTe.AutoSize = true;
            lblNgoaiTe.Location = new Point(16, 142);
            lblNgoaiTe.Name = "lblNgoaiTe";
            lblNgoaiTe.Size = new Size(72, 21);
            lblNgoaiTe.TabIndex = 6;
            lblNgoaiTe.Text = "Ngoại tệ:";
            // 
            // txtDiemDen
            // 
            txtDiemDen.Location = new Point(95, 102);
            txtDiemDen.Name = "txtDiemDen";
            txtDiemDen.Size = new Size(260, 29);
            txtDiemDen.TabIndex = 5;
            // 
            // lblDiemDen
            // 
            lblDiemDen.AutoSize = true;
            lblDiemDen.Location = new Point(16, 105);
            lblDiemDen.Name = "lblDiemDen";
            lblDiemDen.Size = new Size(80, 21);
            lblDiemDen.TabIndex = 4;
            lblDiemDen.Text = "Điểm đến:";
            // 
            // txtTenTour
            // 
            txtTenTour.Location = new Point(95, 66);
            txtTenTour.Name = "txtTenTour";
            txtTenTour.Size = new Size(350, 29);
            txtTenTour.TabIndex = 3;
            // 
            // lblTenTour
            // 
            lblTenTour.AutoSize = true;
            lblTenTour.Location = new Point(16, 69);
            lblTenTour.Name = "lblTenTour";
            lblTenTour.Size = new Size(69, 21);
            lblTenTour.TabIndex = 2;
            lblTenTour.Text = "Tên tour:";
            // 
            // txtMaTour
            // 
            txtMaTour.Location = new Point(95, 31);
            txtMaTour.Name = "txtMaTour";
            txtMaTour.ReadOnly = true;
            txtMaTour.Size = new Size(120, 29);
            txtMaTour.TabIndex = 1;
            txtMaTour.Text = "(Tự động)";
            // 
            // lblMaTour
            // 
            lblMaTour.AutoSize = true;
            lblMaTour.Location = new Point(16, 34);
            lblMaTour.Name = "lblMaTour";
            lblMaTour.Size = new Size(68, 21);
            lblMaTour.TabIndex = 0;
            lblMaTour.Text = "Mã tour:";
            // 
            // tabKhachHang
            // 
            tabKhachHang.Controls.Add(dgvKhachHang);
            tabKhachHang.Controls.Add(pnlKhachHangTop);
            tabKhachHang.Location = new Point(4, 30);
            tabKhachHang.Name = "tabKhachHang";
            tabKhachHang.Padding = new Padding(8);
            tabKhachHang.Size = new Size(1000, 607);
            tabKhachHang.TabIndex = 1;
            tabKhachHang.Text = "Khách hàng";
            tabKhachHang.UseVisualStyleBackColor = true;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colKH_MaKH, colKH_HoTen, colKH_SoDienThoai, colKH_Email });
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.Location = new Point(8, 208);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 30;
            dgvKhachHang.RowTemplate.Height = 26;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(984, 391);
            dgvKhachHang.TabIndex = 1;
            // 
            // colKH_MaKH
            // 
            colKH_MaKH.HeaderText = "Mã KH";
            colKH_MaKH.MinimumWidth = 6;
            colKH_MaKH.Name = "colKH_MaKH";
            colKH_MaKH.ReadOnly = true;
            colKH_MaKH.Width = 90;
            // 
            // colKH_HoTen
            // 
            colKH_HoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colKH_HoTen.HeaderText = "Họ và tên";
            colKH_HoTen.MinimumWidth = 6;
            colKH_HoTen.Name = "colKH_HoTen";
            colKH_HoTen.ReadOnly = true;
            // 
            // colKH_SoDienThoai
            // 
            colKH_SoDienThoai.HeaderText = "Số điện thoại";
            colKH_SoDienThoai.MinimumWidth = 6;
            colKH_SoDienThoai.Name = "colKH_SoDienThoai";
            colKH_SoDienThoai.ReadOnly = true;
            colKH_SoDienThoai.Width = 180;
            // 
            // colKH_Email
            // 
            colKH_Email.HeaderText = "Email";
            colKH_Email.MinimumWidth = 6;
            colKH_Email.Name = "colKH_Email";
            colKH_Email.ReadOnly = true;
            colKH_Email.Width = 260;
            // 
            // pnlKhachHangTop
            // 
            pnlKhachHangTop.Controls.Add(pnlKHSearch);
            pnlKhachHangTop.Controls.Add(grpThongTinKH);
            pnlKhachHangTop.Dock = DockStyle.Top;
            pnlKhachHangTop.Location = new Point(8, 8);
            pnlKhachHangTop.Name = "pnlKhachHangTop";
            pnlKhachHangTop.Size = new Size(984, 200);
            pnlKhachHangTop.TabIndex = 0;
            // 
            // pnlKHSearch
            // 
            pnlKHSearch.Controls.Add(btnTatCaKH);
            pnlKHSearch.Controls.Add(btnTimKH);
            pnlKHSearch.Controls.Add(txtTimKH);
            pnlKHSearch.Dock = DockStyle.Bottom;
            pnlKHSearch.Location = new Point(0, 160);
            pnlKHSearch.Name = "pnlKHSearch";
            pnlKHSearch.Size = new Size(984, 40);
            pnlKHSearch.TabIndex = 1;
            // 
            // btnTatCaKH
            // 
            btnTatCaKH.Location = new Point(410, 5);
            btnTatCaKH.Name = "btnTatCaKH";
            btnTatCaKH.Size = new Size(75, 29);
            btnTatCaKH.TabIndex = 2;
            btnTatCaKH.Text = "Tất cả";
            btnTatCaKH.UseVisualStyleBackColor = true;
            // 
            // btnTimKH
            // 
            btnTimKH.Location = new Point(329, 5);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(75, 29);
            btnTimKH.TabIndex = 1;
            btnTimKH.Text = "Tìm kiếm";
            btnTimKH.UseVisualStyleBackColor = true;
            // 
            // txtTimKH
            // 
            txtTimKH.Location = new Point(3, 8);
            txtTimKH.Name = "txtTimKH";
            txtTimKH.PlaceholderText = "Tìm theo tên hoặc số điện thoại...";
            txtTimKH.Size = new Size(320, 29);
            txtTimKH.TabIndex = 0;
            // 
            // grpThongTinKH
            // 
            grpThongTinKH.Controls.Add(btnLamMoiKH);
            grpThongTinKH.Controls.Add(btnXoaKH);
            grpThongTinKH.Controls.Add(btnSuaKH);
            grpThongTinKH.Controls.Add(btnThemKH);
            grpThongTinKH.Controls.Add(txtEmail);
            grpThongTinKH.Controls.Add(lblEmail);
            grpThongTinKH.Controls.Add(txtSoDienThoai);
            grpThongTinKH.Controls.Add(lblSoDienThoai);
            grpThongTinKH.Controls.Add(txtHoTen);
            grpThongTinKH.Controls.Add(lblHoTen);
            grpThongTinKH.Controls.Add(txtMaKH);
            grpThongTinKH.Controls.Add(lblMaKH);
            grpThongTinKH.Dock = DockStyle.Top;
            grpThongTinKH.Location = new Point(0, 0);
            grpThongTinKH.Name = "grpThongTinKH";
            grpThongTinKH.Size = new Size(984, 154);
            grpThongTinKH.TabIndex = 0;
            grpThongTinKH.TabStop = false;
            grpThongTinKH.Text = "Thông tin khách hàng";
            // 
            // btnLamMoiKH
            // 
            btnLamMoiKH.Location = new Point(390, 107);
            btnLamMoiKH.Name = "btnLamMoiKH";
            btnLamMoiKH.Size = new Size(88, 30);
            btnLamMoiKH.TabIndex = 11;
            btnLamMoiKH.Text = "Làm mới";
            btnLamMoiKH.UseVisualStyleBackColor = true;
            // 
            // btnXoaKH
            // 
            btnXoaKH.Location = new Point(296, 107);
            btnXoaKH.Name = "btnXoaKH";
            btnXoaKH.Size = new Size(88, 30);
            btnXoaKH.TabIndex = 10;
            btnXoaKH.Text = "Xóa";
            btnXoaKH.UseVisualStyleBackColor = true;
            // 
            // btnSuaKH
            // 
            btnSuaKH.Location = new Point(202, 107);
            btnSuaKH.Name = "btnSuaKH";
            btnSuaKH.Size = new Size(88, 30);
            btnSuaKH.TabIndex = 9;
            btnSuaKH.Text = "Sửa";
            btnSuaKH.UseVisualStyleBackColor = true;
            // 
            // btnThemKH
            // 
            btnThemKH.BackColor = Color.FromArgb(0, 128, 0);
            btnThemKH.ForeColor = Color.White;
            btnThemKH.Location = new Point(108, 107);
            btnThemKH.Name = "btnThemKH";
            btnThemKH.Size = new Size(88, 30);
            btnThemKH.TabIndex = 8;
            btnThemKH.Text = "Thêm";
            btnThemKH.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(560, 68);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(260, 29);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(468, 71);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(560, 31);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(260, 29);
            txtSoDienThoai.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(468, 34);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(104, 21);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(108, 68);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 29);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(16, 71);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(79, 21);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên:";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(108, 31);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(120, 29);
            txtMaKH.TabIndex = 1;
            txtMaKH.Text = "(Tự động)";
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Location = new Point(16, 34);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(59, 21);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã KH:";
            // 
            // tabDatTour
            // 
            tabDatTour.Controls.Add(lblTongDoanhThu);
            tabDatTour.Controls.Add(dgvDatTour);
            tabDatTour.Controls.Add(pnlDatTourSearch);
            tabDatTour.Controls.Add(grpThongTinDatTour);
            tabDatTour.Location = new Point(4, 30);
            tabDatTour.Name = "tabDatTour";
            tabDatTour.Padding = new Padding(12);
            tabDatTour.Size = new Size(1000, 607);
            tabDatTour.TabIndex = 2;
            tabDatTour.Text = "Đặt tour";
            tabDatTour.UseVisualStyleBackColor = true;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTongDoanhThu.Location = new Point(748, 582);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(265, 25);
            lblTongDoanhThu.TabIndex = 3;
            lblTongDoanhThu.Text = "Tổng doanh thu: 98.420.000 đ";
            lblTongDoanhThu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvDatTour
            // 
            dgvDatTour.AllowUserToAddRows = false;
            dgvDatTour.AllowUserToDeleteRows = false;
            dgvDatTour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatTour.BackgroundColor = Color.White;
            dgvDatTour.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDatTour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDatTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatTour.Columns.AddRange(new DataGridViewColumn[] { colDT_Ma, colDT_KhachHang, colDT_Tour, colDT_SoNguoi, colDT_TyGia, colDT_TongTien, colDT_NgayDat });
            dgvDatTour.Location = new Point(12, 308);
            dgvDatTour.MultiSelect = false;
            dgvDatTour.Name = "dgvDatTour";
            dgvDatTour.ReadOnly = true;
            dgvDatTour.RowHeadersWidth = 35;
            dgvDatTour.RowTemplate.Height = 26;
            dgvDatTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatTour.Size = new Size(976, 268);
            dgvDatTour.TabIndex = 2;
            // 
            // colDT_Ma
            // 
            colDT_Ma.HeaderText = "Mã";
            colDT_Ma.MinimumWidth = 6;
            colDT_Ma.Name = "colDT_Ma";
            colDT_Ma.ReadOnly = true;
            colDT_Ma.Width = 75;
            // 
            // colDT_KhachHang
            // 
            colDT_KhachHang.HeaderText = "Khách hàng";
            colDT_KhachHang.MinimumWidth = 6;
            colDT_KhachHang.Name = "colDT_KhachHang";
            colDT_KhachHang.ReadOnly = true;
            colDT_KhachHang.Width = 150;
            // 
            // colDT_Tour
            // 
            colDT_Tour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDT_Tour.HeaderText = "Tour";
            colDT_Tour.MinimumWidth = 6;
            colDT_Tour.Name = "colDT_Tour";
            colDT_Tour.ReadOnly = true;
            // 
            // colDT_SoNguoi
            // 
            colDT_SoNguoi.HeaderText = "Số người";
            colDT_SoNguoi.MinimumWidth = 6;
            colDT_SoNguoi.Name = "colDT_SoNguoi";
            colDT_SoNguoi.ReadOnly = true;
            colDT_SoNguoi.Width = 85;
            // 
            // colDT_TyGia
            // 
            colDT_TyGia.HeaderText = "Tỷ giá";
            colDT_TyGia.MinimumWidth = 6;
            colDT_TyGia.Name = "colDT_TyGia";
            colDT_TyGia.ReadOnly = true;
            colDT_TyGia.Width = 120;
            // 
            // colDT_TongTien
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDT_TongTien.DefaultCellStyle = dataGridViewCellStyle4;
            colDT_TongTien.HeaderText = "Tổng tiền (VND)";
            colDT_TongTien.MinimumWidth = 6;
            colDT_TongTien.Name = "colDT_TongTien";
            colDT_TongTien.ReadOnly = true;
            colDT_TongTien.Width = 140;
            // 
            // colDT_NgayDat
            // 
            colDT_NgayDat.HeaderText = "Ngày đặt";
            colDT_NgayDat.MinimumWidth = 6;
            colDT_NgayDat.Name = "colDT_NgayDat";
            colDT_NgayDat.ReadOnly = true;
            colDT_NgayDat.Width = 140;
            // 
            // pnlDatTourSearch
            // 
            pnlDatTourSearch.Controls.Add(btnTimDatTour);
            pnlDatTourSearch.Controls.Add(cboThangKhoiHanh);
            pnlDatTourSearch.Controls.Add(lblThangKhoiHanh);
            pnlDatTourSearch.Controls.Add(txtTimKiemDatTour);
            pnlDatTourSearch.Dock = DockStyle.Top;
            pnlDatTourSearch.Location = new Point(12, 262);
            pnlDatTourSearch.Name = "pnlDatTourSearch";
            pnlDatTourSearch.Size = new Size(976, 40);
            pnlDatTourSearch.TabIndex = 1;
            // 
            // btnTimDatTour
            // 
            btnTimDatTour.Location = new Point(530, 5);
            btnTimDatTour.Name = "btnTimDatTour";
            btnTimDatTour.Size = new Size(65, 29);
            btnTimDatTour.TabIndex = 3;
            btnTimDatTour.Text = "Tìm";
            btnTimDatTour.UseVisualStyleBackColor = true;
            // 
            // cboThangKhoiHanh
            // 
            cboThangKhoiHanh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThangKhoiHanh.FormattingEnabled = true;
            cboThangKhoiHanh.Items.AddRange(new object[] { "", "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cboThangKhoiHanh.Location = new Point(430, 7);
            cboThangKhoiHanh.Name = "cboThangKhoiHanh";
            cboThangKhoiHanh.Size = new Size(90, 29);
            cboThangKhoiHanh.TabIndex = 2;
            // 
            // lblThangKhoiHanh
            // 
            lblThangKhoiHanh.AutoSize = true;
            lblThangKhoiHanh.Location = new Point(315, 10);
            lblThangKhoiHanh.Name = "lblThangKhoiHanh";
            lblThangKhoiHanh.Size = new Size(127, 21);
            lblThangKhoiHanh.TabIndex = 1;
            lblThangKhoiHanh.Text = "Tháng khởi hành";
            // 
            // txtTimKiemDatTour
            // 
            txtTimKiemDatTour.Location = new Point(3, 8);
            txtTimKiemDatTour.Name = "txtTimKiemDatTour";
            txtTimKiemDatTour.PlaceholderText = "Tìm theo tên khách hoặc tên tour";
            txtTimKiemDatTour.Size = new Size(300, 29);
            txtTimKiemDatTour.TabIndex = 0;
            // 
            // grpThongTinDatTour
            // 
            grpThongTinDatTour.Controls.Add(btnDatTour);
            grpThongTinDatTour.Controls.Add(lblTongTienVND);
            grpThongTinDatTour.Controls.Add(lblTongTienText);
            grpThongTinDatTour.Controls.Add(lblNguonTyGia);
            grpThongTinDatTour.Controls.Add(lblTyGiaHomNay);
            grpThongTinDatTour.Controls.Add(lblTyGiaText);
            grpThongTinDatTour.Controls.Add(lblGiaNgoaiTeValue);
            grpThongTinDatTour.Controls.Add(lblGiaNgoaiTeText);
            grpThongTinDatTour.Controls.Add(nudSoNguoi);
            grpThongTinDatTour.Controls.Add(lblSoNguoi);
            grpThongTinDatTour.Controls.Add(cboTour);
            grpThongTinDatTour.Controls.Add(lblTour);
            grpThongTinDatTour.Controls.Add(cboKhachHang);
            grpThongTinDatTour.Controls.Add(lblKhachHang);
            grpThongTinDatTour.Dock = DockStyle.Top;
            grpThongTinDatTour.Location = new Point(12, 12);
            grpThongTinDatTour.Name = "grpThongTinDatTour";
            grpThongTinDatTour.Size = new Size(976, 250);
            grpThongTinDatTour.TabIndex = 0;
            grpThongTinDatTour.TabStop = false;
            grpThongTinDatTour.Text = "Thông tin đặt tour";
            // 
            // btnDatTour
            // 
            btnDatTour.BackColor = Color.FromArgb(0, 128, 0);
            btnDatTour.Cursor = Cursors.Hand;
            btnDatTour.FlatAppearance.BorderSize = 0;
            btnDatTour.FlatStyle = FlatStyle.Flat;
            btnDatTour.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDatTour.ForeColor = Color.White;
            btnDatTour.Location = new Point(135, 203);
            btnDatTour.Name = "btnDatTour";
            btnDatTour.Size = new Size(115, 34);
            btnDatTour.TabIndex = 13;
            btnDatTour.Text = "Đặt tour";
            btnDatTour.UseVisualStyleBackColor = false;
            // 
            // lblTongTienVND
            // 
            lblTongTienVND.AutoSize = true;
            lblTongTienVND.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTongTienVND.ForeColor = Color.FromArgb(160, 0, 0);
            lblTongTienVND.Location = new Point(132, 168);
            lblTongTienVND.Name = "lblTongTienVND";
            lblTongTienVND.Size = new Size(151, 31);
            lblTongTienVND.TabIndex = 12;
            lblTongTienVND.Text = "22.173.000 đ";
            // 
            // lblTongTienText
            // 
            lblTongTienText.AutoSize = true;
            lblTongTienText.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTongTienText.ForeColor = Color.FromArgb(160, 0, 0);
            lblTongTienText.Location = new Point(30, 170);
            lblTongTienText.Name = "lblTongTienText";
            lblTongTienText.Size = new Size(108, 28);
            lblTongTienText.TabIndex = 11;
            lblTongTienText.Text = "Tổng tiền:";
            // 
            // lblNguonTyGia
            // 
            lblNguonTyGia.AutoSize = true;
            lblNguonTyGia.BackColor = Color.FromArgb(233, 236, 239);
            lblNguonTyGia.BorderStyle = BorderStyle.FixedSingle;
            lblNguonTyGia.Font = new Font("Segoe UI", 8.5F);
            lblNguonTyGia.ForeColor = Color.FromArgb(73, 80, 87);
            lblNguonTyGia.Location = new Point(315, 137);
            lblNguonTyGia.Name = "lblNguonTyGia";
            lblNguonTyGia.Padding = new Padding(2);
            lblNguonTyGia.Size = new Size(201, 26);
            lblNguonTyGia.TabIndex = 10;
            lblNguonTyGia.Text = "Tỷ giá lấy từ: cdn.jsdelivr.net";
            // 
            // lblTyGiaHomNay
            // 
            lblTyGiaHomNay.AutoSize = true;
            lblTyGiaHomNay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTyGiaHomNay.Location = new Point(135, 142);
            lblTyGiaHomNay.Name = "lblTyGiaHomNay";
            lblTyGiaHomNay.Size = new Size(140, 21);
            lblTyGiaHomNay.TabIndex = 9;
            lblTyGiaHomNay.Text = "1 THB = 778 VND";
            // 
            // lblTyGiaText
            // 
            lblTyGiaText.AutoSize = true;
            lblTyGiaText.Location = new Point(30, 142);
            lblTyGiaText.Name = "lblTyGiaText";
            lblTyGiaText.Size = new Size(119, 21);
            lblTyGiaText.TabIndex = 8;
            lblTyGiaText.Text = "Tỷ giá hôm nay:";
            // 
            // lblGiaNgoaiTeValue
            // 
            lblGiaNgoaiTeValue.AutoSize = true;
            lblGiaNgoaiTeValue.Location = new Point(135, 114);
            lblGiaNgoaiTeValue.Name = "lblGiaNgoaiTeValue";
            lblGiaNgoaiTeValue.Size = new Size(81, 21);
            lblGiaNgoaiTeValue.TabIndex = 7;
            lblGiaNgoaiTeValue.Text = "9.500 THB";
            // 
            // lblGiaNgoaiTeText
            // 
            lblGiaNgoaiTeText.AutoSize = true;
            lblGiaNgoaiTeText.Location = new Point(30, 114);
            lblGiaNgoaiTeText.Name = "lblGiaNgoaiTeText";
            lblGiaNgoaiTeText.Size = new Size(83, 21);
            lblGiaNgoaiTeText.TabIndex = 6;
            lblGiaNgoaiTeText.Text = "Giá/người:";
            // 
            // nudSoNguoi
            // 
            nudSoNguoi.Location = new Point(135, 83);
            nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.Name = "nudSoNguoi";
            nudSoNguoi.Size = new Size(80, 29);
            nudSoNguoi.TabIndex = 5;
            nudSoNguoi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(30, 85);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(76, 21);
            lblSoNguoi.TabIndex = 4;
            lblSoNguoi.Text = "Số người:";
            // 
            // cboTour
            // 
            cboTour.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTour.FormattingEnabled = true;
            cboTour.Location = new Point(135, 53);
            cboTour.Name = "cboTour";
            cboTour.Size = new Size(250, 29);
            cboTour.TabIndex = 3;
            // 
            // lblTour
            // 
            lblTour.AutoSize = true;
            lblTour.Location = new Point(30, 56);
            lblTour.Name = "lblTour";
            lblTour.Size = new Size(43, 21);
            lblTour.TabIndex = 2;
            lblTour.Text = "Tour:";
            // 
            // cboKhachHang
            // 
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(135, 23);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(250, 29);
            cboKhachHang.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(30, 26);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(94, 21);
            lblKhachHang.TabIndex = 0;
            lblKhachHang.Text = "Khách hàng:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 641);
            Controls.Add(tabControlMain);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(950, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đặt tour - Bình An v1.0.0";
            tabControlMain.ResumeLayout(false);
            tabTour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTour).EndInit();
            pnlTourTop.ResumeLayout(false);
            pnlTourSearch.ResumeLayout(false);
            pnlTourSearch.PerformLayout();
            grpThongTinTour.ResumeLayout(false);
            grpThongTinTour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoChoToiDa).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaNgoaiTe).EndInit();
            tabKhachHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            pnlKhachHangTop.ResumeLayout(false);
            pnlKHSearch.ResumeLayout(false);
            pnlKHSearch.PerformLayout();
            grpThongTinKH.ResumeLayout(false);
            grpThongTinKH.PerformLayout();
            tabDatTour.ResumeLayout(false);
            tabDatTour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatTour).EndInit();
            pnlDatTourSearch.ResumeLayout(false);
            pnlDatTourSearch.PerformLayout();
            grpThongTinDatTour.ResumeLayout(false);
            grpThongTinDatTour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabTour;
        private TabPage tabKhachHang;
        private TabPage tabDatTour;
        private Panel pnlTourTop;
        private GroupBox grpThongTinTour;
        private Panel pnlTourSearch;
        private TextBox txtTimTour;
        private Button btnTimTour;
        private Button btnTatCaTour;
        private DataGridView dgvTour;
        private Label lblMaTour;
        private TextBox txtMaTour;
        private Label lblTenTour;
        private TextBox txtTenTour;
        private Label lblDiemDen;
        private TextBox txtDiemDen;
        private Label lblNgoaiTe;
        private ComboBox cboNgoaiTe;
        private Label lblGiaNgoaiTe_Tour;
        private NumericUpDown nudGiaNgoaiTe;
        private Label lblNgayKhoiHanh;
        private DateTimePicker dtpNgayKhoiHanh;
        private Label lblSoChoToiDa;
        private NumericUpDown nudSoChoToiDa;
        private Button btnThemTour;
        private Button btnSuaTour;
        private Button btnXoaTour;
        private Button btnLamMoiTour;
        private DataGridViewTextBoxColumn colTour_MaTour;
        private DataGridViewTextBoxColumn colTour_TenTour;
        private DataGridViewTextBoxColumn colTour_DiemDen;
        private DataGridViewTextBoxColumn colTour_NgoaiTe;
        private DataGridViewTextBoxColumn colTour_GiaNgoaiTe;
        private DataGridViewTextBoxColumn colTour_NgayKhoiHanh;
        private DataGridViewTextBoxColumn colTour_SoChoToiDa;
        private Panel pnlKhachHangTop;
        private GroupBox grpThongTinKH;
        private Panel pnlKHSearch;
        private TextBox txtTimKH;
        private Button btnTimKH;
        private Button btnTatCaKH;
        private DataGridView dgvKhachHang;
        private Label lblMaKH;
        private TextBox txtMaKH;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnThemKH;
        private Button btnSuaKH;
        private Button btnXoaKH;
        private Button btnLamMoiKH;
        private DataGridViewTextBoxColumn colKH_MaKH;
        private DataGridViewTextBoxColumn colKH_HoTen;
        private DataGridViewTextBoxColumn colKH_SoDienThoai;
        private DataGridViewTextBoxColumn colKH_Email;
        private GroupBox grpThongTinDatTour;
        private Label lblKhachHang;
        private ComboBox cboKhachHang;
        private Label lblTour;
        private ComboBox cboTour;
        private Label lblSoNguoi;
        private NumericUpDown nudSoNguoi;
        private Label lblGiaNgoaiTeText;
        private Label lblGiaNgoaiTeValue;
        private Label lblTyGiaText;
        private Label lblTyGiaHomNay;
        private Label lblNguonTyGia;
        private Label lblTongTienText;
        private Label lblTongTienVND;
        private Button btnDatTour;
        private Panel pnlDatTourSearch;
        private TextBox txtTimKiemDatTour;
        private Label lblThangKhoiHanh;
        private ComboBox cboThangKhoiHanh;
        private Button btnTimDatTour;
        private DataGridView dgvDatTour;
        private Label lblTongDoanhThu;
        private DataGridViewTextBoxColumn colDT_Ma;
        private DataGridViewTextBoxColumn colDT_KhachHang;
        private DataGridViewTextBoxColumn colDT_Tour;
        private DataGridViewTextBoxColumn colDT_SoNguoi;
        private DataGridViewTextBoxColumn colDT_TyGia;
        private DataGridViewTextBoxColumn colDT_TongTien;
        private DataGridViewTextBoxColumn colDT_NgayDat;
    }
}
