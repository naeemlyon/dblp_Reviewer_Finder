namespace dblp_Reviewer_Finder
{
    partial class frm_Visualization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Visualization));
            this.btn_Visualization = new System.Windows.Forms.Button();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.cbo_Height = new System.Windows.Forms.ComboBox();
            this.cbo_Width = new System.Windows.Forms.ComboBox();
            this.lvw_Master = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.lvw_Detail = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.rad_Topics = new System.Windows.Forms.RadioButton();
            this.rad_Authors = new System.Windows.Forms.RadioButton();
            this.btn_Indiv_Files = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Visualization
            // 
            this.btn_Visualization.Location = new System.Drawing.Point(646, 478);
            this.btn_Visualization.Name = "btn_Visualization";
            this.btn_Visualization.Size = new System.Drawing.Size(88, 29);
            this.btn_Visualization.TabIndex = 109;
            this.btn_Visualization.Text = "Visualization";
            this.btn_Visualization.UseVisualStyleBackColor = true;
            this.btn_Visualization.Click += new System.EventHandler(this.btn_Visualization_Click);
            // 
            // tbx_Display
            // 
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbx_Display.Location = new System.Drawing.Point(1, 513);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(733, 36);
            this.tbx_Display.TabIndex = 110;
            // 
            // cbo_Height
            // 
            this.cbo_Height.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Height.FormattingEnabled = true;
            this.cbo_Height.Location = new System.Drawing.Point(590, 483);
            this.cbo_Height.Name = "cbo_Height";
            this.cbo_Height.Size = new System.Drawing.Size(50, 21);
            this.cbo_Height.TabIndex = 112;
            // 
            // cbo_Width
            // 
            this.cbo_Width.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Width.FormattingEnabled = true;
            this.cbo_Width.Location = new System.Drawing.Point(512, 484);
            this.cbo_Width.Name = "cbo_Width";
            this.cbo_Width.Size = new System.Drawing.Size(50, 21);
            this.cbo_Width.TabIndex = 111;
            // 
            // lvw_Master
            // 
            this.lvw_Master.BackColor = System.Drawing.Color.PowderBlue;
            this.lvw_Master.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28});
            this.lvw_Master.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Master.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Master.FullRowSelect = true;
            this.lvw_Master.GridLines = true;
            this.lvw_Master.HideSelection = false;
            this.lvw_Master.Location = new System.Drawing.Point(1, 1);
            this.lvw_Master.MultiSelect = false;
            this.lvw_Master.Name = "lvw_Master";
            this.lvw_Master.Size = new System.Drawing.Size(345, 506);
            this.lvw_Master.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvw_Master.TabIndex = 113;
            this.lvw_Master.UseCompatibleStateImageBehavior = false;
            this.lvw_Master.View = System.Windows.Forms.View.Details;
            this.lvw_Master.Click += new System.EventHandler(this.lvw_Authors_Click);
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Authors";
            this.columnHeader28.Width = 320;
            // 
            // lvw_Detail
            // 
            this.lvw_Detail.BackColor = System.Drawing.Color.Pink;
            this.lvw_Detail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader27});
            this.lvw_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Detail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Detail.FullRowSelect = true;
            this.lvw_Detail.GridLines = true;
            this.lvw_Detail.HideSelection = false;
            this.lvw_Detail.Location = new System.Drawing.Point(352, 12);
            this.lvw_Detail.MultiSelect = false;
            this.lvw_Detail.Name = "lvw_Detail";
            this.lvw_Detail.Size = new System.Drawing.Size(382, 392);
            this.lvw_Detail.TabIndex = 114;
            this.lvw_Detail.UseCompatibleStateImageBehavior = false;
            this.lvw_Detail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Topic";
            this.columnHeader1.Width = 320;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Frequency";
            this.columnHeader27.Width = 40;
            // 
            // rad_Topics
            // 
            this.rad_Topics.AutoSize = true;
            this.rad_Topics.Checked = true;
            this.rad_Topics.Location = new System.Drawing.Point(352, 487);
            this.rad_Topics.Name = "rad_Topics";
            this.rad_Topics.Size = new System.Drawing.Size(57, 17);
            this.rad_Topics.TabIndex = 116;
            this.rad_Topics.TabStop = true;
            this.rad_Topics.Text = "Topics";
            this.rad_Topics.UseVisualStyleBackColor = true;
            this.rad_Topics.Click += new System.EventHandler(this.rad_Topics_Click);
            // 
            // rad_Authors
            // 
            this.rad_Authors.AutoSize = true;
            this.rad_Authors.Location = new System.Drawing.Point(431, 487);
            this.rad_Authors.Name = "rad_Authors";
            this.rad_Authors.Size = new System.Drawing.Size(61, 17);
            this.rad_Authors.TabIndex = 117;
            this.rad_Authors.Text = "Authors";
            this.rad_Authors.UseVisualStyleBackColor = true;
            this.rad_Authors.Click += new System.EventHandler(this.rad_Authors_Click);
            // 
            // btn_Indiv_Files
            // 
            this.btn_Indiv_Files.Location = new System.Drawing.Point(453, 430);
            this.btn_Indiv_Files.Name = "btn_Indiv_Files";
            this.btn_Indiv_Files.Size = new System.Drawing.Size(160, 27);
            this.btn_Indiv_Files.TabIndex = 118;
            this.btn_Indiv_Files.Text = "Indiv Files";
            this.btn_Indiv_Files.UseVisualStyleBackColor = true;
            this.btn_Indiv_Files.Click += new System.EventHandler(this.btn_Indiv_Files_Click);
            // 
            // frm_Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 554);
            this.Controls.Add(this.btn_Indiv_Files);
            this.Controls.Add(this.rad_Authors);
            this.Controls.Add(this.rad_Topics);
            this.Controls.Add(this.lvw_Detail);
            this.Controls.Add(this.lvw_Master);
            this.Controls.Add(this.cbo_Height);
            this.Controls.Add(this.cbo_Width);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.btn_Visualization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frm_Visualization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualization of Growbag (dblp) by naeem@email.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Visualization;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.ComboBox cbo_Height;
        private System.Windows.Forms.ComboBox cbo_Width;
        private System.Windows.Forms.ListView lvw_Master;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ListView lvw_Detail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.RadioButton rad_Topics;
        private System.Windows.Forms.RadioButton rad_Authors;
        private System.Windows.Forms.Button btn_Indiv_Files;
    }
}