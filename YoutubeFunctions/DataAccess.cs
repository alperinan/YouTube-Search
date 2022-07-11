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
    public class DataAccess
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

        public static int addNewSearch()
        {
            int returnValue = -1;

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_AddNewSearch", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@seachDateTime", SqlDbType.DateTime).Value = DateTime.Now;

                SqlParameter param = new SqlParameter("@searchId", 0);
                param.Direction = ParameterDirection.Output;
                param.DbType = DbType.Int32;

                command.Parameters.Add(param);

                command.ExecuteNonQuery();

                returnValue = Convert.ToInt32(command.Parameters["@searchId"].Value.ToString());

            }

            return returnValue;


        }

        public static void addNewSearchDetail(SearchItem sitem, int searchId)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_AddNewSearchDetail", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@searchId", SqlDbType.Int).Value = searchId;
                command.Parameters.Add("@videoId", SqlDbType.NVarChar).Value = sitem.youtubevideo.youtubeId;
                command.Parameters.Add("@videoTitle", SqlDbType.NVarChar).Value = sitem.youtubevideo.videoTitle;
                command.Parameters.Add("@videoViewCount", SqlDbType.Float).Value = sitem.youtubevideo.viewCount;
                command.Parameters.Add("@videoLikeCount", SqlDbType.Float).Value = sitem.youtubevideo.likeCount;
                command.Parameters.Add("@publishedAt", SqlDbType.DateTime).Value = sitem.youtubevideo.publishedAt;
                command.Parameters.Add("@channelId", SqlDbType.NVarChar).Value = sitem.youtubevideo.channelId;
                command.Parameters.Add("@totalVideoCount", SqlDbType.Float).Value = sitem.youtubechannel.totalVideoCount;
                command.Parameters.Add("@totalViewCount", SqlDbType.Float).Value = sitem.youtubechannel.totalViewCount;
                command.Parameters.Add("@totalSubscriber", SqlDbType.Float).Value = sitem.youtubechannel.totalSubscriber;
                command.Parameters.Add("@keyword", SqlDbType.NVarChar).Value = sitem.youtubevideo.keyword;
                command.Parameters.Add("@attribution", SqlDbType.NVarChar).Value = sitem.youtubevideo.attribution;

                command.ExecuteNonQuery();

            }





        }

        public static ArrayList getSearchDetailBySearchId(int searchId)
        {

            ArrayList returnArray = new ArrayList(); 

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getSearchResultsBySearchId", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@searchId", SqlDbType.Int).Value = searchId;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SearchItem sitem = new SearchItem();
                    sitem.youtubevideo = new youtubeVideo();
                    sitem.youtubechannel = new YoutubeDataDetail(); 

                    sitem.youtubevideo.youtubeId = reader[2].ToString(); 
                    sitem.youtubevideo.videoTitle = reader[3].ToString();
                    sitem.youtubevideo.viewCount = Convert.ToDouble( reader[4].ToString());
                    sitem.youtubevideo.likeCount = Convert.ToDouble(reader[5].ToString());
                    sitem.youtubevideo.publishedAt = Convert.ToDateTime(reader[6].ToString());
                    sitem.youtubevideo.channelId = reader[7].ToString();
                    sitem.youtubechannel.totalVideoCount = Convert.ToDouble(reader[8].ToString());
                    sitem.youtubechannel.totalViewCount = Convert.ToDouble(reader[9].ToString());
                    sitem.youtubechannel.totalSubscriber = Convert.ToDouble(reader[10].ToString());
                    sitem.youtubevideo.keyword = reader[11].ToString();
                    sitem.youtubevideo.attribution = reader[12].ToString();

                    returnArray.Add(sitem);



                }

            }


            return returnArray;
        }


        public static ArrayList getSearchResultsForAttribution()
        {

            ArrayList returnArray = new ArrayList();

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getSearchResultsForAttribution", connection);

                command.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SearchItem sitem = new SearchItem();
                    sitem.youtubevideo = new youtubeVideo();
                    sitem.youtubechannel = new YoutubeDataDetail();

                    sitem.youtubevideo.youtubeId = reader[2].ToString();
                    sitem.youtubevideo.videoTitle = reader[3].ToString();
                    sitem.youtubevideo.viewCount = Convert.ToDouble(reader[4].ToString());
                    sitem.youtubevideo.likeCount = Convert.ToDouble(reader[5].ToString());
                    sitem.youtubevideo.publishedAt = Convert.ToDateTime(reader[6].ToString());
                    sitem.youtubevideo.channelId = reader[7].ToString();
                    sitem.youtubechannel.totalVideoCount = Convert.ToDouble(reader[8].ToString());
                    sitem.youtubechannel.totalViewCount = Convert.ToDouble(reader[9].ToString());
                    sitem.youtubechannel.totalSubscriber = Convert.ToDouble(reader[10].ToString());
                    sitem.youtubevideo.keyword = reader[11].ToString();
                    sitem.youtubevideo.attribution = reader[12].ToString();

                    returnArray.Add(sitem);



                }

            }


            return returnArray;
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


        public static void updateSearchAttribution(string attribution, string videoId)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_updateAttributionBySearchId", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@attribution", SqlDbType.NVarChar).Value = attribution;
                command.Parameters.Add("@videoId", SqlDbType.NVarChar).Value = videoId;


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

        public static void setApiKey(string apiKey)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_setApiKey", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@apiKey", SqlDbType.NVarChar).Value = apiKey;

                command.ExecuteNonQuery(); 

            }



        }


        public static void deleteApiKey(string apiKey)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_DeleteApiKey", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@apiKey", SqlDbType.NVarChar).Value = apiKey;

                command.ExecuteNonQuery();

            }



        }

        public static void addApiKey(string apiKey)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_AddApiKey", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@apiKey", SqlDbType.NVarChar).Value = apiKey;

                command.ExecuteNonQuery();

            }



        }

        public static string getApiKey()
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllAppParams", connection);

                command.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                return reader[0].ToString(); 

            }



        }

        public static List<string> getApiKeys()
        {

            List<string> returnList = new List<string>();

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllAppParams", connection);

                command.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    returnList.Add(reader[0].ToString());

                }


            }

            return returnList;

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

        public static void deleteFilters()
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_deleteSearchFilter", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.ExecuteNonQuery();

            }




        }

        public static void addNewFilter(int filterDuration, int channelSubsCountMin, int channelSubsCountMax, int channelVideoCountMin, int channelVideoCountMax,
int maxresultCount, int maxPageCount, int sortBy, DateTime publishedAfter, DateTime publishedBefore, string filterUploadDate)
        {

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_addNewFilter", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@filterDuration", SqlDbType.Int).Value = filterDuration;
                command.Parameters.Add("@channelSubsCountMin", SqlDbType.Int).Value = channelSubsCountMin;
                command.Parameters.Add("@channelSubsCountMax", SqlDbType.Int).Value = channelSubsCountMax;
                command.Parameters.Add("@channelVideoCountMin", SqlDbType.Int).Value = channelVideoCountMin;
                command.Parameters.Add("@channelVideoCountMax", SqlDbType.Int).Value = channelVideoCountMax;
                command.Parameters.Add("@maxresultCount", SqlDbType.Int).Value = maxresultCount;
                command.Parameters.Add("@maxPageCount", SqlDbType.Int).Value = maxPageCount;
                command.Parameters.Add("@sortBy", SqlDbType.Int).Value = sortBy;
                command.Parameters.Add("@publishedAfter", SqlDbType.DateTime).Value = publishedAfter;
                command.Parameters.Add("@publishedBefore", SqlDbType.DateTime).Value = publishedBefore;
                command.Parameters.Add("@filterUploadDate", SqlDbType.NVarChar).Value = filterUploadDate;

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



        public static List<ScheduledSearchResults> getAllScheduledSearchResults()
        {
            List<ScheduledSearchResults> scheduledSearchResults = new List<ScheduledSearchResults>();


            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllSearchResults", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ScheduledSearchResults sresult = new ScheduledSearchResults();

                    sresult.searchId = Convert.ToInt32(reader[0].ToString());
                    sresult.searchDateTime = Convert.ToDateTime(reader[1].ToString());

                    scheduledSearchResults.Add(sresult);


                }


            }

            return scheduledSearchResults;


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



        public static ScheduledSearchParameter getScheduledSearchParameter()
        {

            ScheduledSearchParameter sparameter = new ScheduledSearchParameter(); 

            using (SqlConnection connection = ConnectionManager.GetSqlDatabaseConnection())
            {


                SqlCommand command = new SqlCommand("sp_getAllSearchFilters", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    sparameter.filterDuration= Convert.ToInt32(reader[0].ToString());
                    sparameter.channelSubsCountMin = Convert.ToInt32(reader[1].ToString());
                    sparameter.channelSubsCountMax = Convert.ToInt32(reader[2].ToString());
                    sparameter.channelVideoCountMin = Convert.ToInt32(reader[3].ToString());
                    sparameter.channelVideoCountMax = Convert.ToInt32(reader[4].ToString());
                    sparameter.maxresultCount = Convert.ToInt32(reader[5].ToString());
                    sparameter.maxPageCount = Convert.ToInt32(reader[6].ToString());
                    sparameter.sortBy = Convert.ToInt32(reader[7].ToString());
                    sparameter.publishedAfter = Convert.ToDateTime(reader[8].ToString());
                    sparameter.publishedBefore = Convert.ToDateTime(reader[9].ToString());
                    sparameter.filterUploadDate = reader[10].ToString();



                }


            }

            return sparameter;


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
