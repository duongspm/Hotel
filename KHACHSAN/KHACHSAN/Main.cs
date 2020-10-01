using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHACHSAN
{
    public partial class Main : Form
    {
        //kiểm  tra form con có tồn tại hay chưa
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }
        public Main()
        {
            InitializeComponent();
        }

        private void danhSáchThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmthietBi"))
            {
                frmthietBi frm = new frmthietBi();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmdatPhong"))
            {
                frmdatPhong frm = new frmdatPhong();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmdichVu"))
            {
                frmdichVu frm = new frmdichVu();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmphong"))
            {
                frmphong frm = new frmphong();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmnhanVien"))
            {
                frmnhanVien frm = new frmnhanVien();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void danhSáchPhiếuLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmphieuLuong"))
            {
                frmphieuLuong frm = new frmphieuLuong();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmkhachHang"))
            {
                frmkhachHang frm = new frmkhachHang();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmdoanhThu"))
            {
                frmdoanhThu frm = new frmdoanhThu();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmdangNhap"))
            {
                frmdangNhap frm = new frmdangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Form hiện đang được mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
