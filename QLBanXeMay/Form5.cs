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
    public partial class frmHangTonKho : Form
    {
        string str = "";
        SqlConnection cn;
        public frmHangTonKho()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmHangTonKho_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvHangTonKho.DataSource = GetHangTonKho();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        private List<HangTonKho> GetHangTonKho()
        {
            string sql = " SELECT * FROM HangTonKho";
            return new HangTonKhoBUS().GetHangTonKho(sql);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            string maxe;
            int thang, nam, thoigiantonkho;
            thang = int.Parse(txtThang.Text.Trim());
            nam = int.Parse(txtNam.Text.Trim());
            maxe = txtMaXe.Text.Trim();
            thoigiantonkho = int.Parse(txtThoiGianTonKho.Text.Trim());

            HangTonKho emp = new HangTonKho(thang, nam, maxe, thoigiantonkho);
            try
            {
                int i = new HangTonKhoBUS().Add(emp);
                dgvHangTonKho.DataSource = GetHangTonKho();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from HangTonKho where Thang='" + txtThang.Text + "'and Nam='" + txtNam.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHangTonKho.DataSource = GetHangTonKho();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update HangTonKho set MaXe='" + txtMaXe.Text + "' where Thang='" + txtThang.Text + "' and Nam='" + txtNam.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvHangTonKho.DataSource = GetHangTonKho();
            cn.Close();
        }

        private void dgvHangTonKho_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtThang.Text = dgvHangTonKho.Rows[dong].Cells[0].Value.ToString();
            this.txtNam.Text = dgvHangTonKho.Rows[dong].Cells[1].Value.ToString();
            this.txtMaXe.Text = dgvHangTonKho.Rows[dong].Cells[2].Value.ToString();
            this.txtThoiGianTonKho.Text = dgvHangTonKho.Rows[dong].Cells[3].Value.ToString();
        }

    }
}
