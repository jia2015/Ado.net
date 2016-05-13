using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OnlineStore.App_Code
{
    public abstract class SqlHelper
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["GroupbuyDBconnection"].ToString();

        public static DataSet dataset = new DataSet();

        //public static SqlConnection GetConnection()
        //{
        //    return new SqlConnection(connectionString);
        //}

        public static SqlParameter CreateParameter(SqlDbType type, string name, object value)
        {
            return new SqlParameter()
            {
                SqlDbType = type,
                ParameterName = name,
                Value = value
            };
        }

        public static SqlDataReader ExecuteReader(SqlConnection conn, string commandText)
        {
            return ExecuteReader(conn, commandText, null);
        }

        public static SqlDataReader ExecuteReader(SqlConnection conn, string commandText, SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return reader;
                }
            }
            return null;
        }

        public static DataSet ExecuteAdapter(SqlConnection conn, string commandText)
        {
            return ExecuteAdapter(conn, commandText, null);
        }

        public static DataSet ExecuteAdapter(SqlConnection conn, string commandText, SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataset);
                    return dataset;
                }
            }
            return null;
        }

        public static int ExecuteNonQuery(SqlConnection conn, string commandText)
        {
            return ExecuteNonQuery(conn, commandText, null);
        }

        public static int ExecuteNonQuery(SqlConnection conn, string commandText, SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            return 0;
        }

        public static int ExecuteScalar(SqlConnection conn, string commandText)
        {
            return ExecuteScalar(conn, commandText, null);
        }

        public static int ExecuteScalar(SqlConnection conn, string commandText, SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return (int)cmd.ExecuteScalar();
                }
            }
            return 0;
        }

    }
}
