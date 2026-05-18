namespace QuanLyCHThuoc.BUL
{
    partial class fBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSoHD = new System.Windows.Forms.TextBox();
            this.tbTenKH = new System.Windows.Forms.TextBox();
            this.tbNgayMua = new System.Windows.Forms.TextBox();
            this.tbSdtKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.btXuatHD = new System.Windows.Forms.Button();
            this.btHuyHD = new System.Windows.Forms.Button();
            this.dgvDsSPHD = new System.Windows.Forms.DataGridView();
            this.clNameMedicine = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuanty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIntoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTongTT = new System.Windows.Forms.TextBox();
            this.tbGiamGia = new System.Windows.Forms.TextBox();
            this.tbPhaiTT = new System.Windows.Forms.TextBox();
            this.tbKHDua = new System.Windows.Forms.TextBox();
            this.tbTraLai = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsSPHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số hóa đơn";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên KH";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(686, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày mua";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(672, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 39);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số ĐT";
            // 
            // tbSoHD
            // 
            this.tbSoHD.BackColor = System.Drawing.SystemColors.Window;
            this.tbSoHD.Location = new System.Drawing.Point(175, 95);
            this.tbSoHD.Multiline = true;
            this.tbSoHD.Name = "tbSoHD";
            this.tbSoHD.ReadOnly = true;
            this.tbSoHD.Size = new System.Drawing.Size(143, 27);
            this.tbSoHD.TabIndex = 5;
            // 
            // tbTenKH
            // 
            this.tbTenKH.Location = new System.Drawing.Point(178, 151);
            this.tbTenKH.Multiline = true;
            this.tbTenKH.Name = "tbTenKH";
            this.tbTenKH.Size = new System.Drawing.Size(143, 27);
            this.tbTenKH.TabIndex = 6;
            // 
            // tbNgayMua
            // 
            this.tbNgayMua.BackColor = System.Drawing.SystemColors.Window;
            this.tbNgayMua.Location = new System.Drawing.Point(828, 95);
            this.tbNgayMua.Multiline = true;
            this.tbNgayMua.Name = "tbNgayMua";
            this.tbNgayMua.ReadOnly = true;
            this.tbNgayMua.Size = new System.Drawing.Size(143, 27);
            this.tbNgayMua.TabIndex = 7;
            // 
            // tbSdtKH
            // 
            this.tbSdtKH.Location = new System.Drawing.Point(828, 148);
            this.tbSdtKH.Multiline = true;
            this.tbSdtKH.Name = "tbSdtKH";
            this.tbSdtKH.Size = new System.Drawing.Size(143, 27);
            this.tbSdtKH.TabIndex = 8;
            this.tbSdtKH.Leave += new System.EventHandler(this.tbSdtKH_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "HÓA ĐƠN";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDsSPHD);
            this.panel1.Location = new System.Drawing.Point(70, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 273);
            this.panel1.TabIndex = 10;
            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThanhToan.Controls.Add(this.tbTraLai);
            this.gbThanhToan.Controls.Add(this.tbKHDua);
            this.gbThanhToan.Controls.Add(this.tbPhaiTT);
            this.gbThanhToan.Controls.Add(this.tbGiamGia);
            this.gbThanhToan.Controls.Add(this.tbTongTT);
            this.gbThanhToan.Controls.Add(this.label10);
            this.gbThanhToan.Controls.Add(this.label9);
            this.gbThanhToan.Controls.Add(this.label8);
            this.gbThanhToan.Controls.Add(this.label7);
            this.gbThanhToan.Controls.Add(this.label6);
            this.gbThanhToan.Location = new System.Drawing.Point(70, 544);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(1051, 134);
            this.gbThanhToan.TabIndex = 11;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thông tin thanh toán";
            // 
            // btXuatHD
            // 
            this.btXuatHD.Location = new System.Drawing.Point(690, 700);
            this.btXuatHD.Name = "btXuatHD";
            this.btXuatHD.Size = new System.Drawing.Size(75, 23);
            this.btXuatHD.TabIndex = 12;
            this.btXuatHD.Text = "Xuất HD";
            this.btXuatHD.UseVisualStyleBackColor = true;
            this.btXuatHD.Click += new System.EventHandler(this.btXuatHD_Click);
            // 
            // btHuyHD
            // 
            this.btHuyHD.Location = new System.Drawing.Point(896, 700);
            this.btHuyHD.Name = "btHuyHD";
            this.btHuyHD.Size = new System.Drawing.Size(75, 23);
            this.btHuyHD.TabIndex = 13;
            this.btHuyHD.Text = "Hủy";
            this.btHuyHD.UseVisualStyleBackColor = true;
            this.btHuyHD.Click += new System.EventHandler(this.btHuyHD_Click);
            // 
            // dgvDsSPHD
            // 
            this.dgvDsSPHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsSPHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNameMedicine,
            this.clUnit,
            this.clPrice,
            this.clQuanty,
            this.clIntoMoney,
            this.clNote});
            this.dgvDsSPHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDsSPHD.Location = new System.Drawing.Point(0, 0);
            this.dgvDsSPHD.Name = "dgvDsSPHD";
            this.dgvDsSPHD.RowHeadersWidth = 51;
            this.dgvDsSPHD.RowTemplate.Height = 24;
            this.dgvDsSPHD.Size = new System.Drawing.Size(1051, 273);
            this.dgvDsSPHD.TabIndex = 0;
            this.dgvDsSPHD.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDsSPHD_CellValueChanged);
            // 
            // clNameMedicine
            // 
            this.clNameMedicine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clNameMedicine.HeaderText = "Thuốc điều trị";
            this.clNameMedicine.MinimumWidth = 6;
            this.clNameMedicine.Name = "clNameMedicine";
            // 
            // clUnit
            // 
            this.clUnit.HeaderText = "Đơn vị";
            this.clUnit.MinimumWidth = 6;
            this.clUnit.Name = "clUnit";
            this.clUnit.ReadOnly = true;
            this.clUnit.Width = 125;
            // 
            // clPrice
            // 
            this.clPrice.HeaderText = "Đơn giá";
            this.clPrice.MinimumWidth = 6;
            this.clPrice.Name = "clPrice";
            this.clPrice.ReadOnly = true;
            this.clPrice.Width = 125;
            // 
            // clQuanty
            // 
            this.clQuanty.HeaderText = "S.Lượng";
            this.clQuanty.MinimumWidth = 6;
            this.clQuanty.Name = "clQuanty";
            this.clQuanty.Width = 125;
            // 
            // clIntoMoney
            // 
            this.clIntoMoney.HeaderText = "Thành tiền";
            this.clIntoMoney.MinimumWidth = 6;
            this.clIntoMoney.Name = "clIntoMoney";
            this.clIntoMoney.ReadOnly = true;
            this.clIntoMoney.Width = 125;
            // 
            // clNote
            // 
            this.clNote.HeaderText = "Ghi chú";
            this.clNote.MinimumWidth = 6;
            this.clNote.Name = "clNote";
            this.clNote.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Giảm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(706, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Phải thanh toán";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Khách đưa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Trả lại";
            // 
            // tbTongTT
            // 
            this.tbTongTT.Location = new System.Drawing.Point(117, 33);
            this.tbTongTT.Name = "tbTongTT";
            this.tbTongTT.ReadOnly = true;
            this.tbTongTT.Size = new System.Drawing.Size(100, 22);
            this.tbTongTT.TabIndex = 5;
            this.tbTongTT.Text = "0";
            // 
            // tbGiamGia
            // 
            this.tbGiamGia.Location = new System.Drawing.Point(441, 36);
            this.tbGiamGia.Name = "tbGiamGia";
            this.tbGiamGia.ReadOnly = true;
            this.tbGiamGia.Size = new System.Drawing.Size(100, 22);
            this.tbGiamGia.TabIndex = 6;
            this.tbGiamGia.Text = "0";
            // 
            // tbPhaiTT
            // 
            this.tbPhaiTT.Location = new System.Drawing.Point(775, 33);
            this.tbPhaiTT.Name = "tbPhaiTT";
            this.tbPhaiTT.ReadOnly = true;
            this.tbPhaiTT.Size = new System.Drawing.Size(100, 22);
            this.tbPhaiTT.TabIndex = 7;
            this.tbPhaiTT.Text = "0";
            // 
            // tbKHDua
            // 
            this.tbKHDua.Location = new System.Drawing.Point(117, 79);
            this.tbKHDua.Name = "tbKHDua";
            this.tbKHDua.Size = new System.Drawing.Size(100, 22);
            this.tbKHDua.TabIndex = 8;
            this.tbKHDua.TextChanged += new System.EventHandler(this.tbKHDua_TextChanged);
            // 
            // tbTraLai
            // 
            this.tbTraLai.Location = new System.Drawing.Point(441, 85);
            this.tbTraLai.Name = "tbTraLai";
            this.tbTraLai.ReadOnly = true;
            this.tbTraLai.Size = new System.Drawing.Size(100, 22);
            this.tbTraLai.TabIndex = 9;
            this.tbTraLai.Text = "0";
            // 
            // fBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 780);
            this.Controls.Add(this.btHuyHD);
            this.Controls.Add(this.btXuatHD);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSdtKH);
            this.Controls.Add(this.tbNgayMua);
            this.Controls.Add(this.tbTenKH);
            this.Controls.Add(this.tbSoHD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fBill_FormClosing);
            this.Load += new System.EventHandler(this.fBill_Load);
            this.panel1.ResumeLayout(false);
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsSPHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSoHD;
        private System.Windows.Forms.TextBox tbTenKH;
        private System.Windows.Forms.TextBox tbNgayMua;
        private System.Windows.Forms.TextBox tbSdtKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Button btXuatHD;
        private System.Windows.Forms.Button btHuyHD;
        private System.Windows.Forms.DataGridView dgvDsSPHD;
        private System.Windows.Forms.DataGridViewComboBoxColumn clNameMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuanty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIntoMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNote;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTraLai;
        private System.Windows.Forms.TextBox tbKHDua;
        private System.Windows.Forms.TextBox tbPhaiTT;
        private System.Windows.Forms.TextBox tbGiamGia;
        private System.Windows.Forms.TextBox tbTongTT;
    }
}