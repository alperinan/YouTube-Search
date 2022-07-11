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
            //string connectionString = "Server=B2\\SQLEXPRESS;Database=YoutubeSearch2;Trusted_Connection=True;";
            //string connectionString = "Server=DESKTOP-GHPI2JI\\SQLEXPRESS;Database=ysearch;Trusted_Connection=True;";
             string connectionString = "Server=ALPERINAN-PC\\SQLEXPRESS;Database=YoutubeSearch;Trusted_Connection=True;";
            //string connectionString = "Server=DESKTOP-CP7JD5Q\\SQLEXPRESS;Database=YoutubeSearch2;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }






    }
}
