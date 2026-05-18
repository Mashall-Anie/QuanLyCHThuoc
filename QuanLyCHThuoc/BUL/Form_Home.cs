using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCHThuoc.BUL
{
    public partial class Form_Home : Form
    {
        public Form_Home()
        {
            InitializeComponent();
        }

        private void button_BanHang_Click(object sender, EventArgs e)
        {
            fBill fBill = new fBill();
            fBill.Closed += (s, args) => this.Show();
            fBill.Show();
            this.Hide();

        }

        private void button_KhoThuoc_Click(object sender, EventArgs e)
        {
            fMedicineWarehouse fMedicineWarehouse = new fMedicineWarehouse();
            fMedicineWarehouse.Closed += (s, args) => this.Show();
            fMedicineWarehouse.Show();
            this.Hide();
        }

        private void button_KhachHang_Click(object sender, EventArgs e)
        {
            Form_QLKH form_QLKH = new Form_QLKH();
            form_QLKH.Closed += (s, args) => this.Show();
            form_QLKH.Show();
            this.Hide();
        }

        private void button_BaoCao_Click(object sender, EventArgs e)
        {
            Form_TKBC form_TKBC = new Form_TKBC();
            form_TKBC.Closed += (s, args) => this.Show();
            form_TKBC.Show();
            this.Hide();
        }
    }
}
