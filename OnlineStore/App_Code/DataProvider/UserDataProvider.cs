using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OnlineStore.Models;
using OnlineStore.ViewModels;

namespace OnlineStore.App_Code.DataProvider
{
    public static class UserDataProvider
    {
        public static bool CreateUser(AccountModel user)
        {
            string query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}')", user.Username, user.Password, "RegularUser");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                var result = SqlHelper.ExecuteNonQuery(conn, query);
                return (result == 1);
            }
        }

        public static bool ExistsUser(AccountModel user)
        {
            string query = string.Format("SELECT count(Username) from users WHERE Username = @username");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = SqlHelper.CreateParameter(SqlDbType.VarChar, "@username", user.Username);
                var result = SqlHelper.ExecuteScalar(conn, query, parameters);
                return Convert.ToBoolean(result);
            }
        }

        public static bool ExistsUser(AccountVM user)
        {
            string query = string.Format("SELECT count(Username) from users WHERE Username = @username");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = SqlHelper.CreateParameter(SqlDbType.VarChar, "@username", user.Account.Username);
                var result = SqlHelper.ExecuteScalar(conn, query, parameters);
                return Convert.ToBoolean(result);
            }
        }

        

        public static bool EditUser(AccountModel user)
        {
            return true;
        }

    }
}
