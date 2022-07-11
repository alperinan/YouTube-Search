using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Youtube_Search
{
    public partial class AddManually : Form
    {
        public AddManually()
        {
            InitializeComponent();
        }

        private void cmdAddChannelsToBlacklist_Click(object sender, EventArgs e)
        {
            int totalAddCount = 0;

            using (StringReader reader = new StringReader(txtBoxChannels.Text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    try
                    {
                        string channelId = line.Substring(line.IndexOf("channel") + 8, line.Length - (line.IndexOf("channel") + 8));

                        bool alreadyAdded = DataAccess.checkIfChannelExist(channelId);

                        if (!alreadyAdded)
                        {
                            DataAccess.addNewBlackListChannel(channelId);
                            DataAccess.updateBlacklistChannel(channelId, true);
                            totalAddCount++;
                        }

                    }
                    catch (Exception)
                    {

                    }

                    

                }

                MessageBox.Show("Total " + totalAddCount + " channel was added to blacklist");

                txtBoxChannels.Text = ""; 


            }





        }
    }
}
