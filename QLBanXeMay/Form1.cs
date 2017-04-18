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
namespace QLBanXeMay
{
    public partial class Form1 : Form
    {
        string str = "";
        SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            Close();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Đóng Ứng Dụng", "Chú Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string s = "Select Count(*) from [QLXeMay].[dbo].[Account] where UserName =@user and PassWord=@pass";
                SqlCommand cmd = new SqlCommand(s, cn);
                cmd.Parameters.Add(new SqlParameter("@user", txtdangNhap.Text));
                cmd.Parameters.Add(new SqlParameter("@pass", txtmatkhau.Text));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
            MDIParent1 Mdf = new MDIParent1(this);
            this.Hide();
            Mdf.Show();
                }
                else
                {
                    MessageBox.Show("Tên Đăng Nhập hoặc Mật Khẩu không đúng..!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
        }


    }
}
