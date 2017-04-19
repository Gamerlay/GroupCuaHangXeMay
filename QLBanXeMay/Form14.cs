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
    public partial class frmThemUser : Form
    {
        string str = "";
        SqlConnection cn;
        public frmThemUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemUser_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
        }
        private List<Account> GetAccount()
        {
            string sql = " SELECT * FROM Account";
            return new AccountBUS().GetAccount(sql);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            string user, pass;

            user = txtTenUser.Text.Trim();
            pass = txtMatKhau.Text.Trim();

            Account emp = new Account(user, pass);
            try
            {
                int i = new AccountBUS().Add(emp);
                MessageBox.Show("Thêm thành công !");
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
