﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KHACHSAN
{
    public partial class frmdichVu : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-H2H8GIE\SQLEXPRESS;Initial Catalog=KHACHSAN;Integrated Security=True");
        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();
        public frmdichVu()
        {
            InitializeComponent();
        }

        private void frmdichVu_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadDuLieu();
            ThemSuaXoaDL();
            LayDuLieuLenTextBox();
            DisableTextBox();
            DisableHuyButton();
        }
        public void LoadDuLieu()
        {
            dt.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM DICHVU", conn);
            adap.SelectCommand = cm;
            adap.Fill(dt);
            dgvDichVu.DataSource = dt;
        }
        public void ThemSuaXoaDL()
        {
            adap.InsertCommand = new SqlCommand("INSERT INTO DICHVU VALUES (@maDichVu, @tenDichVu, @gia)", conn);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@maDichVu";
            p1.SourceColumn = "maDichVu";
            adap.InsertCommand.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@tenDichVu";
            p2.SourceColumn = "tenDichVu";
            adap.InsertCommand.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@gia";
            p3.SourceColumn = "gia";
            adap.InsertCommand.Parameters.Add(p3);
            //
            adap.UpdateCommand = new SqlCommand("UPDATE DICHVU SET tenDichVu = @tenDichVu, gia = @gia WHERE maDichVu = @maDichVu", conn);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@maDichVu";
            p4.SourceColumn = "maDichVu";
            adap.UpdateCommand.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@tenDichVu";
            p5.SourceColumn = "tenDichVu";
            adap.UpdateCommand.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@gia";
            p6.SourceColumn = "gia";
            adap.UpdateCommand.Parameters.Add(p6);
            //
            adap.DeleteCommand = new SqlCommand("delete from DICHVU where maDichVu = @maDichVu", conn);

            //dinh nghia parameter @masanpham
            SqlParameter p17 = new SqlParameter();
            p17.ParameterName = "@maDichVu";
            p17.SourceColumn = "maThietBi";
            adap.DeleteCommand.Parameters.Add(p17);
        }
        public void LayDuLieuLenTextBox()
        {
            txtMaDichVu.DataBindings.Clear();
            txtMaDichVu.DataBindings.Add("Text", dgvDichVu.DataSource, "maDichVu");

            txtTenDichVu.DataBindings.Clear();
            txtTenDichVu.DataBindings.Add("Text", dgvDichVu.DataSource, "tenDichVu");

            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", dgvDichVu.DataSource, "gia");
        }
        public void DisableTextBox()
        {
            // disable textbox
            txtMaDichVu.Enabled = false;
            txtTenDichVu.Enabled = false;
            txtGia.Enabled = false;
        }
        public void EnableTextBox()
        {
            txtMaDichVu.Enabled = true;
            txtTenDichVu.Enabled = true;
            txtGia.Enabled = true;
        }
        public void DisableHuyButton()
        {
            btnHuy.Enabled = false;
            btnHuy.BackColor = Color.White;
        }
        public void EnableHuyButton()
        {
            btnHuy.Enabled = true;
            btnHuy.BackColor = Color.DeepSkyBlue;
        }
        public void DisableThemButton()
        {
            btnThem.Enabled = false;
            btnThem.BackColor = Color.White;
        }
        public void EnableThemButton()
        {
            btnThem.Enabled = true;
            btnThem.BackColor = Color.Turquoise;
        }
        public void EnableSuaButton()
        {
            btnSua.Enabled = true;
            btnSua.BackColor = Color.RoyalBlue;
        }
        public void DisableSuaButton()
        {
            btnSua.Enabled = false;
            btnSua.BackColor = Color.White;
        }
        public void DisableXoaButton()
        {
            btnXoa.Enabled = false;
            btnXoa.BackColor = Color.White;
        }
        public void EnableXoaButton()
        {
            btnXoa.Enabled = true;
            btnXoa.BackColor = Color.Tomato;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                // lấy dữ liệu từ textBox
                string id = txtMaDichVu.Text;

                //xóa dòng dl trong csdl
                string str_xoa = "DELETE FROM DICHVU WHERE maDichVu = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(str_xoa, conn);
                cmd.ExecuteNonQuery();

                //load lại dữ liệu trên form
                LoadDuLieu();

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("LƯU"))
            {
                btnThem.Text = "THÊM";
                EnableSuaButton();
                EnableXoaButton();
            }


            if (btnSua.Text.Equals("LƯU"))
            {
                btnSua.Text = "SỬA";
                EnableXoaButton();
                EnableThemButton();
            }

            DisableHuyButton();
            DisableTextBox();

            LoadDuLieu();
            LayDuLieuLenTextBox();
        }
        private void XoaTrang()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtGia.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaDichVu.Text;
            string name = txtTenDichVu.Text;
            string price = txtGia.Text;

            if (id == "")
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ !","Dịch vụ");
                return;
            }
            else if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ !", "Dịch vụ");
                return;
            }
            else if (price == "")
            {
                MessageBox.Show("Vui lòng nhập giá dịch vụ !", "Dịch vụ");
                return;
            }

            else
            {
                if (btnThem.Text.Equals("THÊM"))
                {
                    EnableTextBox();
                    XoaTrang();
                    btnThem.Text = "LƯU";

                    EnableHuyButton();
                    DisableSuaButton();
                    DisableXoaButton();

                }
                else
                {
                    try
                    {
                        // mở kết nối
                        //conn.Open();

                        //insert vào csdl
                        string str_them = "INSERT INTO DICHVU VALUES ('" + id + "', N'" + name + "', '" + price + "')";
                        SqlCommand cmd = new SqlCommand(str_them, conn);
                        cmd.ExecuteNonQuery();

                        //load lại dữ liệu trên form
                        LoadDuLieu();

                        //xóa trắng các ô textbox
                        //XoaTrang();
                        DisableTextBox();
                        btnThem.Text = "THÊM";

                        DisableHuyButton();
                        EnableSuaButton();
                        EnableXoaButton();

                        //đóng kết nối
                        //conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("SỬA"))
            {
                EnableTextBox();

                DisableThemButton();
                DisableXoaButton();

                btnSua.Text = "LƯU";

                EnableHuyButton();
            }
            else if (btnSua.Text.Equals("LƯU"))
            {
                string id = txtMaDichVu.Text;
                string name = txtTenDichVu.Text;
                string price = txtGia.Text;

                if (id == "")
                {
                    MessageBox.Show("Vui lòng nhập mã dịch vụ !", "Dịch vụ");
                    return;
                }
                else if (name == "")
                {
                    MessageBox.Show("Vui lòng nhập tên dịch vụ !", "Dịch vụ");
                    return;
                }
                else if (price == "")
                {
                    MessageBox.Show("Vui lòng nhập giá dịch vụ !", "Dịch vụ");
                    return;
                }
                else
                {
                    //sửa dòng dl trong csdl
                    string str_sua = "UPDATE DICHVU SET tenDichVu = N'" + name + "',gia  = '" + price + "' WHERE maDichVu = '" + id + "' ";
                    SqlCommand cmd = new SqlCommand(str_sua, conn);
                    cmd.ExecuteNonQuery();

                    //load lại dữ liệu trên form
                    LoadDuLieu();

                    DisableTextBox();

                    btnSua.Text = "SỬA";
                    DisableHuyButton();
                    EnableThemButton();
                    EnableXoaButton();

                    //đóng kết nối
                    //conn.Close();
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                adap.Update((DataTable)dgvDichVu.DataSource);
                dt.Clear();
                LoadDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
