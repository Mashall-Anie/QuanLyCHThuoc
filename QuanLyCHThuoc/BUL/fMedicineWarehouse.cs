using QuanLyCHThuoc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCHThuoc.BUL
{
    public partial class fMedicineWarehouse : Form
    {
        #region Global variable

        string query = null;
        Button prevButton = null;
        SqlDataAdapter daSanPham = null, daDanhMuc = null, daPhanLoai = null, daNSX = null;
        public DataTable dtSanPham = null;
        DataTable dtDanhMuc = null, dtPhanLoai = null, dtNSX = null,
                  dtDanhMucPL = null, dtDanhMucChiTiet = null, dtPhanLoaiChiTiet = null;

        string sqlConnection = "Data Source=DESKTOP-9SJILQ8\\SQLEXPRESS;Initial Catalog=QLCHT;Integrated Security=True";
        SqlConnection conn = null;

        #endregion

        public fMedicineWarehouse()
        {
            InitializeComponent();
        }

        private void fMedicineWarehouse_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(sqlConnection);
            conn.Open();

            // San pham
            query = "Select MaSP as [Mã số], TenSP as [Tên], TenDM as [Danh mục], TenPL as [Phân loại], TenNSX as [Sản phẩm của], DonViTinh as [Đơn vị], SP.NSX as [Ngày sản xuất], SP.HSD as [Hạn sử dụng], GiaNhap as [Giá nhập], GiaBan as [Giá bán], SoLuong as [Số lượng], GhiChu as [Ghi chú] " +
                " From SanPham SP, DanhMuc DM, PhanLoai PL, NSX " +
                " Where SP.MaPL = PL.MaPL and PL.MaDM = DM.MaDM and SP.MaNSX = NSX.MaNSX";
            daSanPham = new SqlDataAdapter(query, conn);
            dtSanPham = new DataTable();
            daSanPham.Fill(dtSanPham);
            dgvDsSPKho.DataSource = dtSanPham;
            dgvDsSPKho.Columns["Ngày sản xuất"].DefaultCellStyle.Format =
            dgvDsSPKho.Columns["Hạn sử dụng"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Danh muc
            query = "Select MaDM as [Mã số], TenDM as [Tên] from DanhMuc";
            daDanhMuc = new SqlDataAdapter(query, conn);
            dtDanhMuc = new DataTable();
            dtDanhMucChiTiet = new DataTable();
            dtDanhMucPL = new DataTable();
            daDanhMuc.Fill(dtDanhMuc);
            daDanhMuc.Fill(dtDanhMucPL);
            daDanhMuc.Fill(dtDanhMucChiTiet);
            dgvDanhMuc.DataSource = cbDanhMuc.DataSource = dtDanhMuc;
            cbDanhMucPL.DataSource = dtDanhMucPL;
            cbDanhMucChiTiet.DataSource = dtDanhMucChiTiet;
            cbDanhMucPL.DisplayMember = cbDanhMuc.DisplayMember = cbDanhMucChiTiet.DisplayMember = "Tên";
            cbDanhMucPL.ValueMember = cbDanhMuc.ValueMember = cbDanhMucChiTiet.ValueMember = "Mã số";
            cbDanhMucPL.SelectedValue = cbDanhMucChiTiet.SelectedValue = "";

            // Phan loai
            query = "Select MaPL as [Mã số], TenPL as [Tên], TenDM as [Danh mục] from PhanLoai, DanhMuc where PhanLoai.MaDM = DanhMuc.MaDM";
            daPhanLoai = new SqlDataAdapter(query, conn);
            dtPhanLoai = new DataTable();
            dtPhanLoaiChiTiet = new DataTable();
            daPhanLoai.Fill(dtPhanLoai);
            daPhanLoai.Fill(dtPhanLoaiChiTiet);
            dgvPhanLoai.DataSource = cbPhanLoai.DataSource = dtPhanLoai;
            cbPhanLoaiChiTiet.DataSource = dtPhanLoaiChiTiet;
            cbPhanLoai.DisplayMember = cbPhanLoaiChiTiet.DisplayMember = "Tên";
            cbPhanLoai.ValueMember = cbPhanLoaiChiTiet.ValueMember = "Mã số";
            cbPhanLoaiChiTiet.SelectedValue = "";

            // NSX
            query = "Select MaNSX as [Mã số], TenNSX as [Tên], SDT as [Số điện thoại] from NSX";
            daNSX = new SqlDataAdapter(query, conn);
            dtNSX = new DataTable();
            daNSX.Fill(dtNSX);
            dgvDoiTac.DataSource = dtNSX;
            cbNhaSX.DataSource = dtNSX;
            cbNhaSX.DisplayMember = "Tên";
            cbNhaSX.ValueMember = "Mã số";
            cbNhaSX.SelectedValue = "";
        }

        private void fMedicineWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        // ===== TÌM KIẾM =====

        private void tbTimKiem_Click(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Tìm kiếm...")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void tbTimKiem_Leave(object sender, EventArgs e)
        {
            panelTimKiem.Visible = lvTimKiem.Visible = false;
            if (tbTimKiem.Text == "")
            {
                tbTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
                tbTimKiem.Text = "Tìm kiếm...";
            }
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (tbTimKiem.Text.Trim().Length != 0 && tbTimKiem.Text != "Tìm kiếm...")
            {
                panelTimKiem.Visible = lvTimKiem.Visible = true;
                string querySearch = "Select TenSP from SanPham where TenSP like N'" + tbTimKiem.Text.Trim() + "%'";
                DataTable dtSearch = DataProvider.Instance.ExecuteQuery(querySearch);
                lvTimKiem.Items.Clear();
                foreach (DataRow row in dtSearch.Rows)
                    lvTimKiem.Items.Add(new ListViewItem(row[0].ToString()));
                lvTimKiem.Refresh();
            }
            else
            {
                panelTimKiem.Visible = lvTimKiem.Visible = false;
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            cbDanhMuc.SelectedValue = cbPhanLoai.SelectedValue = "";
            query = "Select MaSP as [Mã số], TenSP as [Tên], TenDM as [Danh mục], TenPL as [Phân loại], TenNSX as [Sản phẩm của], DonViTinh as [Đơn vị], SP.NSX as [Ngày sản xuất], SP.HSD as [Hạn sử dụng], GiaNhap as [Giá nhập], GiaBan as [Giá bán], SoLuong as [Số lượng], GhiChu as [Ghi chú] " +
                " From SanPham SP, DanhMuc DM, PhanLoai PL, NSX " +
                " Where TenSP like N'" + tbTimKiem.Text.Trim() + "%' and SP.MaPL = PL.MaPL and PL.MaDM = DM.MaDM and SP.MaNSX = NSX.MaNSX";
            daSanPham = new SqlDataAdapter(query, conn);
            dtSanPham.Rows.Clear();
            daSanPham.Fill(dtSanPham);
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            prevButton = null;
            Button bt = (Button)sender;
            TabPage tp = GetTabPage(bt, isAdd: true);
            this.controlsStatus(tp, bt, 1);
            this.setNull(tp);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            prevButton = (Button)sender;
            Button bt = (Button)sender;
            TabPage tp = GetTabPage(bt, isAdd: false);
            this.controlsStatus(tp, bt, 1);
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn hủy?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            Button bt = (Button)sender;
            TabPage tp = GetTabPage(bt, isAdd: false);
            this.controlsStatus(tp: tp, openOrClose: 0);
            this.setNull(tp, prevButton);
        }

        private TabPage GetTabPage(Button bt, bool isAdd)
        {
            if (bt == btThemSP || bt == btSuaSP || bt == btHuySP) return tpSanPham;
            if (bt == btThemDanhMuc || bt == btSuaDanhMuc || bt == btHuyDanhMuc) return tpDanhMuc;
            if (bt == btThemPhanLoai || bt == btSuaPhanLoai || bt == btHuyPhanLoai) return tpPhanLoai;
            return tpDoiTac;
        }


        private void dgvDsSPKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                btSuaSP.Enabled = btXoaSp.Enabled = false;
                this.setNull(tpSanPham);
                return;
            }
            btSuaSP.Enabled = btXoaSp.Enabled = true;
            DataGridViewRow row = dgvDsSPKho.CurrentRow;
            tbMaSP.Text = row.Cells[0].Value.ToString().Trim();
            tbTenSP.Text = row.Cells[1].Value.ToString().Trim();
            cbDanhMucChiTiet.Text = row.Cells[2].Value.ToString();
            cbPhanLoaiChiTiet.Text = row.Cells[3].Value.ToString();
            cbNhaSX.Text = row.Cells[4].Value.ToString();
            tbDonViTinh.Text = row.Cells[5].Value.ToString().Trim();
            dtpNSX.Value = DateTime.Parse(row.Cells[6].Value.ToString());
            dtpHSD.Value = DateTime.Parse(row.Cells[7].Value.ToString());
            tbGiaNhap.Text = row.Cells[8].Value.ToString();
            tbGiaBan.Text = row.Cells[9].Value.ToString();
            tbSoLuongCon.Text = row.Cells[10].Value.ToString();
            tbGhiChu.Text = row.Cells[11].Value.ToString().Trim();
        }

        private void btXoaSp_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            query = "Delete from SanPham where MaSP = '" + tbMaSP.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtSanPham.Rows.Clear();
                daSanPham.Fill(dtSanPham);
                this.setNull(tpSanPham); // [ĐÃ SỬA] code 2 gốc bị nhầm thành tpDanhMuc
                btXoaSp.Enabled = btSuaSP.Enabled = false;
                btThemSP.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa. Vui lòng thử lại sau!", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuuSP_Click(object sender, EventArgs e)
        {
            string ma = tbMaSP.Text.Trim();
            string ten = tbTenSP.Text.Trim();
            string pl = cbPhanLoaiChiTiet.SelectedValue?.ToString();
            string nsx = cbNhaSX.SelectedValue?.ToString();
            string dv = tbDonViTinh.Text.Trim();
            string nhap = tbGiaNhap.Text.Trim();
            string ban = tbGiaBan.Text.Trim();
            string sl = tbSoLuongCon.Text.Trim();
            string NSX = dtpNSX.Value.ToString();
            string HSD = dtpHSD.Value.ToString();
            string note = tbGhiChu.Text.Trim().Length != 0 ? tbGhiChu.Text.Trim() : null;

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) ||
                string.IsNullOrEmpty(pl) || string.IsNullOrEmpty(nsx) ||
                string.IsNullOrEmpty(dv) || string.IsNullOrEmpty(nhap) ||
                string.IsNullOrEmpty(ban) || string.IsNullOrEmpty(sl))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prevButton == null)
                query = String.Format("Insert into SanPham values ('{0}', N'{1}', '{2}', '{3}', N'{4}', '{5}', '{6}', '{7}', '{8}', '{9}', N'{10}')",
                    ma, ten, pl, nsx, dv, NSX, HSD, nhap, ban, sl, note);
            else
                query = String.Format("Update SanPham set TenSP = N'{0}', MaPL = '{1}', MaNSX = '{2}', DonViTinh = N'{3}', NSX = '{4}', HSD = '{5}', GiaNhap = '{6}', GiaBan = '{7}', SoLuong = '{8}', GhiChu = N'{9}' where MaSP = '{10}'",
                    ten, pl, nsx, dv, NSX, HSD, nhap, ban, sl, note, ma);

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtSanPham.Rows.Clear();
                daSanPham.Fill(dtSanPham);
                this.controlsStatus(tp: tpSanPham, openOrClose: 0);
                this.setNull(tpSanPham);
            }
            catch (SqlException)
            {
                string message = prevButton == null ? "Không thể thêm dữ liệu." : "Không thể chỉnh sửa dữ liệu.";
                MessageBox.Show(message + " Vui lòng thử lại sau!", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TAB DANH MỤC =====

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                btSuaDanhMuc.Enabled = btXoaDanhMuc.Enabled = false;
                this.setNull(tpDanhMuc);
                return;
            }
            btSuaDanhMuc.Enabled = btXoaDanhMuc.Enabled = true;
            DataGridViewRow row = dgvDanhMuc.CurrentRow;
            tbMaDanhMuc.Text = row.Cells[0].Value.ToString().Trim();
            tbTenDanhMuc.Text = row.Cells[1].Value.ToString().Trim();
        }

        private void btXoaDanhMuc_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            query = "Delete from DanhMuc where MaDM = '" + tbMaDanhMuc.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtDanhMuc.Rows.Clear(); dtDanhMucChiTiet.Rows.Clear(); dtDanhMucPL.Rows.Clear();
                daDanhMuc.Fill(dtDanhMuc); daDanhMuc.Fill(dtDanhMucChiTiet); daDanhMuc.Fill(dtDanhMucPL);
                this.setNull(tpDanhMuc);
                btXoaDanhMuc.Enabled = btSuaDanhMuc.Enabled = false;
                btThemDanhMuc.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa. Danh mục đang được sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuuDanhMuc_Click(object sender, EventArgs e)
        {
            string ma = tbMaDanhMuc.Text.Trim();
            string ten = tbTenDanhMuc.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prevButton == null)
                query = String.Format("Insert into DanhMuc values ('{0}', N'{1}')", ma, ten);
            else
                query = String.Format("Update DanhMuc set TenDM = N'{0}' where MaDM = '{1}'", ten, ma);

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtDanhMuc.Rows.Clear(); dtDanhMucPL.Rows.Clear(); dtDanhMucChiTiet.Rows.Clear();
                daDanhMuc.Fill(dtDanhMuc); daDanhMuc.Fill(dtDanhMucChiTiet); daDanhMuc.Fill(dtDanhMucPL);
                this.controlsStatus(tp: tpDanhMuc, openOrClose: 0);
                this.setNull(tpDanhMuc);
            }
            catch (SqlException)
            {
                string message = prevButton == null ? "Không thể thêm dữ liệu." : "Không thể chỉnh sửa dữ liệu.";
                MessageBox.Show(message + " Vui lòng thử lại sau!", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TAB PHÂN LOẠI =====

        private void dgvPhanLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                btSuaPhanLoai.Enabled = btXoaPhanLoai.Enabled = false;
                this.setNull(tpPhanLoai);
                return;
            }
            btSuaPhanLoai.Enabled = btXoaPhanLoai.Enabled = true;
            DataGridViewRow row = dgvPhanLoai.CurrentRow;
            tbMaPhanLoai.Text = row.Cells[0].Value.ToString().Trim();
            tbTenPhanLoai.Text = row.Cells[1].Value.ToString().Trim();
            cbDanhMucPL.Text = row.Cells[2].Value.ToString();
        }

        private void btXoaPhanLoai_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            query = "Delete from PhanLoai where MaPL = '" + tbMaPhanLoai.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtPhanLoai.Rows.Clear(); dtPhanLoaiChiTiet.Rows.Clear();
                daPhanLoai.Fill(dtPhanLoai); daPhanLoai.Fill(dtPhanLoaiChiTiet);
                this.setNull(tpPhanLoai);
                btXoaPhanLoai.Enabled = btSuaPhanLoai.Enabled = false;
                btThemPhanLoai.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa. Phân loại đang được sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuuPhanLoai_Click(object sender, EventArgs e)
        {
            string ma = tbMaPhanLoai.Text.Trim();
            string ten = tbTenPhanLoai.Text.Trim();
            string dm = cbDanhMucPL.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prevButton == null)
                query = String.Format("Insert into PhanLoai values ('{0}', N'{1}', '{2}')", ma, ten, dm);
            else
                query = String.Format("Update PhanLoai set TenPL = N'{0}', MaDM = '{1}' where MaPL = '{2}'", ten, dm, ma);

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtPhanLoai.Rows.Clear(); dtPhanLoaiChiTiet.Rows.Clear();
                daPhanLoai.Fill(dtPhanLoai); daPhanLoai.Fill(dtPhanLoaiChiTiet);
                this.controlsStatus(tp: tpPhanLoai, openOrClose: 0);
                this.setNull(tpPhanLoai);
            }
            catch (SqlException)
            {
                string message = prevButton == null ? "Không thể thêm dữ liệu." : "Không thể chỉnh sửa dữ liệu.";
                MessageBox.Show(message + " Vui lòng thử lại sau!", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TAB ĐỐI TÁC =====

        private void dgvDoiTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                btSuaDoiTac.Enabled = btXoaDoiTac.Enabled = false;
                this.setNull(tpDoiTac);
                return;
            }
            btSuaDoiTac.Enabled = btXoaDoiTac.Enabled = true;
            DataGridViewRow row = dgvDoiTac.CurrentRow;
            tbMaDoiTac.Text = row.Cells[0].Value.ToString().Trim();
            tbTenDoiTac.Text = row.Cells[1].Value.ToString().Trim();
            tbSdtDoiTac.Text = row.Cells[2].Value.ToString().Trim();
        }

        private void btXoaDoiTac_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            query = "Delete from NSX where MaNSX = '" + tbMaDoiTac.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtNSX.Rows.Clear();
                daNSX.Fill(dtNSX);
                this.setNull(tpDoiTac);
                btXoaDoiTac.Enabled = btSuaDoiTac.Enabled = false;
                btThemDoiTac.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa. Đơn vị đang được sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuuDoiTac_Click(object sender, EventArgs e)
        {
            string ma = tbMaDoiTac.Text.Trim();
            string ten = tbTenDoiTac.Text.Trim();
            string sdt = tbSdtDoiTac.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prevButton == null)
                query = String.Format("Insert into NSX values ('{0}', N'{1}', '{2}')", ma, ten, sdt);
            else
                query = String.Format("Update NSX set TenNSX = N'{0}', SDT = '{1}' where MaNSX = '{2}'", ten, sdt, ma);

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                dtNSX.Rows.Clear();
                daNSX.Fill(dtNSX);
                this.controlsStatus(tp: tpDoiTac, openOrClose: 0);
                this.setNull(tpDoiTac);
            }
            catch (SqlException)
            {
                string message = prevButton == null ? "Không thể thêm dữ liệu." : "Không thể chỉnh sửa dữ liệu.";
                MessageBox.Show(message + " Vui lòng thử lại sau!", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CÁC HÀM BỔ TRỢ =====

        #region Các hàm bổ trợ

        private void setNull(TabPage tp, Button bt = null)
        {
            if (tp == null) return;
            if (tp == tpSanPham)
            {
                tbMaSP.Text = tbTenSP.Text = tbDonViTinh.Text =
                tbGiaNhap.Text = tbGiaBan.Text = tbSoLuongCon.Text = tbGhiChu.Text = null;
                cbDanhMucChiTiet.SelectedValue = cbPhanLoaiChiTiet.SelectedValue = cbNhaSX.SelectedValue = "";
                dtpNSX.Value = dtpHSD.Value = DateTime.Now;
                if (bt != null)
                {
                    int rowIndex = dgvDsSPKho.CurrentRow.Index;
                    int colIndex = dgvDsSPKho.CurrentCell.ColumnIndex;
                    dgvDsSPKho_CellClick(dgvDsSPKho, new DataGridViewCellEventArgs(colIndex, rowIndex));
                }
                else
                {
                    btSuaSP.Enabled = btXoaSp.Enabled = false;
                }
            }
            else if (tp == tpDanhMuc)
            {
                tbMaDanhMuc.Text = tbTenDanhMuc.Text = null;
                if (bt != null)
                {
                    int rowIndex = dgvDanhMuc.CurrentRow.Index;
                    int colIndex = dgvDanhMuc.CurrentCell.ColumnIndex;
                    dgvDanhMuc_CellClick(dgvDanhMuc, new DataGridViewCellEventArgs(colIndex, rowIndex));
                }
                else
                {
                    btSuaDanhMuc.Enabled = btXoaDanhMuc.Enabled = false;
                }
            }
            else if (tp == tpPhanLoai)
            {
                tbMaPhanLoai.Text = tbTenPhanLoai.Text = null;
                cbDanhMucPL.SelectedValue = "";
                if (bt != null)
                {
                    int rowIndex = dgvPhanLoai.CurrentRow.Index;
                    int colIndex = dgvPhanLoai.CurrentCell.ColumnIndex;
                    dgvPhanLoai_CellClick(dgvPhanLoai, new DataGridViewCellEventArgs(colIndex, rowIndex));
                }
                else
                {
                    btSuaPhanLoai.Enabled = btXoaPhanLoai.Enabled = false;
                }
            }
            else if (tp == tpDoiTac)
            {
                tbMaDoiTac.Text = tbTenDoiTac.Text = tbSdtDoiTac.Text = null;
                if (bt != null)
                {
                    int rowIndex = dgvDoiTac.CurrentRow.Index;
                    int colIndex = dgvDoiTac.CurrentCell.ColumnIndex;
                    dgvDoiTac_CellClick(dgvDoiTac, new DataGridViewCellEventArgs(colIndex, rowIndex));
                }
                else
                {
                    btSuaDoiTac.Enabled = btXoaDoiTac.Enabled = false;
                }
            }
        }

        private void controlsStatus(TabPage tp, Button bt = null, int openOrClose = 1)
        {
            bool isOpen = openOrClose == 1;
            if (tp == tpSanPham)
            {
                if (bt == btThemSP || bt == null)
                    textBoxControl(tbMaSP, openOrClose);
                TextBox[] tbs = { tbTenSP, tbDonViTinh, tbGiaNhap, tbGiaBan, tbSoLuongCon, tbGhiChu };
                foreach (TextBox tb in tbs) textBoxControl(tb, openOrClose);
                cbDanhMucChiTiet.Enabled = cbPhanLoaiChiTiet.Enabled =
                cbNhaSX.Enabled = dtpNSX.Enabled = dtpHSD.Enabled = isOpen;
                btThemSP.Visible = btSuaSP.Visible = btXoaSp.Visible = !isOpen;
                btHuySP.Visible = btLuuSP.Visible = isOpen;
            }
            else if (tp == tpDanhMuc)
            {
                if (bt == btThemDanhMuc || bt == null)
                    textBoxControl(tbMaDanhMuc, openOrClose);
                textBoxControl(tbTenDanhMuc, openOrClose);
                btThemDanhMuc.Visible = btSuaDanhMuc.Visible = btXoaDanhMuc.Visible = !isOpen;
                btHuyDanhMuc.Visible = btLuuDanhMuc.Visible = isOpen;
            }
            else if (tp == tpPhanLoai)
            {
                if (bt == btThemPhanLoai || bt == null)
                    textBoxControl(tbMaPhanLoai, openOrClose);
                textBoxControl(tbTenPhanLoai, openOrClose);
                cbDanhMucPL.Enabled = isOpen;
                btThemPhanLoai.Visible = btSuaPhanLoai.Visible = btXoaPhanLoai.Visible = !isOpen;
                btHuyPhanLoai.Visible = btLuuPhanLoai.Visible = isOpen;
            }
            else if (tp == tpDoiTac)
            {
                if (bt == btThemDoiTac || bt == null)
                    textBoxControl(tbMaDoiTac, openOrClose);
                TextBox[] tbs = { tbTenDoiTac, tbSdtDoiTac };
                foreach (TextBox tb in tbs) textBoxControl(tb, openOrClose);
                btThemDoiTac.Visible = btSuaDoiTac.Visible = btXoaDoiTac.Visible = !isOpen;
                btHuyDoiTac.Visible = btLuuDoiTac.Visible = isOpen;
            }
        }

        private void textBoxControl(TextBox tb, int openOrClose)
        {
            if (tb == null) return;
            bool isOpen = openOrClose == 1;
            tb.ReadOnly = !isOpen;
            tb.Cursor = isOpen ? Cursors.IBeam : Cursors.No;
            tb.BackColor = isOpen ? Color.White : SystemColors.Control;
        }

        #endregion
    }
}