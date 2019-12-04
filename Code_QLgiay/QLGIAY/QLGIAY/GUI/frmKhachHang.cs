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
    public partial class frmKhachHang : Form
    {
        private bool isThem = false;
        private string maKH = "";
        KhachHangBus bus = new KhachHangBus();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void BatTat(bool giaTri)
        {
            btnluu.Enabled = giaTri;
            txtMaKhachHang.Enabled = giaTri;
            txtTenKhachHang.Enabled = giaTri;
            btnthem.Enabled = !giaTri;
            btnsua.Enabled = !giaTri;
            btnxoa.Enabled = !giaTri;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maKH = txtMaKhachHang.Text;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Khách Hàng " + txtTenKhachHang.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                KhachHangInfo info = new KhachHangInfo();
                info.MaKH = txtMaKhachHang.Text;
                bus.Xoa(info);
            }

            // Tải lại lưới
            frmKhachHang_Load(sender, e);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTat(false);
            bus.HienThiVaoDGV(bN, dGV, txtMaKhachHang, txtTenKhachHang);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            KhachHangInfo info = new KhachHangInfo();
            info.MaKH = txtMaKhachHang.Text;
            info.TenKH = txtTenKhachHang.Text;
            if (isThem)
                bus.Them(info);
            else
                bus.Sua(info, maKH);
            frmKhachHang_Load(sender, e);
        }

    }
}
