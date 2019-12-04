using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using QLGIAY.BUS;
using QLGIAY.INFO;
namespace QLGIAY.GUI
{
    public partial class frmNhanVien : Form
    {
        //private bool isThem = false;
        //private string maNV = ""; 
        //NhanVienBus nvBus = new NhanVienBus();

        public frmNhanVien()
        {
            InitializeComponent();
        }
        //public void BatTat(bool giaTri)
        //{
        //    chkGioiTinh.Enabled = giaTri;
        //    btnluu.Enabled = giaTri;
        //    txtMaNV.Enabled = giaTri;
        //    txtTenNhanVien.Enabled = giaTri;
        //    dtpNgaySinh.Enabled = giaTri;
        //    txtCMND.Enabled = giaTri;
        //    dtpNgayVaoLam.Enabled = giaTri;
        //    txtDiaChi.Enabled = giaTri;

        //    btnthem.Enabled = !giaTri;
        //    btnsua.Enabled = giaTri;
        ////    btnxoa.Enabled = giaTri;
        //}

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {

            //BatTat(true);
            //isThem = true;
            
        }

        private void btnluu_Click_1(object sender, EventArgs e)
        {
            //  btnsua.Enabled = true;
            //if (txtMaNV.Text.Trim() == "")
            //    MessageBox.Show("Mã nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (txtMaNV.Text.Length > 4)
            //    MessageBox.Show("Mã nhân viên không vượt quá 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (txtTenNhanVien.Text.Trim() == "")
            //    MessageBox.Show("Tên nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (txtCMND.Text.Trim() == "")
            //    MessageBox.Show("Số CMND không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (txtCMND.Text.Length != 9)
            //    MessageBox.Show("Số CMND phải đủ 9 ký tự số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
            //{
            //    NhanVienInfo info = new NhanVienInfo();
            //    info.MaNV = txtMaNV.Text;
            //    info.TenNV = txtTenNhanVien.Text;
            //    info.CMND = txtCMND.Text;
            //    info.DiaChi = txtDiaChi.Text;
            //    info.GioiTinh = chkGioiTinh.Checked ? "F" : "M";
            //    info.NgaySinh = dtpNgaySinh.Value.ToShortDateString();
            //    info.NgayVaoLam = dtpNgayVaoLam.Value.ToShortDateString();
            //    if (isThem)
            //        nvBus.Them(info);
            //    else
            //        nvBus.Sua(info, maNV);

            //    // Tải lại lưới
            //    frmNhanVien_Load_1(sender, e);
            //    btnsua.Enabled = true;
            //}
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtTenNhanVien.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    NhanVienInfo info = new NhanVienInfo();
            //    info.MaNV = txtMaNV.Text;
            //    nvBus.Xoa(info);
            //}

            //// Tải lại lưới
            //frmNhanVien_Load_1(sender, e);
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {

            //BatTat(true);
            //isThem = false;
            //maNV = txtMaNV.Text;
            //maNV = dGV.Rows[dGV.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void frmNhanVien_Load_1(object sender, EventArgs e)
        {

            //BatTat(false);
            //dGV.AutoGenerateColumns = false;
            //nvBus.HienThiVaoDGV(bN, dGV, txtMaNV, txtTenNhanVien, chkGioiTinh, dtpNgaySinh, txtCMND, dtpNgayVaoLam, txtDiaChi);
        }

        private void dGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (dGV.Columns[e.ColumnIndex].Name == "colgioitinh")
            {
                if ((string)e.Value == "F")
                    e.Value = "Nữ";
                else
                    e.Value = "Nam";
            }
             * */
          }
        }
    }

