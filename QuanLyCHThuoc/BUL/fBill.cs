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
    public partial class fBill : Form
    {
        #region Biến toàn cục
        string sqlConnection = "Data Source=DESKTOP-9SJILQ8\\SQLEXPRESS;Initial Catalog=QLCHT;Integrated Security=True";
        SqlConnection conn = null;
        bool sttKH = true; // true = khách hàng mới
        string tongDaMua = null;
        #endregion

        public fBill()
        {
            InitializeComponent();
        }

        private void fBill_Load(object sender, EventArgs e)
        {
            // Tự động sinh số hóa đơn và ngày mua
            SetCodeAndDate();

            conn = new SqlConnection(sqlConnection);
            conn.Open();

            // Load danh sách thuốc vào ComboBox cột đầu của DataGridView
            string query = "Select MaSP as [Mã số], TenSP as [Tên] from SanPham";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            clNameMedicine.DataSource = dt;
            clNameMedicine.DisplayMember = "Tên";
            clNameMedicine.ValueMember = "Mã số";
        }

        // Tự động sinh số HĐ và ngày mua
        void SetCodeAndDate()
        {
            DateTime now = DateTime.Now;
            tbSoHD.Text = now.Day.ToString() + now.Month.ToString() + now.Year.ToString()
                        + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString();
            tbNgayMua.Text = now.ToString("dd-MM-yyyy");
        }

        // Khi nhập SDT khách → kiểm tra khách cũ hay mới → tính giảm giá
        private void tbSdtKH_Leave(object sender, EventArgs e)
        {
            if (tbSdtKH.Text == "") return;

            string query = "Select TongDaMua from KhachHang where SDT = '" + tbSdtKH.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Khách cũ → tính giảm giá dựa trên tổng đã mua
                sttKH = false;
                long tmp = Convert.ToInt64(dt.Rows[0][0]);
                tongDaMua = Convert.ToString(tmp);

                if (tmp < 2000000) tbGiamGia.Text = "0";
                else if (tmp >= 2000000 && tmp < 5000000) tbGiamGia.Text = "7000";
                else if (tmp >= 5000000 && tmp < 8000000) tbGiamGia.Text = "12000";
                else tbGiamGia.Text = "20000";
            }
            else
            {
                // Khách mới
                sttKH = true;
                tongDaMua = null;
                tbGiamGia.Text = "0";
            }

            // Cập nhật lại phải thanh toán sau khi có giảm giá
            tbPhaiTT.Text = Convert.ToString(Convert.ToInt64(tbTongTT.Text) - Convert.ToInt64(tbGiamGia.Text));
        }

        // Khi chọn thuốc hoặc nhập số lượng trong DataGridView
        private void dgvDsSPHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Cột 0 — chọn thuốc → tự điền đơn vị và giá
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (dgvDsSPHD.CurrentCell.Value == null ||
                    dgvDsSPHD.CurrentCell.Value.ToString() == "") return;

                string query = "Select DonViTinh, GiaBan from SanPham where MaSP = '"
                             + dgvDsSPHD.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvDsSPHD.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0]; // Đơn vị
                    dgvDsSPHD.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][1]; // Đơn giá
                }
            }

            // Cột 3 — nhập số lượng → tính thành tiền và tổng
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (dgvDsSPHD.CurrentRow.Cells[2].Value == null ||
                    dgvDsSPHD.CurrentRow.Cells[3].Value == null ||
                    dgvDsSPHD.CurrentRow.Cells[3].Value.ToString() == "") return;

                long donGia = Convert.ToInt64(dgvDsSPHD.CurrentRow.Cells[2].Value);
                long soLuong = Convert.ToInt64(dgvDsSPHD.CurrentRow.Cells[3].Value);
                long thanhTien = donGia * soLuong;

                dgvDsSPHD.CurrentRow.Cells[4].Value = thanhTien.ToString();
                tbTongTT.Text = Convert.ToString(Convert.ToInt64(tbTongTT.Text) + thanhTien);
                tbPhaiTT.Text = Convert.ToString(Convert.ToInt64(tbTongTT.Text) - Convert.ToInt64(tbGiamGia.Text));
            }
        }

        // Khi nhập số tiền khách đưa → tính trả lại
        private void tbKHDua_TextChanged(object sender, EventArgs e)
        {
            if (tbKHDua.Text == "") return;
            try
            {
                tbTraLai.Text = Convert.ToString(
                    Convert.ToInt64(tbKHDua.Text) - Convert.ToInt64(tbPhaiTT.Text));
            }
            catch { tbTraLai.Text = "0"; }
        }

        // Xuất hóa đơn — lưu vào database
        private void btXuatHD_Click(object sender, EventArgs e)
        {
            // Kiểm tra có sản phẩm không
            if (dgvDsSPHD.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tên khách
            if (tbTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = null;
            SqlCommand cmd = null;

            // Lưu khách hàng
            if (sttKH)
            {
                // Khách mới → INSERT
                query = String.Format("Insert into KhachHang values ('{0}', N'{1}', '{2}')",
                    tbSdtKH.Text.Trim(), tbTenKH.Text.Trim(), tbTongTT.Text);
            }
            else
            {
                // Khách cũ → UPDATE tổng đã mua
                tongDaMua = Convert.ToString(
                    Convert.ToInt64(tbTongTT.Text) + Convert.ToInt64(tongDaMua));
                query = "Update KhachHang set TongDaMua = '" + tongDaMua
                      + "' where SDT = '" + tbSdtKH.Text.Trim() + "'";
            }
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            // Lưu hóa đơn
            string date = tbNgayMua.Text.Substring(6, 4) + "/" +
                          tbNgayMua.Text.Substring(3, 2) + "/" +
                          tbNgayMua.Text.Substring(0, 2);
            query = String.Format("Insert into HoaDon values ('{0}', '{1}', '{2}')",
                tbSoHD.Text.Trim(), date, tbSdtKH.Text.Trim());
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            // Lưu chi tiết hóa đơn
            query = "Insert into ChiTietHD values";
            for (int i = 0; i < dgvDsSPHD.Rows.Count - 1; i++)
            {
                string ghiChu = dgvDsSPHD.Rows[i].Cells[5].Value != null
                    ? dgvDsSPHD.Rows[i].Cells[5].Value.ToString().Trim() : null;
                query += String.Format(" ('{0}', '{1}', '{2}', '{3}'),",
                    tbSoHD.Text.Trim(),
                    dgvDsSPHD.Rows[i].Cells[0].Value.ToString().Trim(),
                    dgvDsSPHD.Rows[i].Cells[3].Value.ToString(),
                    ghiChu);
            }
            query = query.Remove(query.Length - 1); // Xóa dấu phẩy cuối
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            ResetForm();
        }

        // Hủy hóa đơn
        private void btHuyHD_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn hủy?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            ResetForm();
        }

        // Reset toàn bộ form về trạng thái ban đầu
        void ResetForm()
        {
            SetCodeAndDate();
            tbTenKH.Text = tbSdtKH.Text = tbKHDua.Text = "";
            tbTongTT.Text = tbGiamGia.Text = tbPhaiTT.Text = tbTraLai.Text = "0";
            dgvDsSPHD.Rows.Clear();
            sttKH = true;
            tongDaMua = null;
        }

        private void fBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}