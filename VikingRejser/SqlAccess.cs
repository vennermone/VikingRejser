using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikingRejser
{
    internal class SqlAccess
    {
        SqlConnection connection = null;

        public SqlAccess()
        {
            Connect();
        }


        bool Connect()
        {
            string cs;
            cs = "Data Source=(localdb)\\MSSQLLocalDB;Database=VikingRejseData";

            connection = new SqlConnection();
            connection.ConnectionString = cs;
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;

        }
        public DataTable ExecuteSql(string sql)
        {
            // Open new connection.
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            // Create sql command.
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            // Exceute sql command
            DataTable table = ExecuteCmd(cmd);
            // Close the connetion.
            connection.Close();
            return table;
        }

        private DataTable ExecuteCmd(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            return table;
        }
    }

}
