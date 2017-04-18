using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class HoaDonNhap
    {
        public string MaNhap { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public string NgayNhap { get; set; }
        public string TenXe { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public HoaDonNhap(string manhap, string manv, string mancc/*, string ngaynhap*/, string tenxe, int soluong, int dongia)
        {
            MaNhap = manhap;
            MaNV = manv;
            MaNCC = mancc;
            // NgayNhap = ngaynhap;
            TenXe = tenxe;
            SoLuong = soluong;
            DonGia = dongia;
        }
    }
}
