using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLGIAY.BUS;
using QLGIAY.INFO;
namespace QLGIAY.GUI
{
    public partial class frmGiay : Form
    {
        private bool isThem = false;
        private string maGiay = ""; 
        GiayBus bus = new GiayBus();

        public frmGiay()
        {
            InitializeComponent();
        }
        public void BatTat(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            txtMaGiay.Enabled = giaTri;
            txtTenGiay.Enabled = giaTri;
            txtLoaiGiay.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaGiay.Text = "";
            txtTenGiay.Text = "";
            txtLoaiGiay.Text = "";
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maGiay = txtMaGiay.Text;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn xóa Giầy " + txtTenGiay.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GiayInfo info = new GiayInfo();
                info.MaGiay = txtMaGiay.Text;
                bus.Xoa(info);
            }

            // Tải lại lưới
            frmGiay_Load_1(sender, e);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            GiayInfo info = new GiayInfo();
            info.MaGiay = txtMaGiay.Text;
            info.TenGiay = txtTenGiay.Text;
            info.LoaiGiay = txtLoaiGiay.Text;
            if (isThem)
                bus.Them(info);
            else
                bus.Sua(info, maGiay);
            frmGiay_Load_1(sender, e);
        }

        private void btnDongForm_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiay_Load_1(object sender, EventArgs e)
        {
            BatTat(false);
            bus.HienThiVaoDGV(bN, dGV, txtMaGiay, txtTenGiay, txtLoaiGiay);
        }
    }
}