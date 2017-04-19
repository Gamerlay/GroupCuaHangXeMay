using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
namespace XeMay_DAO
{
    public class AccountDAO
    {
        private DataProvider dp;
        public AccountDAO()
        {
            dp = new DataProvider();
        }
        public List<Account> GetAccount(string sql)
        {
            dp.connect();
            List<Account> list = new List<Account>();
            {
                string user, pass;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        user = dr.GetString(0);
                        pass = dr.GetString(1);

                        Account em = new Account(user, pass);
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
        public int Add(Account emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@user", emp.UserName));
            paras.Add(new SqlParameter("@pass", emp.Password));

            try
            {
                return (dp.ExcuteNonQuery("ThemAccount", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
