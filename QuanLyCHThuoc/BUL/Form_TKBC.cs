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
    public partial class Form_TKBC : Form
    {
        string sqlConnection = "Data Source=DESKTOP-9SJILQ8\\SQLEXPRESS;Initial Catalog=QLCHT;Integrated Security=True";
        SqlConnection conn = null;

        public Form_TKBC()
        {
            InitializeComponent();
        }

        private void Form_TKBC_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(sqlConnection);
            conn.Open();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (cbNoiDung.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nội dung thống kê!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadBaoCao();
        }

        void LoadBaoCao()
        {
            string query = null;
            DateTime ngayBD = dtpNgayBD.Value.Date;
            DateTime ngayKT = dtpNgayKT.Value.Date;

            if (cbNoiDung.Text == "Thống Kê Hàng Tồn")
            {
                query = "Select MaSP as [Mã SP], TenSP as [Tên sản phẩm], " +
                        "SoLuong as [Số lượng tồn], GiaBan as [Giá bán], " +
                        "GiaNhap as [Giá nhập], DonViTinh as [Đơn vị] " +
                        "From SanPham Order by SoLuong asc";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTKBC.DataSource = dt;
            }
            else // Thống Kê Doanh Thu
            {
                if (ngayBD > ngayKT)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = "Select HD.SoHD as [Số HĐ], HD.NgayMua as [Ngày mua], " +
                        "KH.SDT as [SĐT khách hàng], " +
                        "SUM(SP.GiaNhap * CT.SoLuong) as [Tổng tiền nhập], " +
                        "SUM(SP.GiaBan * CT.SoLuong) as [Tổng tiền bán], " +
                        "SUM(SP.GiaBan * CT.SoLuong) - SUM(SP.GiaNhap * CT.SoLuong) as [Lợi nhuận] " +
                        "From HoaDon HD " +
                        "Inner Join ChiTietHD CT on HD.SoHD = CT.SoHD " +
                        "Inner Join SanPham SP on CT.MaSP = SP.MaSP " +
                        "Inner Join KhachHang KH on HD.SDT = KH.SDT " +
                        "Where HD.NgayMua Between @NgayBD and @NgayKT " +
                        "Group by HD.SoHD, HD.NgayMua, KH.SDT";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@NgayBD", ngayBD);
                da.SelectCommand.Parameters.AddWithValue("@NgayKT", ngayKT);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTKBC.DataSource = dt;
            }
        }

        private void Form_TKBC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
