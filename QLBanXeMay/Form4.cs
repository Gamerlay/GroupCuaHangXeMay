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
    public partial class frmChiTietXe : Form
    {
        string str = "";
        SqlConnection cn;
        public frmChiTietXe()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChiTietXe_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvChiTietXe.DataSource = GetChiTietXe();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        private List<ChiTietXe> GetChiTietXe()
        {
            string sql = " SELECT * FROM ChiTietXe";
            return new ChiTietXeBUS().GetChiTietXe(sql);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string sokhung, somay, maxe, mausac;
            int trongluong, hopso, dungtichbinhxang, dungtichxilanh;
            sokhung = txtSoKhung.Text.Trim();
            somay = txtSoMay.Text.Trim();
            maxe = txtMaXe.Text.Trim();
            mausac = txtMauSac.Text.Trim();
            trongluong = int.Parse(txtTrongLuong.Text.Trim());
            hopso = int.Parse(txtHopSo.Text.Trim());
            dungtichbinhxang = int.Parse(txtBinhXang.Text.Trim());
            dungtichxilanh = int.Parse(txtXiLanh.Text.Trim());
            ChiTietXe emp = new ChiTietXe(sokhung, somay, maxe, mausac, trongluong, hopso, dungtichbinhxang, dungtichxilanh);
            try
            {
                int i = new ChiTietXeBUS().Add(emp);
                dgvChiTietXe.DataSource = GetChiTietXe();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from ChiTietXe where SoKhung='" + txtSoKhung.Text + "' and SoMay='" + txtSoMay.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvChiTietXe.DataSource = GetChiTietXe();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update ChiTietXe set MaXe ='" + txtMaXe.Text + "' where SoKhung='" + txtSoKhung.Text + "' and SoMay='" + txtSoMay.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvChiTietXe.DataSource = GetChiTietXe();
            cn.Close();

        }

        private void dgvChiTietXe_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtSoKhung.Text = dgvChiTietXe.Rows[dong].Cells[0].Value.ToString();
            this.txtSoMay.Text = dgvChiTietXe.Rows[dong].Cells[1].Value.ToString();
            this.txtMaXe.Text = dgvChiTietXe.Rows[dong].Cells[3].Value.ToString();
            this.txtMauSac.Text = dgvChiTietXe.Rows[dong].Cells[2].Value.ToString();
            this.txtTrongLuong.Text = dgvChiTietXe.Rows[dong].Cells[4].Value.ToString();
            this.txtHopSo.Text = dgvChiTietXe.Rows[dong].Cells[5].Value.ToString();
            this.txtBinhXang.Text = dgvChiTietXe.Rows[dong].Cells[6].Value.ToString();
            this.txtXiLanh.Text = dgvChiTietXe.Rows[dong].Cells[7].Value.ToString();
        }

    }
}
