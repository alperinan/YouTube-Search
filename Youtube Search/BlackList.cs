using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Search
{
    public partial class BlackList : Form
    {
        public BlackList()
        {

            InitializeComponent();

            dgBlackList.Columns.Add("channelId", "Channel Id");
            

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.ValueType = typeof(DateTime);
            column.HeaderText = "Added Date/Time";
            column.Name = "added";
            
            
            


            dgBlackList.Columns.Add(column);
            dgBlackList.Columns.Add("exported", "Exported");

            List<BlackListedChannel> blacklistedChannels = DataAccess.getAllBlacklistedChannels();

            refreshGrid();

            dgBlackList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgBlackList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn sortColumn = dgBlackList.Columns[1];

            dgBlackList.Sort(sortColumn, ListSortDirection.Descending);




        }

        private void tsCopyChannelId_Click(object sender, EventArgs e)
        {
            if (dgBlackList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgBlackList.SelectedRows[0];

                string channelId = row.Cells[0].Value.ToString();

                System.Windows.Forms.Clipboard.SetText(channelId);

            }

            


        }

        private void refreshGrid ()
        {
            dgBlackList.Rows.Clear();

            int totalExportedChannel = 0;
            List<BlackListedChannel> blacklistedChannels = DataAccess.getAllBlacklistedChannels();

            foreach (BlackListedChannel bchannel in blacklistedChannels)
            {
                if (bchannel.exported)
                    totalExportedChannel++;

                if (chkBoxShowOnlyExported.Checked)
                {
                    if (!bchannel.exported)
                    {
                        string exported = "No";

                        if (bchannel.exported)
                            exported = "Yes";



                        dgBlackList.Rows.Add(bchannel.channelId, bchannel.addedTime, exported);
                    }

                }
                else
                {
                    string exported = "No";

                    if (bchannel.exported)
                        exported = "Yes";

                    dgBlackList.Rows.Add(bchannel.channelId, bchannel.addedTime, exported);

                }


                

            }

            toolStripStatusLabel1.Text = "Total " + blacklistedChannels.Count + " blacklist channels listed, " + totalExportedChannel + " channels were exported, " +(blacklistedChannels.Count-totalExportedChannel )+" channels were not exported";

        }

        private void tsDeleteChannel_Click(object sender, EventArgs e)
        {
            
            if (dgBlackList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgBlackList.SelectedRows[0];

                string channelId= row.Cells[0].Value.ToString();

                DialogResult dg = MessageBox.Show("Are you sure you want to delete this channel?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dg == DialogResult.Yes)
                {

                    DataAccess.deleteBlackListChannel(channelId);

                    refreshGrid();
                }
            }


        }

        private void cmdExportToExcel_Click(object sender, EventArgs e)
        {


            saveFileDialog1.Filter = "Excel Files|*.xlsx";

            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                ExportToExcel exporttoexcel = new ExportToExcel(dgBlackList, saveFileDialog1.FileName);
                exporttoexcel.ShowDialog();

                markAllExported();
                refreshGrid(); 


            }

            

        }

        private void markAllExported ()
        {

            foreach( DataGridViewRow row in dgBlackList.Rows)
            {
                string channelId = row.Cells[0].Value.ToString();

                DataAccess.updateBlacklistChannel(channelId, true);


            }

        }

        private void chkBoxShowOnlyExported_CheckedChanged(object sender, EventArgs e)
        {
            refreshGrid();
        }
    }
}
