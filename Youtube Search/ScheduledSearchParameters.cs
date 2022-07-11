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

namespace Youtube_Search
{
    public partial class ScheduledSearchParameters : Form
    {
        public VideoSearchParams vparams;
        public ArrayList filteredSearchResults;
        public string searchingFor;

        public ScheduledSearchParameters()
        {

            InitializeComponent();

            cmbBoxMaxResults.SelectedIndex = 0;
            cmbBoxPageCount.SelectedIndex = 0;

            //disable custom date fields
            txtBoxPublishedAfter.Enabled = false;
            txtBoxPublishedBefore.Enabled = false;
            dtPublishedAfter.Enabled = false;
            dtPublishedBefore.Enabled = false;

            refreshFavoritesList();

            //let's fill other fields

            ScheduledSearchParameter sparameter = DataAccess.getScheduledSearchParameter(); 

            switch(sparameter.filterDuration)
            {
                case 0:
                    radioShort.Checked = true;  

                    break;

                case 1:
                    RadioMedium.Checked = true; 
                    break;

                case 2:
                    radioLong.Checked = true; 
                    break;

            }


            if (sparameter.channelSubsCountMin != 0)
                txtBoxSubsCountMin.Text = sparameter.channelSubsCountMin.ToString();

            if (sparameter.channelSubsCountMax != 0)
                txtBoxSubsCountMax.Text = sparameter.channelSubsCountMax.ToString();

            if (sparameter.channelVideoCountMin != 0)
                txtBoxVideoCountMin.Text = sparameter.channelVideoCountMin.ToString();

            if (sparameter.channelVideoCountMax != 0)
                txtBoxVideoCountMax.Text = sparameter.channelVideoCountMax.ToString();

            cmbBoxMaxResults.Text = sparameter.maxresultCount.ToString();

            cmbBoxPageCount.Text = sparameter.maxPageCount.ToString();

            cmbBoxSortBy.SelectedIndex = sparameter.sortBy;

            switch (sparameter.filterUploadDate)
            {
                case "radio1Hour":
                    radio1Hour.Checked = true;
                    break;

                case "radioToday":
                    radioToday.Checked = true;
                    break;

                case "radioThisWeek":
                    radioThisWeek.Checked = true;
                    break;

                case "radioThisMonth":
                    radioThisMonth.Checked = true;
                    break;


                case "radioThisYear":
                    radioThisYear.Checked = true;
                    break;

                case "radioCustom":
                    radioCustom.Checked = true;

                    if (sparameter.publishedAfter != new DateTime(1800, 1, 1))
                        txtBoxPublishedAfter.Text = sparameter.publishedAfter.ToShortDateString();

                    if (sparameter.publishedBefore != new DateTime(1800, 1, 1))
                        txtBoxPublishedBefore.Text = sparameter.publishedBefore.ToShortDateString();

                    break;


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


        public VideoSearchParams getSearchParametersFromForm()
        {
            VideoSearchParams vparams = new VideoSearchParams();

            vparams.searchAll = true;

            if (vparams.searchAll)
            {
                foreach (var listBoxItem in lstBoxFavoriteKeywords.Items)
                {

                    vparams.favKeywords.Add(listBoxItem.ToString());

                }


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




        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        
        private bool checkForm ()
        {

            if (radioCustom.Checked)
            {

               if ( txtBoxPublishedAfter.Text.Equals ("") && txtBoxPublishedBefore.Text.Equals(""))
                {

                    MessageBox.Show("You need to provide at least one date");
                    return false; 

                }

                if (!txtBoxPublishedAfter.Text.Equals("") && !txtBoxPublishedBefore.Text.Equals(""))
                {
                    if (DateTime.Parse(txtBoxPublishedAfter.Text) > DateTime.Parse(txtBoxPublishedBefore.Text))
                    {
                        MessageBox.Show("before date can not be later than after date");
                        return false;
                    }
                }


            }

            



            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (checkForm())
            {

                string filterUpload = "None";
                DateTime publishedAfter = new DateTime(1800, 1, 1);
                DateTime publishedBefore = new DateTime(1800, 1, 1);
                int videoDuration = -1;
                int channelSubsCountMin = 0;
                int channelSubsCountMax = 0;
                int channelVideoCountMin = 0;
                int channelVideoCountMax = 0;
                int maxResultCount;
                int maxPageCount;
                int videosSortOrder;

                if (radio1Hour.Checked || radioToday.Checked || radioThisWeek.Checked || radioThisMonth.Checked || radioThisYear.Checked || radioCustom.Checked)
                {
                    //something is definitely set, let's see which one
                    if (radio1Hour.Checked)
                    {
                        filterUpload = "radio1Hour";

                    }

                    if (radioToday.Checked)
                    {

                        filterUpload = "radioToday";

                    }


                    if (radioThisWeek.Checked)
                    {
                        filterUpload = "radioThisWeek";
                    }


                    if (radioThisMonth.Checked)
                    {

                        filterUpload = "radioThisMonth";

                    }

                    if (radioThisYear.Checked)
                    {

                        filterUpload = "radioThisYear";

                    }

                    if (radioCustom.Checked)
                    {
                        filterUpload = "radioCustom";

                        if (!txtBoxPublishedAfter.Text.Equals(""))
                        {
                            publishedAfter = DateTime.Parse(txtBoxPublishedAfter.Text);

                        }

                        if (!txtBoxPublishedBefore.Text.Equals(""))
                        {
                            publishedBefore = DateTime.Parse(txtBoxPublishedBefore.Text);


                        }


                    }





                }




                if (radioShort.Checked || RadioMedium.Checked || radioLong.Checked)
                {


                    if (radioShort.Checked)
                        videoDuration = 0;

                    if (RadioMedium.Checked)
                        videoDuration = 1;

                    if (radioLong.Checked)
                        videoDuration = 2;


                }

                //channel filters

                if (!txtBoxSubsCountMin.Text.Equals("") || !txtBoxSubsCountMax.Text.Equals(""))
                {


                    if (!txtBoxSubsCountMin.Text.Equals(""))
                    {
                        channelSubsCountMin = Convert.ToInt32(txtBoxSubsCountMin.Text);

                    }


                    if (!txtBoxSubsCountMax.Text.Equals(""))
                    {
                        channelSubsCountMax = Convert.ToInt32(txtBoxSubsCountMax.Text);
                    }


                }

                if (!txtBoxVideoCountMin.Text.Equals("") || !txtBoxVideoCountMax.Text.Equals(""))
                {




                    if (!txtBoxVideoCountMin.Text.Equals(""))
                    {
                        channelVideoCountMin = Convert.ToInt32(txtBoxVideoCountMin.Text);
                    }


                    if (!txtBoxVideoCountMax.Text.Equals(""))
                    {
                        channelVideoCountMax = Convert.ToInt32(txtBoxVideoCountMax.Text);
                    }


                }


                maxResultCount = Convert.ToInt32(cmbBoxMaxResults.Items[cmbBoxMaxResults.SelectedIndex].ToString());

                maxPageCount = Convert.ToInt32(cmbBoxPageCount.Items[cmbBoxPageCount.SelectedIndex].ToString());

                videosSortOrder = cmbBoxSortBy.SelectedIndex;


                //now let's add all these to database
                //first we will clear db

                DataAccess.deleteFilters();

                //now add the values

                DataAccess.addNewFilter(videoDuration, channelSubsCountMin, channelSubsCountMax, channelVideoCountMin, channelVideoCountMax, maxResultCount, maxPageCount, videosSortOrder, publishedAfter, publishedBefore, filterUpload);

                this.Close();
            }


        }

        private void radioCustom_CheckedChanged(object sender, EventArgs e)
        {
            if(radioCustom.Checked)
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

        private void dtPublishedAfter_ValueChanged(object sender, EventArgs e)
        {
            txtBoxPublishedAfter.Text = dtPublishedAfter.Value.ToShortDateString();
        }

        private void dtPublishedBefore_ValueChanged(object sender, EventArgs e)
        {
            txtBoxPublishedBefore.Text = dtPublishedBefore.Value.ToShortDateString(); 
        }

        private void txtBoxPublishedAfter_DoubleClick(object sender, EventArgs e)
        {
            txtBoxPublishedAfter.Text = ""; 
        }

        private void txtBoxPublishedBefore_DoubleClick(object sender, EventArgs e)
        {
            txtBoxPublishedBefore.Text = ""; 
        }

        private void cmdClearParameters_Click(object sender, EventArgs e)
        {
            txtBoxPublishedAfter.Text = "";
            txtBoxPublishedBefore.Text = "";

            radio1Hour.Checked = false;
            radioCustom.Checked = false;
            radioLong.Checked = false;
            RadioMedium.Checked = false;
            radioShort.Checked = false;
            radioThisMonth.Checked = false;
            radioThisWeek.Checked = false;
            radioThisYear.Checked = false;
            radioToday.Checked = false;

            txtBoxSubsCountMax.Text = "";
            txtBoxSubsCountMin.Text = "";
            txtBoxVideoCountMax.Text = "";
            txtBoxVideoCountMin.Text = "";

            cmbBoxMaxResults.SelectedIndex = 0;
            cmbBoxPageCount.SelectedIndex = 0;
            cmbBoxSortBy.SelectedIndex = -1;



        }
    }
}
