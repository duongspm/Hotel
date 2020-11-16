using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace KHACHSAN
{
    public partial class frmkhachHang : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-H2H8GIE\SQLEXPRESS;Initial Catalog=KHACHSAN;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public frmkhachHang()
        {
            InitializeComponent();
        }

        private void frmkhachHang_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadDuLieu();
            ThemSuaXoaDL();
            DisableTextBox();
            LayDuLieuLenTextBox();
            DisableHuyButton();
        }
        public void LoadDuLieu()
        {
            dt.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM KHACHHANG", conn);
            adapter.SelectCommand = cm;
            adapter.Fill(dt);
            dgvKhachHang.DataSource = dt;
        }
        public void LayDuLieuLenTextBox()
        {
            txtmaKhachHang.DataBindings.Clear();
            txtmaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "maKhachHang");
            txttenKhachHang.DataBindings.Clear();
            txttenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "tenKhachHang");
            mtbsoDienThoai.DataBindings.Clear();
            mtbsoDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "soDienThoai");

        }
        private void ThemSuaXoaDL()
        {
            adapter.InsertCommand = new SqlCommand("INSERT INTO KHACHHANG VALUES (@maKhachHang, @tenKhachHang, @soDienThoai)", conn);

            // dinh nghia parameter
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@maKhachHang";
            p1.SourceColumn = "maKhachHang";
            adapter.InsertCommand.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@tenKhachHang";
            p2.SourceColumn = "tenKhachHang";
            adapter.InsertCommand.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@soDienThoai";
            p3.SourceColumn = "soDienThoai";
            adapter.InsertCommand.Parameters.Add(p3);

            adapter.UpdateCommand = new SqlCommand("UPDATE KHACHHANG SET tenKhachHang = @tenKhachHang, soDienThoai = @soDienThoai WHERE maKhachHang = @maKhachHang", conn);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@maKhachHang";
            p4.SourceColumn = "maKhachHang";
            adapter.UpdateCommand.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@tenKhachHang";
            p5.SourceColumn = "tenKhachHang";
            adapter.UpdateCommand.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@soDienThoai";
            p6.SourceColumn = "soDienThoai";
            adapter.UpdateCommand.Parameters.Add(p6);

            adapter.DeleteCommand = new SqlCommand("DELETE  FROM KHACHHANG WHERE maKhachHang = @maKhachHang", conn);

            //dinh nghia parameter @masanpham
            SqlParameter p19 = new SqlParameter();
            p19.ParameterName = "@maKhachHang";
            p19.SourceColumn = "maKhachHang";
            adapter.DeleteCommand.Parameters.Add(p19);
        }
        public void DisableTextBox()
        {
            // disable textbox
            txtmaKhachHang.Enabled = false;
            txttenKhachHang.Enabled = false;
            mtbsoDienThoai.Enabled = false;
        }
        public void EnableTextBox()
        {
            txtmaKhachHang.Enabled = true;
            txttenKhachHang.Enabled = true;
            mtbsoDienThoai.Enabled = true;
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
        public void XoaTrang()
        {
            txtmaKhachHang.Text = "";
            txttenKhachHang.Text = "";
            mtbsoDienThoai.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            LayDuLieuLenTextBox();

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
            txtSearch.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
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
            else if(btnThem.Text.Equals("LƯU"))
            {
                try
                {
                    string id = txtmaKhachHang.Text;
                    string name = txttenKhachHang.Text;
                    string sdt = mtbsoDienThoai.Text;

                    Regex ma = new Regex(@"^[0-9]{9,15}$");
                    if (!ma.IsMatch(txtmaKhachHang.Text))
                    {
                        MessageBox.Show("Mã khách hàng độ dài 9 - 15 ký tự chỉ chứa số, Không ký tự đặc biệt", "Vui lòng nhập mã khách hàng !");
                        return;
                    }
                    if (name=="")
                    {
                        MessageBox.Show("Vui lòng nhập tên khách hàng!");
                        return;
                    }
                    Regex dt = new Regex(@"((0)+([0-9]{9})\b)");
                    if (!dt.IsMatch(mtbsoDienThoai.Text))
                    //if(sdt=="")
                    {
                        MessageBox.Show("Số điện thoại sai định dạng ! Không chứa kí tự đặc biệt, đủ 10 số và bắt đầu bằng số 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbsoDienThoai.Focus();
                        return;
                    }
                    string str_them = "INSERT INTO KHACHHANG VALUES ('" + id + "', N'" + name + "', N'" + sdt + "')";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
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
            else
            {
                string id = txtmaKhachHang.Text;
                string name = txttenKhachHang.Text;
                string sdt = mtbsoDienThoai.Text;
                Regex ma = new Regex(@"^[0-9]{9,15}$");
                if (!ma.IsMatch(txtmaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng độ dài 9 - 15 ký tự chỉ chứa số, Không ký tự đặc biệt", "Vui lòng nhập mã khách hàng !");
                    return;
                }
                if (name == "")
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!");
                    return;
                }
                Regex dt = new Regex(@"((0)+([0-9]{9})\b)");
                if (!dt.IsMatch(mtbsoDienThoai.Text))
                {
                    MessageBox.Show("Số điện thoại sai định dạng ! Không chứa kí tự đặc biệt, đủ 10 số và bắt đầu bằng số 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbsoDienThoai.Focus();
                    return;
                }
                string str_sua = "UPDATE KHACHHANG SET tenKhachHang = N'" + name + "',soDienThoai = N'" + sdt + "'  WHERE maKhachHang = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(str_sua, conn);
                cmd.ExecuteNonQuery();

                //load lại dữ liệu trên form
                LoadDuLieu();

                DisableTextBox();

                btnSua.Text = "SỬA";
                DisableHuyButton();
                EnableThemButton();
                EnableXoaButton();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string id = txtmaKhachHang.Text;

                    //xóa dòng dl trong csdl
                    string str_xoa = "DELETE FROM KHACHHANG WHERE maKhachHang = '" + id + "' ";
                    SqlCommand cmd = new SqlCommand(str_xoa, conn);
                    cmd.ExecuteNonQuery();

                    //load lại dữ liệu trên form
                    LoadDuLieu();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                    adapter.Update((DataTable)dgvKhachHang.DataSource);
                    dt.Clear();
                    LoadDuLieu();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string timkiem = "SELECT* FROM KHACHHANG WHERE maKhachHang like '%'+@maKhachHang+'%' or tenKhachHang like '%' + @maKhachHang + '%' or soDienThoai like '%' + @maKhachHang + '%'";
                SqlCommand cmd = new SqlCommand(timkiem, conn);
                cmd.Parameters.AddWithValue("maKhachHang", txtSearch.Text);
                cmd.Parameters.AddWithValue("tenKhachHang", txttenKhachHang.Text);
                cmd.Parameters.AddWithValue("soDienThoai", mtbsoDienThoai.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvKhachHang.DataSource = dt;
                EnableHuyButton();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Không tìm thấy !");
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                adapter.Update((DataTable)dgvKhachHang.DataSource);
                dt.Clear();
                LoadDuLieu();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
