using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


namespace Youtube_Search
{

    public class ScheduledSearchResults
    {
        public int searchId;
        public DateTime searchDateTime;


    }


    public class BlackListedChannel
    {
        public string channelId;
        public DateTime addedTime;
        public bool exported;


    }

    public class SearchItem
    {

        public youtubeVideo youtubevideo;
        public YoutubeDataDetail youtubechannel;


    }

    public class youtubeVideo
    {

        public int id;
        public string keyword; 
        public string youtubeId;
        public string channelId;
        public string channelTitle;
        public string videoTitle;
        public string videoDescription;
        public double viewCount;
        public double likeCount;
        public double dislikeCount;
        public double favoriteCount;
        public double commentCount;
        public DateTime publishedAt;
        public string attribution="To Be Added";
        public bool copyright;

    }

    public class Channel
    {
        public int id;
        public string email;
        public string passwd;
        public string channelUrl;
        public string channelName;
        public string phoneNumbers;

    }

    public class YoutubeDataDetail
    {

        public double totalViewCount;
        public double totalVideoCount;
        public double totalSubscriber;
        public bool channelOpen;



    }

    public class ScheduledSearchParameter
    {
        public int filterDuration;
        public int channelSubsCountMin;
        public int channelSubsCountMax;
        public int channelVideoCountMin;
        public int channelVideoCountMax;
        public int maxresultCount;
        public int maxPageCount;
        public int sortBy;
        public DateTime publishedAfter;
        public DateTime publishedBefore;
        public string filterUploadDate;

    }

    public class VideoSearchParams
    {
        public bool searchAll;
        public string keyword;
        public List<string> favKeywords= new List<string> ();
        public DateTime publishedAfter;
        public bool publishedAfterSet = false;
        public DateTime publishedBefore;
        public bool publishedBeforeSet = false;
        public bool channelVideoCountMinSet = false;
        public bool channelVideoCountMaxSet = false;
        public int channelVideoCountMin;
        public int channelVideoCountMax;
        public bool channelSubsCountMinSet = false;
        public bool channelSubsCountMaxSet = false;
        public int channelSubsCountMin;
        public int channelSubsCountMax;
        public bool videoDurationSet = false;
        public int videoDuration;
        public bool maxResultCountSet=false;
        public int maxResultCount;
        public int maxPageCount;
        public bool videosSorted = false;
        public int videosSortOrder;







    }


    public class SearchUsingJson
    {

        string apiKey = ""; 
        
        public SearchUsingJson(string apiKey)
        {

            this.apiKey = apiKey;

        }
        
        //string apiKey = "AIzaSyAp_zo6weUkRV1OnVk8PgSsHTcpaRxobGw";//son key
        //string apiKey = "AIzaSyD4S570CpZn7-qTyS--YH_EjMPAoNSt3zo";


        //AIzaSyD4S570CpZn7-qTyS--YH_EjMPAoNSt3zo

        public List<string> getRecommendations(string keyword)
        {
            List<string> recommendations = new List<string>();

            System.Net.WebClient wc = new System.Net.WebClient();


            try
            {
                string a = wc.DownloadString("http://suggestqueries.google.com/complete/search?client=youtube&ds=yt&q=" + keyword);

                int startIndex = a.IndexOf(",[\"") + 1;
                int endIndex = a.IndexOf("]],") + 1;

                string b = a.Substring(startIndex, endIndex - startIndex);

                string[] c = Regex.Split(b, ",0]");

                foreach (string d in c)
                {
                    if (d.IndexOf('"') != -1)
                    {

                        int start = d.IndexOf("\"") + 1;
                        int end = d.IndexOf("\"", start);
                        string result = d.Substring(start, end - start);

                        recommendations.Add(result);
                    }

                }



                /*
                while (reader.Read())
                {

                    if (reader.Value != null)
                    {

                        if (reader.Value.ToString().Equals("viewCount"))
                        {
                            reader.Read();
                            //youtubedata.totalViewCount = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("subscriberCount"))
                        {
                            reader.Read();
                            //youtubedata.totalSubscriber = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("videoCount"))
                        {
                            reader.Read();
                            //youtubedata.totalVideoCount = Convert.ToInt32(reader.Value.ToString());

                        }

                    }
                }*/




            }
            catch (Exception e)
            {

            }

            return recommendations;




            /*
                        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "AIzaSyCmMzhe5Ljvuon9RPgWHjJDaLeS2TV7PeA",
                            ApplicationName = "API Project "
                        });

                        YouTubeService ytbs = new YouTubeService();
                        var channelListRequest = ytbs.Channels.List("'Statistics', Id:'UCNtUalxbIpgSNF2EBKCy2uw'");
                        */



        }


