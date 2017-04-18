using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class HoaDonXuatDAO
    {
        private DataProvider dp;
        public HoaDonXuatDAO()
        {
            dp = new DataProvider();
        }
        public List<HoaDonXuat> GetHoaDonXuat(string sql)
        {
            dp.connect();
            List<HoaDonXuat> list = new List<HoaDonXuat>();
            {
                int soluong, dongia;
                string maxuat, manv, makh, tenxe;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        maxuat = dr.GetString(0);
                        manv = dr.GetString(1);
                        makh = dr.GetString(2);
                        tenxe = dr.GetString(4);
                        soluong = dr.GetInt32(5);
                        dongia = dr.GetInt32(6);

                        HoaDonXuat em = new HoaDonXuat(maxuat, manv, makh, tenxe, soluong, dongia);
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
        public int Add(HoaDonXuat emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@maxuat", emp.MaXuat));
            paras.Add(new SqlParameter("@manv", emp.MaNV));
            paras.Add(new SqlParameter("@makh", emp.MaKH));
            paras.Add(new SqlParameter("@tenxe", emp.TenXe));
            paras.Add(new SqlParameter("@soluong", emp.SoLuong));
            paras.Add(new SqlParameter("@dongia", emp.DonGia));
            try
            {
                return (dp.ExcuteNonQuery("ThemHoaDonXuat", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
