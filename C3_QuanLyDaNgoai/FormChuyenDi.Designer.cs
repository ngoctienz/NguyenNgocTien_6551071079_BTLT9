namespace C3_QuanLyDaNgoai
{
    partial class FormChuyenDi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Header labels & Language
            lblTieuDeChinh = new Label();
            lblNgonNgu = new Label();
            cboNgonNgu = new ComboBox();

            // Group: Thông tin chuyến đi
            lblThongTinChuyenDi = new Label();
            lblTenChuyen = new Label();
            txtTenChuyen = new TextBox();
            lblDiaDiem = new Label();
            txtDiaDiem = new TextBox();
            lblNgayDi = new Label();
            dtpNgayDi = new DateTimePicker();
            lblSoNguoi = new Label();
            numSoNguoi = new NumericUpDown();
            lblNganSach = new Label();
            txtNganSach = new TextBox();
            lblPhuongTien = new Label();
            cboPhuongTien = new ComboBox();
            chkDaHoanThanh = new CheckBox();

            // Buttons CRUD
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            // Weather section
            btnXemThoiTiet = new Button();
            prgThoiTiet = new ProgressBar();
            pnlThoiTiet = new Panel();
            lblTieuDeThoiTiet = new Label();
            picThoiTiet = new PictureBox();
            lblMoTaThoiTiet = new Label();
            lblNhietDo = new Label();
            lblKhaNangMua = new Label();
            pnlCanhBao = new Panel();
            picIconCanhBao = new PictureBox();
            lblCanhBao = new Label();

            // Filter section
            txtTimKiem = new TextBox();
            chkChuaHoanThanh = new CheckBox();
            btnTim = new Button();

            // GridView
            dgvChuyenDi = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)numSoNguoi).BeginInit();
            pnlThoiTiet.SuspendLayout();
            pnlCanhBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThoiTiet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCanhBao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            SuspendLayout();

            // 
            // lblTieuDeChinh
            // 
            lblTieuDeChinh.AutoSize = true;
            lblTieuDeChinh.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDeChinh.Location = new Point(14, 12);
            lblTieuDeChinh.Name = "lblTieuDeChinh";
            lblTieuDeChinh.Size = new Size(270, 25);
            lblTieuDeChinh.TabIndex = 0;
            lblTieuDeChinh.Text = "Kế hoạch dã ngoại cuối tuần";

            // 
            // lblNgonNgu
            // 
            lblNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNgonNgu.Location = new Point(738, 16);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(68, 17);
            lblNgonNgu.TabIndex = 1;
            lblNgonNgu.Text = "Ngôn ngữ";

            // 
            // cboNgonNgu
            // 
            cboNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNgonNgu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboNgonNgu.FormattingEnabled = true;
            cboNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            cboNgonNgu.Location = new Point(812, 12);
            cboNgonNgu.Name = "cboNgonNgu";
            cboNgonNgu.Size = new Size(130, 25);
            cboNgonNgu.TabIndex = 2;

            // 
            // lblThongTinChuyenDi
            // 
            lblThongTinChuyenDi.AutoSize = true;
            lblThongTinChuyenDi.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblThongTinChuyenDi.Location = new Point(16, 50);
            lblThongTinChuyenDi.Name = "lblThongTinChuyenDi";
            lblThongTinChuyenDi.Size = new Size(140, 19);
            lblThongTinChuyenDi.TabIndex = 3;
            lblThongTinChuyenDi.Text = "Thông tin chuyến đi";

            // 
            // lblTenChuyen
            // 
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenChuyen.Location = new Point(16, 80);
            lblTenChuyen.Name = "lblTenChuyen";
            lblTenChuyen.Size = new Size(74, 17);
            lblTenChuyen.TabIndex = 4;
            lblTenChuyen.Text = "Tên chuyến";

            // 
            // txtTenChuyen
            // 
            txtTenChuyen.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenChuyen.Location = new Point(116, 77);
            txtTenChuyen.Name = "txtTenChuyen";
            txtTenChuyen.Size = new Size(390, 24);
            txtTenChuyen.TabIndex = 5;
            txtTenChuyen.Text = "Cắm trại đồi chè";

            // 
            // lblDiaDiem
            // 
            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaDiem.Location = new Point(16, 112);
            lblDiaDiem.Name = "lblDiaDiem";
            lblDiaDiem.Size = new Size(59, 17);
            lblDiaDiem.TabIndex = 6;
            lblDiaDiem.Text = "Địa điểm";

            // 
            // txtDiaDiem
            // 
            txtDiaDiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiaDiem.Location = new Point(116, 109);
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(390, 24);
            txtDiaDiem.TabIndex = 7;
            txtDiaDiem.Text = "Đà Lạt";

            // 
            // lblNgayDi
            // 
            lblNgayDi.AutoSize = true;
            lblNgayDi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNgayDi.Location = new Point(16, 144);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(55, 17);
            lblNgayDi.TabIndex = 8;
            lblNgayDi.Text = "Ngày đi";

            // 
            // dtpNgayDi
            // 
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.Location = new Point(116, 140);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(130, 24);
            dtpNgayDi.TabIndex = 9;
            dtpNgayDi.Value = new DateTime(2026, 10, 25);

            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSoNguoi.Location = new Point(16, 176);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(61, 17);
            lblSoNguoi.TabIndex = 10;
            lblSoNguoi.Text = "Số người";

            // 
            // numSoNguoi
            // 
            numSoNguoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            numSoNguoi.Location = new Point(116, 172);
            numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoNguoi.Name = "numSoNguoi";
            numSoNguoi.Size = new Size(130, 24);
            numSoNguoi.TabIndex = 11;
            numSoNguoi.Value = new decimal(new int[] { 6, 0, 0, 0 });

            // 
            // lblNganSach
            // 
            lblNganSach.AutoSize = true;
            lblNganSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNganSach.Location = new Point(16, 207);
            lblNganSach.Name = "lblNganSach";
            lblNganSach.Size = new Size(69, 17);
            lblNganSach.TabIndex = 12;
            lblNganSach.Text = "Ngân sách";

            // 
            // txtNganSach
            // 
            txtNganSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtNganSach.Location = new Point(116, 204);
            txtNganSach.Name = "txtNganSach";
            txtNganSach.Size = new Size(130, 24);
            txtNganSach.TabIndex = 13;
            txtNganSach.Text = "3.500.000";

            // 
            // lblPhuongTien
            // 
            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPhuongTien.Location = new Point(16, 239);
            lblPhuongTien.Name = "lblPhuongTien";
            lblPhuongTien.Size = new Size(80, 17);
            lblPhuongTien.TabIndex = 14;
            lblPhuongTien.Text = "Phương tiện";

            // 
            // cboPhuongTien
            // 
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongTien.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboPhuongTien.FormattingEnabled = true;
            cboPhuongTien.Items.AddRange(new object[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" });
            cboPhuongTien.Location = new Point(116, 236);
            cboPhuongTien.Name = "cboPhuongTien";
            cboPhuongTien.Size = new Size(130, 25);
            cboPhuongTien.TabIndex = 15;

            // 
            // chkDaHoanThanh
            // 
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkDaHoanThanh.Location = new Point(16, 273);
            chkDaHoanThanh.Name = "chkDaHoanThanh";
            chkDaHoanThanh.Size = new Size(111, 21);
            chkDaHoanThanh.TabIndex = 16;
            chkDaHoanThanh.Text = "Đã hoàn thành";
            chkDaHoanThanh.UseVisualStyleBackColor = true;

            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnThem.Location = new Point(16, 308);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 30);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;

            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnSua.Location = new Point(122, 308);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 30);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;

            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnXoa.Location = new Point(228, 308);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 30);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;

            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnLamMoi.Location = new Point(334, 308);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 30);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;

            // 
            // btnXemThoiTiet
            // 
            btnXemThoiTiet.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnXemThoiTiet.Location = new Point(540, 50);
            btnXemThoiTiet.Name = "btnXemThoiTiet";
            btnXemThoiTiet.Size = new Size(140, 30);
            btnXemThoiTiet.TabIndex = 21;
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.UseVisualStyleBackColor = true;

            // 
            // prgThoiTiet
            // 
            prgThoiTiet.Location = new Point(690, 52);
            prgThoiTiet.Name = "prgThoiTiet";
            prgThoiTiet.Size = new Size(130, 26);
            prgThoiTiet.Style = ProgressBarStyle.Marquee;
            prgThoiTiet.MarqueeAnimationSpeed = 30;
            prgThoiTiet.Visible = false;
            prgThoiTiet.TabIndex = 22;

            // 
            // pnlThoiTiet
            // 
            pnlThoiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThoiTiet.BorderStyle = BorderStyle.FixedSingle;
            pnlThoiTiet.Controls.Add(lblTieuDeThoiTiet);
            pnlThoiTiet.Controls.Add(picThoiTiet);
            pnlThoiTiet.Controls.Add(lblMoTaThoiTiet);
            pnlThoiTiet.Controls.Add(lblNhietDo);
            pnlThoiTiet.Controls.Add(lblKhaNangMua);
            pnlThoiTiet.Controls.Add(pnlCanhBao);
            pnlThoiTiet.Location = new Point(540, 88);
            pnlThoiTiet.Name = "pnlThoiTiet";
            pnlThoiTiet.Size = new Size(402, 250);
            pnlThoiTiet.TabIndex = 23;

            // 
            // lblTieuDeThoiTiet
            // 
            lblTieuDeThoiTiet.AutoSize = true;
            lblTieuDeThoiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDeThoiTiet.Location = new Point(12, 10);
            lblTieuDeThoiTiet.Name = "lblTieuDeThoiTiet";
            lblTieuDeThoiTiet.Size = new Size(265, 19);
            lblTieuDeThoiTiet.TabIndex = 0;
            lblTieuDeThoiTiet.Text = "Dự báo thời tiết ngày 25/10/2026 - Đà Lạt";

            // 
            // picThoiTiet
            // 
            picThoiTiet.Location = new Point(25, 42);
            picThoiTiet.Name = "picThoiTiet";
            picThoiTiet.Size = new Size(95, 95);
            picThoiTiet.SizeMode = PictureBoxSizeMode.CenterImage;
            picThoiTiet.TabIndex = 1;
            picThoiTiet.TabStop = false;

            // 
            // lblMoTaThoiTiet
            // 
            lblMoTaThoiTiet.AutoSize = true;
            lblMoTaThoiTiet.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblMoTaThoiTiet.Location = new Point(138, 42);
            lblMoTaThoiTiet.Name = "lblMoTaThoiTiet";
            lblMoTaThoiTiet.Size = new Size(130, 25);
            lblMoTaThoiTiet.TabIndex = 2;
            lblMoTaThoiTiet.Text = "Mưa rào nhẹ";

            // 
            // lblNhietDo
            // 
            lblNhietDo.AutoSize = true;
            lblNhietDo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNhietDo.Location = new Point(140, 77);
            lblNhietDo.Name = "lblNhietDo";
            lblNhietDo.Size = new Size(133, 17);
            lblNhietDo.TabIndex = 3;
            lblNhietDo.Text = "Nhiệt độ: 14°C - 22°C";

            // 
            // lblKhaNangMua
            // 
            lblKhaNangMua.AutoSize = true;
            lblKhaNangMua.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblKhaNangMua.Location = new Point(140, 102);
            lblKhaNangMua.Name = "lblKhaNangMua";
            lblKhaNangMua.Size = new Size(125, 17);
            lblKhaNangMua.TabIndex = 4;
            lblKhaNangMua.Text = "Khả năng mưa: 75%";

            // 
            // pnlCanhBao
            // 
            pnlCanhBao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCanhBao.BackColor = Color.FromArgb(255, 235, 208);
            pnlCanhBao.Controls.Add(picIconCanhBao);
            pnlCanhBao.Controls.Add(lblCanhBao);
            pnlCanhBao.Location = new Point(16, 175);
            pnlCanhBao.Name = "pnlCanhBao";
            pnlCanhBao.Size = new Size(368, 52);
            pnlCanhBao.TabIndex = 5;

            // 
            // picIconCanhBao
            // 
            picIconCanhBao.Location = new Point(10, 12);
            picIconCanhBao.Name = "picIconCanhBao";
            picIconCanhBao.Size = new Size(26, 26);
            picIconCanhBao.TabIndex = 0;
            picIconCanhBao.TabStop = false;

            // 
            // lblCanhBao
            // 
            lblCanhBao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCanhBao.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblCanhBao.ForeColor = Color.FromArgb(140, 55, 0);
            lblCanhBao.Location = new Point(42, 8);
            lblCanhBao.Name = "lblCanhBao";
            lblCanhBao.Size = new Size(316, 36);
            lblCanhBao.TabIndex = 1;
            lblCanhBao.Text = "Nên mang áo mưa hoặc cân nhắc dời lịch";
            lblCanhBao.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Location = new Point(16, 360);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm địa điểm...";
            txtTimKiem.Size = new Size(230, 24);
            txtTimKiem.TabIndex = 24;
            txtTimKiem.Text = "Tìm địa điểm...";

            // 
            // chkChuaHoanThanh
            // 
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkChuaHoanThanh.Location = new Point(258, 362);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Size = new Size(216, 21);
            chkChuaHoanThanh.TabIndex = 25;
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
            chkChuaHoanThanh.UseVisualStyleBackColor = true;

            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnTim.Location = new Point(488, 356);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(90, 30);
            btnTim.TabIndex = 26;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;

            // 
            // dgvChuyenDi
            // 
            dgvChuyenDi.AllowUserToAddRows = false;
            dgvChuyenDi.AllowUserToDeleteRows = false;
            dgvChuyenDi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChuyenDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.BackgroundColor = SystemColors.Window;
            dgvChuyenDi.BorderStyle = BorderStyle.Fixed3D;
            dgvChuyenDi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenDi.Location = new Point(16, 395);
            dgvChuyenDi.MultiSelect = false;
            dgvChuyenDi.Name = "dgvChuyenDi";
            dgvChuyenDi.ReadOnly = true;
            dgvChuyenDi.RowHeadersWidth = 28;
            dgvChuyenDi.RowTemplate.Height = 26;
            dgvChuyenDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.Size = new Size(926, 205);
            dgvChuyenDi.TabIndex = 27;

            // 
            // FormChuyenDi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(958, 615);
            Controls.Add(lblTieuDeChinh);
            Controls.Add(lblNgonNgu);
            Controls.Add(cboNgonNgu);
            Controls.Add(lblThongTinChuyenDi);
            Controls.Add(lblTenChuyen);
            Controls.Add(txtTenChuyen);
            Controls.Add(lblDiaDiem);
            Controls.Add(txtDiaDiem);
            Controls.Add(lblNgayDi);
            Controls.Add(dtpNgayDi);
            Controls.Add(lblSoNguoi);
            Controls.Add(numSoNguoi);
            Controls.Add(lblNganSach);
            Controls.Add(txtNganSach);
            Controls.Add(lblPhuongTien);
            Controls.Add(cboPhuongTien);
            Controls.Add(chkDaHoanThanh);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXemThoiTiet);
            Controls.Add(prgThoiTiet);
            Controls.Add(pnlThoiTiet);
            Controls.Add(txtTimKiem);
            Controls.Add(chkChuaHoanThanh);
            Controls.Add(btnTim);
            Controls.Add(dgvChuyenDi);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(970, 650);
            Name = "FormChuyenDi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại cuối tuần";

            ((System.ComponentModel.ISupportInitialize)numSoNguoi).EndInit();
            pnlThoiTiet.ResumeLayout(false);
            pnlThoiTiet.PerformLayout();
            pnlCanhBao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picThoiTiet).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCanhBao).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDeChinh;
        private Label lblNgonNgu;
        private ComboBox cboNgonNgu;
        private Label lblThongTinChuyenDi;
        private Label lblTenChuyen;
        private TextBox txtTenChuyen;
        private Label lblDiaDiem;
        private TextBox txtDiaDiem;
        private Label lblNgayDi;
        private DateTimePicker dtpNgayDi;
        private Label lblSoNguoi;
        private NumericUpDown numSoNguoi;
        private Label lblNganSach;
        private TextBox txtNganSach;
        private Label lblPhuongTien;
        private ComboBox cboPhuongTien;
        private CheckBox chkDaHoanThanh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnXemThoiTiet;
        private ProgressBar prgThoiTiet;
        private Panel pnlThoiTiet;
        private Label lblTieuDeThoiTiet;
        private PictureBox picThoiTiet;
        private Label lblMoTaThoiTiet;
        private Label lblNhietDo;
        private Label lblKhaNangMua;
        private Panel pnlCanhBao;
        private PictureBox picIconCanhBao;
        private Label lblCanhBao;
        private TextBox txtTimKiem;
        private CheckBox chkChuaHoanThanh;
        private Button btnTim;
        private DataGridView dgvChuyenDi;
    }
}
