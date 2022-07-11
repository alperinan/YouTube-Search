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

namespace Youtube_Search
{
    public partial class ScheduledSearchOutcome : Form
    {

        public ScheduledSearchOutcome()
        {
            InitializeComponent();
            initializeGridColumns(); 

           

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

        public ScheduledSearchOutcome(int searchId)
        {
            InitializeComponent();
            initializeGridColumns();

            ArrayList searchResults = DataAccess.getSearchDetailBySearchId(searchId);

            List<string> blackListedChannels = DataAccess.getAllBlacklistedChannelIds();

            foreach (SearchItem sitem in searchResults)
            {

                if (!channelBlackListed(sitem.youtubevideo.channelId, blackListedChannels))
                {
                    dgVideos.Rows.Add(sitem.youtubevideo.youtubeId, sitem.youtubevideo.videoTitle, sitem.youtubevideo.viewCount, sitem.youtubevideo.likeCount, sitem.youtubevideo.publishedAt, sitem.youtubevideo.channelId, sitem.youtubechannel.totalVideoCount, sitem.youtubechannel.totalViewCount, sitem.youtubechannel.totalSubscriber, sitem.youtubevideo.keyword, sitem.youtubevideo.attribution);
                }
            }

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
            dgVideos.Columns.Add("Attribution", "Attribution");

            dgVideos.Columns[0].Visible = false;
            dgVideos.Columns[4].Visible = false;
            dgVideos.Columns[9].Visible = false;

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
                        string channelUrl = "https://www.youtube.com/channel/" + row.Cells[5].Value.ToString() + "/videos?flow=grid&view=0&sort=p";


                        System.Diagnostics.Process.Start(channelUrl);
                    }
                }


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

        private void tsCancel_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;
        }
    }
}
