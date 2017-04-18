using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;
namespace XeMay_BUS
{
    public class NhanVienBUS
    {
        public List<NhanVien> GetNhanVien(string sql)
        {

            return new NhanVienDAO().GetNhanVien(sql);

        }
        public int Add(NhanVien emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.HoNV == " " || emp.TenNV == " ")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }

            try
            {
                return (new NhanVienDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}