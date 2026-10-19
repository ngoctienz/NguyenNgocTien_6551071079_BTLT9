namespace C1_QuanLyChiTieu
{
    partial class FormChiTieu
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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvMaStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvNgayStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvTienStyle = new DataGridViewCellStyle();

            grpThongTin = new GroupBox();
            lblNgayChi = new Label();
            dtpNgayChi = new DateTimePicker();
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            lblLoaiChi = new Label();
            cboLoaiChi = new ComboBox();
            lblSoTien = new Label();
            nudSoTien = new NumericUpDown();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();

            grpTimKiem = new GroupBox();
            lblTimNoiDung = new Label();
            txtTimNoiDung = new TextBox();
            lblLocLoaiChi = new Label();
            cboLocLoaiChi = new ComboBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnTim = new Button();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvChiTieu = new DataGridView();
            colMa = new DataGridViewTextBoxColumn();
            colNgayChi = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colLoaiChi = new DataGridViewTextBoxColumn();
            colSoTien = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();

            lblTongChi = new Label();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).BeginInit();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).BeginInit();
            SuspendLayout();

            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblNgayChi);
            grpThongTin.Controls.Add(dtpNgayChi);
            grpThongTin.Controls.Add(lblNoiDung);
            grpThongTin.Controls.Add(txtNoiDung);
            grpThongTin.Controls.Add(lblLoaiChi);
            grpThongTin.Controls.Add(cboLoaiChi);
            grpThongTin.Controls.Add(lblSoTien);
            grpThongTin.Controls.Add(nudSoTien);
            grpThongTin.Controls.Add(lblGhiChu);
            grpThongTin.Controls.Add(txtGhiChu);
            grpThongTin.Font = new Font("Segoe UI", 9.5F);
            grpThongTin.Location = new Point(14, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(586, 175);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khoản chi";

            // 
            // lblNgayChi
            // 
            lblNgayChi.AutoSize = true;
            lblNgayChi.Location = new Point(16, 28);
            lblNgayChi.Name = "lblNgayChi";
            lblNgayChi.Size = new Size(61, 17);
            lblNgayChi.TabIndex = 0;
            lblNgayChi.Text = "Ngày chi";

            // 
            // dtpNgayChi
            // 
            dtpNgayChi.CustomFormat = "dd/MM/yyyy";
            dtpNgayChi.Format = DateTimePickerFormat.Custom;
            dtpNgayChi.Location = new Point(88, 25);
            dtpNgayChi.Name = "dtpNgayChi";
            dtpNgayChi.Size = new Size(160, 24);
            dtpNgayChi.TabIndex = 1;

            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Location = new Point(16, 62);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(62, 17);
            lblNoiDung.TabIndex = 2;
            lblNoiDung.Text = "Nội dung";

            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(88, 59);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(160, 24);
            txtNoiDung.TabIndex = 3;

            // 
            // lblLoaiChi
            // 
            lblLoaiChi.AutoSize = true;
            lblLoaiChi.Location = new Point(16, 96);
            lblLoaiChi.Name = "lblLoaiChi";
            lblLoaiChi.Size = new Size(53, 17);
            lblLoaiChi.TabIndex = 4;
            lblLoaiChi.Text = "Loại chi";

            // 
            // cboLoaiChi
            // 
            cboLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiChi.FormattingEnabled = true;
            cboLoaiChi.Items.AddRange(new object[] {
                "Ăn uống",
                "Đi lại",
                "Học tập",
                "Giải trí",
                "Khác"
            });
            cboLoaiChi.Location = new Point(88, 93);
            cboLoaiChi.Name = "cboLoaiChi";
            cboLoaiChi.Size = new Size(160, 25);
            cboLoaiChi.TabIndex = 5;

            // 
            // lblSoTien
            // 
            lblSoTien.AutoSize = true;
            lblSoTien.Location = new Point(285, 62);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new Size(49, 17);
            lblSoTien.TabIndex = 6;
            lblSoTien.Text = "Số tiền";

            // 
            // nudSoTien
            // 
            nudSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSoTien.Location = new Point(345, 59);
            nudSoTien.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            nudSoTien.Name = "nudSoTien";
            nudSoTien.Size = new Size(220, 24);
            nudSoTien.TabIndex = 7;
            nudSoTien.ThousandsSeparator = true;

            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(16, 131);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(51, 17);
            lblGhiChu.TabIndex = 8;
            lblGhiChu.Text = "Ghi chú";

            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(88, 127);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(477, 36);
            txtGhiChu.TabIndex = 9;

            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Controls.Add(lblTimNoiDung);
            grpTimKiem.Controls.Add(txtTimNoiDung);
            grpTimKiem.Controls.Add(lblLocLoaiChi);
            grpTimKiem.Controls.Add(cboLocLoaiChi);
            grpTimKiem.Controls.Add(lblTuNgay);
            grpTimKiem.Controls.Add(dtpTuNgay);
            grpTimKiem.Controls.Add(lblDenNgay);
            grpTimKiem.Controls.Add(dtpDenNgay);
            grpTimKiem.Controls.Add(btnTim);
            grpTimKiem.Font = new Font("Segoe UI", 9.5F);
            grpTimKiem.Location = new Point(614, 12);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(360, 175);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm";

            // 
            // lblTimNoiDung
            // 
            lblTimNoiDung.AutoSize = true;
            lblTimNoiDung.Location = new Point(14, 28);
            lblTimNoiDung.Name = "lblTimNoiDung";
            lblTimNoiDung.Size = new Size(53, 17);
            lblTimNoiDung.TabIndex = 0;
            lblTimNoiDung.Text = "TextBox";

            // 
            // txtTimNoiDung
            // 
            txtTimNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimNoiDung.Location = new Point(80, 25);
            txtTimNoiDung.Name = "txtTimNoiDung";
            txtTimNoiDung.PlaceholderText = "Nhập nội dung...";
            txtTimNoiDung.Size = new Size(265, 24);
            txtTimNoiDung.TabIndex = 1;

            // 
            // lblLocLoaiChi
            // 
            lblLocLoaiChi.AutoSize = true;
            lblLocLoaiChi.Location = new Point(14, 62);
            lblLocLoaiChi.Name = "lblLocLoaiChi";
            lblLocLoaiChi.Size = new Size(53, 17);
            lblLocLoaiChi.TabIndex = 2;
            lblLocLoaiChi.Text = "Loại chi";

            // 
            // cboLocLoaiChi
            // 
            cboLocLoaiChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLocLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiChi.FormattingEnabled = true;
            cboLocLoaiChi.Items.AddRange(new object[] {
                "Tất cả",
                "Ăn uống",
                "Đi lại",
                "Học tập",
                "Giải trí",
                "Khác"
            });
            cboLocLoaiChi.Location = new Point(80, 59);
            cboLocLoaiChi.Name = "cboLocLoaiChi";
            cboLocLoaiChi.Size = new Size(265, 25);
            cboLocLoaiChi.TabIndex = 3;

            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(14, 96);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(55, 17);
            lblTuNgay.TabIndex = 4;
            lblTuNgay.Text = "Từ ngày";

            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(80, 93);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(165, 24);
            dtpTuNgay.TabIndex = 5;

            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(14, 131);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(63, 17);
            lblDenNgay.TabIndex = 6;
            lblDenNgay.Text = "Đến ngày";

            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(80, 127);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(165, 24);
            dtpDenNgay.TabIndex = 7;

            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.Location = new Point(255, 125);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(90, 28);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;

            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9.5F);
            btnThem.Location = new Point(102, 196);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(92, 32);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;

            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9.5F);
            btnSua.Location = new Point(208, 196);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(92, 32);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;

            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9.5F);
            btnXoa.Location = new Point(314, 196);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(92, 32);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;

            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 9.5F);
            btnLamMoi.Location = new Point(420, 196);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(92, 32);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;

            // 
            // dgvChiTieu
            // 
            dgvChiTieu.AllowUserToAddRows = false;
            dgvChiTieu.AllowUserToDeleteRows = false;
            dgvChiTieu.AllowUserToResizeRows = false;
            dgvChiTieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTieu.BackgroundColor = Color.White;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHeaderStyle.BackColor = SystemColors.Control;
            dgvHeaderStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHeaderStyle.ForeColor = SystemColors.WindowText;
            dgvHeaderStyle.SelectionBackColor = SystemColors.Highlight;
            dgvHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvHeaderStyle.WrapMode = DataGridViewTriState.True;
            dgvChiTieu.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvChiTieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTieu.Columns.AddRange(new DataGridViewColumn[] {
                colMa,
                colNgayChi,
                colNoiDung,
                colLoaiChi,
                colSoTien,
                colGhiChu
            });
            dgvChiTieu.GridColor = Color.LightGray;
            dgvChiTieu.Location = new Point(14, 238);
            dgvChiTieu.MultiSelect = false;
            dgvChiTieu.Name = "dgvChiTieu";
            dgvChiTieu.ReadOnly = true;
            dgvChiTieu.RowHeadersWidth = 36;
            dgvChiTieu.RowTemplate.Height = 28;
            dgvChiTieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTieu.Size = new Size(960, 272);
            dgvChiTieu.TabIndex = 6;

            // 
            // colMa
            // 
            dgvMaStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMa.DefaultCellStyle = dgvMaStyle;
            colMa.HeaderText = "Mã";
            colMa.Name = "colMa";
            colMa.ReadOnly = true;
            colMa.Width = 85;

            // 
            // colNgayChi
            // 
            dgvNgayStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgayChi.DefaultCellStyle = dgvNgayStyle;
            colNgayChi.HeaderText = "Ngày chi";
            colNgayChi.Name = "colNgayChi";
            colNgayChi.ReadOnly = true;
            colNgayChi.Width = 115;

            // 
            // colNoiDung
            // 
            colNoiDung.HeaderText = "Nội dung";
            colNoiDung.Name = "colNoiDung";
            colNoiDung.ReadOnly = true;
            colNoiDung.Width = 180;

            // 
            // colLoaiChi
            // 
            colLoaiChi.HeaderText = "Loại chi";
            colLoaiChi.Name = "colLoaiChi";
            colLoaiChi.ReadOnly = true;
            colLoaiChi.Width = 120;

            // 
            // colSoTien
            // 
            dgvTienStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoTien.DefaultCellStyle = dgvTienStyle;
            colSoTien.HeaderText = "Số tiền";
            colSoTien.Name = "colSoTien";
            colSoTien.ReadOnly = true;
            colSoTien.Width = 125;

            // 
            // colGhiChu
            // 
            colGhiChu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;

            // 
            // lblTongChi
            // 
            lblTongChi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongChi.AutoSize = true;
            lblTongChi.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTongChi.ForeColor = Color.Red;
            lblTongChi.Location = new Point(720, 520);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(220, 25);
            lblTongChi.TabIndex = 7;
            lblTongChi.Text = "Tổng chi: 1.250.000 đ";

            // 
            // FormChiTieu
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 558);
            Controls.Add(lblTongChi);
            Controls.Add(dgvChiTieu);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpTimKiem);
            Controls.Add(grpThongTin);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(900, 500);
            Name = "FormChiTieu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sổ chi tiêu cá nhân";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).EndInit();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblNgayChi;
        private DateTimePicker dtpNgayChi;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Label lblLoaiChi;
        private ComboBox cboLoaiChi;
        private Label lblSoTien;
        private NumericUpDown nudSoTien;
        private Label lblGhiChu;
        private TextBox txtGhiChu;

        private GroupBox grpTimKiem;
        private Label lblTimNoiDung;
        private TextBox txtTimNoiDung;
        private Label lblLocLoaiChi;
        private ComboBox cboLocLoaiChi;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTim;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvChiTieu;
        private DataGridViewTextBoxColumn colMa;
        private DataGridViewTextBoxColumn colNgayChi;
        private DataGridViewTextBoxColumn colNoiDung;
        private DataGridViewTextBoxColumn colLoaiChi;
        private DataGridViewTextBoxColumn colSoTien;
        private DataGridViewTextBoxColumn colGhiChu;

        private Label lblTongChi;
    }
}
