﻿using System;
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
    public partial class frmKhachHang : Form
    {
        string str = "";
        SqlConnection cn;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
            try
            {
                dgvKhachHang.DataSource = GetKhachHang();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        private List<KhachHang> GetKhachHang()
        {
            string sql = " SELECT * FROM KhachHang";
            return new KhachHangBUS().GetKhachHang(sql);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            string makh, hokh, tenkh, ngaysinh, sdt, diachi, email;

            makh = txtMaKH.Text.Trim();
            hokh = txtHoKH.Text.Trim();
            tenkh = txtTenKH.Text.Trim();
            //ngaysinh = textBox4.Text.Trim();
            diachi = txtDiaChi.Text.Trim();
            sdt = txtSDT.Text.Trim();
            email = txtEmail.Text.Trim();

            KhachHang emp = new KhachHang(makh, hokh, tenkh, /*ngaysinh,*/diachi, sdt, email);
            try
            {
                int i = new KhachHangBUS().Add(emp);
                dgvKhachHang.DataSource = GetKhachHang();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }       
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string s = "Delete from KhachHang where MaKH='" + txtMaKH.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvKhachHang.DataSource = GetKhachHang();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string s = "update KhachHang set HoKH='" + txtHoKH.Text + "', tenKH='" + txtTenKH.Text + "' where MaKH ='" + txtMaKH.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dgvKhachHang.DataSource = GetKhachHang();
            cn.Close();
        }

    }
}