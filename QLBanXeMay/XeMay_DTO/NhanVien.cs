using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace XeMay_DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        //public string Ngaysinh { get; set; }
        public string GioiTinh { get; set; }
        public int Luong { get; set; }
        public string ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public NhanVien(string manv, string honv, string tennv,/*, string ngaysinh,*/ string gioitinh, int luong, string chucvu, string diachi, string sdt, string email)
        {
            MaNV = manv;
            HoNV = honv;
            TenNV = tennv;
            //Ngaysinh = ngaysinh;
            GioiTinh = gioitinh;
            Luong = luong;
            ChucVu = chucvu;
            DiaChi = diachi;
            SDT = sdt;
            Email = email;
        }
    }
}
