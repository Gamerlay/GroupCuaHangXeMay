using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class XeTrongCuaHangBUS
    {
        public List<XeTrongCuaHang> GetXeTrongCuaHang(string sql)
        {

            return new XeTrongCuaHangDAO().GetXeTrongCuaHang(sql);

        }
        public int Add(XeTrongCuaHang emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.MaXe == "")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new XeTrongCuaHangDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
