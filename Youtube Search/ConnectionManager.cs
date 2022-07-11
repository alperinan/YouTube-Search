using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Youtube_Search
{
    class ConnectionManager
    {

        public static SqlConnection GetSqlDatabaseConnection()
        {
            //string connectionString = "Server=WINDOWS-CRQT8RK\\SQLEXPRESS;Database=YoutubeSearch;Trusted_Connection=True;";
            string connectionString = "Server=ALPERINAN-PC\\SQLEXPRESS;Database=YoutubeSearch;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }






    }
}
