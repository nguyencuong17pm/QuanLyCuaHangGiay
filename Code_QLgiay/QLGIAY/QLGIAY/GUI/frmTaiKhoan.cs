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
    public partial class frmTaiKhoan : Form
    {
            private bool isThem = false;
            private TaiKhoanBus tkBus = new TaiKhoanBus();
            private NhanVienBus nvBus = new NhanVienBus();

            public frmTaiKhoan()
            {
                InitializeComponent();
            }

            private void BatTat(bool giaTri)
            {
                cboNhanVien.Enabled = giaTri;
                cboQuyenHan.Enabled = giaTri;
                txtMatKhau.Enabled = giaTri;
                btnLuu.Enabled = giaTri;

                btnThem.Enabled = !giaTri;
                btnCapNhat.Enabled = !giaTri;
                btnXoa.Enabled = giaTri;
            }
            private void btnThem_Click_1(object sender, EventArgs e)
            {

                BatTat(true);
                isThem = true;
                cboNhanVien.Text = "";
                cboQuyenHan.Text = "";
                txtMatKhau.Text = "";
            }

            private void btnCapNhat_Click_1(object sender, EventArgs e)
            {
                BatTat(true);
                isThem = false;

            }

            private void btnXoa_Click_1(object sender, EventArgs e)
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản " + cboNhanVien.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    TaiKhoanInfo info = new TaiKhoanInfo();
                    info.ID = Convert.ToInt32(dGV.CurrentRow.Cells[0].Value.ToString());
                    tkBus.Xoa(info);
                }

                // Tải lại lưới
                frmTaiKhoan_Load_1(sender, e);
            }

            private void btnLuu_Click_1(object sender, EventArgs e)
            {
                if (cboNhanVien.Text == "")
                    MessageBox.Show("Chưa chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (cboQuyenHan.Text == "")
                    MessageBox.Show("Chưa chọn quyền hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtMatKhau.Text == "")
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    TaiKhoanInfo tk = new TaiKhoanInfo();
                    tk.NhanVien.MaNV = cboNhanVien.SelectedValue.ToString();
                    tk.MatKhau = txtMatKhau.Text;
                    tk.Quyen = cboQuyenHan.SelectedIndex;

                    if (isThem)
                        tkBus.Them(tk);
                    else
                    {
                        tk.ID = Convert.ToInt32(dGV.CurrentRow.Cells[0].Value.ToString());
                        tkBus.Sua(tk);
                    }

                    // Tải lại lưới
                    frmTaiKhoan_Load_1(sender, e);
                }
            }

            private void btnThoat_Click_1(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnTaiLai_Click_1(object sender, EventArgs e)
            {
                txtMatKhau.Clear();
                cboNhanVien.ResetText();
                cboQuyenHan.ResetText();
            }

            private void dGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
                e.Cancel = true;
            }

            private void dGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {

                if (dGV.Columns[e.ColumnIndex].Name == "colMatKhau")
                {
                    e.Value = "••••••";
                }

                if (dGV.Columns[e.ColumnIndex].Name == "colQuyenHan")
                {
                    if (e.Value.ToString() == "0")
                        e.Value = "Quản lý cửa hàng";
                    else
                        e.Value = "Nhân viên cửa hàng";
                }
            }

            private void frmTaiKhoan_Load_1(object sender, EventArgs e)
            {
                BatTat(false);
                dGV.AutoGenerateColumns = false;
                tkBus.HienThiVaoDGV(dGV, bN, cboNhanVien, cboQuyenHan, txtMatKhau);
                nvBus.HienThiVaoComboBox(cboNhanVien);
            }
        }
    }
