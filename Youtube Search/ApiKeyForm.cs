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
    public partial class ApiKeyForm : Form
    {
        public ApiKeyForm()
        {
            InitializeComponent();

            fillList();
        }

        private void fillList ()
        {
            lstBoxApiKeys.Items.Clear();

            List<string> keys = DataAccess.getApiKeys();

            foreach (string a in keys)
            {

                lstBoxApiKeys.Items.Add(a);

            }


        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataAccess.setApiKey(txtBoxApiKey.Text);

            this.Close(); 
        }

        private void ApiKeyForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdAddApiKey_Click(object sender, EventArgs e)
        {
            if (!txtBoxApiKey.Text.Equals(""))
            {
                bool exist = existOnList(txtBoxApiKey.Text);

                if (!exist)
                {
                    //do the work

                    DataAccess.addApiKey(txtBoxApiKey.Text);

                    txtBoxApiKey.Text = "";

                    fillList();

                }
                else
                {
                    MessageBox.Show("This key already exists");

                }



            }
            else
            {
                MessageBox.Show("Key cannot be blank");

            }

        }

        private  bool existOnList (string txt)
        {

            foreach (string a in lstBoxApiKeys.Items)
            {
                if (txt.Equals(a))
                    return true;


            }

            return false;
        }

        private void deleteFromList(string txt)
        {
            DataAccess.deleteApiKey(txt);


        }

        private void lstBoxApiKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxApiKeys.SelectedIndex == -1)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure you want to delete ?", "delete confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.Yes)
            {

                deleteFromList(lstBoxApiKeys.SelectedItem.ToString());

                fillList();
            }
        }

        private void lstBoxApiKeys_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstBoxApiKeys.SelectedIndex==-1)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }
        }
    }
}
