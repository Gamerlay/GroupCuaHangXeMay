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
    public partial class frmNhaCungCap : Form
    {
        string str = "";
        SqlConnection cn;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<NhaCungCap> GetNhaCungCap()
        {
            string sql = " SELECT * FROM NhaCungCap";
            return new NhaCungCapBUS().GetNhaCungCap(sql);
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvNhaCungCap.DataSource = GetNhaCungCap();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string mancc, tenncc, sdt, diachi, email;
            mancc = txtMaNCC.Text.Trim();
            tenncc = txtTenNCC.Text.Trim();
            sdt = txtSDT.Text.Trim();
            diachi = txtDiaChi.Text.Trim();
            email = txtEmail.Text.Trim();


            NhaCungCap emp = new NhaCungCap(mancc, tenncc, sdt, diachi, email);
            try
            {
                int i = new NhaCungCapBUS().Add(emp);
                dgvNhaCungCap.DataSource = GetNhaCungCap();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from NhaCungCap where MaNCC='" + txtMaNCC.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvNhaCungCap.DataSource = GetNhaCungCap();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update NhaCungCap set TenNCC='" + txtTenNCC.Text + "' where MaNCC ='" + txtMaNCC.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvNhaCungCap.DataSource = GetNhaCungCap();
            cn.Close();
        }

        private void dgvNhaCungCap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            this.txtMaNCC.Text = dgvNhaCungCap.Rows[dong].Cells[0].Value.ToString();
            this.txtTenNCC.Text = dgvNhaCungCap.Rows[dong].Cells[1].Value.ToString();
            this.txtSDT.Text = dgvNhaCungCap.Rows[dong].Cells[2].Value.ToString();
            this.txtDiaChi.Text = dgvNhaCungCap.Rows[dong].Cells[3].Value.ToString();
            this.txtEmail.Text = dgvNhaCungCap.Rows[dong].Cells[4].Value.ToString();
        }
    }
}
