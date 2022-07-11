namespace Youtube_Search
{
    partial class ScheduledSearchParameters
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdClearParameters = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBoxPageCount = new System.Windows.Forms.ComboBox();
            this.cmbBoxSortBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBoxMaxResults = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBoxVideoCountMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxVideoCountMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSubsCountMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxSubsCountMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioLong = new System.Windows.Forms.RadioButton();
            this.RadioMedium = new System.Windows.Forms.RadioButton();
            this.radioShort = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxPublishedBefore = new System.Windows.Forms.TextBox();
            this.lblPublishedBefore = new System.Windows.Forms.Label();
            this.dtPublishedBefore = new System.Windows.Forms.DateTimePicker();
            this.txtBoxPublishedAfter = new System.Windows.Forms.TextBox();
            this.lblPublishedAfter = new System.Windows.Forms.Label();
            this.dtPublishedAfter = new System.Windows.Forms.DateTimePicker();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioThisYear = new System.Windows.Forms.RadioButton();
            this.radioThisMonth = new System.Windows.Forms.RadioButton();
            this.radioThisWeek = new System.Windows.Forms.RadioButton();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.radio1Hour = new System.Windows.Forms.RadioButton();
            this.lstBoxFavoriteKeywords = new System.Windows.Forms.ListBox();
            this.lblFavoriteKeywords = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdClearParameters);
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbBoxPageCount);
            this.groupBox1.Controls.Add(this.cmbBoxSortBy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbBoxMaxResults);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lstBoxFavoriteKeywords);
            this.groupBox1.Controls.Add(this.lblFavoriteKeywords);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 327);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmdClearParameters
            // 
            this.cmdClearParameters.Location = new System.Drawing.Point(394, 298);
            this.cmdClearParameters.Name = "cmdClearParameters";
            this.cmdClearParameters.Size = new System.Drawing.Size(81, 23);
            this.cmdClearParameters.TabIndex = 17;
            this.cmdClearParameters.Text = "Clear";
            this.cmdClearParameters.UseVisualStyleBackColor = true;
            this.cmdClearParameters.Click += new System.EventHandler(this.cmdClearParameters_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(568, 298);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(86, 23);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(481, 298);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(81, 23);
            this.cmdSave.TabIndex = 15;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Navy;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(373, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Page Count";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBoxPageCount
            // 
            this.cmbBoxPageCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxPageCount.FormattingEnabled = true;
            this.cmbBoxPageCount.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20"});
            this.cmbBoxPageCount.Location = new System.Drawing.Point(490, 218);
            this.cmbBoxPageCount.Name = "cmbBoxPageCount";
            this.cmbBoxPageCount.Size = new System.Drawing.Size(164, 21);
            this.cmbBoxPageCount.TabIndex = 13;
            // 
            // cmbBoxSortBy
            // 
            this.cmbBoxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSortBy.FormattingEnabled = true;
            this.cmbBoxSortBy.Items.AddRange(new object[] {
            "View Count",
            "Date",
            "Rating"});
            this.cmbBoxSortBy.Location = new System.Drawing.Point(490, 250);
            this.cmbBoxSortBy.Name = "cmbBoxSortBy";
            this.cmbBoxSortBy.Size = new System.Drawing.Size(164, 21);
            this.cmbBoxSortBy.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Navy;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(373, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sort By";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Navy;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(373, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Results Per Page";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBoxMaxResults
            // 
            this.cmbBoxMaxResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMaxResults.FormattingEnabled = true;
            this.cmbBoxMaxResults.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cmbBoxMaxResults.Location = new System.Drawing.Point(490, 185);
            this.cmbBoxMaxResults.Name = "cmbBoxMaxResults";
            this.cmbBoxMaxResults.Size = new System.Drawing.Size(164, 21);
            this.cmbBoxMaxResults.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtBoxVideoCountMax);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtBoxVideoCountMin);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtBoxSubsCountMax);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtBoxSubsCountMin);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(186, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 140);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Channel Filters";
            // 
            // txtBoxVideoCountMax
            // 
            this.txtBoxVideoCountMax.Location = new System.Drawing.Point(116, 100);
            this.txtBoxVideoCountMax.Name = "txtBoxVideoCountMax";
            this.txtBoxVideoCountMax.Size = new System.Drawing.Size(42, 20);
            this.txtBoxVideoCountMax.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "max";
            // 
            // txtBoxVideoCountMin
            // 
            this.txtBoxVideoCountMin.Location = new System.Drawing.Point(36, 100);
            this.txtBoxVideoCountMin.Name = "txtBoxVideoCountMin";
            this.txtBoxVideoCountMin.Size = new System.Drawing.Size(42, 20);
            this.txtBoxVideoCountMin.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "min";
            // 
            // txtBoxSubsCountMax
            // 
            this.txtBoxSubsCountMax.Location = new System.Drawing.Point(116, 43);
            this.txtBoxSubsCountMax.Name = "txtBoxSubsCountMax";
            this.txtBoxSubsCountMax.Size = new System.Drawing.Size(42, 20);
            this.txtBoxSubsCountMax.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "max";
            // 
            // txtBoxSubsCountMin
            // 
            this.txtBoxSubsCountMin.Location = new System.Drawing.Point(36, 43);
            this.txtBoxSubsCountMin.Name = "txtBoxSubsCountMin";
            this.txtBoxSubsCountMin.Size = new System.Drawing.Size(42, 20);
            this.txtBoxSubsCountMin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "min";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Video Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subscriber Count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioLong);
            this.groupBox3.Controls.Add(this.RadioMedium);
            this.groupBox3.Controls.Add(this.radioShort);
            this.groupBox3.Location = new System.Drawing.Point(12, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 141);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter By Duration";
            // 
            // radioLong
            // 
            this.radioLong.AutoSize = true;
            this.radioLong.Location = new System.Drawing.Point(4, 104);
            this.radioLong.Name = "radioLong";
            this.radioLong.Size = new System.Drawing.Size(95, 17);
            this.radioLong.TabIndex = 2;
            this.radioLong.TabStop = true;
            this.radioLong.Text = "Long (>20 min)";
            this.radioLong.UseVisualStyleBackColor = true;
            // 
            // RadioMedium
            // 
            this.RadioMedium.AutoSize = true;
            this.RadioMedium.Location = new System.Drawing.Point(4, 65);
            this.RadioMedium.Name = "RadioMedium";
            this.RadioMedium.Size = new System.Drawing.Size(144, 17);
            this.RadioMedium.TabIndex = 1;
            this.RadioMedium.TabStop = true;
            this.RadioMedium.Text = "Medium (>4 and <20 min)";
            this.RadioMedium.UseVisualStyleBackColor = true;
            // 
            // radioShort
            // 
            this.radioShort.AutoSize = true;
            this.radioShort.Location = new System.Drawing.Point(4, 28);
            this.radioShort.Name = "radioShort";
            this.radioShort.Size = new System.Drawing.Size(90, 17);
            this.radioShort.TabIndex = 0;
            this.radioShort.TabStop = true;
            this.radioShort.Text = "Short (<4 min)";
            this.radioShort.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxPublishedBefore);
            this.groupBox2.Controls.Add(this.lblPublishedBefore);
            this.groupBox2.Controls.Add(this.dtPublishedBefore);
            this.groupBox2.Controls.Add(this.txtBoxPublishedAfter);
            this.groupBox2.Controls.Add(this.lblPublishedAfter);
            this.groupBox2.Controls.Add(this.dtPublishedAfter);
            this.groupBox2.Controls.Add(this.radioCustom);
            this.groupBox2.Controls.Add(this.radioThisYear);
            this.groupBox2.Controls.Add(this.radioThisMonth);
            this.groupBox2.Controls.Add(this.radioThisWeek);
            this.groupBox2.Controls.Add(this.radioToday);
            this.groupBox2.Controls.Add(this.radio1Hour);
            this.groupBox2.Location = new System.Drawing.Point(363, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter By Upload Date";
            // 
            // txtBoxPublishedBefore
            // 
            this.txtBoxPublishedBefore.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxPublishedBefore.Location = new System.Drawing.Point(181, 113);
            this.txtBoxPublishedBefore.Name = "txtBoxPublishedBefore";
            this.txtBoxPublishedBefore.ReadOnly = true;
            this.txtBoxPublishedBefore.Size = new System.Drawing.Size(73, 20);
            this.txtBoxPublishedBefore.TabIndex = 11;
            this.txtBoxPublishedBefore.DoubleClick += new System.EventHandler(this.txtBoxPublishedBefore_DoubleClick);
            // 
            // lblPublishedBefore
            // 
            this.lblPublishedBefore.AutoSize = true;
            this.lblPublishedBefore.Location = new System.Drawing.Point(159, 115);
            this.lblPublishedBefore.Name = "lblPublishedBefore";
            this.lblPublishedBefore.Size = new System.Drawing.Size(20, 13);
            this.lblPublishedBefore.TabIndex = 10;
            this.lblPublishedBefore.Text = "To";
            // 
            // dtPublishedBefore
            // 
            this.dtPublishedBefore.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPublishedBefore.Location = new System.Drawing.Point(181, 113);
            this.dtPublishedBefore.Name = "dtPublishedBefore";
            this.dtPublishedBefore.Size = new System.Drawing.Size(102, 20);
            this.dtPublishedBefore.TabIndex = 9;
            this.dtPublishedBefore.ValueChanged += new System.EventHandler(this.dtPublishedBefore_ValueChanged);
            // 
            // txtBoxPublishedAfter
            // 
            this.txtBoxPublishedAfter.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxPublishedAfter.Location = new System.Drawing.Point(48, 113);
            this.txtBoxPublishedAfter.Name = "txtBoxPublishedAfter";
            this.txtBoxPublishedAfter.ReadOnly = true;
            this.txtBoxPublishedAfter.Size = new System.Drawing.Size(73, 20);
            this.txtBoxPublishedAfter.TabIndex = 8;
            this.txtBoxPublishedAfter.DoubleClick += new System.EventHandler(this.txtBoxPublishedAfter_DoubleClick);
            // 
            // lblPublishedAfter
            // 
            this.lblPublishedAfter.AutoSize = true;
            this.lblPublishedAfter.Location = new System.Drawing.Point(12, 115);
            this.lblPublishedAfter.Name = "lblPublishedAfter";
            this.lblPublishedAfter.Size = new System.Drawing.Size(30, 13);
            this.lblPublishedAfter.TabIndex = 7;
            this.lblPublishedAfter.Text = "From";
            // 
            // dtPublishedAfter
            // 
            this.dtPublishedAfter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPublishedAfter.Location = new System.Drawing.Point(48, 113);
            this.dtPublishedAfter.Name = "dtPublishedAfter";
            this.dtPublishedAfter.Size = new System.Drawing.Size(102, 20);
            this.dtPublishedAfter.TabIndex = 6;
            this.dtPublishedAfter.ValueChanged += new System.EventHandler(this.dtPublishedAfter_ValueChanged);
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Location = new System.Drawing.Point(193, 70);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(60, 17);
            this.radioCustom.TabIndex = 5;
            this.radioCustom.TabStop = true;
            this.radioCustom.Text = "Custom";
            this.radioCustom.UseVisualStyleBackColor = true;
            this.radioCustom.CheckedChanged += new System.EventHandler(this.radioCustom_CheckedChanged);
            // 
            // radioThisYear
            // 
            this.radioThisYear.AutoSize = true;
            this.radioThisYear.Location = new System.Drawing.Point(108, 70);
            this.radioThisYear.Name = "radioThisYear";
            this.radioThisYear.Size = new System.Drawing.Size(70, 17);
            this.radioThisYear.TabIndex = 4;
            this.radioThisYear.TabStop = true;
            this.radioThisYear.Text = "This Year";
            this.radioThisYear.UseVisualStyleBackColor = true;
            // 
            // radioThisMonth
            // 
            this.radioThisMonth.AutoSize = true;
            this.radioThisMonth.Location = new System.Drawing.Point(15, 70);
            this.radioThisMonth.Name = "radioThisMonth";
            this.radioThisMonth.Size = new System.Drawing.Size(78, 17);
            this.radioThisMonth.TabIndex = 3;
            this.radioThisMonth.TabStop = true;
            this.radioThisMonth.Text = "This Month";
            this.radioThisMonth.UseVisualStyleBackColor = true;
            // 
            // radioThisWeek
            // 
            this.radioThisWeek.AutoSize = true;
            this.radioThisWeek.Location = new System.Drawing.Point(193, 29);
            this.radioThisWeek.Name = "radioThisWeek";
            this.radioThisWeek.Size = new System.Drawing.Size(77, 17);
            this.radioThisWeek.TabIndex = 2;
            this.radioThisWeek.TabStop = true;
            this.radioThisWeek.Text = "This Week";
            this.radioThisWeek.UseVisualStyleBackColor = true;
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.Location = new System.Drawing.Point(108, 29);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(55, 17);
            this.radioToday.TabIndex = 1;
            this.radioToday.TabStop = true;
            this.radioToday.Text = "Today";
            this.radioToday.UseVisualStyleBackColor = true;
            // 
            // radio1Hour
            // 
            this.radio1Hour.AutoSize = true;
            this.radio1Hour.Location = new System.Drawing.Point(15, 29);
            this.radio1Hour.Name = "radio1Hour";
            this.radio1Hour.Size = new System.Drawing.Size(80, 17);
            this.radio1Hour.TabIndex = 0;
            this.radio1Hour.TabStop = true;
            this.radio1Hour.Text = "Last 1 Hour";
            this.radio1Hour.UseVisualStyleBackColor = true;
            // 
            // lstBoxFavoriteKeywords
            // 
            this.lstBoxFavoriteKeywords.FormattingEnabled = true;
            this.lstBoxFavoriteKeywords.Location = new System.Drawing.Point(109, 27);
            this.lstBoxFavoriteKeywords.Name = "lstBoxFavoriteKeywords";
            this.lstBoxFavoriteKeywords.Size = new System.Drawing.Size(245, 134);
            this.lstBoxFavoriteKeywords.TabIndex = 3;
            // 
            // lblFavoriteKeywords
            // 
            this.lblFavoriteKeywords.BackColor = System.Drawing.Color.Navy;
            this.lblFavoriteKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavoriteKeywords.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblFavoriteKeywords.Location = new System.Drawing.Point(13, 27);
            this.lblFavoriteKeywords.Name = "lblFavoriteKeywords";
            this.lblFavoriteKeywords.Size = new System.Drawing.Size(79, 20);
            this.lblFavoriteKeywords.TabIndex = 2;
            this.lblFavoriteKeywords.Text = "Keywords";
            this.lblFavoriteKeywords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduledSearchParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 337);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScheduledSearchParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScheduledSearchParameters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBoxPageCount;
        private System.Windows.Forms.ComboBox cmbBoxSortBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBoxMaxResults;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtBoxVideoCountMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxVideoCountMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSubsCountMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxSubsCountMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioLong;
        private System.Windows.Forms.RadioButton RadioMedium;
        private System.Windows.Forms.RadioButton radioShort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBoxPublishedBefore;
        private System.Windows.Forms.Label lblPublishedBefore;
        private System.Windows.Forms.DateTimePicker dtPublishedBefore;
        private System.Windows.Forms.TextBox txtBoxPublishedAfter;
        private System.Windows.Forms.Label lblPublishedAfter;
        private System.Windows.Forms.DateTimePicker dtPublishedAfter;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.RadioButton radioThisYear;
        private System.Windows.Forms.RadioButton radioThisMonth;
        private System.Windows.Forms.RadioButton radioThisWeek;
        private System.Windows.Forms.RadioButton radioToday;
        private System.Windows.Forms.RadioButton radio1Hour;
        private System.Windows.Forms.ListBox lstBoxFavoriteKeywords;
        private System.Windows.Forms.Label lblFavoriteKeywords;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClearParameters;
    }
}