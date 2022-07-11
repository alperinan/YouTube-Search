namespace Youtube_Search
{
    partial class MainSearchResults
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
            this.dgVideos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVideos
            // 
            this.dgVideos.AllowUserToAddRows = false;
            this.dgVideos.AllowUserToDeleteRows = false;
            this.dgVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVideos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgVideos.Location = new System.Drawing.Point(0, 0);
            this.dgVideos.Name = "dgVideos";
            this.dgVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVideos.Size = new System.Drawing.Size(296, 346);
            this.dgVideos.TabIndex = 3;
            this.dgVideos.DoubleClick += new System.EventHandler(this.dgVideos_DoubleClick);
            // 
            // MainSearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 346);
            this.Controls.Add(this.dgVideos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainSearchResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainSearchResults";
            ((System.ComponentModel.ISupportInitialize)(this.dgVideos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVideos;
    }
}