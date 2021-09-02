using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public sealed class SQLConnectionManager
    {
        //? Create and open the Database Connection
        public static SqlConnection CreateCon()
        {
            var Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                Conn.Open();
            }
            catch
            {
                throw;
            }

            return Conn;
        }

        //? Close the Database Connection
        public static void CloseConn(SqlConnection Conn)
        {
            if (Conn != null)
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                {
                    Conn.Close();
                }
                Conn.Dispose();
            }
        }
    }
}