        public YoutubeDataDetail getChannelData(string channelName)
        {
            if (channelName.Equals("UCpEhnqL0y41EpW2TvWAHD7Q"))
            {


            }

            System.Net.WebClient wc = new System.Net.WebClient();

            YoutubeDataDetail youtubedata = new YoutubeDataDetail();
            youtubedata.channelOpen = true;

            try
            {

                string s = wc.DownloadString("https://www.googleapis.com/youtube/v3/channels?part=statistics&id=" + channelName + "&key=" + apiKey);

                if (s.Contains("\"totalResults\": 0,"))
                {
                    youtubedata.channelOpen = false;

                    return youtubedata;

                }


                JObject JObj = (JObject)JsonConvert.DeserializeObject(s);



                var entry = JObj["items"];

                JsonTextReader reader = new JsonTextReader(new StringReader(entry.ToString()));



                while (reader.Read())
                {

                    if (reader.Value != null)
                    {

                        if (reader.Value.ToString().Equals("viewCount"))
                        {
                            reader.Read();
                            youtubedata.totalViewCount = Convert.ToDouble(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("subscriberCount"))
                        {
                            reader.Read();
                            youtubedata.totalSubscriber = Convert.ToDouble(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("videoCount"))
                        {
                            reader.Read();
                            youtubedata.totalVideoCount = Convert.ToDouble(reader.Value.ToString());

                        }

                    }
                }




            }
            catch (Exception e)
            {
                string a = e.Message;
                //youtubedata.channelOpen = false;

                //return youtubedata;
            }

            return youtubedata;




            /*
                        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "AIzaSyCmMzhe5Ljvuon9RPgWHjJDaLeS2TV7PeA",
                            ApplicationName = "API Project "
                        });

                        YouTubeService ytbs = new YouTubeService();
                        var channelListRequest = ytbs.Channels.List("'Statistics', Id:'UCNtUalxbIpgSNF2EBKCy2uw'");
                        */



        }


        public youtubeVideo getVideoData(youtubeVideo youtubevideo)
        {



            System.Net.WebClient wc = new System.Net.WebClient();

            


            try
            {
                string b = "https://www.googleapis.com/youtube/v3/videos?id=" + youtubevideo.youtubeId + "&part=statistics,contentDetails,snippet,status&key=" + apiKey;
                string s = wc.DownloadString("https://www.googleapis.com/youtube/v3/videos?id=" + youtubevideo.youtubeId + "&part=statistics,contentDetails,snippet,status&key=" + apiKey);


                JObject jobject = JObject.Parse(s);

                JToken juser = jobject["items"];


                //string totalResults = (string)juser["items"]["id"];

                if (s.Contains("\"totalResults\": 0,"))
                {

                    /*
                    youtubedata.channelOpen = false;

                    return youtubedata;
                    */
                }


                JObject JObj = (JObject)JsonConvert.DeserializeObject(s);



                var entry = JObj["items"];

                JsonTextReader reader = new JsonTextReader(new StringReader(entry.ToString()));



                while (reader.Read())
                {

                    if (reader.Value != null)
                    {
                        if (reader.Value.ToString().Equals("licensedContent"))
                        {
                            reader.Read();
                            
                            //bool b = Convert.ToBoolean( reader.Value.ToString());

                            youtubevideo.copyright = Convert.ToBoolean(reader.Value.ToString()); 



                        }

                        //if (reader.Value.ToString().Equals("tags"))
                        //{
                        //    reader.Read();

                        //    string a = reader.Value.ToString();
                        //}

                        if (reader.Value.ToString().Equals("viewCount"))
                        {
                            reader.Read();
                            youtubevideo.viewCount = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("likeCount"))
                        {
                            reader.Read();
                            youtubevideo.likeCount = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("dislikeCount"))
                        {
                            reader.Read();
                            youtubevideo.dislikeCount = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("favoriteCount"))
                        {
                            reader.Read();
                            youtubevideo.favoriteCount = Convert.ToInt32(reader.Value.ToString());

                        }

                        if (reader.Value.ToString().Equals("commentCount"))
                        {
                            reader.Read();
                            youtubevideo.commentCount = Convert.ToInt32(reader.Value.ToString());

                        }





                    }
                }




            }
            catch (Exception e)
            {
                string a = e.Message;
                //youtubedata.channelOpen = false;

                //return youtubedata;
            }

            return youtubevideo;




            /*
                        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "AIzaSyCmMzhe5Ljvuon9RPgWHjJDaLeS2TV7PeA",
                            ApplicationName = "API Project "
                        });

                        YouTubeService ytbs = new YouTubeService();
                        var channelListRequest = ytbs.Channels.List("'Statistics', Id:'UCNtUalxbIpgSNF2EBKCy2uw'");
                        */



        }





    }
}
