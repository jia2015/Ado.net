using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineStore.App_Code.DataProvider
{
    public static class ActivityDataProvider
    {
        public static DataTable GetActivities()
        {
            string query = string.Format("SELECT * FROM gather "+
                                        "ORDER BY gather.EndTime ASC");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                var reader = SqlHelper.ExecuteReader(conn, query);
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public static DataTable GetActivityByCategory(int cateID)
        {
            string query = string.Format("SELECT gather.* FROM gather WHERE gather.CateID = @id " +
                                        "ORDER BY gather.EndTime ASC");
            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = SqlHelper.CreateParameter(SqlDbType.Int, "@id", cateID);
                var reader = SqlHelper.ExecuteReader(conn, query, parameters);
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
    }
}