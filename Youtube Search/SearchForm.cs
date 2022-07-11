using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using YoutubeFunctions;

namespace Youtube_Search
{
    public partial class SearchForm : Form
    {

        public VideoSearchParams vparams;
        public ArrayList filteredSearchResults;
        public string searchingFor;

        public SearchForm()
        {
            InitializeComponent();
            cmbBoxMaxResults.SelectedIndex = 0;
            cmbBoxPageCount.SelectedIndex = 0;
            initializeGridColumns();

            //disable custom date fields
            txtBoxPublishedAfter.Enabled = false;
            txtBoxPublishedBefore.Enabled = false;
            dtPublishedAfter.Enabled = false;
            dtPublishedBefore.Enabled = false;

            refreshFavoritesList(); 
        }

        private void initializeGridColumns()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");

            dgVideos.Columns.Add("youtubeId", "Video ID");          
            dgVideos.Columns.Add("videoTitle", "Video Title");
            dgVideos.Columns.Add("viewCount", "View Count");
            dgVideos.Columns.Add("likeCount", "Like Count");
            dgVideos.Columns.Add("publishedAt", "Published Date");
            dgVideos.Columns.Add("channelId", "Channel ID");
            dgVideos.Columns.Add("cvideoCount", "Channel Video Count");
            dgVideos.Columns.Add("cviewCount", "Channel View Count");
            dgVideos.Columns.Add("csubsCount", "Channel Subscriber Count");
            dgVideos.Columns.Add("Searched Kewyword", "Searched Kewyword");
            dgVideos.Columns.Add("Copyright", "Copyright");

            dgVideos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgVideos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgVideos.Columns[2].ValueType = typeof(int);
            dgVideos.Columns[2].DefaultCellStyle.FormatProvider = ci;
            dgVideos.Columns[2].DefaultCellStyle.Format = "N0";

            dgVideos.Columns[3].ValueType = typeof(int);
            dgVideos.Columns[3].DefaultCellStyle.FormatProvider = ci;
            dgVideos.Columns[3].DefaultCellStyle.Format = "N0";

            dgVideos.Columns[6].ValueType = typeof(int);
            dgVideos.Columns[6].DefaultCellStyle.FormatProvider = ci;
            dgVideos.Columns[6].DefaultCellStyle.Format = "N0";

            dgVideos.Columns[7].ValueType = typeof(int);
            dgVideos.Columns[7].DefaultCellStyle.FormatProvider = ci;
            dgVideos.Columns[7].DefaultCellStyle.Format = "N0";

            dgVideos.Columns[8].ValueType = typeof(int);
            dgVideos.Columns[8].DefaultCellStyle.FormatProvider = ci;
            dgVideos.Columns[8].DefaultCellStyle.Format = "N0";

        }

        public VideoSearchParams getSearchParameters ()
        {
            VideoSearchParams vparams = new VideoSearchParams();

            vparams.searchAll = chkSearchAll.Checked;


            vparams.keyword = txtBoxKeywords.Text.Trim();

            if (vparams.searchAll)
            {
                foreach (var listBoxItem in lstBoxFavoriteKeywords.Items)
                {

                    vparams.favKeywords.Add(listBoxItem.ToString());

                }


            }
            else
            {

                vparams.favKeywords.Add(txtBoxKeywords.Text.Trim());

            }


            if (radio1Hour.Checked || radioToday.Checked || radioThisWeek.Checked || radioThisMonth.Checked || radioThisYear.Checked || radioCustom.Checked)
            {
                //something is definitely set, let's see which one
                if (radio1Hour.Checked)
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = DateTime.Now.AddHours(-1);

                }

                if (radioToday.Checked)
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = DateTime.Today;

                }


                if (radioThisWeek.Checked)
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


