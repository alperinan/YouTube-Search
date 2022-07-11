namespace Youtube_Search
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdScheduledSearchFilters = new System.Windows.Forms.Button();
            this.cmdShowSearchResults = new System.Windows.Forms.Button();
            this.cmdAddToBlackListManually = new System.Windows.Forms.Button();
            this.cmdBlackListedChannels = new System.Windows.Forms.Button();
            this.cmdApiKey = new System.Windows.Forms.Button();
            this.cmdSearchYoutube = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdScheduledSearchFilters
            // 
            this.cmdScheduledSearchFilters.Image = global::Youtube_Search.Properties.Resources.filter_data_128x128;
            this.cmdScheduledSearchFilters.Location = new System.Drawing.Point(274, 223);
            this.cmdScheduledSearchFilters.Name = "cmdScheduledSearchFilters";
            this.cmdScheduledSearchFilters.Size = new System.Drawing.Size(243, 178);
            this.cmdScheduledSearchFilters.TabIndex = 5;
            this.cmdScheduledSearchFilters.Text = "Scheduled Search Filters";
            this.cmdScheduledSearchFilters.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdScheduledSearchFilters.UseVisualStyleBackColor = true;
            this.cmdScheduledSearchFilters.Click += new System.EventHandler(this.cmdScheduledSearchFilters_Click);
            // 
            // cmdShowSearchResults
            // 
            this.cmdShowSearchResults.Image = global::Youtube_Search.Properties.Resources.scheduled_Search_128x128;
            this.cmdShowSearchResults.Location = new System.Drawing.Point(11, 223);
            this.cmdShowSearchResults.Name = "cmdShowSearchResults";
            this.cmdShowSearchResults.Size = new System.Drawing.Size(243, 178);
            this.cmdShowSearchResults.TabIndex = 4;
            this.cmdShowSearchResults.Text = "Show Scheduled Search Results";
            this.cmdShowSearchResults.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdShowSearchResults.UseVisualStyleBackColor = true;
            this.cmdShowSearchResults.Click += new System.EventHandler(this.cmdShowSearchResults_Click);
            // 
            // cmdAddToBlackListManually
            // 
            this.cmdAddToBlackListManually.Image = global::Youtube_Search.Properties.Resources.notebook_add129;
            this.cmdAddToBlackListManually.Location = new System.Drawing.Point(537, 27);
            this.cmdAddToBlackListManually.Name = "cmdAddToBlackListManually";
            this.cmdAddToBlackListManually.Size = new System.Drawing.Size(243, 178);
            this.cmdAddToBlackListManually.TabIndex = 3;
            this.cmdAddToBlackListManually.Text = "Add To Blacklist Manually";
            this.cmdAddToBlackListManually.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAddToBlackListManually.UseVisualStyleBackColor = true;
            this.cmdAddToBlackListManually.Click += new System.EventHandler(this.cmdAddToBlackListManually_Click);
            // 
            // cmdBlackListedChannels
            // 
            this.cmdBlackListedChannels.Image = global::Youtube_Search.Properties.Resources.dislike_128;
            this.cmdBlackListedChannels.Location = new System.Drawing.Point(274, 27);
            this.cmdBlackListedChannels.Name = "cmdBlackListedChannels";
            this.cmdBlackListedChannels.Size = new System.Drawing.Size(243, 178);
            this.cmdBlackListedChannels.TabIndex = 2;
            this.cmdBlackListedChannels.Text = "Blacklisted Channels";
            this.cmdBlackListedChannels.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdBlackListedChannels.UseVisualStyleBackColor = true;
            this.cmdBlackListedChannels.Click += new System.EventHandler(this.cmdBlackListedChannels_Click);
            // 
            // cmdApiKey
            // 
            this.cmdApiKey.Image = global::Youtube_Search.Properties.Resources.favorites_add;
            this.cmdApiKey.Location = new System.Drawing.Point(537, 223);
            this.cmdApiKey.Name = "cmdApiKey";
            this.cmdApiKey.Size = new System.Drawing.Size(243, 178);
            this.cmdApiKey.TabIndex = 1;
            this.cmdApiKey.Text = "YouTube API Key";
            this.cmdApiKey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdApiKey.UseVisualStyleBackColor = true;
            this.cmdApiKey.Click += new System.EventHandler(this.cmdApiKey_Click);
            // 
            // cmdSearchYoutube
            // 
            this.cmdSearchYoutube.Image = global::Youtube_Search.Properties.Resources.file_search;
            this.cmdSearchYoutube.Location = new System.Drawing.Point(11, 27);
            this.cmdSearchYoutube.Name = "cmdSearchYoutube";
            this.cmdSearchYoutube.Size = new System.Drawing.Size(243, 178);
            this.cmdSearchYoutube.TabIndex = 0;
            this.cmdSearchYoutube.Text = "Search Youtube";
            this.cmdSearchYoutube.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSearchYoutube.UseVisualStyleBackColor = true;
            this.cmdSearchYoutube.Click += new System.EventHandler(this.cmdSearchYoutube_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 442);
            this.Controls.Add(this.cmdScheduledSearchFilters);
            this.Controls.Add(this.cmdShowSearchResults);
            this.Controls.Add(this.cmdAddToBlackListManually);
            this.Controls.Add(this.cmdBlackListedChannels);
            this.Controls.Add(this.cmdApiKey);
            this.Controls.Add(this.cmdSearchYoutube);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSearchYoutube;
        private System.Windows.Forms.Button cmdApiKey;
        private System.Windows.Forms.Button cmdBlackListedChannels;
        private System.Windows.Forms.Button cmdAddToBlackListManually;
        private System.Windows.Forms.Button cmdShowSearchResults;
        private System.Windows.Forms.Button cmdScheduledSearchFilters;
    }
}