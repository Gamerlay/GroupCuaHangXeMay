using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;
namespace XeMay_BUS
{
    public class AccountBUS
    {
        public List<Account> GetAccount(string sql)
        {

            return new AccountDAO().GetAccount(sql);

        }
        public int Add(Account emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.UserName == "" || emp.Password == "")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new AccountDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
