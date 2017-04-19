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

using XeMay_BUS;
using XeMay_DTO; 
namespace QLBanXeMay
{
    public partial class frmXeTrongCuaHang : Form
    {
        string str = "";
        SqlConnection cn;
        public frmXeTrongCuaHang()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<XeTrongCuaHang> GetXeTrongCuaHang()
        {
            string sql = " SELECT * FROM XeTrongCuaHang";
            return new XeTrongCuaHangBUS().GetXeTrongCuaHang(sql);
        }
        private void frmXeTrongCuaHang_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvXeTrongCuaHang.DataSource = GetXeTrongCuaHang();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string maxe, manhap, maxuat, tenxe;
            int dongianhap, dongiaxuat;
            maxe = txtMaXe.Text.Trim();
            manhap = txtMaNhap.Text.Trim();
            maxuat = txtMaXuat.Text.Trim();
            tenxe = txtTenXe.Text.Trim();
            dongianhap = int.Parse(txtDonGiaNhap.Text.Trim());
            dongiaxuat = int.Parse(txtDonGiaXuat.Text.Trim());


            XeTrongCuaHang emp = new XeTrongCuaHang(maxe, manhap, maxuat, tenxe, dongianhap, dongiaxuat);
            try
            {
                int i = new XeTrongCuaHangBUS().Add(emp);
                dgvXeTrongCuaHang.DataSource = GetXeTrongCuaHang();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }  
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from XeTrongCuaHang where MaXe='" + txtMaXe.Text + "' and MaNhap ='" + txtMaNhap + "' and MaXuat='" + txtMaXuat.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvXeTrongCuaHang.DataSource = GetXeTrongCuaHang();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update XeTrongCuaHang set TenXe='" + txtTenXe.Text + "' where MaXe='" + txtMaXe.Text + "' and MaNhap ='" + txtMaNhap + "' and MaXuat='" + txtMaXuat.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvXeTrongCuaHang.DataSource = GetXeTrongCuaHang();
            cn.Close();
        }

        private void dgvXeTrongCuaHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtMaXe.Text = dgvXeTrongCuaHang.Rows[dong].Cells[0].Value.ToString();
            this.txtMaNhap.Text = dgvXeTrongCuaHang.Rows[dong].Cells[1].Value.ToString();
            this.txtMaXuat.Text = dgvXeTrongCuaHang.Rows[dong].Cells[2].Value.ToString();
            this.txtTenXe.Text = dgvXeTrongCuaHang.Rows[dong].Cells[3].Value.ToString();
            this.txtDonGiaNhap.Text = dgvXeTrongCuaHang.Rows[dong].Cells[4].Value.ToString();
            this.txtDonGiaXuat.Text = dgvXeTrongCuaHang.Rows[dong].Cells[5].Value.ToString();
        }
    }
}
