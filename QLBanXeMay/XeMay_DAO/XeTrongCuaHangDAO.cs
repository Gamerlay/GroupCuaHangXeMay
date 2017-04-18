using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class XeTrongCuaHangDAO
    {
        private DataProvider dp;
        public XeTrongCuaHangDAO()
        {
            dp = new DataProvider();
        }
        public List<XeTrongCuaHang> GetXeTrongCuaHang(string sql)
        {
            dp.connect();
            List<XeTrongCuaHang> list = new List<XeTrongCuaHang>();
            {
                string maxe, manhap, maxuat, tenxe;
                int dongianhap, dongiaxuat;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        maxe = dr.GetString(0);
                        manhap = dr.GetString(1);
                        maxuat = dr.GetString(2);
                        tenxe = dr.GetString(3);
                        dongianhap = dr.GetInt32(4);
                        dongiaxuat = dr.GetInt32(5);

                        XeTrongCuaHang em = new XeTrongCuaHang(maxe, manhap, maxuat, tenxe, dongianhap, dongiaxuat);
                        list.Add(em);
                    }
                    dr.Close();
                    return list;
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
                finally { dp.disconnect(); }
            }
        }
        public int Add(XeTrongCuaHang emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@maxe", emp.MaXe));
            paras.Add(new SqlParameter("@manhap", emp.MaNhap));
            paras.Add(new SqlParameter("@maxuat", emp.MaXuat));
            paras.Add(new SqlParameter("@tenxe", emp.TenXe));
            paras.Add(new SqlParameter("@dongianhap", emp.DonGiaNhap));
            paras.Add(new SqlParameter("@dongiaxuat", emp.DonGiaXuat));
            try
            {
                return (dp.ExcuteNonQuery("ThemXeTrongCuaHang", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
