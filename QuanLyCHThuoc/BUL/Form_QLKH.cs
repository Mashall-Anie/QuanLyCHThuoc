
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCHThuoc.BUL
{
    public partial class Form_QLKH : Form
    {
        private DataTable htKH;
        string sqlConect = @"Data Source=DESKTOP-9SJILQ8\SQLEXPRESS;Initial Catalog=QLCHT;Integrated Security=True";
        SqlConnection conn = null;

        public Form_QLKH()
        {
            InitializeComponent();
        }

        private void Form_QLKH_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(sqlConect);
            conn.Open();
            LoadData1();
        }

        void LoadData1()
        {
            string query = "Select * from KhachHang";
            SqlDataAdapter daKH = new SqlDataAdapter(query, conn);
            htKH = new DataTable();
            daKH.Fill(htKH);
            dgvKhachHang.DataSource = htKH;
        }

        void LoadData2(string sdt)
        {
            string query = "SELECT h.NgayMua, sp.TenSP, ct.SoLuong, k.TongDaMua " +
                           "FROM HoaDon h " +
                           "INNER JOIN ChiTietHD ct ON h.SoHD = ct.SoHD " +
                           "INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP " +
                           "INNER JOIN KhachHang k ON h.SDT = k.SDT " +
                           "WHERE k.SDT = '" + sdt + "'";
            SqlDataAdapter daLS = new SqlDataAdapter(query, conn);
            DataTable htLS = new DataTable();
            daLS.Fill(htLS);
            dgvLichSu.DataSource = htLS;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                tbTenKH.Text = row.Cells["HoTenK"].Value.ToString();
                tbSdtKH.Text = row.Cells["SDT"].Value.ToString();
                LoadData2(tbSdtKH.Text);
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = tbTimKiemKH.Text.Trim();
            string query = "SELECT * FROM KhachHang WHERE SDT LIKE @SearchText OR HoTenK LIKE @SearchText";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tồn tại khách hàng với thông tin tìm kiếm.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTimKiemKH.Text = "";
                LoadData1();
            }
        }

        private void cbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sapxep = cbSapXep.SelectedItem.ToString();
            if (sapxep == "Z-A")
                dgvKhachHang.Sort(dgvKhachHang.Columns["HoTenK"], ListSortDirection.Descending);
            else
                dgvKhachHang.Sort(dgvKhachHang.Columns["HoTenK"], ListSortDirection.Ascending);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string tenMoi = tbTenKH.Text.Trim();
            string sdtMoi = tbSdtKH.Text.Trim();

            if (tenMoi == "" || sdtMoi == "")
            {
                MessageBox.Show("Chưa chọn đối tượng hoặc để trống thông tin!",
                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sdtCanSua = dgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
            string query = "UPDATE KhachHang SET HoTenK = @HoTen, SDT = @SDT WHERE SDT = @SDTCanSua";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@HoTen", tenMoi);
            cmd.Parameters.AddWithValue("@SDT", sdtMoi);
            cmd.Parameters.AddWithValue("@SDTCanSua", sdtCanSua);
            cmd.ExecuteNonQuery();
            LoadData1();
            MessageBox.Show("Thông tin khách hàng đã được cập nhật thành công.");
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            string sdtCanXoa = dgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
            string query = "DELETE FROM KhachHang WHERE SDT = @SDTCanXoa";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SDTCanXoa", sdtCanXoa);
            cmd.ExecuteNonQuery();
            LoadData1();
            MessageBox.Show("Khách hàng đã được xóa thành công.");
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
