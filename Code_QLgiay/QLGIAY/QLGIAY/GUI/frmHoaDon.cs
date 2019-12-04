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
using Microsoft.Office.Interop.Excel;
namespace QLGIAY.GUI
{
    public partial class frmHoaDon : Form
    {
        private bool isThem = false;
        private string maHD = "";
        GiayBus gBus = new GiayBus();
        HoaDonBus hdBus = new HoaDonBus();
        NhanVienBus nvBus = new NhanVienBus();
        KhachHangBus khBus = new KhachHangBus();
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void BatTat(bool giaTri)
        {
            chkGioiTinh.Enabled = !giaTri;
            cboMaGiay.Enabled = !giaTri;
            cboMaNhanVien.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;
            cboKhachHang.Enabled = !giaTri;
            txtSoTien.Enabled = !giaTri;
            txtSoDienThoai.Enabled = !giaTri;
            txtMaHoaDon.Enabled = !giaTri;
            txtDiaChi.Enabled = !giaTri;
            btnThem.Enabled = giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;

        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {

            BatTat(false);
            isThem = true;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            
            isThem = false;
            maHD = txtMaHoaDon.Text;

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hóa đơn " + txtMaHoaDon.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                HoaDonInfo info = new HoaDonInfo();
                info.MaHD = txtMaHoaDon.Text;
                hdBus.Xoa(info);
            }

            frmHoaDon_Load_1(sender, e);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Trim() == "")
                MessageBox.Show("Mã Hóa Đơn không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaHoaDon.Text.Length > 4)
                MessageBox.Show("Mã Hóa Đơn không vượt quá 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboKhachHang.Text.Trim() == "")
                MessageBox.Show("Tên Khách Hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaNhanVien.Text.Trim() == "")
                MessageBox.Show("Chưa chọn Mã Nhân Viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaGiay.Text.Trim() == "")
                MessageBox.Show("Chưa chọn Mã Giầy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                HoaDonInfo info = new HoaDonInfo();

                info.DiaChi = txtDiaChi.Text;
                info.MaHD = txtMaHoaDon.Text;
                info.SoDienThoai = txtSoDienThoai.Text;
                info.SoTien = txtSoTien.Text;
                info.GioiTinh = chkGioiTinh.Checked ? "F" : "M";
                info.KH.MaKH = cboKhachHang.SelectedValue.ToString();
                info.Giay.MaGiay = cboMaGiay.SelectedValue.ToString();
                info.NV.MaNV = cboMaNhanVien.SelectedValue.ToString();
                if (isThem)
                    hdBus.Them(info);
                else
                    hdBus.Sua(info, maHD);

                frmHoaDon_Load_1(sender, e);
            }
        }

        private void btnDongForm_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoaDon_Load_1(object sender, EventArgs e)
        {

            BatTat(true);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dGV.AutoGenerateColumns = false;
            gBus.HienThiVaoComboBox1(cboMaGiay);
            nvBus.HienThiVaoComboBox(cboMaNhanVien);
            khBus.HienThiVaoComboBox2(cboKhachHang);
            hdBus.HienThiVaoDGV(bN, dGV, txtDiaChi, txtMaHoaDon, txtSoDienThoai, txtSoTien, cboKhachHang, cboMaNhanVien, chkGioiTinh, cboMaGiay, "");

        }

        private void btnlamlai_Click(object sender, EventArgs e)
        {
            BatTat(true);
            txtDiaChi.Clear();
            txtMaHoaDon.Clear();
            txtSoDienThoai.Clear();
            txtSoTien.Clear();
            cboMaGiay.ResetText();
            cboMaNhanVien.ResetText();
            chkGioiTinh.ResetText();
            cboKhachHang.ResetText();
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;
             sheet = workbook.ActiveSheet;
            sheet.Name = "DSHoaDon";
            // dòng tiêu đề
            for (int c = 0; c < dGV.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dGV.Columns[c].HeaderText;
            }
            // dòng nội dung
            for (int i = 0; i < dGV.Rows.Count; i++)
            {
                for (int j= 0; j < dGV.Columns.Count; j++)
                {
                    if (dGV.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = dGV.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                MessageBox.Show("Hoá đơn đã được xuất ra!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            hdBus.HienThiVaoDGV(bN, dGV, txtDiaChi, txtMaHoaDon, txtSoDienThoai, txtSoTien, cboKhachHang, cboMaNhanVien, chkGioiTinh, cboMaGiay,txtTuKhoa.Text);
        }
    }
}