using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Youtube_Search
{
    class DataAccess
    {
        public static void addNewBlackListChannel(string channelId)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_addNewBlackListChannel", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@channelId", SqlDbType.NVarChar).Value = channelId;
                command.Parameters.Add("@addedDateTime", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@exported", SqlDbType.Bit).Value = false;


                command.ExecuteNonQuery();

            }




        }

        public static void addNewKeyword(string newKeyword)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_addNewKeyword", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@newKeyword", SqlDbType.NVarChar).Value = newKeyword;


                command.ExecuteNonQuery();

            }




        }


        public static void deleteKeyword(string keywordToDelete)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_deleteKeyword", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@newKeyword", SqlDbType.NVarChar).Value = keywordToDelete;


                command.ExecuteNonQuery();

            }




        }


        public static bool checkIfKeywordExist(string keywordToFind)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_checkKeyword", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@newKeyword", SqlDbType.NVarChar).Value = keywordToFind;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;

                }else
                {
                    return false; 

                }

            }



        }

        public static bool checkIfChannelExist(string channelId)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_checkChannelExist", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@channelId", SqlDbType.NVarChar).Value = channelId;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;

                }
                else
                {
                    return false;

                }

            }



        }


        public static void deleteBlackListChannel(string channelId)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_deleteNewBlackListChannel", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@channelId", SqlDbType.NVarChar).Value = channelId;

                command.ExecuteNonQuery();

            }




        }

        public static void updateBlacklistChannel(string channelId, bool exported)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_updateBlackListChannel", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@channelId", SqlDbType.NVarChar).Value = channelId;
                command.Parameters.Add("@exported", SqlDbType.Bit).Value = exported;

                command.ExecuteNonQuery();

            }




        }


        public static List<string> getAllBlacklistedChannelIds()
        {
            List<string> blackListChannels = new List<string> ();
            

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllBlackListChannels", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    blackListChannels.Add( reader[0].ToString());
                    

                    

                }


            }

            return blackListChannels; 


        }



        public static List<BlackListedChannel> getAllBlacklistedChannels()
        {
            List<BlackListedChannel> blackListChannels = new List<BlackListedChannel>();


            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllBlackListChannels", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BlackListedChannel blacklistedchannel = new BlackListedChannel();

                    blacklistedchannel.channelId = reader[0].ToString();
                    blacklistedchannel.addedTime = DateTime.Parse(reader[1].ToString());
                    blacklistedchannel.exported = Convert.ToBoolean(reader[2]);

                    blackListChannels.Add(blacklistedchannel);


                }


            }

            return blackListChannels;


        }


        public static List<string> getAllKeywords()
        {
            List<string> blackListChannels = new List<string>();


            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllKeywords", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    blackListChannels.Add(reader[0].ToString());

                }


            }

            return blackListChannels;


        }


    }
}
