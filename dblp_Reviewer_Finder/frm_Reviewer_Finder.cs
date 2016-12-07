using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlacialComponents.Controls;
using System.Text.RegularExpressions;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace dblp_Reviewer_Finder
{
    public partial class frm_dblp_Reviewer : Form
    {
        #region Class Level Variables and Initialize Calls
        string myConnectionString = "DSN=Naeem;UID=root;PWD=admin";
        OdbcConnection MyConn;
        OdbcCommand MyCmd = new OdbcCommand();
        OdbcCommand MyCmd_2 = new OdbcCommand();
        OdbcCommand MyCmd_3 = new OdbcCommand();        
        String prev_Topic = String.Empty;
        const String App_Title = "Growbag Expert Finder (naeem@email.com)";
        const String LastValueFile = "E:\\Last_Value.txt";
        const String Tilda = "~";
        const String SemiColon = ";";
        const String Comma = ",";
        const String Tab = "\t";

        #region Establish Connection to Catalog

        public frm_dblp_Reviewer()
        {
            InitializeComponent();
            Initialize_Database();
           // Populate_YearComboBox();
            // Step_1(); 
           // Load_All_Topics_with_Authors();            
           
            /*
            int i= 0;
            for (i = 0; i < lvw_Keywords.Items.Count; i++ )
            {
                cbo_From.Items.Add(i.ToString());
                cbo_To.Items.Add(i.ToString());
            }

            What_was_Latest_Value();
            */
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            What_was_Latest_Value();
        }

        private void What_was_Latest_Value()
        {
            int Last_Value = 0;            
            try
            {
                StreamReader SR = File.OpenText(LastValueFile);
                Last_Value = int.Parse( SR.ReadToEnd());
                SR.Close();
                SR.Dispose();
            }
            catch
            {  }

            if (lvw_Keywords.Items.Count <= Last_Value)
                Last_Value = 0;
            cbo_From.SelectedIndex = Last_Value ;            
            if ((Last_Value + 9) >= lvw_Keywords.Items.Count)
                cbo_To.SelectedIndex = lvw_Keywords.Items.Count - 1;
            else
                cbo_To.SelectedIndex = Last_Value + 9;
        }


        private void Initialize_Database()
        {
            MyConn = new OdbcConnection(myConnectionString);            
            MyConn.Open();
            MyCmd.Connection = MyConn;
            MyCmd_2.Connection = MyConn;
            MyCmd_3.Connection = MyConn;

        }
        #endregion 

        #region Populate Year

        private void Populate_YearComboBox()
        {
            int i = 1990;
            int Cur = 2011;
            for (i = 1990; i < Cur; i++)
            {
                cbo_Year.Items.Add(i.ToString());
            }
            cbo_Year.SelectedIndex = cbo_Year.Items.Count - 5;
        }

        private void chk_Year_Click(object sender, EventArgs e)
        {
            if (chk_Year.CheckState == CheckState.Checked)
                cbo_Year.Enabled = true;
            else if (chk_Year.CheckState == CheckState.Unchecked)
                cbo_Year.Enabled = false;
        }

        #endregion

        #endregion

        #region Venue Ranking
        private void Venue_Ranking()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT distinct title from dblp_venues_old LIMIT 60,70");
            MyCmd.CommandText = SQL.ToString();
            OdbcDataReader R = MyCmd.ExecuteReader();          
            ListViewItem L;
            OdbcCommand MyCmd_2 = new OdbcCommand();
            MyCmd_2.Connection = MyConn;

            while (R.Read())
            {
                L = lvw_Keywords.Items.Add(R[0].ToString());
                //L.SubItems.Add(R[0].ToString());                
                SQL = SQL.Remove (0,SQL.Length);
                SQL.Append("SELECT title FROM venue_ranking_core WHERE title LIKE " +  "\"%" + R[0] + "%\"");
                MyCmd_2.CommandText = SQL.ToString();
                OdbcDataReader R_2 = MyCmd_2.ExecuteReader();
                while (R_2.Read())
                {
                    L = lvw_Keywords.Items.Add("-");
                    L.SubItems.Add(R_2[0].ToString());                
                }
                R_2.Close();
                R_2.Dispose();
            }
            //tbx_Display.Text = nResultCount.ToString();
            R.Close();
            R.Dispose();
        }

        #endregion

        #region Step-1: Show All Topic
        private void Step_1()
        {   
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT a.cs_key, b.keywords FROM dblpcsmapping2 AS a INNER JOIN dblp_abstracts AS b ON b.dblp_key = a.dblp_key ");
            //SQL.Append(" Where a.cs_key < 75000 "); // for bilal et. al.,            
            // SQL.Append(" Where a.cs_key >= 375000 and a.cs_key < 475000 "); // to bilal and waqas            
            //SQL.Append(" Where a.cs_key >= 655000 ");  // for bilal et. al.,            
            SQL.Append(" Where a.cs_key >= 625000 and a.cs_key < 655000 ");
            
            
            SQL.Append(" ORDER BY b.keywords DESC");
            MyCmd.CommandText = SQL.ToString();
            OdbcDataReader R = MyCmd.ExecuteReader();
            ListViewItem L;
            Hashtable H = new Hashtable();

            while (R.Read())
            {
                if (R[1].ToString().Trim().Length > 1)
                {
                    if (H.Contains(R[1].ToString()) == false)
                    {
                        H.Add(R[1].ToString(), R[0].ToString());
                        L = lvw_Keywords.Items.Add(R[1].ToString());
                        L.Tag = R[0].ToString();
                    }
                }                
            }            
            R.Close();
            R.Dispose();
            tbx_Display.Text = lvw_Keywords.Items.Count.ToString() + " Topics loaded ";                   

        }
        #endregion
        
        #region Step-2 Author of a selected Topic
        
        private void lvw_Keywords_Click(object sender, EventArgs e)
        {   
            String strTopic = lvw_Keywords.SelectedItems[0].Tag.ToString();
            tbx_Display.Text = lvw_Keywords.SelectedItems[0].Index.ToString() + ": " + lvw_Keywords.SelectedItems[0].Text;            
            Step_2(strTopic);
        }

        private void Step_2(String Inp)
        {            
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT distinct a.author FROM cs_author_ref_new AS a WHERE a.cs_key=" + "\"" + Inp + "\" ");
            //tbx_Display.Text = SQL.ToString();            
            MyCmd.CommandText = SQL.ToString();
            OdbcDataReader R = MyCmd.ExecuteReader();                  
            //lvw_Auth.Items.Clear();
            gls_Control.Items.Clear();
            gls_Control.Refresh();
            cbo_Authors.Items.Clear();
            GLItem L;
            int i = 0;
            while (R.Read())
            {
                L = gls_Control.Items.Add (R[0].ToString());
                for (i=1; i<gls_Control.Columns.Count; i++)
                 L.SubItems.Add("");
                
                cbo_Authors.Items.Add(R[0].ToString());
            }            
            R.Close();
            R.Dispose();
            if (cbo_Authors.Items.Count > 0)
               cbo_Authors.SelectedIndex = 0;
        }
        #endregion
                
        #region Step-3 Related Publications of Authors
        
        private void Fill_Up_Reviewer_Table() 
        {
            int i = 0, j=0;
            int UL = gls_Control.Items.Count;
            String strTopic = lvw_Keywords.SelectedItems[0].Tag.ToString();
            for (i = 0; i < UL; i++)
            {                
                String strAuthor = gls_Control.Items[i].Text;
                Hashtable Pub_Year_Wise = new Hashtable();

                Hashtable hTitles = Step_3(strTopic, strAuthor, Pub_Year_Wise);
                gls_Control.Items[i].SubItems[1].Text = hTitles.Count.ToString(); // display Publication count information            

                // hidden information for graph plotting (Year-wise Publication)..                          
                int Year_From = int.MaxValue;
                int Year_To = int.MinValue ;
                gls_Control.Items[i].SubItems[1].Tag = Hashtable_to_Array(Pub_Year_Wise, ref Year_From, ref Year_To); 

                // citation
                int Citation = get_Author_Citation(hTitles);
                gls_Control.Items[i].SubItems[2].Text = (Citation.ToString());
                // Year_From and Year_To 
                gls_Control.Items[i].SubItems[2].Tag  = Year_From + Comma + Year_To; 


                // co author network quantity..
                int CoAuthors = Computer_CoAuthor_Network(strAuthor, hTitles);
                gls_Control.Items[i].SubItems[3].Text = (CoAuthors.ToString()); //             

                ComboBox CBO = new ComboBox();
                IDictionaryEnumerator ID = hTitles.GetEnumerator();
                 while (ID.MoveNext())
                 {
                     CBO.Items.Add(ID.Key.ToString());  
                 }
                gls_Control.Items[i].SubItems[4].Control = CBO;

                String URL = Extract_HOME_Page_URL(strAuthor); // URL Home Page..                
                gls_Control.Items[i].SubItems[5].Text = URL;
                //Write_All_URLS(strAuthor, URL); // Testing module only...

                // collect all of the link found on this Author's HomePage
                Hashtable HomePage_All_URLS =  Mine_Out_HyperLink(URL);
                String WebPageData = String.Empty;

                // Fech out all of the web page data..                                    
                IDictionaryEnumerator link = HomePage_All_URLS.GetEnumerator();
                    while (link.MoveNext())
                    {                        
                        try
                        {
                            //System.Windows.Forms.Application.DoEvents(); // try to avoid context switch deadlock
                            WebPageData += Fetch_WebPage_Data(link.Key.ToString()) + Environment.NewLine;
                            //MessageBox.Show (link.Key.ToString() , App_Title);
                        }
                        catch
                        {
                            // listBox1.Items.Add(link.Key.ToString());
                            // listBox1.Items.Add("--------------");
                        }       
                    }                
                                
                // Mine out the web pages...
                String[] Arr = Mine_Out_HomePage(WebPageData);
                ComboBox CBO2 = new ComboBox();
                for (j=0; j<Arr.Length; j++)                                
                {
                    CBO2.Items.Add(Arr[j]);
                }
                gls_Control.Items[i].SubItems[6].Control = CBO2;    
            }
            
        }

        private void Write_All_URLS( String Author, String URL)
        {
            if (URL.Trim().Length < 2) return; // url empty...no need of entry..
            StreamWriter SW = File.AppendText("H:\\dblp_urls.txt");
            SW.WriteLine (Author + "," + URL);
            SW.Close();
            SW.Dispose();
        }


        private Hashtable Step_3(String strTopic, String strAuth, Hashtable H)
        {
            Hashtable hTitles = new Hashtable();            
            int Cnt = 0;
            String S = String.Empty;

            S = "SELECT cs_key FROM cs_author_ref_new WHERE author =" + "\"" + strAuth + "\"";
            MyCmd.CommandText = S;
            OdbcDataReader R = MyCmd.ExecuteReader();
            S = String.Empty;
            while (R.Read())
            {
                S += R[0].ToString() + ",";
            }
            if (S.Length > 1)
            {
                S = S.Substring(0, S.Length - 1);                
            }
            R.Close();
            
            S = "SELECT title, year, cs_key FROM cs_pub_new WHERE cs_key IN (" + S + ")";
            MyCmd.CommandText = S;
            R = MyCmd.ExecuteReader();
            S = String.Empty;            
            while (R.Read())
            {
                if (hTitles.Contains(R[0].ToString()) == false)
                {
                    //L = lvw_Pub.Items.Add(R[0].ToString()); //title
                    //L.SubItems.Add(R[1].ToString());        // year
                    hTitles.Add(R[0].ToString(), R[2].ToString()); 

                    // year wise publication
                    if (H.Contains(R[1].ToString()) == false)
                    {
                        H.Add(R[1].ToString(), 1);
                    }
                    else
                    {
                        Cnt = int.Parse(H[R[1].ToString()].ToString());
                        Cnt++;
                        H[R[1].ToString()] = Cnt;
                    }
                }
                //if (R[0].ToString() == strTopic) // colorize the relevant publications
               // else
               //  lbx_UnRelated_Pub.Items.Add(R[2].ToString());
            }
            R.Close();
            R.Dispose();                       
            return hTitles;
        }
        #endregion

        #region Computer Co-Author Network
        private int Computer_CoAuthor_Network(String strAuth, Hashtable hTitles)
        {
            String hisPub = String.Empty;
            String S = String.Empty;
            int Sum = 0;             

            IDictionaryEnumerator ID = hTitles.GetEnumerator();
            while (ID.MoveNext())
            {
                S += ID.Value.ToString() + Comma;  // cs_key;
            }
            if (S.Length < 1) return Sum;
            S = S.Substring(0, S.Length - 1);

            S = "SELECT COUNT( DISTINCT author) FROM cs_author_ref_new WHERE cs_key IN (" + S + ")";
            MyCmd.CommandText = S;
            OdbcDataReader R = MyCmd.ExecuteReader();
            R.Read();
            Sum = int.Parse(R[0].ToString());            
            R.Close();
            return Sum;
        }

        #endregion
        
        #region get Citation (Two Routines)
        private String get_Citation(String strTitle)
        {
            String cs_key = String.Empty;
            String dblp_key = String.Empty;
            String citation = String.Empty; 
            String S = String.Empty;

            S = "SELECT cs_key from cs_pub_new where title='" + strTitle + "'";
            MyCmd.CommandText = S;
            OdbcDataReader R = MyCmd.ExecuteReader();
            while (R.Read())
             cs_key = R[0].ToString();
            R.Close();            
            //tbx_Display.Text = cs_key;

            S = "SELECT dblp_key from dblpcsmapping2 where cs_key = '" + cs_key  + "'";
            MyCmd.CommandText = S;
            R = MyCmd.ExecuteReader();
            while (R.Read())
             dblp_key = R[0].ToString();
            R.Close();
            // tbx_Display.AppendText ( Environment.NewLine +   dblp_key);

            S = "SELECT citation_count FROM citation_analysis WHERE dblp_key = '" + dblp_key + "'";
            MyCmd.CommandText = S;
            R = MyCmd.ExecuteReader();
            while (R.Read())  
             citation = R[0].ToString();
            R.Close();

            if (citation.Trim().Length == 0)
                citation = "0";
            return citation;

        }


        private int get_Author_Citation(Hashtable hTitles)
        {
            int totalCitation = 0;
            String S = String.Empty;            
            IDictionaryEnumerator IE = hTitles.GetEnumerator();            
            while (IE.MoveNext())
            {
                S += "'" + IE.Value.ToString() + "',"; // cs_key
            }
            if (S.Length < 1) return totalCitation;
            S = S.Substring(0, S.Length - 1); // Remove last two characters ,
            
            S = "SELECT dblp_key from dblpcsmapping2 where cs_key IN (" + S + ")";            
            MyCmd.CommandText = S;
            S = String.Empty;
            OdbcDataReader R = MyCmd.ExecuteReader();
            while (R.Read())
                S += "'" + R[0].ToString() + "',"; // dblp_key
            R.Close();
            if (S.Trim().Length < 1) return totalCitation;
            S = S.Substring(0, S.Length - 1); // Remove last two characters ,

            S = "SELECT citation_count FROM citation_analysis WHERE dblp_key IN (" + S + ")";
            MyCmd.CommandText = S;
            R = MyCmd.ExecuteReader();
            while (R.Read())
                totalCitation += int.Parse(R[0].ToString());
            R.Close();
            R.Dispose();                        
           
            return totalCitation;
        }
        #endregion

        #region Populate_Chart (Year Wise)
        private void Populate_Chart_Year_Wise(String H)
        {
            int i = 0;
            String[] Arr = H.Split(SemiColon.ToCharArray());
            Double[] xValues = new Double[Arr.Length];
            Double[] yValues = new Double[Arr.Length];

            for (i = 0; i < Arr.Length; i++)
            {
                String[] A = Arr[i].Split( Tilda.ToCharArray());
                yValues[i] = Double.Parse(A[0].ToString());
                xValues[i] = int.Parse(A[1].ToString());
            }

            cht_Pub_History.ChartAreas[0].AxisX.Minimum = 1990;
            cht_Pub_History.ChartAreas[0].AxisX.Maximum = xValues.Max();
            
            //            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;

            // Populate series data using random data
            //double[] yValues = { 23.67, 75.45, 60.45, 34.54, 85.62, 32.43, 55.98, 67.23, 56.34, 23.14, 45.24, 67.41, 13.45, 56.36, 45.29 };
            for (int pointIndex = 0; pointIndex < yValues.Length; pointIndex++)
            {
                cht_Pub_History.Series["Series1"].Points.AddXY(xValues[pointIndex], yValues[pointIndex]);
            }

            // Export series values into DataSet object
            dataSet1 = cht_Pub_History.DataManipulator.ExportSeriesValues("Series1");

            // Initializes a new instance of the DataView class
            DataView firstView = new DataView(dataSet1.Tables[0]);

            // Since the DataView implements IEnumerable, pass the reader directly into
            // the DataBind method with the name of the Columns selected in the query    
            cht_Pub_History.Series["Series1"].Points.DataBindXY(firstView, "X", firstView, "Y");

            //chart1.Series[0].Label = "#ValX #Val (#ValPercentY{P0})";

            // Invalidate Chart
            cht_Pub_History.Invalidate();

        }
        #endregion
  
        #region Convert Hashtable to String Array
        private String Hashtable_to_Array(Hashtable H, ref int Year_From, ref int Year_To)
        {
            String Ret = String.Empty;
            IDictionaryEnumerator ID = H.GetEnumerator();
            
            while (ID.MoveNext())
            {
                try
                {
                    if (int.Parse(ID.Key.ToString()) > 1930)
                    {
                        if (int.Parse(ID.Key.ToString()) < Year_From)
                            Year_From = int.Parse(ID.Key.ToString());
                        if (int.Parse(ID.Key.ToString()) > Year_To) 
                            Year_To = int.Parse(ID.Key.ToString());
                    }
                }
                catch
                { } // do nothing...
                Ret += ID.Value.ToString() + Tilda + ID.Key.ToString() + SemiColon;
            }
            if (Ret.Length > 1)
                Ret = Ret.Substring(0, Ret.Length - 1); // remove last extra comma
            return Ret;
        }
        #endregion
               
        #region tab_Main_Selected
        private void tab_Main_Selected(Object sender, TabControlEventArgs e)
        {            
            switch (e.TabPageIndex)
            {
                case 1:
                    {                        
                        int i = cbo_Authors.SelectedIndex;
                        Populate_Chart_Year_Wise(gls_Control.Items[i].SubItems[1].Tag.ToString()); // Number of Publ. Year-wise.
                        break;
                    }
                case 2:
                    {
                        cht_CoAuthor_Network.Visible = true; 
                        break;
                    }
                case 3:
                    {
                        cht_Pub_Citation.Visible = true;
                        break;
                    }
                case 4:
                    {                        
                        break;
                    }
                default: // case 0: is main_window
                    break;                
            }
        }
        #endregion
        
        #region interaction with XML File by FILE/ IO Only..
        private String Extract_HOME_Page_URL(String givenAuthor)
        {
            String HomePage = String.Empty; // "Nothing Found";
            String Line = String.Empty;
            String sPath = "A:\\dblpXML\\dblp.xml";
            StreamReader SR = File.OpenText(sPath);
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                if (Line.Contains(givenAuthor) == true)
                {
                    Line = SR.ReadLine(); 
                    if (Line.Contains("<title>Home Page</title>") == true)
                    {
                        Line = SR.ReadLine();
                        Line = Line.Replace("<url>", "");
                        Line = Line.Replace("</www>", "");
                        HomePage  = Line.Replace("</url>", "");
                        SR.Close();
                        SR.Dispose();
                        return HomePage;
                    }
                }
            }
            SR.Close();
            SR.Dispose();
            return HomePage;
        }
        #endregion

        #region Extract all Homepage Link
        private void btn_Extract_All_Homepage_Links_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Extract_All_Homepage_Links();
        }
        
        //   <www key="homepages/m/DavidMaier" ...>
        //   <author>David Maier</author>
        //       <title>Home Page</title>
        //       <url>http://web.cecs.pdx.edu/maier/</url>
        //   </www>

        private String Extract_All_Homepage_Links()
        {
            String HomePage = String.Empty; // "Nothing Found";
            String Author = String.Empty ;
            String Line = String.Empty; 
            String sPath = "A:\\dblpXML\\dblp.xml";
            StreamReader SR = File.OpenText(sPath);
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\" + "HomePages.txt");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                if (Line.Contains("<www") == true) // found <www TAG
                {
                    Line = SR.ReadLine(); // read <author TAG
                    if (Line.Contains("<author") == true)
                    {                        
                        Line = Line.Replace("<author>", "");
                        Line = Line.Replace("</author>", "");
                        Author = Line;
                        Line = SR.ReadLine(); // move to <title TAG
                        if (Line.Contains("<title>Home Page</title>") == true)
                        {
                         Line = SR.ReadLine();
                         Line = Line.Replace("<url>", "");
                         Line = Line.Replace("</www>", "");
                         HomePage  = Line.Replace("</url>", "");                        
                         SW.WriteLine(Author + Tab + HomePage);
                        }
                    }
                }
            }
            SR.Close();
            SR.Dispose();
            SW.Close();
            SW.Dispose();

            return "All Home Pages link extracted ";
        }

        #endregion
        
        #region Fetch WebPage Data
        private String Fetch_WebPage_Data(String URL)
        {   
            String Result = String.Empty;
            
            if (URL.Trim().Length < 2) return Result;            
            
            if (Uri.IsWellFormedUriString(URL, UriKind.Absolute) == false) return Result;

            // cv found
            if (URL.ToLower().Contains(".pdf") == true)
               return Read_PDF(URL);
            
            try
            {
                WebResponse objResponse;
                WebRequest objRequest = System.Net.HttpWebRequest.Create(URL);                
                objResponse = objRequest.GetResponse();
                
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    Result = sr.ReadToEnd();                    
                    // Close and clean up the StreamReader
                    sr.Close();
                }

                // meta http-equiv=\"Refresh\" page is being refreshed. grab the new link from it..    
                Result = Result.ToLower();
                if ((Result.Contains("meta") == true) && (Result.Contains("http-equiv") == true) && (Result.Contains("refresh") == true))
                {
                    Result = Result.Substring(Result.LastIndexOf("url=") + 4);
                    Result = Result.Replace("\">", "");
                    Result += Fetch_WebPage_Data(Result.Trim());
                }

            }
            catch
            {
                return Result;
            }

            
            

            return Result;
        }
        #endregion
                
        #region Start Button
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Start_Numbering();
            tbx_Display.Clear();            
            tbx_Display.Refresh();
            tbx_Display.Text = Complete_Run();                            
            MessageBox.Show(cbo_From.Text + " to " + cbo_To.Text + Environment.NewLine + "Completed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Start_Numbering()
        {
            String[] Arr = Application.StartupPath.Split("\\".ToCharArray());
            this.Text = Arr[Arr.Length - 1].ToString() + " (" + cbo_From.Text + " - " + cbo_To.Text + ") " + App_Title;
            File.Delete(LastValueFile);
            File.AppendAllText(LastValueFile, (int.Parse(cbo_To.Text) + 1).ToString());
        }

        #endregion
        
        #region Complete_Run()
        private String Complete_Run()
        {
            int i = int.Parse(cbo_From.Text) ;
            int UL = int.Parse(cbo_To.Text);
            
            for (;i <= UL; i++)
            {            
                lvw_Keywords.Items[i].Selected = true;
                String TopicName = lvw_Keywords.Items[i].Text;
                lvw_Keywords_Click(null, null);
                try
                {
                    Fill_Up_Reviewer_Table();
                    Write_Results(TopicName);
                }
                catch
                {
                    File.AppendAllText("E:\\Problems.txt", TopicName + Environment.NewLine);                
                }
                
            }
            return "Run Completed..";
        }
        #endregion
        
        #region Write_Results()
        private void Write_Results(String TopicName)
        {
            int i = 0,j=0;
            String S = String.Empty;
            GLItem GL;
            TopicName = TopicName.Replace(Comma, SemiColon);
            TopicName = TopicName + Comma;            
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\Results.txt");
            
            for (i=0; i<gls_Control.Items.Count; i++)
            {
                GL = gls_Control.Items[i];
                S = TopicName;
                S += GL.Text + ",";
                S += GL.SubItems[1].Text + Comma;
                S += GL.SubItems[2].Text + Comma;
                S += GL.SubItems[3].Text + Comma;
                S += GL.SubItems[5].Text + Comma;
                S += gls_Control.Items[i].SubItems[1].Tag.ToString() + Comma; // Number of Publ. Year-wise.                  
                S += gls_Control.Items[i].SubItems[2].Tag.ToString() + Comma; // Year_From, Year_To 
                ComboBox C1 = (ComboBox) GL.SubItems[6].Control;
                for (j = 0; j < C1.Items.Count; j++)
                    S += C1.Items[j].ToString() + Comma; 
                SW.WriteLine(S);                
            }
            SW.Close();
            SW.Dispose();
        }
        #endregion

        #region Mine Out Web Page
        private String[] Mine_Out_HomePage(String WebPage)
        {
            String[] Ret = new String[12];
            int i=0;

            // Projects 
            Regex Projects = new Regex(@"(project)|(industrial)", RegexOptions.IgnoreCase);
            Match M = Projects.Match(WebPage);
            Ret[0] = "Projects: " + M.Success.ToString();

            // Awards 
            Regex Awards = new Regex(@"(Award)|(Medal)", RegexOptions.IgnoreCase);
            M = Awards.Match(WebPage);
            Ret[1] = "Awards: " + M.Success.ToString();

            // Honorarium 
            Regex Honorarium = new Regex(@"(rewards)|(Honorarium)|(Honoraria)", RegexOptions.IgnoreCase);
            M = Honorarium.Match(WebPage);
            Ret[2] = "Honorarium: " + M.Success.ToString();

            // Affiliations 
            Regex Affiliations = new Regex(@"(Affiliation)|(Affiliated)|(Associated)|(general chair)|(co-chair)|(IEEE Fellow)|(ACM Fellow)", RegexOptions.IgnoreCase);
            M = Affiliations.Match(WebPage);
            Ret[3] = "Affiliations: " + M.Success.ToString();

            // Request for Comments (RFC)
            Regex RFC = new Regex(@"(RFC)|(IETF)!(Request for Comments)", RegexOptions.IgnoreCase);
            M = RFC.Match(WebPage);
            Ret[4] = "RFC: " + M.Success.ToString();

            // Protocol Design 
            Regex Protocol_Design = new Regex(@"(Protocol Design)|(Develop Protocol) ", RegexOptions.IgnoreCase);
            M = Protocol_Design.Match(WebPage);
            Ret[5] = "Protocol Design: " + M.Success.ToString();

            //

            // Distinction 
            Regex Distinction = new Regex(@"(Distinction)|(eminent)", RegexOptions.IgnoreCase);
            M = Projects.Match(WebPage);
            Ret[6] = "Distinction: " + M.Success.ToString();

            // Collaboration 
            Regex Collaboration = new Regex(@"(Collaboration)|(industry)", RegexOptions.IgnoreCase);
            M = Collaboration.Match(WebPage);
            Ret[7] = "Collaboration: " + M.Success.ToString();

            // Supervision
            Regex Supervision = new Regex(@"(Supervision)|(Superviser)|(no. of student)|(number of student)|(Past Students)|(Current Students)", RegexOptions.IgnoreCase);
            M = Supervision.Match(WebPage);
            Ret[8] = "Supervision: " + M.Success.ToString();

            // Reviewer 
            Regex Reviewer = new Regex(@"(Reviewer)|(Reviewer)", RegexOptions.IgnoreCase);
            M = Reviewer.Match(WebPage);
            Ret[9] = "Reviewer: " + M.Success.ToString();

            // Invited Speaker, Invited Guest, Invited Talk 
            Regex Invited_Speaker = new Regex(@"(Invited Speaker)|(Invited Talk)|(invited Keynote)|(keynote speaker)|(Plenary Talk)", RegexOptions.IgnoreCase);
            M = Invited_Speaker.Match(WebPage);
            Ret[10] = "Keynote_Speaker: " + M.Success.ToString();

            // topic relevance
            String[] arrTopic = lvw_Keywords.SelectedItems[0].Text.Split(",".ToCharArray());
            String Topics = @"";
            for (i = 0; i < arrTopic.Length; i++)
                Topics += "(" + arrTopic[i] + ") | ";
            Topics = Topics.Substring(0, Topics.Length - 2);
            // Topics = Topics.Replace("++", ""); // issue of possesive quantifier
            Regex Relevance = new Regex(Topics, RegexOptions.IgnoreCase);
            M = Relevance.Match(WebPage);
            Ret[11] = "Relevance: " + M.Success.ToString();

                                   
            return Ret;
        }
        
        #endregion

        #region Mine_Out_HyperLink(String link)
        private Hashtable  Mine_Out_HyperLink(String link)
        {
            Hashtable Ret = new Hashtable();
            if (Uri.IsWellFormedUriString(link, UriKind.Absolute) == false) return Ret;
            Ret.Add(link, "Author Personal Web Page"); // first entry is Author's main personal web page..
            String LinkName = String.Empty;
            String HREF = String.Empty;

            WebBrowser web = new WebBrowser();
            web.NewWindow += new CancelEventHandler(web_NewWindow);
            web.Navigate(link); 

            //wait for the browser object to load the page
            while (web.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }                       
            
            for (int i=0; i<web.Document.Links.Count; i++)
            {
                if ((web.Document.Links[i].GetAttribute("href") != null))
                {
                    HREF = web.Document.Links[i].GetAttribute("href").ToString();
                    if (Ret.Contains(HREF) == false)
                    {
                        LinkName = web.Document.Links[i].InnerText;
                        if ((String.IsNullOrEmpty(LinkName) == true) || (String.IsNullOrEmpty(HREF) == true))
                        {     } // do nothing..

                        else if ((HREF.Contains(".ps") == true) ||
                            (HREF.Contains(".doc") == true) ||
                            (HREF.Contains(".docx") == true) ||
                            (HREF.Contains(".xls") == true) ||
                            (HREF.Contains(".xlsx") == true)
                            )
                        { } // Do Nothing. We did not process these MIME

                        // whether it contains cv link then must include it.
                        else if ((HREF.Contains(".pdf") == true) &&
                                 ((LinkName.ToLower().Contains("cv") == true) ||
                                  (LinkName.ToLower().Contains("curriculum") == true) ||
                                  (LinkName.ToLower().Contains("vitae") == true))
                                 )
                        {
                            Ret.Add(HREF, LinkName);
                        }

                        // discard all other pdf link 
                        else if ((HREF.Contains(".pdf") == true))
                        { }

                        else
                        {
                            Ret.Add(HREF, LinkName);
                        }
                    }
                }
            }
            return Ret;
        }

        
        void web_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Read_PDF(String link)
        private String Read_PDF(String link) 
        {
            // link = "H:\\a.pdf";
            PdfReader reader2 = new PdfReader((string)link); 
            String strText = String.Empty; 
            for (int page = 1; page <= reader2.NumberOfPages; page++) 
            { 
                iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy(); 
                PdfReader reader = new PdfReader(link); 
                String S = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, page, its); 
                S = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(S))); 
                strText += S; 
                reader.Close(); 
            } 
            return strText;
        }        
        #endregion

        #region Final Processing
        private void btn_Final_Click(object sender, EventArgs e)
        {
            Hashtable H = new Hashtable();
            String Line = String.Empty ;
            int i = 0;
            String YearlyPub = String.Empty;
            String Last_Year = String.Empty;
            
            Hashtable Auth_Keywords = new Hashtable();

            // Load Auth with their keywords into a Hash table.. 
            StreamReader SR = File.OpenText(Application.StartupPath + "\\Auth_Keywords.txt");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();    
                if (H.Contains(Line) == false)
                {
                    H.Add(Line, 1);
                }
                else
                {
                    i = int.Parse(H[Line].ToString());
                    i++;
                    H[Line] = i;
                }
            }
            SR.Close();
            SR.Dispose();            

            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                Line = ID.Key.ToString();
                String[] Arr = Line.Split(Tab.ToCharArray());
                if (Auth_Keywords.Contains(Arr[0]) == false)
                {
                    Auth_Keywords.Add(Arr[0], ID.Value.ToString() + Tilda + Arr[1] + SemiColon );
                }
                else
                {
                    Line = Auth_Keywords[Arr[0]].ToString();
                    Line += ID.Value.ToString() + Tilda + Arr[1] + SemiColon;
                    Auth_Keywords[Arr[0]] = Line ;
                }
            }
                        
            H.Clear();
        


            ///////////////////////////////////
            SR = File.OpenText(Application.StartupPath + "\\Origional.txt");
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\out.tmp");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();                
                String[] Arr = Line.Split(Tab.ToCharArray());
                if (Auth_Keywords.Contains(Arr[0]) == false) continue; // this author has not been listed any keywords..
                Line = Auth_Keywords[Arr[0]].ToString() + Tab + Arr[0] + Tab ;               

                for (i = 1; i < 8; i++)
                {
                    Line += Arr[i] + Tab;
                }
                // X years of publications count only...
                YearlyPub = Arr[5];
                Last_Year = Arr[7];
                Line += Calculate_Last_X_Year_Publications(YearlyPub, Last_Year) + Tab ;

                for (i = 8; i < Arr.Length; i++)
                {
                    Line += Arr[i] + Tab;
                }
                               
                SW.WriteLine(Line);
                
            }
            SR.Close();
            SW.Close();
            SR.Dispose();
            SW.Dispose();

            // remove all extra characters
            Line = "Topic,Author,PubCount,Citations,CoAuthorNetwork,HomePage,PubHistory,PubHistoryFrom,PubHistoryTo," + nUD_Year.Value.ToString() + ".YearPub,";
            Line += "Projects,Awards,Honorarium,Affiliations,RFC,ProtocolDesign,Distinction,Collaboration,Supervision,Reviewer,Keynote_Speaker,Relevance" + Environment.NewLine;
            Line = Line.Replace(Comma, Tab);

            SR = File.OpenText(Application.StartupPath + "\\out.tmp");
            String Temp = SR.ReadToEnd();
            SR.Close();
            SR.Dispose();
            File.Delete(Application.StartupPath + "\\Results_Final.txt");
            File.Delete(Application.StartupPath + "\\out.tmp");
            
            Temp = Temp.Replace("Projects: ", "");
            Temp = Temp.Replace("Awards: ", "");
            Temp = Temp.Replace("Honorarium: ", "");
            Temp = Temp.Replace("Affiliations: ", "");
            Temp = Temp.Replace("RFC: ", "");
            Temp = Temp.Replace("Protocol Design: ", "");
            Temp = Temp.Replace("Distinction: ", "");
            Temp = Temp.Replace("Collaboration: ", "");
            Temp = Temp.Replace("Supervision: ", "");
            Temp = Temp.Replace("Reviewer: ", "");
            Temp = Temp.Replace("Keynote_Speaker: ", "");
            Temp = Temp.Replace("Relevance: ", "");
            Temp = Temp.Replace("True", "1");
            Temp = Temp.Replace("False", "0");
            File.AppendAllText(Application.StartupPath + "\\Results_Final.txt", Line + Temp);

            //////////////////////////////////
            MessageBox.Show("Result_Final.txt generated..",App_Title,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        #region Calculate_Last_X_Year_Publications
        // YearlyPub = 2~1992;1~1990;11~1997;6~1995;15~1999;11~0;2~1993;12~2002;10~1996;9~2000;9~2003;4~1994;6~1998;13~2001
        private String Calculate_Last_X_Year_Publications(String YearlyPub, String Last_Year)
        {
            int Ret = 0;
            int lastYear = int.Parse(Last_Year);
            int X = lastYear - int.Parse(nUD_Year.Value.ToString());            
            int i = 0, j=0;
            String[] Arr = YearlyPub.Split(SemiColon.ToCharArray());
            for (i = lastYear; i > X; i--)
            {
                for (j = 0; j < Arr.Length; j++)
                {
                    String[] Tmp = Arr[j].ToString().Split(Tilda.ToCharArray());
                    if (Tmp[1] == i.ToString())
                        Ret += int.Parse (Tmp[0].ToString());
                }
            }
            return Ret.ToString();
        }
        #endregion      

        

        #endregion

        #region Tau B               
        private void kendl(double[] data1, double[] data2, long n, ref double tau, ref double z, double prob)
        {
            // Given data arrays data1[1..n] and data2[1..n], this program returns Kendall’s τ as tau,
            // its number of standard deviations from zero as z, and its two-sided significance level as prob.
            // Small values of prob indicate a significant correlation (tau positive) or anticorrelation (tau
            // negative).

            //double erfcc;
            //double x;
            long n2 = 0, n1 = 0, k, j = 0;
            long IS = 0;
            double svar, aa, a2, a1;

            for (j = 1; j < n; j++)
            {
                // Loop over first member of pair,
                for (k = (j + 1); k <= n; k++)
                {
                    // and second member.
                    a1 = data1[j] - data1[k];
                    a2 = data2[j] - data2[k];
                    aa = a1 * a2;

                    if ( aa != 0)
                    {
                        //Neither array has a tie.
                        ++n1;
                        ++n2;
                        //aa > 0.0 ? ++IS : --IS;
                        if ( aa > 0 )
                            ++IS;
                        else
                            --IS;
                    }
                    else
                    {
                        //One or both arrays have ties.
                        if ( a1 != 0)
                            ++n1; //An “extra x” event.
                        if ( a2 != 0)
                            ++n2; //An “extra y” event.
                    }
                }
            }

            tau = IS / (Math.Sqrt((double)n1) * Math.Sqrt((double)n2)); // Equation (14.6.8).
            svar = (4.0 * n + 10.0) / (9.0 * n * (n - 1.0)); // Equation (14.6.9).
            z = (tau) / Math.Sqrt(svar);
            //prob=erfcc(fabs(*z)/1.4142136); //Significance.
        }    
       

        private void Kendall_tau_Start()
        {
            // tau = 0.5
            double[] data1 = { 1, 2, 3, 4, 5 };
            double[] data2 = { 3, 4, 1, 2, 5 };

             //tau = 0.818
            /*
             double[] data1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
             double[] data2 = { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 12, 11 };
            */
            /* tau = 0.364
            double[] data1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            double[] data2 = { 12,2,3,4,5,6,7,8,9,10,11,1};
            */

            long n = data1.Length -1;
            double tau = 0;
            double z = 0;
            double prob = 0;
            
            kendl(data1, data2, n, ref  tau, ref  z, prob);

            tbx_Display.Text = "Tau = " + tau.ToString() + " Z = " + z.ToString();
        }
       #endregion

        #region Create_InputFiles_4_Matlab()
        private String Create_InputFiles_4_Matlab()
        {
            Double WebWt = 0, NonWebWt = 0;
            Double RelPub = 0, PubCount = 0;
            int i = 0;
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\Stupid_Dot_Net.txt");            
            SW.Close();            
            String Line = String.Empty;
            StreamReader SR = File.OpenText(Application.StartupPath +  "\\Input.txt");
            while ((!SR.EndOfStream)) // && (++i < 1000))
            {
                Line = SR.ReadLine();
                String[] Arr = Line.Split(Tab.ToCharArray());
                PubCount = Double.Parse(Arr[2]);
                NonWebWt = Double.Parse(Arr[22]);
                WebWt = Double.Parse(Arr[23]);                
                String[] Keywords = Arr[0].Split(SemiColon.ToCharArray());

                for (i=0; i < Keywords.Length-1; i++)
                {
                    Arr = Keywords[i].Split(Tilda.ToCharArray());
                    RelPub = Double.Parse(Arr[0].ToString());
                    NonWebWt += (RelPub / PubCount);

                    try
                    {
                        SW = File.AppendText("E:\\5_matlab\\m\\" + Arr[1].Trim() + ".txt");
                        SW.WriteLine(NonWebWt.ToString() + Tab + WebWt);
                        SW.Close();
                    }
                    catch
                    {
                        SW.Close();
                    }
                }
            }
            
            SR.Close();
            SR.Dispose();
            SW.Dispose();
            File.Delete(Application.StartupPath + "\\Stupid_Dot_Net.txt");
            return "Completed..";
        }

        private void btn_Prepare_Matlab_Input_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Create_InputFiles_4_Matlab();
        }
        
        #endregion        
      
        #region Regression Least Square
        private void Least_Square()
        {
            LstSquQuadRegr solvr = new LstSquQuadRegr();
            Double X = 0, Y = 0;
            StreamReader SR = File.OpenText(Application.StartupPath + "\\" + "reg.txt");
            while (!SR.EndOfStream)
            {
                String[] Arr = SR.ReadLine().Split(Tab.ToCharArray());
                X = Double.Parse(Arr[0]);
                Y = Double.Parse(Arr[1]);
                solvr.AddPoints(X, Y);

            }
            SR.Close();
            SR.Dispose();

            double the_a_term = solvr.aTerm();
            double the_b_term = solvr.bTerm();
            double the_c_term = solvr.cTerm();
            double the_rSquare = solvr.rSquare();

            tbx_Display.Text = the_a_term.ToString() + " : " + the_b_term.ToString() + " : " + the_c_term.ToString() + Environment.NewLine + the_rSquare.ToString();
        }
        #endregion
        
        #region Keywords Related Pub.Count
        private String Keywords_Related_Pub_Count(String strAuth, int Cnt)
        {
            Hashtable hTitles = new Hashtable();
            String Out = String.Empty;
            String S = String.Empty;

            S = "SELECT cs_key FROM cs_author_ref_new WHERE author =" + "\"" + strAuth + "\"";
            MyCmd.CommandText = S;
            OdbcDataReader R = MyCmd.ExecuteReader();
            OdbcDataReader R2;

            S = String.Empty;
            while (R.Read())
            {
                S += R[0].ToString() + ",";
            }
            if (S.Length > 1)
            {
                S = S.Substring(0, S.Length - 1);
            }
            else
            {
               R.Close();
               return Out;
            }
            R.Close();
            
            S = "SELECT title, year, cs_key FROM cs_pub_new WHERE cs_key IN (" + S + ")";
            MyCmd.CommandText = S;
            R = MyCmd.ExecuteReader();
            S = String.Empty;
            while (R.Read())
            {
                    S = "SELECT a.keywords, a.genterms FROM dblp_abstracts as a inner join dblpcsmapping2 as d on a.dblp_key=d.dblp_key WHERE d.cs_key = " + R[2].ToString();
                    MyCmd_2.CommandText = S;
                    R2 = MyCmd_2.ExecuteReader();
                    while (R2.Read())
                    {
                        Out += Cnt +  Tab + strAuth + Tab + R[0].ToString();
                        S = R2[0].ToString().Trim();
                        S = S.Replace(",",";");
                        Out += Tab + S;
                        S = R2[1].ToString().Trim();
                        S = S.Replace(",", ";");                        
                        Out += Tab + S + Environment.NewLine;                                                  
                    }
                    R2.Close();                
            }
            R.Close();
            R.Dispose();            
            return Out;
        }

        private void btn_Keywords_Related_Pub_Count_Click(object sender, EventArgs e)
        {
            String Topics = String.Empty;
            String strAuth = String.Empty;            
            int i=0;
            Start_Numbering();
            for (i = int.Parse(cbo_From.Text); i <= int.Parse(cbo_To.Text); i++)
            {
                strAuth = lvw_Keywords.Items[i].Text;
                Topics = Keywords_Related_Pub_Count(strAuth, i);
                File.AppendAllText(Application.StartupPath + "\\ExtractedTopics.txt", Topics);
            }
            tbx_Display.Text = cbo_From.Text + " to " + cbo_To.Text + Environment.NewLine + "Completed";
            MessageBox.Show(cbo_From.Text + " to " + cbo_To.Text + Environment.NewLine + "Completed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        } 
        
        private void Load_All_Topics_with_Authors()
        {
            lvw_Keywords.Columns[0].Text = "Authors";
            ListViewItem L;
            StreamReader SR = new StreamReader(Application.StartupPath + "\\Auth_Topics.txt");
            while (!SR.EndOfStream)
            {   
                L = lvw_Keywords.Items.Add(SR.ReadLine());
            }
            SR.Close();
            SR.Dispose();
            tbx_Display.Text = lvw_Keywords.Items.Count.ToString() + " Loaded";
        }
       #endregion

        #region Post Processing

        private void btn_Post_Processing_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Post_Processing_1();
        }
        private String Post_Processing_1()
        {
            String Auth = String.Empty;
            String[] Arr;
            File.Delete(Application.StartupPath + "\\" + "Out.txt"); 
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\" + "Out.txt");
            StreamReader SR = File.OpenText(Application.StartupPath + "\\" + "Input.txt");
            while (!SR.EndOfStream)
            {
                Arr = SR.ReadLine().Split(Tab.ToCharArray()) ;
                Auth = Arr[0];
                Arr = Arr[1].Split(";".ToCharArray());
                foreach (String tmp in Arr)
                {
                   SW.WriteLine (Auth + Tab + tmp );
                }

            }
            SR.Close();
            SR.Dispose();
            SW.Close();
            SW.Dispose();
            return "Out.txt generated..";

        }
        #endregion

        #region btn_dblp_Pub_History
        private void btn_dblp_Pub_History_Click(object sender, EventArgs e)
        {
           //  tbx_Display.Text = Apply_Curve_Fitting_on_dblp_PubHistory(); return;
            String Pub_Year_Wise = String.Empty;
            String S = String.Empty;
            String Pub_Years = String.Empty;
                       
            Hashtable H = Populate_dblp_Authors_for_Pub_History();            

            File.Delete (Application.StartupPath + "\\dblp_Authors_for_Pub_History.csv"); 
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\dblp_Authors_for_Pub_History.csv"); 
            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext()) 
            {
                Pub_Years  = ID.Value.ToString();
                Pub_Year_Wise = dblp_Publication_History(Pub_Years);

                S = ID.Key.ToString() + "," + Pub_Year_Wise;
                SW.WriteLine(S);                                                       
            }
            SW.Close();
            SW.Dispose();
            MessageBox.Show(" Dataset retrival Completed.. Now going for curve fitting.."); 
            tbx_Display.Text = Apply_Curve_Fitting_on_dblp_PubHistory();
        }
        #endregion

        #region Publication String from DBLP
        private Hashtable Populate_dblp_Authors_for_Pub_History()
        {
            String SQL = String.Empty;
            SQL = "SELECT dblp_author_ref_new.author AS auth , dblp_pub_new.year FROM dblp_author_ref_new ";
            SQL += "JOIN dblp_pub_new ON dblp_author_ref_new.id=dblp_pub_new.id ";
            MyCmd.CommandText = SQL.ToString();
            OdbcDataReader R = MyCmd.ExecuteReader();
            Hashtable H = new Hashtable();
            String S = String.Empty;
            // int i = 2000; 
            while (R.Read())
            {
                if (R[1].ToString().Trim().Length > 1)
                {       
                    if (H.Contains(R[0].ToString()) == false)
                    {
                       H.Add(R[0].ToString(), R[1].ToString());
                    }
                        else
                    {
                        S = H[R[0].ToString()].ToString();
                        S += "," + R[1].ToString();
                        H[R[0].ToString()] = S;
                    }
                }
            }
            R.Close();
            R.Dispose();
            return H;            
        }

        private String dblp_Publication_History(String Pub_Years)
        {            
            String S = String.Empty;
            int Cnt = 0;
            Hashtable H = new Hashtable();
            String Ret = String.Empty;
            String[] Arr = Pub_Years.Split(Comma.ToCharArray());
            for (int i = 0; i < Arr.Length; i++)
            {
                S = Arr[i];
                if (H.Contains(S) == false)
                    H.Add(S, "1");
                else
                {
                    Cnt = int.Parse(H[S].ToString());
                    Cnt++;
                    H[S] = Cnt.ToString();
                }
            }

            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                Ret += ID.Value.ToString() + Tilda + ID.Key.ToString() + SemiColon;
            }

            Ret = Ret.Substring(0, (Ret.Length - 1));
            return Ret;
        }


        private String Apply_Curve_Fitting_on_dblp_PubHistory()
        {
            StreamReader SR = File.OpenText(Application.StartupPath + "\\dblp_Authors_for_Pub_History.csv");
            File.Delete (Application.StartupPath + "\\dblp_Authors_for_Pub_History_Final.csv");
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\dblp_Authors_for_Pub_History_Final.csv");
            String Line = String.Empty;
            int Cnt=0;      

            while (!SR.EndOfStream)
            {
                Cnt = 0;
                Line = SR.ReadLine();
                String[] Arr = Line.Split(Comma.ToCharArray());
                // 1~1977;1~1970;2~1988;3~1987;3~1986;2~1985;1~1984;3~1983;2~1981;1~1980
                String[] A1 = Arr[1].Split(SemiColon.ToCharArray());
                LstSquQuadRegr solvr = new LstSquQuadRegr();
                Double X = 0, Y = 0;
                if (A1.Length > 3) // only those authors whose at least 3 years of publications availabls
                {
                    for (int i = 0; i < A1.Length; i++)
                    {
                        String[] A2 = A1[i].Split(Tilda.ToCharArray());
                        Cnt += int.Parse(A2[0]);
                        X = Double.Parse(A2[1]);
                        Y = Double.Parse(A2[0]);
                        solvr.AddPoints(X, Y);
                    }

                    Line += "," + Cnt.ToString();
                    Line += "," + solvr.aTerm().ToString(); // the_a_term
                    Line += "," + solvr.bTerm().ToString(); // the_b_term
                    Line += "," + solvr.cTerm(); // the_c_term 
                    Line += "," + solvr.rSquare(); // the_rSquare               
                    SW.WriteLine(Line);
                }
            }

            SR.Close();
            SR.Dispose();

            return "Done";
        }

        #endregion

        #region Gen Final Results
        private void btn_Gen_Final_Result_Files_Click(object sender, EventArgs e)
        {
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String Author = String.Empty;
            int i = 0;
            String XYearPub = String.Empty;
            StreamReader SR = File.OpenText(Application.StartupPath + "\\Origional.txt");
            while (!SR.EndOfStream)
            {
                String[] Arr= SR.ReadLine().Split(Tab.ToCharArray());
                XYearPub = Calculate_Last_X_Year_Publications(Arr[5],Arr[7]);
                Author = Arr[0];
                Line = String.Empty;
                for (i = 0; i <=3 ; i++)
                {
                    Line += Arr[i] + Tab;
                }                
                   Line += XYearPub + Tab;                
                for (i = 4; i < Arr.Length; i++)
                {
                    Line += Arr[i] + Tab;
                }

                Line = Line.Replace("Projects: ", "");
                Line = Line.Replace("Awards: ", "");
                Line = Line.Replace("Honorarium: ", "");
                Line = Line.Replace("Affiliations: ", "");
                Line = Line.Replace("RFC: ", "");
                Line = Line.Replace("Protocol Design: ", "");
                Line = Line.Replace("Distinction: ", "");
                Line = Line.Replace("Collaboration: ", "");
                Line = Line.Replace("Supervision: ", "");
                Line = Line.Replace("Reviewer: ", "");
                Line = Line.Replace("Keynote_Speaker: ", "");
                Line = Line.Replace("Relevance: ", "");
                Line = Line.Replace("True", "1");
                Line = Line.Replace("False", "0");                

                if (H.Contains(Author) == false )
                    H.Add(Author, Line);
            }
            SR.Close();
            SR.Dispose();
            tbx_Display.Text = Create_InputFiles_4_Last_Results(H);
        }
        #endregion

        #region Create_InputFiles_4_Last_Results()
        private String Create_InputFiles_4_Last_Results(Hashtable H)
        {
            int i = 0; //, j=0;
            String Author = String.Empty;
            String coOccuredKeywords = String.Empty;
            String generalTerms = String.Empty;
            StreamWriter SW = File.AppendText(Application.StartupPath + "\\Stupid_Dot_Net.txt");
            SW.Close();
            String Line = String.Empty;
            StreamReader SR = File.OpenText(Application.StartupPath + "\\ExtractedTopics.txt");
            while ((!SR.EndOfStream)) // && (++j < 1000))
            {
                Line = SR.ReadLine();
                String[] Arr = Line.Split(Tab.ToCharArray());

                Author = Arr[1];
                coOccuredKeywords = Arr[3];
                generalTerms = Arr[4]; 

                if (H.Contains(Author) == true)                 
                {
                    Arr = coOccuredKeywords.Split(SemiColon.ToCharArray());
                    for (i = 0; i < Arr.Length; i++)
                    {
                        try
                        {
                            SW = File.AppendText(Application.StartupPath + "\\coOccuredKeywords\\" + Arr[i].Trim());
                            SW.WriteLine (H[Author]);
                            SW.Close();
                        }
                        catch
                        {
                            SW.Close();
                        }
                    }


                    Arr = generalTerms.Split(SemiColon.ToCharArray());
                    for (i = 0; i < Arr.Length; i++)
                    {
                        try
                        {
                            SW = File.AppendText(Application.StartupPath + "\\generalTerms\\" + Arr[i].Trim());
                            SW.WriteLine(H[Author]);
                            SW.Close();
                        }
                        catch
                        {
                            SW.Close();
                        }
                    }


                }
            }

            SR.Close();
            SR.Dispose();
            SW.Dispose();
            File.Delete(Application.StartupPath + "\\Stupid_Dot_Net.txt");
            return "Completed..";
        }
        #endregion        

    }
}
