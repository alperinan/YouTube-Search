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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cmdSearchYoutube_Click(object sender, EventArgs e)
        {
            SearchForm sform = new SearchForm();

            sform.Show(); 
        }

        private void cmdBlackListedChannels_Click(object sender, EventArgs e)
        {
            BlackList blist = new BlackList();

            blist.Show(); 
        }

        private void cmdAddToBlackListManually_Click(object sender, EventArgs e)
        {
            AddManually addmanual = new AddManually();

            addmanual.ShowDialog(); 
        }

        private void cmdScheduledSearchFilters_Click(object sender, EventArgs e)
        {
            ScheduledSearchParameters sparameters = new ScheduledSearchParameters();
            sparameters.ShowDialog(); 
        }

        private void cmdApiKey_Click(object sender, EventArgs e)
        {
            ApiKeyForm akeyform = new ApiKeyForm();

            akeyform.ShowDialog(); 
        }

        private void cmdShowSearchResults_Click(object sender, EventArgs e)
        {
            MainSearchResults msresults = new MainSearchResults();
            msresults.ShowDialog(); 
        }
    }
}
