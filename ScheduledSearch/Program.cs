using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeFunctions;
using System.Collections;
using System.Text.RegularExpressions;
using Youtube_Search;

namespace ScheduledSearch
{
    class Program
    {

        static void Main(string[] args)
        {
            ArrayList finalResults = searchAllKeywords(); 

            if (finalResults.Count>0)
            {
                //let's create a new search


                int newSearchId = DataAccess.addNewSearch();

                List<string> blackListedChannels = DataAccess.getAllBlacklistedChannelIds();
                List<string> addedChannels = new List<string>();

                foreach (SearchItem sitem in finalResults)
                {

                    bool channelAdded = channelBlackListed(sitem.youtubevideo.channelId, addedChannels);

                    if (!channelBlackListed(sitem.youtubevideo.channelId, blackListedChannels) && !channelAdded)
                    {

                        DataAccess.addNewSearchDetail(sitem, newSearchId);

                        addedChannels.Add(sitem.youtubevideo.channelId);

                    }





                }


                //foreach (SearchItem sitem in finalResults)
                //{

                //    DataAccess.addNewSearchDetail(sitem, newSearchId); 



                //}


            }

        }

        private static ArrayList searchAllKeywords()
        {
            Stack<string> apiKeys = new Stack<string>();

            List<string> apiKeysFromDb = DataAccess.getApiKeys();

            foreach (string a in apiKeysFromDb)
            {

                apiKeys.Push(a);
                

            }

            string currentKey = apiKeys.Pop();

            VideoSearchParams vparams = getSearchParameters(); 

            ArrayList searchResults = new ArrayList();

            string searchingFor = ""; 
            //let's do the search
            //but we will search all or some ?

            ArrayList filteredSearchResults = new ArrayList();


            foreach (string keywordToSearch in vparams.favKeywords)
            {

                try
                {
                    vparams.keyword = keywordToSearch;
                    searchingFor = keywordToSearch;


                    SearchYoutube sytube = new SearchYoutube(currentKey);

                    searchResults = sytube.performVideoSearchArrayWithParameters(vparams);



                    if (vparams.channelSubsCountMinSet || vparams.channelSubsCountMaxSet || vparams.channelVideoCountMaxSet || vparams.channelVideoCountMinSet)
                    {
                        int i = 0;

                        foreach (youtubeVideo yvideo in searchResults)
                        {


                            SearchUsingJson susingJson = new SearchUsingJson(currentKey);

                            YoutubeDataDetail channelDetail = susingJson.getChannelData(yvideo.channelId);

                            bool toBeAdded = true;

                            if (vparams.channelSubsCountMinSet)
                            {
                                if (channelDetail.totalSubscriber < vparams.channelSubsCountMin)
                                {

                                    toBeAdded = false;
                                }



                            }


                            if (vparams.channelSubsCountMaxSet)
                            {
                                if (channelDetail.totalSubscriber > vparams.channelSubsCountMax)
                                {

                                    toBeAdded = false;
                                }



                            }


                            if (vparams.channelVideoCountMinSet)
                            {
                                if (channelDetail.totalVideoCount < vparams.channelVideoCountMin)
                                {

                                    toBeAdded = false;
                                }



                            }



                            if (vparams.channelVideoCountMaxSet)
                            {
                                if (channelDetail.totalVideoCount > vparams.channelVideoCountMax)
                                {

                                    toBeAdded = false;
                                }



                            }



                            if (toBeAdded)
                            {
                                SearchItem sitem = new SearchItem();

                                sitem.youtubechannel = channelDetail;
                                sitem.youtubevideo = yvideo;
                                sitem.youtubevideo.keyword = searchingFor;

                                filteredSearchResults.Add(sitem);


                            }


                            i++;

                            int progressPerc = (i / searchResults.Count) * 100;


                        }


                    }
                    else
                    {
                        int i = 0;

                        foreach (youtubeVideo yvideo in searchResults)
                        {


                            SearchUsingJson susingJson = new SearchUsingJson(currentKey);

                            YoutubeDataDetail channelDetail = susingJson.getChannelData(yvideo.channelId);

                            SearchItem sitem = new SearchItem();
                            sitem.youtubevideo = yvideo;
                            sitem.youtubechannel = channelDetail;
                            sitem.youtubevideo.keyword = searchingFor;
                            filteredSearchResults.Add(sitem);

                            i++;

                            int progressPerc = (i * 100) / searchResults.Count;




                        }

                        searchResults = null;
                    }
                }
                catch (Exception ex)
                {
                    if (apiKeys.Count>0)
                    {
                        currentKey = apiKeys.Pop();
                    }
                    else
                    {
                        break;
                    }

                }

            }



            return filteredSearchResults; 




        }

