namespace Youtube_Search
{
    partial class ExportToExcel
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
            this.labelWarning = new System.Windows.Forms.Label();
            this.pgExportToExcel = new System.Windows.Forms.ProgressBar();
            this.bgWorkerExportToExcel = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.BackColor = System.Drawing.Color.LightSkyBlue;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Maroon;
            this.labelWarning.Location = new System.Drawing.Point(118, 35);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(267, 20);
            this.labelWarning.TabIndex = 5;
            this.labelWarning.Text = "Please wait while Excel file is created";
            // 
            // pgExportToExcel
            // 
            this.pgExportToExcel.Location = new System.Drawing.Point(70, 87);
            this.pgExportToExcel.Name = "pgExportToExcel";
            this.pgExportToExcel.Size = new System.Drawing.Size(369, 23);
            this.pgExportToExcel.TabIndex = 6;
            // 
            // bgWorkerExportToExcel
            // 
            this.bgWorkerExportToExcel.WorkerReportsProgress = true;
            this.bgWorkerExportToExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerExportToExcel_DoWork);
            this.bgWorkerExportToExcel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerExportToExcel_ProgressChanged);
            this.bgWorkerExportToExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerExportToExcel_RunWorkerCompleted);
            // 
            // ExportToExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 155);
            this.Controls.Add(this.pgExportToExcel);
            this.Controls.Add(this.labelWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportToExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportToExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.ProgressBar pgExportToExcel;
        private System.ComponentModel.BackgroundWorker bgWorkerExportToExcel;
    }
}