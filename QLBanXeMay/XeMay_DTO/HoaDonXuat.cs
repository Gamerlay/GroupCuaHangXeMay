using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class HoaDonXuat
    {
        public string MaXuat { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string NgayXuat { get; set; }
        public string TenXe { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public HoaDonXuat(string maxuat, string manv, string makh, /*string ngayxuat,*/ string tenxe, int soluong, int dongia)
        {
            MaXuat = maxuat;
            MaNV = manv;
            MaKH = makh;
            // NgayXuat = ngayxuat;
            TenXe = tenxe;
            SoLuong = soluong;
            DonGia = dongia;
        }
    }
}
