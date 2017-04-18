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
using System.Configuration;

using XeMay_BUS;
using XeMay_DTO; 
namespace QLBanXeMay
{
    public partial class frmNhanVien : Form
    {
        string str = "";
        SqlConnection cn;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvNhanVien.DataSource = GetNhanVien();
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        private List<NhanVien> GetNhanVien()
        {
            string sql = " SELECT * FROM NhanVien";
            return new NhanVienBUS().GetNhanVien(sql);
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            int luong;
            string manv, honv, tennv, /*ngaysinh,*/ gioitinh, chucvu, sdt, diachi, email;

            manv = txtMaNV.Text.Trim();
            honv = txtHoNV.Text.Trim();
            tennv = txtTenNV.Text.Trim();
            // ngaysinh 
            gioitinh = txtGioiTinh.Text.Trim();
            luong = int.Parse(txtLuong.Text.Trim());
            chucvu = txtChucVu.Text.Trim();
            diachi = txtDiaChi.Text.Trim();
            sdt = txtSDT.Text.Trim();
            email = txtEmail.Text.Trim();

            NhanVien emp = new NhanVien(manv, honv, tennv, /*ngaysinh,*/ gioitinh, luong, chucvu, diachi, sdt, email);
            try
            {
                int i = new NhanVienBUS().Add(emp);
                dgvNhanVien.DataSource = GetNhanVien();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from NhanVien where MaNV='" + txtMaNV.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvNhanVien.DataSource = GetNhanVien();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update NhanVien set HoNV='" + txtHoNV.Text + "', tenNV='" + txtTenNV.Text + "' where MaNV ='" + txtMaNV.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvNhanVien.DataSource = GetNhanVien();
            cn.Close();
        }

        private void dgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtMaNV.Text = dgvNhanVien.Rows[dong].Cells[0].Value.ToString();
            this.txtHoNV.Text = dgvNhanVien.Rows[dong].Cells[1].Value.ToString();
            this.txtTenNV.Text = dgvNhanVien.Rows[dong].Cells[2].Value.ToString();
            //this.dtpNgaySinh.Text = dgvNhanVien.Rows[dong].Cells[3].Value.ToString();
            this.txtGioiTinh.Text = dgvNhanVien.Rows[dong].Cells[3].Value.ToString();
            this.txtLuong.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
            this.txtChucVu.Text = dgvNhanVien.Rows[dong].Cells[5].Value.ToString();
            this.txtDiaChi.Text = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
            this.txtSDT.Text = dgvNhanVien.Rows[dong].Cells[7].Value.ToString();
            this.txtEmail.Text = dgvNhanVien.Rows[dong].Cells[8].Value.ToString();
        }

    }
}