        private static bool channelBlackListed(string channelId, List<string> blackListedChannels)
        {
            bool returnValue = false;

            if (blackListedChannels.Exists(e => e.EndsWith(channelId)))

            {

                return true;

            }







            return returnValue;
        }

        public static VideoSearchParams getSearchParameters()
        {
            VideoSearchParams vparams = new VideoSearchParams();

            vparams.searchAll = true;

            vparams.favKeywords = DataAccess.getAllKeywords();


            ScheduledSearchParameter sparameter = DataAccess.getScheduledSearchParameter(); 

            if (!sparameter.filterUploadDate.Equals("None"))
            {
                //something is definitely set, let's see which one
                if (sparameter.filterUploadDate.Equals("radio1Hour"))
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = DateTime.Now.AddHours(-1);

                }

                if (sparameter.filterUploadDate.Equals("radioToday"))
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = DateTime.Today;

                }


                if (sparameter.filterUploadDate.Equals("radioThisWeek"))
                {

                    vparams.publishedAfterSet = true;

                    DayOfWeek doftheweek = DateTime.Now.DayOfWeek;

                    switch (doftheweek.ToString())
                    {
                        case "Monday":

                            vparams.publishedAfter = DateTime.Today;

                            break;


                        case "Tuesday":

                            vparams.publishedAfter = DateTime.Today.AddDays(-1);
                            break;


                        case "Wednesday":

                            vparams.publishedAfter = DateTime.Today.AddDays(-2);

                            break;


                        case "Thursday":

                            vparams.publishedAfter = DateTime.Today.AddDays(-3);

                            break;


                        case "Friday":

                            vparams.publishedAfter = DateTime.Today.AddDays(-4);

                            break;


                        case "Saturday":
                            vparams.publishedAfter = DateTime.Today.AddDays(-5);

                            break;


                        case "Sunday":
                            vparams.publishedAfter = DateTime.Today.AddDays(-6);
                            break;

                    }

                    //MessageBox.Show( vparams.publishedAfter.ToString());

                }


                if (sparameter.filterUploadDate.Equals("radioThisMonth"))
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                }

                if (sparameter.filterUploadDate.Equals("radioThisYear"))
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = new DateTime(DateTime.Now.Year, 1, 1);

                }

                if (sparameter.filterUploadDate.Equals("radioCustom"))
                {
                    if (sparameter.publishedAfter != new DateTime(1800, 1, 1))
                    {
                        vparams.publishedAfterSet = true;
                        vparams.publishedAfter = sparameter.publishedAfter;

                    }

                    if (sparameter.publishedBefore != new DateTime(1800, 1, 1))
                    {
                        vparams.publishedBeforeSet = true;
                        vparams.publishedBefore = sparameter.publishedBefore;


                    }


                }





            }




            if (sparameter.filterDuration!=-1)
            {

                vparams.videoDurationSet = true;

                vparams.videoDuration = sparameter.filterDuration;


            }

            //channel filters

            if (sparameter.channelSubsCountMin!=0 || sparameter.channelSubsCountMax!=0)
            {




                if (sparameter.channelSubsCountMin != 0)
                {
                    vparams.channelSubsCountMin = sparameter.channelSubsCountMin;
                    vparams.channelSubsCountMinSet = true;

                }


                if (sparameter.channelSubsCountMax!=0)
                {
                    vparams.channelSubsCountMax = sparameter.channelSubsCountMax;
                    vparams.channelSubsCountMaxSet = true;
                }


            }

            if (sparameter.channelVideoCountMin!=0 || sparameter.channelVideoCountMax!=0)
            {




                if (sparameter.channelVideoCountMin != 0)
                {
                    vparams.channelVideoCountMin = sparameter.channelVideoCountMin;
                    vparams.channelVideoCountMinSet = true;
                }


                if (sparameter.channelVideoCountMax != 0)
                {
                    vparams.channelVideoCountMax = sparameter.channelVideoCountMax;
                    vparams.channelVideoCountMaxSet = true;
                }


            }

            vparams.maxResultCountSet = true;

            vparams.maxResultCount = sparameter.maxresultCount;

            vparams.maxPageCount = sparameter.maxPageCount;

            if (sparameter.sortBy!= -1)
            {

                vparams.videosSorted = true;
                vparams.videosSortOrder = sparameter.sortBy;


            }

            return vparams;




        }





    }
}