                if (radioThisMonth.Checked)
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                }

                if (radioThisYear.Checked)
                {

                    vparams.publishedAfterSet = true;

                    vparams.publishedAfter = new DateTime(DateTime.Now.Year, 1, 1);

                }

                if (radioCustom.Checked)
                {
                    if (!txtBoxPublishedAfter.Text.Equals(""))
                    {
                        vparams.publishedAfterSet = true;
                        vparams.publishedAfter = DateTime.Parse(txtBoxPublishedAfter.Text);

                    }

                    if (!txtBoxPublishedBefore.Text.Equals(""))
                    {
                        vparams.publishedBeforeSet = true;
                        vparams.publishedBefore = DateTime.Parse(txtBoxPublishedBefore.Text);


                    }


                }





            }




            if (radioShort.Checked || RadioMedium.Checked || radioLong.Checked)
            {

                vparams.videoDurationSet = true;

                if (radioShort.Checked)
                    vparams.videoDuration = 0;

                if (RadioMedium.Checked)
                    vparams.videoDuration = 1;

                if (radioLong.Checked)
                    vparams.videoDuration = 2;
                

            }

            //channel filters

            if (!txtBoxSubsCountMin.Text.Equals("") || !txtBoxSubsCountMax.Text.Equals(""))
            {


                

                if (!txtBoxSubsCountMin.Text.Equals(""))
                {
                    vparams.channelSubsCountMin = Convert.ToInt32(txtBoxSubsCountMin.Text);
                    vparams.channelSubsCountMinSet = true;

                }


                if (!txtBoxSubsCountMax.Text.Equals(""))
                {
                    vparams.channelSubsCountMax = Convert.ToInt32(txtBoxSubsCountMax.Text);
                    vparams.channelSubsCountMaxSet = true;
                }


            }

            if (!txtBoxVideoCountMin.Text.Equals("") || !txtBoxVideoCountMax.Text.Equals(""))
            {


                

                if (!txtBoxVideoCountMin.Text.Equals(""))
                {
                    vparams.channelVideoCountMin = Convert.ToInt32(txtBoxVideoCountMin.Text);
                    vparams.channelVideoCountMinSet = true;
                }


                if (!txtBoxVideoCountMax.Text.Equals(""))
                {
                    vparams.channelVideoCountMax = Convert.ToInt32(txtBoxVideoCountMax.Text);
                    vparams.channelVideoCountMaxSet = true;
                }


            }

            vparams.maxResultCountSet = true;

            vparams.maxResultCount = Convert.ToInt32(cmbBoxMaxResults.Items[cmbBoxMaxResults.SelectedIndex].ToString());
            
            vparams.maxPageCount = Convert.ToInt32(cmbBoxPageCount.Items[cmbBoxPageCount.SelectedIndex].ToString());

            if (cmbBoxSortBy.SelectedIndex != -1)
            {

                vparams.videosSorted = true;
                vparams.videosSortOrder = cmbBoxSortBy.SelectedIndex;


            }

            return vparams;




        }

        private bool checkIsNumber (string strToBeChecked)
        {
            int i = 0;

       
            bool result = int.TryParse(strToBeChecked, out i);

            return result;

        }

        private void cmdStartSearch_Click(object sender, EventArgs e)
        {

            bool formOk = true;

            if (txtBoxKeywords.Text.Equals("") && !chkSearchAll.Checked)
            {
                formOk = false;

                MessageBox.Show("Please provide a keyword", "Data Needed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (!checkIsNumber(txtBoxSubsCountMin.Text) && !txtBoxSubsCountMin.Text.Equals(""))
            {
                formOk = false;

                MessageBox.Show("Subscriber Min Count must be a number", "Data Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (!checkIsNumber(txtBoxSubsCountMax.Text) && !txtBoxSubsCountMax.Text.Equals(""))
            {
                formOk = false;

                MessageBox.Show("Subscriber Max Count must be a number", "Data Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            if (!checkIsNumber(txtBoxVideoCountMax.Text) && !txtBoxVideoCountMax.Text.Equals(""))
            {
                formOk = false;

                MessageBox.Show("Video Max Count must be a number", "Data Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (!checkIsNumber(txtBoxVideoCountMin.Text) && !txtBoxVideoCountMin.Text.Equals(""))
            {
                formOk = false;

                MessageBox.Show("Video Min Count must be a number", "Data Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            if (formOk)
            {

                    vparams = getSearchParameters();

                    bgPerformSearch.RunWorkerAsync();

                    cmdStartSearch.Enabled = false;

                tsProgressBar.Value = 0;
            }

        }

        private bool channelBlackListed (string channelId, List<string> blackListedChannels)
        {
            bool returnValue = false;

            if (blackListedChannels.Exists(e => e.EndsWith(channelId)))

            {

                return true; 

            }

            





            return returnValue;
        }


        private void txtBoxPublishedAfter_DoubleClick(object sender, EventArgs e)
        {
            txtBoxPublishedAfter.Text = "";
        }

        private void txtBoxPublishedBefore_DoubleClick(object sender, EventArgs e)
        {
            txtBoxPublishedBefore.Text = "";
        }

        private void dtPublishedAfter_ValueChanged(object sender, EventArgs e)
        {
            txtBoxPublishedAfter.Text = dtPublishedAfter.Value.ToShortDateString();
        }

        private void dtPublishedBefore_ValueChanged(object sender, EventArgs e)
        {
            txtBoxPublishedBefore.Text = dtPublishedBefore.Value.ToShortDateString();
        }

        private void radioCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCustom.Checked)
            {
                txtBoxPublishedAfter.Enabled = true;
                txtBoxPublishedBefore.Enabled = true;
                dtPublishedAfter.Enabled = true;
                dtPublishedBefore.Enabled = true;

            }
            else
            {

                txtBoxPublishedAfter.Enabled = false;
                txtBoxPublishedBefore.Enabled = false;
                dtPublishedAfter.Enabled = false;
                dtPublishedBefore.Enabled = false;
            }
        }

        private void dgVideos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Space)
            {
                
                if (dgVideos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                    {
                        //DataGridViewRow row = this.dgVideos.SelectedRows[0];

                        //string channelUrl = "https://www.youtube.com/channel/" + row.Cells[5].Value.ToString();
                        string channelUrl = "https://www.youtube.com/channel/"+ row.Cells[5].Value.ToString() + "/videos?flow=grid&view=0&sort=p";


                        System.Diagnostics.Process.Start(channelUrl);
                    }
                }


            }


        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;


        }

        private void tsOpenVideo_Click(object sender, EventArgs e)
        {
            if (dgVideos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                {
                    //DataGridViewRow row = this.dgVideos.SelectedRows[0];

                    string channelUrl = "https://www.youtube.com/watch?v=" + row.Cells[0].Value.ToString();

                    System.Diagnostics.Process.Start(channelUrl);
                }
            }


        }

        private void tsRemove_Click(object sender, EventArgs e)
        {

            if (dgVideos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                {
                    dgVideos.Rows.Remove(row);
                        
                }
            }


        }

        private void tsAddToBlacklist_Click(object sender, EventArgs e)
        {

            if (dgVideos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                {
                    //DataGridViewRow row = this.dgVideos.SelectedRows[0];

                    string channelId = row.Cells[5].Value.ToString();

                    bool alreadyAdded = DataAccess.checkIfChannelExist(channelId);

                    if (!alreadyAdded)
                    DataAccess.addNewBlackListChannel(channelId);

                    dgVideos.Rows.Remove(row);



                }
            }


        }

        private void refreshFavoritesList()
        {
            List<string> keywords = DataAccess.getAllKeywords();

            lstBoxFavoriteKeywords.Items.Clear();

            keywords.Sort();

            foreach (string s in keywords)
            {
                lstBoxFavoriteKeywords.Items.Add(s); 

            }

        }

        private void cmdAddToFavorites_Click(object sender, EventArgs e)
        {


            if (!txtBoxKeywords.Text.Equals(""))
            {
                bool exist = DataAccess.checkIfKeywordExist(txtBoxKeywords.Text.Trim());

                if (exist)
                {

                    MessageBox.Show("This keyword already exist, please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataAccess.addNewKeyword(txtBoxKeywords.Text.Trim());
                    refreshFavoritesList();
                }
            }
            else
            {

                MessageBox.Show("Keyword must be at least 3 characters long, please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxKeywords.Focus();


            }
             
        }

        private void tsDeleteKeyword_Click(object sender, EventArgs e)
        {
            if (lstBoxFavoriteKeywords.SelectedItems.Count>0)
            {
                foreach (string txt in lstBoxFavoriteKeywords.SelectedItems)
                {

                    DataAccess.deleteKeyword(txt);


                }

                refreshFavoritesList();




            }

            //if (lstBoxFavoriteKeywords.SelectedIndex!=-1)
            //{
            //    DataAccess.deleteKeyword(lstBoxFavoriteKeywords.Text);
            //    refreshFavoritesList();


            //}
        }

        private void lstBoxFavoriteKeywords_DoubleClick(object sender, EventArgs e)
        {
            if (lstBoxFavoriteKeywords.SelectedIndex != -1)
            {
                txtBoxKeywords.Text = lstBoxFavoriteKeywords.Text;
                


            }
        }

        private void txtBoxKeywords_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxKeywords.Text.Trim().Length > 0)
            {
                string apiKey = DataAccess.getApiKey();

                SearchUsingJson sjson = new SearchUsingJson(apiKey);

                List<string> recommendations = sjson.getRecommendations(txtBoxKeywords.Text.Trim());

                AutoCompleteStringCollection data = new AutoCompleteStringCollection();

                foreach (string a in recommendations)
                {

                    data.Add(a);

                }

                txtBoxKeywords.AutoCompleteCustomSource = data;


            }
        }

        private void dgVideos_DoubleClick(object sender, EventArgs e)
        {

            if (dgVideos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                {
                    //DataGridViewRow row = this.dgVideos.SelectedRows[0];

                    //string channelUrl = "https://www.youtube.com/channel/" + row.Cells[5].Value.ToString();
                    string channelUrl = "https://www.youtube.com/channel/" + row.Cells[5].Value.ToString() + "/videos?flow=grid&view=0&sort=p";


                    System.Diagnostics.Process.Start(channelUrl);
                }
            }




        }

        private void bgPerformSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            //we will need some ints for stats




            // first we need to get black listed channels



            //then we need to get favorited channels



            //let's get filters

            

            //let's make sure form is ok

            ArrayList searchResults = new ArrayList();


            //let's do the search
            //but we will search all or some ?

            filteredSearchResults = new ArrayList();

            foreach (string keywordToSearch in vparams.favKeywords)
            {

                vparams.keyword = keywordToSearch;
                searchingFor = keywordToSearch;

                bgPerformSearch.ReportProgress(0);

                string apiKey = DataAccess.getApiKey();

                SearchYoutube sytube = new SearchYoutube(apiKey);

                searchResults = sytube.performVideoSearchArrayWithParameters(vparams);

                

                if (vparams.channelSubsCountMinSet || vparams.channelSubsCountMaxSet || vparams.channelVideoCountMaxSet || vparams.channelVideoCountMinSet)
                {
                    int i = 0;

                    foreach (youtubeVideo yvideo in searchResults)
                    {


                        SearchUsingJson susingJson = new SearchUsingJson(apiKey);

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

                        bgPerformSearch.ReportProgress(progressPerc);

                    }


                }
                else
                {
                    int i = 0;

                    foreach (youtubeVideo yvideo in searchResults)
                    {


                        SearchUsingJson susingJson = new SearchUsingJson(apiKey);

                        YoutubeDataDetail channelDetail = susingJson.getChannelData(yvideo.channelId);

                        SearchItem sitem = new SearchItem();
                        sitem.youtubevideo = yvideo;
                        sitem.youtubechannel = channelDetail;
                        sitem.youtubevideo.keyword = searchingFor;
                        filteredSearchResults.Add(sitem);

                        i++;

                        int progressPerc = (i * 100) / searchResults.Count;

                        bgPerformSearch.ReportProgress(progressPerc);



                    }

                    searchResults = null;
                }




            }






        }

        private void bgPerformSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                toolStripStatusLabel1.Text = "Obtaining video search results for "+ searchingFor;
            }
            else if (e.ProgressPercentage > 0)
            {

                tsProgressBar.Value = e.ProgressPercentage;
                toolStripStatusLabel1.Text = "Adding channel data to video results for " + searchingFor;

            }

        }

        private void bgPerformSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            fillGrid();
            cmdStartSearch.Enabled = true;

            tsProgressBar.Value = 100;


        }

        private void fillGrid()
        {
            List<string> addedChannels = new List<string>();

            int totalSearchResult = 0;
            //int totalBlackListedChannel = 0;
            int totalBlackListedVideo = 0;

            dgVideos.Rows.Clear();

            List<string> blackListedChannels = DataAccess.getAllBlacklistedChannelIds();

            totalSearchResult = filteredSearchResults.Count;

            foreach (SearchItem sitem in filteredSearchResults)
            {

                //bool channelAdded = channelBlackListed(sitem.youtubevideo.channelId, addedChannels);

                //if (!channelBlackListed(sitem.youtubevideo.channelId, blackListedChannels) && !channelAdded)
                //{

                //    dgVideos.Rows.Add(sitem.youtubevideo.youtubeId, sitem.youtubevideo.videoTitle, sitem.youtubevideo.viewCount, sitem.youtubevideo.likeCount, sitem.youtubevideo.publishedAt, sitem.youtubevideo.channelId, sitem.youtubechannel.totalVideoCount, sitem.youtubechannel.totalViewCount, sitem.youtubechannel.totalSubscriber, sitem.youtubevideo.keyword, sitem.youtubevideo.copyright);

                //    addedChannels.Add(sitem.youtubevideo.channelId);

                //}
                //else
                //{

                //    totalBlackListedVideo++;

                //}

                dgVideos.Rows.Add(sitem.youtubevideo.youtubeId, sitem.youtubevideo.videoTitle, sitem.youtubevideo.viewCount, sitem.youtubevideo.likeCount, sitem.youtubevideo.publishedAt, sitem.youtubevideo.channelId, sitem.youtubechannel.totalVideoCount, sitem.youtubechannel.totalViewCount, sitem.youtubechannel.totalSubscriber, sitem.youtubevideo.keyword, sitem.youtubevideo.copyright);


            }

            //let's update the status

            if (totalBlackListedVideo != 0)
            {

                toolStripStatusLabel1.Text = "Your search has found total " + totalSearchResult + " videos but " + (totalSearchResult - totalBlackListedVideo) + " shown because some channels are blacklisted";


            }
            else
            {

                toolStripStatusLabel1.Text = "Your search has found total " + totalSearchResult + " videos";

            }



        }

        private void chkSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchAll.Checked)
            {
                txtBoxKeywords.Enabled = false;

            }
            else
            {

                txtBoxKeywords.Enabled = true;

            }
        }

        private void tsAddToBlacklistAndBlock_Click(object sender, EventArgs e)
        {
            if (dgVideos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgVideos.SelectedRows)
                {
                    //DataGridViewRow row = this.dgVideos.SelectedRows[0];

                    string channelId = row.Cells[5].Value.ToString();

                    bool alreadyAdded = DataAccess.checkIfChannelExist(channelId);

                    if (!alreadyAdded)
                    {
                        DataAccess.addNewBlackListChannel(channelId);
                        DataAccess.updateBlacklistChannel(channelId, true);
                    }

                    dgVideos.Rows.Remove(row);



                }
            }

        }
    }
}
