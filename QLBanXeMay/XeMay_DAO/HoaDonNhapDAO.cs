using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class HoaDonNhapDAO
    {
        private DataProvider dp;
        public HoaDonNhapDAO()
        {
            dp = new DataProvider();
        }
        public List<HoaDonNhap> GetHoaDonNhap(string sql)
        {
            dp.connect();
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            {
                int soluong, dongia;
                string manhap, manv, mancc, tenxe;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        manhap = dr.GetString(0);
                        manv = dr.GetString(1);
                        mancc = dr.GetString(2);
                        tenxe = dr.GetString(4);
                        soluong = dr.GetInt32(5);
                        dongia = dr.GetInt32(6);

                        HoaDonNhap em = new HoaDonNhap(manhap, manv, mancc, tenxe, soluong, dongia);
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
        public int Add(HoaDonNhap emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@manhap", emp.MaNhap));
            paras.Add(new SqlParameter("@manv", emp.MaNV));
            paras.Add(new SqlParameter("@mancc", emp.MaNCC));
            paras.Add(new SqlParameter("@tenxe", emp.TenXe));
            paras.Add(new SqlParameter("@soluong", emp.SoLuong));
            paras.Add(new SqlParameter("@dongia", emp.DonGia));
            try
            {
                return (dp.ExcuteNonQuery("ThemHoaDonNhap", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
