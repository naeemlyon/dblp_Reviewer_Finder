namespace dblp_Reviewer_Finder
{
    partial class frmExpert
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
            System.Windows.Forms.Button btn_Start;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lvw_Keywords = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.lvw_Authors = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.rad_coOccuredKeywords = new System.Windows.Forms.RadioButton();
            this.rad_generalTerms = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataSet1 = new System.Data.DataSet();
            this.tbc_Chart = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cht_Pub_History = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvw_Marginalized = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            btn_Start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tbc_Chart.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_History)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            btn_Start.BackColor = System.Drawing.Color.Gold;
            btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_Start.ForeColor = System.Drawing.Color.DarkGreen;
            btn_Start.Location = new System.Drawing.Point(586, 645);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new System.Drawing.Size(118, 40);
            btn_Start.TabIndex = 113;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = false;
            btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lvw_Keywords
            // 
            this.lvw_Keywords.BackColor = System.Drawing.Color.PowderBlue;
            this.lvw_Keywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader27,
            this.columnHeader1});
            this.lvw_Keywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Keywords.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Keywords.FullRowSelect = true;
            this.lvw_Keywords.GridLines = true;
            this.lvw_Keywords.HideSelection = false;
            this.lvw_Keywords.Location = new System.Drawing.Point(917, 5);
            this.lvw_Keywords.MultiSelect = false;
            this.lvw_Keywords.Name = "lvw_Keywords";
            this.lvw_Keywords.Size = new System.Drawing.Size(363, 307);
            this.lvw_Keywords.TabIndex = 95;
            this.lvw_Keywords.UseCompatibleStateImageBehavior = false;
            this.lvw_Keywords.View = System.Windows.Forms.View.Details;
            this.lvw_Keywords.Click += new System.EventHandler(this.lvw_Keywords_Click);
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Topic";
            this.columnHeader28.Width = 200;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Publications";
            this.columnHeader27.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Authors";
            // 
            // tbx_Display
            // 
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbx_Display.Location = new System.Drawing.Point(1, 641);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(250, 44);
            this.tbx_Display.TabIndex = 105;
            // 
            // lvw_Authors
            // 
            this.lvw_Authors.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lvw_Authors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvw_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Authors.ForeColor = System.Drawing.Color.Crimson;
            this.lvw_Authors.FullRowSelect = true;
            this.lvw_Authors.GridLines = true;
            this.lvw_Authors.HideSelection = false;
            this.lvw_Authors.Location = new System.Drawing.Point(-1, 5);
            this.lvw_Authors.MultiSelect = false;
            this.lvw_Authors.Name = "lvw_Authors";
            this.lvw_Authors.Size = new System.Drawing.Size(912, 307);
            this.lvw_Authors.TabIndex = 109;
            this.lvw_Authors.UseCompatibleStateImageBehavior = false;
            this.lvw_Authors.View = System.Windows.Forms.View.Details;
            this.lvw_Authors.Click += new System.EventHandler(this.lvw_Authors_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Publications";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Citation";
            this.columnHeader4.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "coAuthNet";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "5.Year.Pub";
            this.columnHeader10.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "This.Topic.Pub";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Non.Web.Wt";
            this.columnHeader7.Width = 125;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Web.Wt";
            this.columnHeader8.Width = 85;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Score";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 115;
            // 
            // rad_coOccuredKeywords
            // 
            this.rad_coOccuredKeywords.AutoSize = true;
            this.rad_coOccuredKeywords.Location = new System.Drawing.Point(154, 17);
            this.rad_coOccuredKeywords.Name = "rad_coOccuredKeywords";
            this.rad_coOccuredKeywords.Size = new System.Drawing.Size(149, 17);
            this.rad_coOccuredKeywords.TabIndex = 109;
            this.rad_coOccuredKeywords.Text = "co Occured Keywords";
            this.rad_coOccuredKeywords.UseVisualStyleBackColor = true;
            // 
            // rad_generalTerms
            // 
            this.rad_generalTerms.AutoSize = true;
            this.rad_generalTerms.Checked = true;
            this.rad_generalTerms.Location = new System.Drawing.Point(11, 15);
            this.rad_generalTerms.Name = "rad_generalTerms";
            this.rad_generalTerms.Size = new System.Drawing.Size(107, 17);
            this.rad_generalTerms.TabIndex = 110;
            this.rad_generalTerms.TabStop = true;
            this.rad_generalTerms.Text = "General Terms";
            this.rad_generalTerms.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Green;
            this.groupBox1.Controls.Add(this.rad_generalTerms);
            this.groupBox1.Controls.Add(this.rad_coOccuredKeywords);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(262, 639);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 49);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // tbc_Chart
            // 
            this.tbc_Chart.Controls.Add(this.tabPage1);
            this.tbc_Chart.Controls.Add(this.tabPage2);
            this.tbc_Chart.Location = new System.Drawing.Point(710, 328);
            this.tbc_Chart.Name = "tbc_Chart";
            this.tbc_Chart.SelectedIndex = 0;
            this.tbc_Chart.Size = new System.Drawing.Size(570, 357);
            this.tbc_Chart.TabIndex = 111;
            this.tbc_Chart.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbc_Chart_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cht_Pub_History);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pub.History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cht_Pub_History
            // 
            this.cht_Pub_History.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.cht_Pub_History.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.None;
            chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            chartArea1.Name = "ChartArea1";
            this.cht_Pub_History.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.cht_Pub_History.Legends.Add(legend1);
            this.cht_Pub_History.Location = new System.Drawing.Point(6, 6);
            this.cht_Pub_History.Name = "cht_Pub_History";
            series1.BackImageTransparentColor = System.Drawing.Color.White;
            series1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "EmptyPointValue=Zero";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht_Pub_History.Series.Add(series1);
            this.cht_Pub_History.Size = new System.Drawing.Size(550, 289);
            this.cht_Pub_History.TabIndex = 111;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Web.Wt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvw_Marginalized
            // 
            this.lvw_Marginalized.BackColor = System.Drawing.Color.LightPink;
            this.lvw_Marginalized.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.lvw_Marginalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Marginalized.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Marginalized.FullRowSelect = true;
            this.lvw_Marginalized.GridLines = true;
            this.lvw_Marginalized.HideSelection = false;
            this.lvw_Marginalized.Location = new System.Drawing.Point(-1, 328);
            this.lvw_Marginalized.MultiSelect = false;
            this.lvw_Marginalized.Name = "lvw_Marginalized";
            this.lvw_Marginalized.Size = new System.Drawing.Size(705, 307);
            this.lvw_Marginalized.TabIndex = 114;
            this.lvw_Marginalized.UseCompatibleStateImageBehavior = false;
            this.lvw_Marginalized.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Author";
            this.columnHeader11.Width = 130;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Publications";
            this.columnHeader12.Width = 85;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Citation";
            this.columnHeader13.Width = 65;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "coAuthNet";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "5.Year.Pub";
            this.columnHeader15.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "This.Topic.Pub";
            this.columnHeader16.Width = 110;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Score";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 120;
            // 
            // frmExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 697);
            this.Controls.Add(this.lvw_Marginalized);
            this.Controls.Add(btn_Start);
            this.Controls.Add(this.tbc_Chart);
            this.Controls.Add(this.lvw_Authors);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.lvw_Keywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expert Identifier & Ranking System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tbc_Chart.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_History)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_Keywords;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.ListView lvw_Authors;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.RadioButton rad_coOccuredKeywords;
        private System.Windows.Forms.RadioButton rad_generalTerms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.TabControl tbc_Chart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_Pub_History;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvw_Marginalized;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
    }
}