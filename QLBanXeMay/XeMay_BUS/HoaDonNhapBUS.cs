using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class HoaDonNhapBUS
    {
        public List<HoaDonNhap> GetHoaDonNhap(string sql)
        {

            return new HoaDonNhapDAO().GetHoaDonNhap(sql);

        }
        public int Add(HoaDonNhap emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.MaNhap == "")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new HoaDonNhapDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
