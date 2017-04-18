using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanXeMay
{
    public partial class MDIParent1 : Form
    {

        public MDIParent1()
        {
            InitializeComponent();
        }

        Boolean KiemTraTonTai(string Frmname)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(Frmname))
                {
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form2") == false)
            {
                frmNhanVien frm2 = new frmNhanVien();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form3") == false)
            {
                frmKhachHang frm3 = new frmKhachHang();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form4") == false)
            {
                frmChiTietXe frm4 = new frmChiTietXe();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form5") == false)
            {
                frmHangTonKho frm5 = new frmHangTonKho();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form10") == false)
            {
                frmTimKiemNhanVien frm10 = new frmTimKiemNhanVien();
                frm10.MdiParent = this;
                frm10.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form11") == false)
            {
                frmTimKiemKhachHang frm11 = new frmTimKiemKhachHang();
                frm11.MdiParent = this;
                frm11.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form12") == false)
            {
                frmTimkiemNhaCungCap frm12 = new frmTimkiemNhaCungCap();
                frm12.MdiParent = this;
                frm12.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form13") == false)
            {
                Form13 frm13 = new Form13();
                frm13.MdiParent = this;
                frm13.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form14") == false)
            {
                frmThemUser frm14 = new frmThemUser();
                frm14.MdiParent = this;
                frm14.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form15") == false)
            {
                frmDoiMatKhau frm15 = new frmDoiMatKhau();
                frm15.MdiParent = this;
                frm15.Show();
            }
        }
       
        public MDIParent1(Form1 frm1)
        {
            InitializeComponent();
            Form1 = frm1;
        }
        
        Form1 Form1;

        private void button15_Click(object sender, EventArgs e)
        {
            Form1.Show();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form9") == false)
            {
                frmNhaCungCap frm9 = new frmNhaCungCap();
                frm9.MdiParent = this;
                frm9.Show();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form6") == false)
            {
                frmHoaDonNhap frm6 = new frmHoaDonNhap();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form7") == false)
            {
                frmHoaDonBan frm7 = new frmHoaDonBan();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTai("Form8") == false)
            {
                frmXeTrongCuaHang frm8 = new frmXeTrongCuaHang();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }
    }
}
