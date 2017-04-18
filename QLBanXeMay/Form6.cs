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
    public partial class frmHoaDonNhap : Form
    {
        string str = "";
        SqlConnection cn;
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvHoaDonNhap.DataSource = GetHoaDonNhap();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private List<HoaDonNhap> GetHoaDonNhap()
        {
            string sql = " SELECT * FROM HoaDonNhap";
            return new HoaDonNhapBUS().GetHoaDonNhap(sql);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string manhap, manv, mancc, tenxe;
            int soluong, dongia;
            manhap = txtMaNhap.Text.Trim();
            manv = txtMaNV.Text.Trim();
            mancc = txtMaNCC.Text.Trim();
            tenxe = txtTenXe.Text.Trim();
            soluong = int.Parse(txtSoLuong.Text.Trim());
            dongia = int.Parse(txtDonGia.Text.Trim());


            HoaDonNhap emp = new HoaDonNhap(manhap, manv, mancc, tenxe, soluong, dongia);
            try
            {
                int i = new HoaDonNhapBUS().Add(emp);
                dgvHoaDonNhap.DataSource = GetHoaDonNhap();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from HoaDonNhap where MaNhap='" + txtMaNhap.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHoaDonNhap.DataSource = GetHoaDonNhap();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update HoaDonNhap set MaNV='" + txtMaNV.Text + "', MaNCC='" + txtMaNCC.Text + "' where MaNhap ='" + txtMaNhap.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHoaDonNhap.DataSource = GetHoaDonNhap();
            cn.Close();
        }
    }
}
