namespace Youtube_Search
{
    partial class AddManually
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
            this.cmdAddChannelsToBlacklist = new System.Windows.Forms.Button();
            this.txtBoxChannels = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdAddChannelsToBlacklist
            // 
            this.cmdAddChannelsToBlacklist.Location = new System.Drawing.Point(502, 347);
            this.cmdAddChannelsToBlacklist.Name = "cmdAddChannelsToBlacklist";
            this.cmdAddChannelsToBlacklist.Size = new System.Drawing.Size(160, 76);
            this.cmdAddChannelsToBlacklist.TabIndex = 0;
            this.cmdAddChannelsToBlacklist.Text = "Add Channels To Blacklist";
            this.cmdAddChannelsToBlacklist.UseVisualStyleBackColor = true;
            this.cmdAddChannelsToBlacklist.Click += new System.EventHandler(this.cmdAddChannelsToBlacklist_Click);
            // 
            // txtBoxChannels
            // 
            this.txtBoxChannels.Location = new System.Drawing.Point(12, 12);
            this.txtBoxChannels.Multiline = true;
            this.txtBoxChannels.Name = "txtBoxChannels";
            this.txtBoxChannels.Size = new System.Drawing.Size(650, 329);
            this.txtBoxChannels.TabIndex = 1;
            // 
            // AddManually
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 427);
            this.Controls.Add(this.txtBoxChannels);
            this.Controls.Add(this.cmdAddChannelsToBlacklist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AddManually";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Manually";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAddChannelsToBlacklist;
        private System.Windows.Forms.TextBox txtBoxChannels;
    }
}