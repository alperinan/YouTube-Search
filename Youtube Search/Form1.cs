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
using YoutubeFunctions;

namespace Youtube_Search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
            SearchYoutube sytube = new SearchYoutube();

            textBox1.Text = sytube.performVideoSearch("fenerbahce");

            SearchUsingJson sjson = new SearchUsingJson();
            YoutubeDataDetail videoDetail = sjson.getVideoData("2AkvmFtpufg");*/

            string apiKey = DataAccess.getApiKey();


            SearchYoutube sytube = new SearchYoutube(apiKey);

            ArrayList videos = sytube.performVideoSearchArray("fenerbahce");
        }
    }
}
