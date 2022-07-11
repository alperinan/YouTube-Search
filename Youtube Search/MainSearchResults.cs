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
    public partial class MainSearchResults : Form
    {
        public MainSearchResults()
        {
            InitializeComponent();

            dgVideos.Columns.Add("searchId", "Search ID");
            dgVideos.Columns.Add("searchDate", "Search DateTime");
            dgVideos.Columns[0].Visible = false;
            dgVideos.Columns[1].Width = 200;
            List <ScheduledSearchResults> searchResults = DataAccess.getAllScheduledSearchResults();
            
            foreach (ScheduledSearchResults sresult in searchResults)
            {
                dgVideos.Rows.Add(sresult.searchId, sresult.searchDateTime.ToString());
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgVideos_DoubleClick(object sender, EventArgs e)
        {
            if (dgVideos.SelectedRows.Count > 0)
            {

                    DataGridViewRow row = this.dgVideos.SelectedRows[0];

                    int searchId = Convert.ToInt32( row.Cells[0].Value.ToString());

                //MessageBox.Show(searchId + "");

                ScheduledSearchOutcome soutcome = new ScheduledSearchOutcome(searchId);
                soutcome.ShowDialog(); 


            }

        }
    }

}
