namespace Youtube_Search
{
    partial class ApiKeyForm
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
            this.txtBoxApiKey = new System.Windows.Forms.TextBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAddApiKey = new System.Windows.Forms.Button();
            this.lstBoxApiKeys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxApiKey
            // 
            this.txtBoxApiKey.Location = new System.Drawing.Point(93, 24);
            this.txtBoxApiKey.Name = "txtBoxApiKey";
            this.txtBoxApiKey.Size = new System.Drawing.Size(377, 20);
            this.txtBoxApiKey.TabIndex = 0;
            // 
            // lblKeywords
            // 
            this.lblKeywords.BackColor = System.Drawing.Color.Navy;
            this.lblKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeywords.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblKeywords.Location = new System.Drawing.Point(8, 24);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(79, 20);
            this.lblKeywords.TabIndex = 2;
            this.lblKeywords.Text = "New Api Key";
            this.lblKeywords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(110, -5);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(394, 284);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAddApiKey
            // 
            this.cmdAddApiKey.Image = global::Youtube_Search.Properties.Resources.plus1;
            this.cmdAddApiKey.Location = new System.Drawing.Point(476, 24);
            this.cmdAddApiKey.Name = "cmdAddApiKey";
            this.cmdAddApiKey.Size = new System.Drawing.Size(26, 20);
            this.cmdAddApiKey.TabIndex = 5;
            this.cmdAddApiKey.UseVisualStyleBackColor = true;
            this.cmdAddApiKey.Click += new System.EventHandler(this.cmdAddApiKey_Click);
            // 
            // lstBoxApiKeys
            // 
            this.lstBoxApiKeys.FormattingEnabled = true;
            this.lstBoxApiKeys.Location = new System.Drawing.Point(92, 66);
            this.lstBoxApiKeys.Name = "lstBoxApiKeys";
            this.lstBoxApiKeys.Size = new System.Drawing.Size(377, 199);
            this.lstBoxApiKeys.TabIndex = 6;
            this.lstBoxApiKeys.SelectedIndexChanged += new System.EventHandler(this.lstBoxApiKeys_SelectedIndexChanged);
            this.lstBoxApiKeys.SelectedValueChanged += new System.EventHandler(this.lstBoxApiKeys_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(8, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Api Keys";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Location = new System.Drawing.Point(92, 284);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // ApiKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxApiKeys);
            this.Controls.Add(this.cmdAddApiKey);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblKeywords);
            this.Controls.Add(this.txtBoxApiKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ApiKeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ApiKeyForm";
            this.Load += new System.EventHandler(this.ApiKeyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxApiKey;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAddApiKey;
        private System.Windows.Forms.ListBox lstBoxApiKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdDelete;
    }
}