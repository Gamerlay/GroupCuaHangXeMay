using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoKH { get; set; }
        public string TenKH { get; set; }
        public string Ngaysinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public KhachHang(string makh, string hokh, string tenkh,/* string ngaysinh,*/string diachi, string sdt, string email)
        {
            MaKH = makh;
            HoKH = hokh;
            TenKH = tenkh;
            //Ngaysinh = ngaysinh;
            DiaChi = diachi;
            SDT = sdt;
            Email = email;
        }
    }
}
