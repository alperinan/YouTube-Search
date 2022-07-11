namespace Youtube_Search
{
    partial class BlackList
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
            this.dgBlackList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsCopyChannelId = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeleteChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdExportToExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkBoxShowOnlyExported = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBlackList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBlackList
            // 
            this.dgBlackList.AllowUserToAddRows = false;
            this.dgBlackList.AllowUserToDeleteRows = false;
            this.dgBlackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBlackList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBlackList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBlackList.Location = new System.Drawing.Point(12, 121);
            this.dgBlackList.MultiSelect = false;
            this.dgBlackList.Name = "dgBlackList";
            this.dgBlackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBlackList.Size = new System.Drawing.Size(725, 472);
            this.dgBlackList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCopyChannelId,
            this.tsDeleteChannel,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 70);
            // 
            // tsCopyChannelId
            // 
            this.tsCopyChannelId.Name = "tsCopyChannelId";
            this.tsCopyChannelId.Size = new System.Drawing.Size(203, 22);
            this.tsCopyChannelId.Text = "Copy Channel ID";
            this.tsCopyChannelId.Click += new System.EventHandler(this.tsCopyChannelId_Click);
            // 
            // tsDeleteChannel
            // 
            this.tsDeleteChannel.Name = "tsDeleteChannel";
            this.tsDeleteChannel.Size = new System.Drawing.Size(203, 22);
            this.tsDeleteChannel.Text = "Delete BlackList Channel";
            this.tsDeleteChannel.Click += new System.EventHandler(this.tsDeleteChannel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem1.Text = "Cancel";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(749, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // cmdExportToExcel
            // 
            this.cmdExportToExcel.Image = global::Youtube_Search.Properties.Resources.Excel_icon;
            this.cmdExportToExcel.Location = new System.Drawing.Point(12, 12);
            this.cmdExportToExcel.Name = "cmdExportToExcel";
            this.cmdExportToExcel.Size = new System.Drawing.Size(133, 103);
            this.cmdExportToExcel.TabIndex = 2;
            this.cmdExportToExcel.Text = "Export To Excel";
            this.cmdExportToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExportToExcel.UseVisualStyleBackColor = true;
            this.cmdExportToExcel.Click += new System.EventHandler(this.cmdExportToExcel_Click);
            // 
            // chkBoxShowOnlyExported
            // 
            this.chkBoxShowOnlyExported.AutoSize = true;
            this.chkBoxShowOnlyExported.Checked = true;
            this.chkBoxShowOnlyExported.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxShowOnlyExported.Location = new System.Drawing.Point(190, 41);
            this.chkBoxShowOnlyExported.Name = "chkBoxShowOnlyExported";
            this.chkBoxShowOnlyExported.Size = new System.Drawing.Size(183, 17);
            this.chkBoxShowOnlyExported.TabIndex = 3;
            this.chkBoxShowOnlyExported.Text = "Show only not exported channels";
            this.chkBoxShowOnlyExported.UseVisualStyleBackColor = true;
            this.chkBoxShowOnlyExported.CheckedChanged += new System.EventHandler(this.chkBoxShowOnlyExported_CheckedChanged);
            // 
            // BlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 627);
            this.Controls.Add(this.chkBoxShowOnlyExported);
            this.Controls.Add(this.cmdExportToExcel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgBlackList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "BlackList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackList";
            ((System.ComponentModel.ISupportInitialize)(this.dgBlackList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBlackList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button cmdExportToExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsCopyChannelId;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteChannel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chkBoxShowOnlyExported;
    }
}