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
    public partial class frmHoaDonBan : Form
    {
        string str = "";
        SqlConnection cn;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvHoaDonXuat.DataSource = GetHoaDonXuat();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        private List<HoaDonXuat> GetHoaDonXuat()
        {
            string sql = " SELECT * FROM HoaDonXuat";
            return new HoaDonXuatBUS().GetHoaDonXuat(sql);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            string maxuat, manv, makh, tenxe;
            int soluong, dongia;
            maxuat = txtMaXuat.Text.Trim();
            manv = txtMaNV.Text.Trim();
            makh = txtMaKH.Text.Trim();
            tenxe = txtTenXe.Text.Trim();
            soluong = int.Parse(txtSoLuong.Text.Trim());
            dongia = int.Parse(txtDonGia.Text.Trim());


            HoaDonXuat emp = new HoaDonXuat(maxuat, manv, makh, tenxe, soluong, dongia);
            try
            {
                int i = new HoaDonXuatBUS().Add(emp);
                dgvHoaDonXuat.DataSource = GetHoaDonXuat();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from HoaDonXuat where MaXuat='" + txtMaXuat.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHoaDonXuat.DataSource = GetHoaDonXuat();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update HoaDonXuat set MaNV='" + txtMaNV.Text + "', MaKH ='" + txtMaKH.Text + "' where MaXuat ='" + txtMaXuat.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHoaDonXuat.DataSource = GetHoaDonXuat();
            cn.Close();
        }

        private void dgvHoaDonXuat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtMaXuat.Text = dgvHoaDonXuat.Rows[dong].Cells[0].Value.ToString();
            this.txtMaNV.Text = dgvHoaDonXuat.Rows[dong].Cells[1].Value.ToString();
            this.txtMaKH.Text = dgvHoaDonXuat.Rows[dong].Cells[2].Value.ToString();
            //this.txtNgayXuat.Text = dgvHoaDonXuat.Rows[dong].Cells[3].Value.ToString();
            this.txtTenXe.Text = dgvHoaDonXuat.Rows[dong].Cells[4].Value.ToString();
            this.txtSoLuong.Text = dgvHoaDonXuat.Rows[dong].Cells[5].Value.ToString();
            this.txtDonGia.Text = dgvHoaDonXuat.Rows[dong].Cells[6].Value.ToString();
        }

    }
}
