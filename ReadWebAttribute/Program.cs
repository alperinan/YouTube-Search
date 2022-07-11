using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Youtube_Search;

namespace ReadWebAttribute
{
    class Program
    {
        static void Main(string[] args)
        {


            ArrayList toBeFilled = DataAccess.getSearchResultsForAttribution();

            

            foreach (SearchItem sitem in toBeFilled)
            {
                string url = "https://www.youtube.com/watch?v="+sitem.youtubevideo.youtubeId;
                string result = "";

                try
                {
                    

                    result = new System.Net.WebClient().DownloadString(url);
                }
                catch
                {


                }

                if (!result.Equals(""))
                {
                    string[] lines = result.Split(new char[] { '\n' });

                    bool found = false;

                    foreach (string line in lines)
                    {

                        if (line.Contains("meta name=attribution"))
                        {
                            //that's our guy
                            int startIndex = line.IndexOf("content") + 8;
                            int endIndex = line.IndexOf("/");

                            string attribution = line.Substring(startIndex, endIndex - startIndex);

                            //let's update the database

                            DataAccess.updateSearchAttribution(attribution, sitem.youtubevideo.youtubeId);
                            found = true; 
                            break;

                        }



                    }

                    if (!found)
                    {
                        DataAccess.updateSearchAttribution("", sitem.youtubevideo.youtubeId);

                    }


                }


            }

            //< meta name = attribution content = Collective />

        }


            



    }
}
