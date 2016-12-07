namespace dblp_Reviewer_Finder
{
    partial class frm_dblp_Reviewer
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
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dblp_Reviewer));
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Gen_Final_Result_Files = new System.Windows.Forms.Button();
            this.btn_dblp_Pub_History = new System.Windows.Forms.Button();
            this.btn_Keywords_Related_Pub_Count = new System.Windows.Forms.Button();
            this.btn_Prepare_Matlab_Input = new System.Windows.Forms.Button();
            this.btn_Extract_All_Homepage_Links = new System.Windows.Forms.Button();
            this.btn_Post_Processing = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nUD_Year = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Final = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.cbo_To = new System.Windows.Forms.ComboBox();
            this.cbo_From = new System.Windows.Forms.ComboBox();
            this.cbo_Year = new System.Windows.Forms.ComboBox();
            this.chk_Year = new System.Windows.Forms.CheckBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.gls_Control = new GlacialComponents.Controls.GlacialList();
            this.lvw_Keywords = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cht_Pub_History = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cht_CoAuthor_Network = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cht_Pub_Citation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataSet1 = new System.Data.DataSet();
            this.cbo_Authors = new System.Windows.Forms.ComboBox();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.tab_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Year)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_History)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_CoAuthor_Network)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_Citation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabPage1);
            this.tab_Main.Controls.Add(this.tabPage2);
            this.tab_Main.Controls.Add(this.tabPage3);
            this.tab_Main.Controls.Add(this.tabPage4);
            this.tab_Main.Controls.Add(this.tabPage5);
            this.tab_Main.Controls.Add(this.tabPage6);
            this.tab_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Main.Location = new System.Drawing.Point(-2, 12);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(1012, 614);
            this.tab_Main.TabIndex = 85;
            this.tab_Main.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_Main_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.btn_Gen_Final_Result_Files);
            this.tabPage1.Controls.Add(this.btn_dblp_Pub_History);
            this.tabPage1.Controls.Add(this.btn_Keywords_Related_Pub_Count);
            this.tabPage1.Controls.Add(this.btn_Prepare_Matlab_Input);
            this.tabPage1.Controls.Add(this.btn_Extract_All_Homepage_Links);
            this.tabPage1.Controls.Add(this.btn_Post_Processing);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.gls_Control);
            this.tabPage1.Controls.Add(this.lvw_Keywords);
            this.tabPage1.ForeColor = System.Drawing.Color.Maroon;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Page";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Gen_Final_Result_Files
            // 
            this.btn_Gen_Final_Result_Files.Location = new System.Drawing.Point(846, 537);
            this.btn_Gen_Final_Result_Files.Name = "btn_Gen_Final_Result_Files";
            this.btn_Gen_Final_Result_Files.Size = new System.Drawing.Size(146, 31);
            this.btn_Gen_Final_Result_Files.TabIndex = 110;
            this.btn_Gen_Final_Result_Files.Text = "Gen Final Result Files";
            this.btn_Gen_Final_Result_Files.UseVisualStyleBackColor = true;
            this.btn_Gen_Final_Result_Files.Click += new System.EventHandler(this.btn_Gen_Final_Result_Files_Click);
            // 
            // btn_dblp_Pub_History
            // 
            this.btn_dblp_Pub_History.Location = new System.Drawing.Point(6, 538);
            this.btn_dblp_Pub_History.Name = "btn_dblp_Pub_History";
            this.btn_dblp_Pub_History.Size = new System.Drawing.Size(126, 32);
            this.btn_dblp_Pub_History.TabIndex = 109;
            this.btn_dblp_Pub_History.Text = "dblp Pub History";
            this.btn_dblp_Pub_History.UseVisualStyleBackColor = true;
            this.btn_dblp_Pub_History.Click += new System.EventHandler(this.btn_dblp_Pub_History_Click);
            // 
            // btn_Keywords_Related_Pub_Count
            // 
            this.btn_Keywords_Related_Pub_Count.Location = new System.Drawing.Point(630, 536);
            this.btn_Keywords_Related_Pub_Count.Name = "btn_Keywords_Related_Pub_Count";
            this.btn_Keywords_Related_Pub_Count.Size = new System.Drawing.Size(187, 32);
            this.btn_Keywords_Related_Pub_Count.TabIndex = 108;
            this.btn_Keywords_Related_Pub_Count.Text = "Keywords Related Pub Count";
            this.btn_Keywords_Related_Pub_Count.UseVisualStyleBackColor = true;
            this.btn_Keywords_Related_Pub_Count.Click += new System.EventHandler(this.btn_Keywords_Related_Pub_Count_Click);
            // 
            // btn_Prepare_Matlab_Input
            // 
            this.btn_Prepare_Matlab_Input.Location = new System.Drawing.Point(148, 539);
            this.btn_Prepare_Matlab_Input.Name = "btn_Prepare_Matlab_Input";
            this.btn_Prepare_Matlab_Input.Size = new System.Drawing.Size(142, 33);
            this.btn_Prepare_Matlab_Input.TabIndex = 107;
            this.btn_Prepare_Matlab_Input.Text = "Prepare Matlab Input";
            this.btn_Prepare_Matlab_Input.UseVisualStyleBackColor = true;
            this.btn_Prepare_Matlab_Input.Click += new System.EventHandler(this.btn_Prepare_Matlab_Input_Click);
            // 
            // btn_Extract_All_Homepage_Links
            // 
            this.btn_Extract_All_Homepage_Links.Location = new System.Drawing.Point(306, 537);
            this.btn_Extract_All_Homepage_Links.Name = "btn_Extract_All_Homepage_Links";
            this.btn_Extract_All_Homepage_Links.Size = new System.Drawing.Size(185, 34);
            this.btn_Extract_All_Homepage_Links.TabIndex = 106;
            this.btn_Extract_All_Homepage_Links.Text = "Extract All Homepage Links";
            this.btn_Extract_All_Homepage_Links.UseVisualStyleBackColor = true;
            this.btn_Extract_All_Homepage_Links.Click += new System.EventHandler(this.btn_Extract_All_Homepage_Links_Click);
            // 
            // btn_Post_Processing
            // 
            this.btn_Post_Processing.Location = new System.Drawing.Point(506, 537);
            this.btn_Post_Processing.Name = "btn_Post_Processing";
            this.btn_Post_Processing.Size = new System.Drawing.Size(116, 34);
            this.btn_Post_Processing.TabIndex = 105;
            this.btn_Post_Processing.Text = "Post Processing";
            this.btn_Post_Processing.UseVisualStyleBackColor = true;
            this.btn_Post_Processing.Click += new System.EventHandler(this.btn_Post_Processing_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nUD_Year);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_Final);
            this.groupBox2.Location = new System.Drawing.Point(822, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 95);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Pub. Yrs";
            // 
            // nUD_Year
            // 
            this.nUD_Year.Location = new System.Drawing.Point(43, 18);
            this.nUD_Year.Name = "nUD_Year";
            this.nUD_Year.Size = new System.Drawing.Size(46, 20);
            this.nUD_Year.TabIndex = 104;
            this.nUD_Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_Year.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Last";
            // 
            // btn_Final
            // 
            this.btn_Final.Location = new System.Drawing.Point(37, 51);
            this.btn_Final.Name = "btn_Final";
            this.btn_Final.Size = new System.Drawing.Size(92, 30);
            this.btn_Final.TabIndex = 102;
            this.btn_Final.Text = "Final";
            this.btn_Final.UseVisualStyleBackColor = true;
            this.btn_Final.Click += new System.EventHandler(this.btn_Final_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.btn_Refresh);
            this.groupBox1.Controls.Add(this.cbo_To);
            this.groupBox1.Controls.Add(this.cbo_From);
            this.groupBox1.Controls.Add(this.cbo_Year);
            this.groupBox1.Controls.Add(this.chk_Year);
            this.groupBox1.Controls.Add(this.btn_Start);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Location = new System.Drawing.Point(822, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 163);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(55, 92);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(45, 16);
            this.btn_Refresh.TabIndex = 108;
            this.btn_Refresh.Text = "\'\'\'\'\'\'\'\'\'\'";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // cbo_To
            // 
            this.cbo_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_To.FormattingEnabled = true;
            this.cbo_To.Location = new System.Drawing.Point(92, 60);
            this.cbo_To.Name = "cbo_To";
            this.cbo_To.Size = new System.Drawing.Size(69, 21);
            this.cbo_To.TabIndex = 107;
            // 
            // cbo_From
            // 
            this.cbo_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_From.FormattingEnabled = true;
            this.cbo_From.Location = new System.Drawing.Point(6, 61);
            this.cbo_From.Name = "cbo_From";
            this.cbo_From.Size = new System.Drawing.Size(66, 21);
            this.cbo_From.TabIndex = 106;
            // 
            // cbo_Year
            // 
            this.cbo_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Year.Enabled = false;
            this.cbo_Year.FormattingEnabled = true;
            this.cbo_Year.Location = new System.Drawing.Point(59, 18);
            this.cbo_Year.Name = "cbo_Year";
            this.cbo_Year.Size = new System.Drawing.Size(80, 21);
            this.cbo_Year.TabIndex = 105;
            // 
            // chk_Year
            // 
            this.chk_Year.AutoSize = true;
            this.chk_Year.Location = new System.Drawing.Point(24, 22);
            this.chk_Year.Name = "chk_Year";
            this.chk_Year.Size = new System.Drawing.Size(15, 14);
            this.chk_Year.TabIndex = 104;
            this.chk_Year.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(19, 119);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(126, 33);
            this.btn_Start.TabIndex = 103;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // gls_Control
            // 
            this.gls_Control.AllowColumnResize = true;
            this.gls_Control.AllowMultiselect = false;
            this.gls_Control.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.gls_Control.AlternatingColors = false;
            this.gls_Control.AutoHeight = true;
            this.gls_Control.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gls_Control.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "Author";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 120;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "Pub.Count";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 65;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column3";
            glColumn3.NumericSort = false;
            glColumn3.Text = "Citation";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 55;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column4";
            glColumn4.NumericSort = false;
            glColumn4.Text = "Co.Authors";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 72;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column5";
            glColumn5.NumericSort = false;
            glColumn5.Text = "Pub.Titles";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 370;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column1x";
            glColumn6.NumericSort = false;
            glColumn6.Text = "URL";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 80;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column2x";
            glColumn7.NumericSort = false;
            glColumn7.Text = "Web.Score";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 135;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column1xx";
            glColumn8.NumericSort = false;
            glColumn8.Text = "Final.Score";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 75;
            this.gls_Control.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8});
            this.gls_Control.ControlStyle = GlacialComponents.Controls.GLControlStyles.Normal;
            this.gls_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gls_Control.FullRowSelect = true;
            this.gls_Control.GridColor = System.Drawing.Color.LightGray;
            this.gls_Control.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.gls_Control.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.gls_Control.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.gls_Control.HeaderHeight = 22;
            this.gls_Control.HeaderVisible = true;
            this.gls_Control.HeaderWordWrap = false;
            this.gls_Control.HotColumnTracking = false;
            this.gls_Control.HotItemTracking = false;
            this.gls_Control.HotTrackingColor = System.Drawing.Color.LightGray;
            this.gls_Control.HoverEvents = false;
            this.gls_Control.HoverTime = 1;
            this.gls_Control.ImageList = null;
            this.gls_Control.ItemHeight = 17;
            this.gls_Control.ItemWordWrap = false;
            this.gls_Control.Location = new System.Drawing.Point(6, 298);
            this.gls_Control.Name = "gls_Control";
            this.gls_Control.Selectable = true;
            this.gls_Control.SelectedTextColor = System.Drawing.Color.White;
            this.gls_Control.SelectionColor = System.Drawing.Color.DarkBlue;
            this.gls_Control.ShowBorder = true;
            this.gls_Control.ShowFocusRect = false;
            this.gls_Control.Size = new System.Drawing.Size(988, 222);
            this.gls_Control.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.gls_Control.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.gls_Control.TabIndex = 94;
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
            this.lvw_Keywords.Location = new System.Drawing.Point(6, 6);
            this.lvw_Keywords.MultiSelect = false;
            this.lvw_Keywords.Name = "lvw_Keywords";
            this.lvw_Keywords.Size = new System.Drawing.Size(811, 286);
            this.lvw_Keywords.TabIndex = 86;
            this.lvw_Keywords.UseCompatibleStateImageBehavior = false;
            this.lvw_Keywords.View = System.Windows.Forms.View.Details;
            this.lvw_Keywords.Click += new System.EventHandler(this.lvw_Keywords_Click);
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Topic";
            this.columnHeader28.Width = 250;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Frequency";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 500;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cht_Pub_History);
            this.tabPage2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Publication History";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.cht_Pub_History.Location = new System.Drawing.Point(71, 6);
            this.cht_Pub_History.Name = "cht_Pub_History";
            series1.BackImageTransparentColor = System.Drawing.Color.White;
            series1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "EmptyPointValue=Zero";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht_Pub_History.Series.Add(series1);
            this.cht_Pub_History.Size = new System.Drawing.Size(895, 443);
            this.cht_Pub_History.TabIndex = 87;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cht_CoAuthor_Network);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1004, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Co Author Network";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cht_CoAuthor_Network
            // 
            chartArea2.Name = "ChartArea1";
            this.cht_CoAuthor_Network.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.cht_CoAuthor_Network.Legends.Add(legend2);
            this.cht_CoAuthor_Network.Location = new System.Drawing.Point(22, 22);
            this.cht_CoAuthor_Network.Name = "cht_CoAuthor_Network";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Funnel;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.cht_CoAuthor_Network.Series.Add(series2);
            this.cht_CoAuthor_Network.Size = new System.Drawing.Size(930, 419);
            this.cht_CoAuthor_Network.TabIndex = 0;
            this.cht_CoAuthor_Network.Text = "chart1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cht_Pub_Citation);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1004, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Citation & Publications";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cht_Pub_Citation
            // 
            chartArea3.Name = "ChartArea1";
            this.cht_Pub_Citation.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.cht_Pub_Citation.Legends.Add(legend3);
            this.cht_Pub_Citation.Location = new System.Drawing.Point(37, 34);
            this.cht_Pub_Citation.Name = "cht_Pub_Citation";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.cht_Pub_Citation.Series.Add(series3);
            this.cht_Pub_Citation.Size = new System.Drawing.Size(930, 419);
            this.cht_Pub_Citation.TabIndex = 1;
            this.cht_Pub_Citation.Text = "chart2";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1004, 484);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1004, 484);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // cbo_Authors
            // 
            this.cbo_Authors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Authors.FormattingEnabled = true;
            this.cbo_Authors.Location = new System.Drawing.Point(784, 632);
            this.cbo_Authors.Name = "cbo_Authors";
            this.cbo_Authors.Size = new System.Drawing.Size(240, 21);
            this.cbo_Authors.TabIndex = 86;
            // 
            // tbx_Display
            // 
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbx_Display.Location = new System.Drawing.Point(12, 632);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(757, 36);
            this.tbx_Display.TabIndex = 94;
            // 
            // frm_dblp_Reviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 668);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.cbo_Authors);
            this.Controls.Add(this.tab_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_dblp_Reviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expert Discovery System (naeem@email.com)";
            this.tab_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Year)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_History)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_CoAuthor_Network)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_Pub_Citation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvw_Keywords;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_Pub_History;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_CoAuthor_Network;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_Pub_Citation;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private GlacialComponents.Controls.GlacialList gls_Control;
        private System.Windows.Forms.ComboBox cbo_Authors;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ComboBox cbo_To;
        private System.Windows.Forms.ComboBox cbo_From;
        private System.Windows.Forms.ComboBox cbo_Year;
        private System.Windows.Forms.CheckBox chk_Year;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUD_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Final;
        private System.Windows.Forms.Button btn_Post_Processing;
        private System.Windows.Forms.Button btn_Extract_All_Homepage_Links;
        private System.Windows.Forms.Button btn_Prepare_Matlab_Input;
        private System.Windows.Forms.Button btn_Keywords_Related_Pub_Count;
        private System.Windows.Forms.Button btn_dblp_Pub_History;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_Gen_Final_Result_Files;       

    }
}

