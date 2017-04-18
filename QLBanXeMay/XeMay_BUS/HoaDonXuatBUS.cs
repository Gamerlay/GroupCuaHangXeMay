using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class HoaDonXuatBUS
    {
        public List<HoaDonXuat> GetHoaDonXuat(string sql)
        {

            return new HoaDonXuatDAO().GetHoaDonXuat(sql);

        }
        public int Add(HoaDonXuat emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.MaXuat == "")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new HoaDonXuatDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
