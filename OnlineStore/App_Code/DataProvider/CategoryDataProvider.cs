using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineStore.App_Code.DataProvider
{
    public class CategoryDataProvider
    {
        public static DataTable GetCategories()
        {
            string query = string.Format("SELECT * FROM categories");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                var reader = SqlHelper.ExecuteReader(conn, query);
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
    }
}