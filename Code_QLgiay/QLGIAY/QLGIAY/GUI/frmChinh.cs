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
namespace QLGIAY.GUI
{
    public partial class frmChinh : Form
    {
        
        frmGiay fG = null;
        frmNhanVien FNV = null;
        frmKhachHang fKH = null;
        frmTaiKhoan fTK = null;
        frmHoaDon fHD = null;
        frmDangNhap DN = null;
        frmThôngTin TT = null;
        public static string HoVaTen = "";
        public static int quyenHan = -1;
        public frmChinh()
        {
            InitializeComponent();
        }

        private void btnGiay_Click(object sender, EventArgs e)
        {

            if (fG == null || fG.IsDisposed)
            {
                fG = new frmGiay();
                fG.MdiParent = this;
                fG.Show();
            }
            else
                fG.Activate();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            if (FNV == null || FNV.IsDisposed)
            {
                FNV = new frmNhanVien();
                FNV.MdiParent = this;
                FNV.Show();
            }
            else
                FNV.Activate();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

            if (fHD == null || fHD.IsDisposed)
            {
                fHD = new frmHoaDon();
                fHD.MdiParent = this;
                fHD.Show();
            }
            else
                fHD.Activate();
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

            if (fTK == null || fTK.IsDisposed)
            {
                fTK = new frmTaiKhoan();
                fTK.MdiParent = this;
                fTK.Show();
            }
            else
                fTK.Activate();
        }

        private void mnuGiay_Click(object sender, EventArgs e)
        {
            btnNhanVien_Click(sender, e);
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            btnNhanVien_Click(sender, e);
        }
  
        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            btnHoaDon_Click(sender, e);
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            btnKhachHang_Click(sender, e);
        }

        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan_Click(sender, e);
        }
        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            btnDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuGiay.Enabled = false;
            mnuTaiKhoan.Enabled = false;
            mnuHoaDon.Enabled = false;
            btnHoaDon.Enabled = false;
            btnDangXuat.Enabled = false;
            btnKhachHang.Enabled = false;
            btnNhanVien.Enabled = false;
            btnGiay.Enabled = false;
            btnTaiKhoan.Enabled = false;
            lblTrangThai.Text = "Bạn Cần Đăng Nhập";
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
           
        }
        public void QuanLy()
        {
            mnuDangNhap.Enabled = false;
            btnDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuGiay.Enabled = true;
            mnuTaiKhoan.Enabled = true;
            mnuHoaDon.Enabled = true;
            btnHoaDon.Enabled = true;
            btnDangXuat.Enabled = true;
            btnKhachHang.Enabled = true;
            btnNhanVien.Enabled = true;
            btnGiay.Enabled = true;
            btnTaiKhoan.Enabled = true;
            lblTrangThai.Text = "Quản lý Cửa Hàng : " + HoVaTen;
        }
        public void NhanVien()
        {
            mnuDangNhap.Enabled = false;
            btnDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = false;
            mnuGiay.Enabled = true;
            mnuTaiKhoan.Enabled = false;
            mnuHoaDon.Enabled = true;
            btnHoaDon.Enabled = true;
            btnDangXuat.Enabled = true;
            btnKhachHang.Enabled = true;
            btnNhanVien.Enabled = false;
            btnGiay.Enabled = true;
            btnTaiKhoan.Enabled = false;
            lblTrangThai.Text = "Nhân Viên Cửa Hàng: " + HoVaTen;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
        back:
            if (DN == null || DN.IsDisposed)
                DN = new frmDangNhap();
            if (DN.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (DN.txtMaNhanVien.Text.Trim() == "")
                {
                    MessageBox.Show("Mã nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto back;
                }
                else if (DN.txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto back;
                }
                else
                {
                    TaiKhoanBus tKBus = new TaiKhoanBus();
                    if (tKBus.dangnhap(DN.txtMaNhanVien.Text, DN.txtMatKhau.Text))
                    {
                        if (quyenHan == 0)
                            QuanLy();
                        else if (quyenHan == 1)
                            NhanVien();
                        else
                            ChuaDangNhap();
                    }
                    else
                    {
                        MessageBox.Show("Mã Nhân Viên hoặc Mật Khẩu không chính xác!");
                        goto back;
                    }
                    DN.txtMaNhanVien.Clear();
                    DN.txtMatKhau.Clear();
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {  
              foreach (Form dm in this.MdiChildren)
                {
                    ChuaDangNhap();
                    dm.Close();
                }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            ChuaDangNhap();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {

            TT = new frmThôngTin();
            TT.ShowDialog();
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            btnThongTinPhanMem_Click(sender, e);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                fKH.MdiParent = this;
                fKH.Show();
            }
            else
                fKH.Activate();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            //frmHuongDan HD = new frmHuongDan();
            //HD.Show();
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "filehuongdan.chm"));
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            btnTroGiup_Click(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát không?", "Chú ý",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }

    }
}
    