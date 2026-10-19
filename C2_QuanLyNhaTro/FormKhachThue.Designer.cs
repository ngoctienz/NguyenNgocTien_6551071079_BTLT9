namespace C2_QuanLyNhaTro
{
    partial class FormKhachThue
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
            grpThongTin = new GroupBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            grpGioiTinh = new GroupBox();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblPhong = new Label();
            cboPhong = new ComboBox();
            lblTinh = new Label();
            cboTinh = new ComboBox();
            lblPhuongXa = new Label();
            cboPhuongXa = new ComboBox();
            chkDaDangKyTamTru = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTrangThai = new Label();
            grpTimKiem = new GroupBox();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblLocPhong = new Label();
            cboLocPhong = new ComboBox();
            lblLocTinh = new Label();
            cboLocTinh = new ComboBox();
            btnBoLoc = new Button();
            btnTaiLaiDiaChi = new Button();
            dgvKhachThue = new DataGridView();
            btnGayLoiThu = new Button();
            grpThongTin.SuspendLayout();
            grpGioiTinh.SuspendLayout();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(grpGioiTinh);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(lblSoDienThoai);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(lblPhong);
            grpThongTin.Controls.Add(cboPhong);
            grpThongTin.Controls.Add(lblTinh);
            grpThongTin.Controls.Add(cboTinh);
            grpThongTin.Controls.Add(lblPhuongXa);
            grpThongTin.Controls.Add(cboPhuongXa);
            grpThongTin.Controls.Add(chkDaDangKyTamTru);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Location = new Point(14, 16);
            grpThongTin.Margin = new Padding(3, 4, 3, 4);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Padding = new Padding(3, 4, 3, 4);
            grpThongTin.Size = new Size(1097, 309);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khách thuê";
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(14, 47);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(69, 31);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            lblHoTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(89, 43);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(342, 27);
            txtHoTen.TabIndex = 1;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Location = new Point(457, 29);
            grpGioiTinh.Margin = new Padding(3, 4, 3, 4);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Padding = new Padding(3, 4, 3, 4);
            grpGioiTinh.Size = new Size(229, 59);
            grpGioiTinh.TabIndex = 2;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(17, 29);
            rdoNam.Margin = new Padding(3, 4, 3, 4);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(109, 29);
            rdoNu.Margin = new Padding(3, 4, 3, 4);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.Location = new Point(14, 100);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(69, 31);
            lblNgaySinh.TabIndex = 3;
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(89, 96);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(228, 27);
            dtpNgaySinh.TabIndex = 4;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Location = new Point(457, 100);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(109, 31);
            lblSoDienThoai.TabIndex = 5;
            lblSoDienThoai.Text = "Số điện thoại:";
            lblSoDienThoai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(573, 96);
            txtSoDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(228, 27);
            txtSoDienThoai.TabIndex = 6;
            // 
            // lblPhong
            // 
            lblPhong.Location = new Point(14, 153);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(69, 31);
            lblPhong.TabIndex = 7;
            lblPhong.Text = "Phòng:";
            lblPhong.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(89, 149);
            cboPhong.Margin = new Padding(3, 4, 3, 4);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(342, 28);
            cboPhong.TabIndex = 8;
            // 
            // lblTinh
            // 
            lblTinh.Location = new Point(457, 153);
            lblTinh.Name = "lblTinh";
            lblTinh.Size = new Size(109, 31);
            lblTinh.TabIndex = 9;
            lblTinh.Text = "Tỉnh/Thành:";
            lblTinh.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboTinh
            // 
            cboTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinh.FormattingEnabled = true;
            cboTinh.Location = new Point(573, 149);
            cboTinh.Margin = new Padding(3, 4, 3, 4);
            cboTinh.Name = "cboTinh";
            cboTinh.Size = new Size(342, 28);
            cboTinh.TabIndex = 10;
            // 
            // lblPhuongXa
            // 
            lblPhuongXa.Location = new Point(14, 207);
            lblPhuongXa.Name = "lblPhuongXa";
            lblPhuongXa.Size = new Size(109, 31);
            lblPhuongXa.TabIndex = 11;
            lblPhuongXa.Text = "Phường/Xã:";
            lblPhuongXa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboPhuongXa
            // 
            cboPhuongXa.FormattingEnabled = true;
            cboPhuongXa.Location = new Point(129, 203);
            cboPhuongXa.Margin = new Padding(3, 4, 3, 4);
            cboPhuongXa.Name = "cboPhuongXa";
            cboPhuongXa.Size = new Size(302, 28);
            cboPhuongXa.TabIndex = 12;
            // 
            // chkDaDangKyTamTru
            // 
            chkDaDangKyTamTru.AutoSize = true;
            chkDaDangKyTamTru.Location = new Point(457, 205);
            chkDaDangKyTamTru.Margin = new Padding(3, 4, 3, 4);
            chkDaDangKyTamTru.Name = "chkDaDangKyTamTru";
            chkDaDangKyTamTru.Size = new Size(158, 24);
            chkDaDangKyTamTru.TabIndex = 13;
            chkDaDangKyTamTru.Text = "Đã đăng ký tạm trú";
            chkDaDangKyTamTru.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(89, 251);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(103, 40);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(203, 251);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(103, 40);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(318, 251);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(103, 40);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(432, 251);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(103, 40);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            lblTrangThai.ForeColor = Color.Gray;
            lblTrangThai.Location = new Point(571, 245);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(514, 53);
            lblTrangThai.TabIndex = 18;
            lblTrangThai.Visible = false;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Controls.Add(lblTimKiem);
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(lblLocPhong);
            grpTimKiem.Controls.Add(cboLocPhong);
            grpTimKiem.Controls.Add(lblLocTinh);
            grpTimKiem.Controls.Add(cboLocTinh);
            grpTimKiem.Controls.Add(btnBoLoc);
            grpTimKiem.Controls.Add(btnTaiLaiDiaChi);
            grpTimKiem.Location = new Point(14, 336);
            grpTimKiem.Margin = new Padding(3, 4, 3, 4);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Padding = new Padding(3, 4, 3, 4);
            grpTimKiem.Size = new Size(1097, 117);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm / Lọc";
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(14, 36);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(184, 20);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm theo họ tên hoặc SĐT:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(203, 32);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(228, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // lblLocPhong
            // 
            lblLocPhong.AutoSize = true;
            lblLocPhong.Location = new Point(457, 36);
            lblLocPhong.Name = "lblLocPhong";
            lblLocPhong.Size = new Size(54, 20);
            lblLocPhong.TabIndex = 2;
            lblLocPhong.Text = "Phòng:";
            // 
            // cboLocPhong
            // 
            cboLocPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocPhong.FormattingEnabled = true;
            cboLocPhong.Location = new Point(515, 32);
            cboLocPhong.Margin = new Padding(3, 4, 3, 4);
            cboLocPhong.Name = "cboLocPhong";
            cboLocPhong.Size = new Size(171, 28);
            cboLocPhong.TabIndex = 3;
            // 
            // lblLocTinh
            // 
            lblLocTinh.AutoSize = true;
            lblLocTinh.Location = new Point(709, 36);
            lblLocTinh.Name = "lblLocTinh";
            lblLocTinh.Size = new Size(86, 20);
            lblLocTinh.TabIndex = 4;
            lblLocTinh.Text = "Tỉnh/Thành:";
            // 
            // cboLocTinh
            // 
            cboLocTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinh.FormattingEnabled = true;
            cboLocTinh.Location = new Point(801, 32);
            cboLocTinh.Margin = new Padding(3, 4, 3, 4);
            cboLocTinh.Name = "cboLocTinh";
            cboLocTinh.Size = new Size(171, 28);
            cboLocTinh.TabIndex = 5;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Location = new Point(990, 31);
            btnBoLoc.Margin = new Padding(3, 4, 3, 4);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(91, 33);
            btnBoLoc.TabIndex = 6;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            // 
            // btnTaiLaiDiaChi
            // 
            btnTaiLaiDiaChi.Location = new Point(14, 71);
            btnTaiLaiDiaChi.Margin = new Padding(3, 4, 3, 4);
            btnTaiLaiDiaChi.Name = "btnTaiLaiDiaChi";
            btnTaiLaiDiaChi.Size = new Size(149, 33);
            btnTaiLaiDiaChi.TabIndex = 7;
            btnTaiLaiDiaChi.Text = "Tải lại địa chỉ";
            btnTaiLaiDiaChi.UseVisualStyleBackColor = true;
            btnTaiLaiDiaChi.Visible = false;
            // 
            // dgvKhachThue
            // 
            dgvKhachThue.AllowUserToAddRows = false;
            dgvKhachThue.AllowUserToDeleteRows = false;
            dgvKhachThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachThue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachThue.Location = new Point(14, 464);
            dgvKhachThue.Margin = new Padding(3, 4, 3, 4);
            dgvKhachThue.MultiSelect = false;
            dgvKhachThue.Name = "dgvKhachThue";
            dgvKhachThue.ReadOnly = true;
            dgvKhachThue.RowHeadersWidth = 25;
            dgvKhachThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachThue.Size = new Size(1097, 363);
            dgvKhachThue.TabIndex = 2;
            // 
            // btnGayLoiThu
            // 
            btnGayLoiThu.Location = new Point(997, 840);
            btnGayLoiThu.Margin = new Padding(3, 4, 3, 4);
            btnGayLoiThu.Name = "btnGayLoiThu";
            btnGayLoiThu.Size = new Size(114, 33);
            btnGayLoiThu.TabIndex = 3;
            btnGayLoiThu.TabStop = false;
            btnGayLoiThu.Text = "Gây lỗi thử";
            btnGayLoiThu.UseVisualStyleBackColor = true;
            // 
            // FormKhachThue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 887);
            Controls.Add(grpThongTin);
            Controls.Add(grpTimKiem);
            Controls.Add(dgvKhachThue);
            Controls.Add(btnGayLoiThu);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 918);
            Name = "FormKhachThue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhà trọ - Khách thuê";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblPhong;
        private ComboBox cboPhong;
        private Label lblTinh;
        private ComboBox cboTinh;
        private Label lblPhuongXa;
        private ComboBox cboPhuongXa;
        private CheckBox chkDaDangKyTamTru;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTrangThai;
        private GroupBox grpTimKiem;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblLocPhong;
        private ComboBox cboLocPhong;
        private Label lblLocTinh;
        private ComboBox cboLocTinh;
        private Button btnBoLoc;
        private Button btnTaiLaiDiaChi;
        private DataGridView dgvKhachThue;
        private DataGridViewTextBoxColumn colMaKhach;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colTenPhong;
        private DataGridViewTextBoxColumn colGiaThue;
        private DataGridViewTextBoxColumn colQueQuan;
        private DataGridViewCheckBoxColumn colTamTru;
        private DataGridViewTextBoxColumn colMaPhong;
        private Button btnGayLoiThu;
    }
}
