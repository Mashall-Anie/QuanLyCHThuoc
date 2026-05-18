namespace QuanLyCHThuoc.BUL
{
    partial class Form_Home
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Txt_NameCH = new System.Windows.Forms.Label();
            this.button_KhachHang = new System.Windows.Forms.Button();
            this.button_BaoCao = new System.Windows.Forms.Button();
            this.button_KhoThuoc = new System.Windows.Forms.Button();
            this.button_BanHang = new System.Windows.Forms.Button();
            this.Ico_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ico_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(510, 558);
            this.splitContainer1.SplitterDistance = 91;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Ico_Logo);
            this.splitContainer2.Panel1.Controls.Add(this.Txt_NameCH);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_KhachHang);
            this.splitContainer2.Panel2.Controls.Add(this.button_BaoCao);
            this.splitContainer2.Panel2.Controls.Add(this.button_KhoThuoc);
            this.splitContainer2.Panel2.Controls.Add(this.button_BanHang);
            this.splitContainer2.Size = new System.Drawing.Size(510, 558);
            this.splitContainer2.SplitterDistance = 91;
            this.splitContainer2.TabIndex = 1;
            // 
            // Txt_NameCH
            // 
            this.Txt_NameCH.AutoSize = true;
            this.Txt_NameCH.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_NameCH.Location = new System.Drawing.Point(77, 24);
            this.Txt_NameCH.Name = "Txt_NameCH";
            this.Txt_NameCH.Size = new System.Drawing.Size(248, 27);
            this.Txt_NameCH.TabIndex = 1;
            this.Txt_NameCH.Text = "Cửa hàng thuốc ThanhAn";
            // 
            // button_KhachHang
            // 
            this.button_KhachHang.BackColor = System.Drawing.Color.PeachPuff;
            this.button_KhachHang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_KhachHang.Location = new System.Drawing.Point(32, 270);
            this.button_KhachHang.Name = "button_KhachHang";
            this.button_KhachHang.Size = new System.Drawing.Size(152, 153);
            this.button_KhachHang.TabIndex = 3;
            this.button_KhachHang.Text = "Khách hàng";
            this.button_KhachHang.UseVisualStyleBackColor = false;
            this.button_KhachHang.Click += new System.EventHandler(this.button_KhachHang_Click);
            // 
            // button_BaoCao
            // 
            this.button_BaoCao.BackColor = System.Drawing.Color.PeachPuff;
            this.button_BaoCao.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BaoCao.Location = new System.Drawing.Point(286, 270);
            this.button_BaoCao.Name = "button_BaoCao";
            this.button_BaoCao.Size = new System.Drawing.Size(152, 153);
            this.button_BaoCao.TabIndex = 2;
            this.button_BaoCao.Text = "Báo cáo";
            this.button_BaoCao.UseVisualStyleBackColor = false;
            this.button_BaoCao.Click += new System.EventHandler(this.button_BaoCao_Click);
            // 
            // button_KhoThuoc
            // 
            this.button_KhoThuoc.BackColor = System.Drawing.Color.PeachPuff;
            this.button_KhoThuoc.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_KhoThuoc.Location = new System.Drawing.Point(286, 36);
            this.button_KhoThuoc.Name = "button_KhoThuoc";
            this.button_KhoThuoc.Size = new System.Drawing.Size(152, 153);
            this.button_KhoThuoc.TabIndex = 1;
            this.button_KhoThuoc.Text = "Kho thuốc";
            this.button_KhoThuoc.UseVisualStyleBackColor = false;
            this.button_KhoThuoc.Click += new System.EventHandler(this.button_KhoThuoc_Click);
            // 
            // button_BanHang
            // 
            this.button_BanHang.BackColor = System.Drawing.Color.PeachPuff;
            this.button_BanHang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BanHang.Location = new System.Drawing.Point(32, 36);
            this.button_BanHang.Name = "button_BanHang";
            this.button_BanHang.Size = new System.Drawing.Size(152, 153);
            this.button_BanHang.TabIndex = 0;
            this.button_BanHang.Text = "Bán hàng";
            this.button_BanHang.UseVisualStyleBackColor = false;
            this.button_BanHang.Click += new System.EventHandler(this.button_BanHang_Click);
            // 
            // Ico_Logo
            // 
            this.Ico_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ico_Logo.Image = global::QuanLyCHThuoc.Properties.Resources.Ico_Logo;
            this.Ico_Logo.Location = new System.Drawing.Point(12, 12);
            this.Ico_Logo.Name = "Ico_Logo";
            this.Ico_Logo.Size = new System.Drawing.Size(59, 50);
            this.Ico_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ico_Logo.TabIndex = 2;
            this.Ico_Logo.TabStop = false;
            // 
            // Form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 558);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ico_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label Txt_NameCH;
        private System.Windows.Forms.Button button_KhachHang;
        private System.Windows.Forms.Button button_BaoCao;
        private System.Windows.Forms.Button button_KhoThuoc;
        private System.Windows.Forms.Button button_BanHang;
        private System.Windows.Forms.PictureBox Ico_Logo;
    }
}