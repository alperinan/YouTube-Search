using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.IO;

using System.Reflection;
using System.Threading;
using System.Collections;


namespace Youtube_Search
{
    public class SearchYoutube
    {
        string youtubeKey = "";

        //string youtubeKey = "AIzaSyAp_zo6weUkRV1OnVk8PgSsHTcpaRxobGw";//enson key
        //string youtubeKey = "AIzaSyD4S570CpZn7-qTyS--YH_EjMPAoNSt3zo";
        
        public SearchYoutube(string youtubeKey)
        {

            this.youtubeKey = youtubeKey;

        }



        public string performVideoSearch(string keyword)

        {

            string returnString = ""; 

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = youtubeKey,
                ApplicationName = this.GetType().ToString()
            });
            
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 50;
            

            searchListRequest.PublishedAfter = DateTime.Now.AddDays(-2); 

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;

                    case "youtube#channel":
                        channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        break;

                    case "youtube#playlist":
                        playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        break;
                }
            }

            returnString = String.Format("Videos:\n{0}\n", string.Join("\n", videos));
            //Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

            return returnString;


        }



        public ArrayList performVideoSearchArray(string keyword)

        {

            ArrayList returnArray  = new ArrayList ();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = youtubeKey,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 50;
            
            //searchListRequest.PublishedAfter = DateTime.Now.AddDays(-2);

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {

                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":

                        youtubeVideo yvideo = new youtubeVideo();

                        yvideo.channelId = searchResult.Snippet.ChannelId;
                        yvideo.channelTitle = searchResult.Snippet.ChannelTitle;                       
                        yvideo.videoDescription = searchResult.Snippet.Description;
                        yvideo.videoTitle = searchResult.Snippet.Title;
                        yvideo.youtubeId= searchResult.Id.VideoId;
                        yvideo.publishedAt = Convert.ToDateTime( searchResult.Snippet.PublishedAt); 

                        returnArray.Add(yvideo);

                        break;


                }
            }



            return returnArray;


        }



        public ArrayList performVideoSearchArrayWithParameters(VideoSearchParams vparams)

        {

            ArrayList returnArray = new ArrayList();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = youtubeKey,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");

            searchListRequest.Q = vparams.keyword; // Replace with your search term.

            searchListRequest.MaxResults = vparams.maxResultCount;

            searchListRequest.Type = "video";

            if (vparams.publishedAfterSet)
            {
                searchListRequest.PublishedAfter = vparams.publishedAfter;
            }

            if (vparams.publishedBeforeSet)
            {
                searchListRequest.PublishedBefore = vparams.publishedBefore;
            }

            if (vparams.videoDurationSet)
            {


                switch(vparams.videoDuration)
                {
                    case 0:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Short__;

                        break;

                    case 1:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Medium;
                        break;

                    case 2:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Long__;
                        break;


                }



            }

            if (vparams.videosSorted)
            {
                
                switch (vparams.videosSortOrder)
                {
                    case 0:
                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.ViewCount;
                        break;

                    case 1:

                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
                        break;

                    case 2:
                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Rating;


                        break;


                }


                

            }


            //searchListRequest.PublishedAfter = DateTime.Now.AddDays(-2);
                        string apiKey = DataAccess.getApiKey();


            for (int i = 0; i < vparams.maxPageCount; i++)
            {

                
                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = searchListRequest.Execute();             

                if (i != 0)
                    searchListRequest.PageToken = searchListResponse.NextPageToken;
               

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {

                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            
                            youtubeVideo yvideo = new youtubeVideo();

                            yvideo.channelId = searchResult.Snippet.ChannelId;
                            yvideo.channelTitle = searchResult.Snippet.ChannelTitle;
                            yvideo.videoDescription = searchResult.Snippet.Description;
                            yvideo.videoTitle = searchResult.Snippet.Title;
                            yvideo.youtubeId = searchResult.Id.VideoId;
                            yvideo.publishedAt = Convert.ToDateTime(searchResult.Snippet.PublishedAt);


                            SearchUsingJson sjson = new SearchUsingJson(apiKey);

                            yvideo = sjson.getVideoData(yvideo);

                            returnArray.Add(yvideo);

                            break;


                    }
                }
            }


            return returnArray;


        }



        public ArrayList performVideoSearchArrayWithParametersWithNextPageToken(VideoSearchParams vparams, string nextPageToken)

        {

            ArrayList returnArray = new ArrayList();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = youtubeKey,
                ApplicationName = this.GetType().ToString()
            });


            var searchListRequest = youtubeService.Search.List("snippet");

            searchListRequest.Q = vparams.keyword; // Replace with your search term.

            searchListRequest.MaxResults = vparams.maxResultCount;

            searchListRequest.Type = "video";

            if (vparams.publishedAfterSet)
            {
                searchListRequest.PublishedAfter = vparams.publishedAfter;
            }

            if (vparams.publishedBeforeSet)
            {
                searchListRequest.PublishedBefore = vparams.publishedBefore;
            }

            if (vparams.videoDurationSet)
            {


                switch (vparams.videoDuration)
                {
                    case 0:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Short__;

                        break;

                    case 1:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Medium;
                        break;

                    case 2:
                        searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Long__;
                        break;


                }



            }

            if (vparams.videosSorted)
            {

                switch (vparams.videosSortOrder)
                {
                    case 0:
                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.ViewCount;
                        break;

                    case 1:

                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
                        break;

                    case 2:
                        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Rating;


                        break;


                }




            }


            //searchListRequest.PublishedAfter = DateTime.Now.AddDays(-2);

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();


            

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            string apiKey = DataAccess.getApiKey();


            foreach (var searchResult in searchListResponse.Items)
            {

                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":

                        youtubeVideo yvideo = new youtubeVideo();

                        yvideo.channelId = searchResult.Snippet.ChannelId;
                        yvideo.channelTitle = searchResult.Snippet.ChannelTitle;
                        yvideo.videoDescription = searchResult.Snippet.Description;
                        yvideo.videoTitle = searchResult.Snippet.Title;
                        yvideo.youtubeId = searchResult.Id.VideoId;
                        yvideo.publishedAt = Convert.ToDateTime(searchResult.Snippet.PublishedAt);

                        SearchUsingJson sjson = new SearchUsingJson(apiKey);

                        yvideo = sjson.getVideoData(yvideo);

                        returnArray.Add(yvideo);

                        break;


                }
            }



            return returnArray;


        }




    }








}



