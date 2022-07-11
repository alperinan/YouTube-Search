namespace Youtube_Search
{
    partial class ScheduledSearchOutcome
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
            this.components = new System.ComponentModel.Container();
            this.dgVideos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAddToBlacklist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddToBlacklistAndBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpenVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCancel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgVideos
            // 
            this.dgVideos.AllowUserToAddRows = false;
            this.dgVideos.AllowUserToDeleteRows = false;
            this.dgVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVideos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVideos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgVideos.Location = new System.Drawing.Point(0, 0);
            this.dgVideos.Name = "dgVideos";
            this.dgVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVideos.Size = new System.Drawing.Size(1235, 422);
            this.dgVideos.TabIndex = 2;
            this.dgVideos.DoubleClick += new System.EventHandler(this.dgVideos_DoubleClick);
            this.dgVideos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgVideos_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddToBlacklist,
            this.tsAddToBlacklistAndBlock,
            this.tsRemove,
            this.tsOpenVideo,
            this.tsCancel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(259, 136);
            // 
            // tsAddToBlacklist
            // 
            this.tsAddToBlacklist.Name = "tsAddToBlacklist";
            this.tsAddToBlacklist.Size = new System.Drawing.Size(258, 22);
            this.tsAddToBlacklist.Text = "Add Selected to Blacklist";
            this.tsAddToBlacklist.Click += new System.EventHandler(this.tsAddToBlacklist_Click);
            // 
            // tsAddToBlacklistAndBlock
            // 
            this.tsAddToBlacklistAndBlock.Name = "tsAddToBlacklistAndBlock";
            this.tsAddToBlacklistAndBlock.Size = new System.Drawing.Size(258, 22);
            this.tsAddToBlacklistAndBlock.Text = "Add Selected to Blacklist and Block";
            this.tsAddToBlacklistAndBlock.Click += new System.EventHandler(this.tsAddToBlacklistAndBlock_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(258, 22);
            this.tsRemove.Text = "Remove Selected Rows";
            this.tsRemove.Click += new System.EventHandler(this.tsRemove_Click);
            // 
            // tsOpenVideo
            // 
            this.tsOpenVideo.Name = "tsOpenVideo";
            this.tsOpenVideo.Size = new System.Drawing.Size(258, 22);
            this.tsOpenVideo.Text = "Open Selected Videos";
            this.tsOpenVideo.Click += new System.EventHandler(this.tsOpenVideo_Click);
            // 
            // tsCancel
            // 
            this.tsCancel.Name = "tsCancel";
            this.tsCancel.Size = new System.Drawing.Size(258, 22);
            this.tsCancel.Text = "Cancel";
            this.tsCancel.Click += new System.EventHandler(this.tsCancel_Click);
            // 
            // ScheduledSearchOutcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 422);
            this.Controls.Add(this.dgVideos);
            this.Name = "ScheduledSearchOutcome";
            this.Text = "ScheduledSearchOutcome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgVideos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVideos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAddToBlacklist;
        private System.Windows.Forms.ToolStripMenuItem tsAddToBlacklistAndBlock;
        private System.Windows.Forms.ToolStripMenuItem tsRemove;
        private System.Windows.Forms.ToolStripMenuItem tsOpenVideo;
        private System.Windows.Forms.ToolStripMenuItem tsCancel;
    }
}