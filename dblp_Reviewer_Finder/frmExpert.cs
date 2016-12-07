using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace dblp_Reviewer_Finder
{
    public partial class frmExpert : Form
    {
        #region Local Variables
        const String Tab = "\t";
        const String Tilda = "~";
        const String SemiColon = ";";
        const String Comma = ",";
        // Enable Power of Sorting for Listviews
        private ListViewSortManager sortMgr_Topics, sortMgr_Auth, sortMgr_Marginalized;
    
        public frmExpert()
        {
            InitializeComponent();
            tbc_Chart.Tag = "1"; // Default tab for the charting control..
            // Enable Power of Sorting in the Listviews
            sortMgr_Auth = new ListViewSortManager(lvw_Authors,
            new Type[] {
            typeof(ListViewTextSort),            // first colum
            typeof(ListViewDoubleSort),          // second column and so on..
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),            
          } );

            sortMgr_Topics = new ListViewSortManager(lvw_Keywords,
                        new Type[] {
            typeof(ListViewTextSort),            
            typeof(ListViewInt32Sort),
            typeof(ListViewInt32Sort),            
          });

            sortMgr_Marginalized = new ListViewSortManager(lvw_Marginalized,
            new Type[] {
            typeof(ListViewTextSort),            // first colum
            typeof(ListViewDoubleSort),          // second column and so on..
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),
            typeof(ListViewDoubleSort),            
          });


        }
        #endregion

        #region Populate Topics
        private String Populate_Topics()
        {
            ListViewItem L;
            int Cnt = 0;
            String Topic = String.Empty;
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String Pth = String.Empty;
            
            if (rad_coOccuredKeywords.Checked == true)
                Pth = Application.StartupPath + "\\coOccuredKeywords";
            else
               Pth = Application.StartupPath + "\\generalTerms";

            lvw_Keywords.Items.Clear();
            lvw_Authors.Items.Clear();
            lvw_Marginalized.Items.Clear();
            DirectoryInfo D = new DirectoryInfo(Pth);            
            FileInfo[] fi = D.GetFiles();
            foreach (FileInfo f in fi)
            {
                Topic = f.Name.ToString();
                L = lvw_Keywords.Items.Add(Topic);
                Cnt = 0;
                H.Clear();
                StreamReader SR = File.OpenText(f.FullName);

                while (!SR.EndOfStream)
                {
                    Line = SR.ReadLine();
                    Cnt++;
                    if (H.Contains(Line) == false)
                        H.Add(Line, "");
                }
                SR.Close();
                SR.Dispose();
                L.SubItems.Add(Cnt.ToString());
                L.SubItems.Add(H.Count.ToString());
            }
            return fi.Length.ToString() + " Topics Loaded..";
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Populate_Topics();
        }
        #endregion

        #region Click any Item to Display All Experts
        private void lvw_Keywords_Click(object sender, EventArgs e)
        {
            String Topic = lvw_Keywords.SelectedItems[0].Text;
            tbx_Display.Text = lvw_Keywords.SelectedItems[0].Index.ToString() + ": " + lvw_Keywords.SelectedItems[0].Text;
                        
            int Cnt = 0;
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String Pth = String.Empty;
            String Author = String.Empty;
            Double WebWt = 0, NonWebWt = 0, Score = 0;
            String WebWtDetail = String.Empty;
            int Rank = 0;

            if (rad_coOccuredKeywords.Checked == true)
                Pth = Application.StartupPath + "\\coOccuredKeywords\\";
            else
                Pth = Application.StartupPath + "\\generalTerms\\";
                      

            StreamReader SR = File.OpenText( Pth + Topic );

                while (!SR.EndOfStream)
                {
                    Line  = SR.ReadLine();                    
                    if (H.Contains(Line) == false)
                        H.Add(Line, "1");
                    else
                    {
                        Cnt = int.Parse(H[Line].ToString());
                        Cnt++;
                        H[Line] = Cnt;
                    }
                }
                SR.Close();
                SR.Dispose();
                lvw_Authors.Items.Clear(); 
                ListViewItem L;
                int i = 0,j=1;
                
                IDictionaryEnumerator ID = H.GetEnumerator();
                while (ID.MoveNext())
                {
                    String[] Arr = ID.Key.ToString().Split(Tab.ToCharArray());
                    // Author Name 
                    L = lvw_Authors.Items.Add(Arr[0].ToString());

                    // Pub, Citation, coAuthNet, xYearPub
                    for (i = 1; i <5; i++)
                        L.SubItems.Add(Arr[i]);
                    Double PubCount  = Double.Parse(Arr[1]);
                    Double Citation  = Double.Parse(Arr[2]);
                    Double coAuthNet = Double.Parse(Arr[3]);
                    Double xYearPub  = Double.Parse(Arr[4]);
                    
                    // Pub History
                    L.SubItems[4].Tag = Arr[6];
                    
                    // pub this Topic only                                        
                    Double PubThisTopic = Double.Parse(H[ID.Key].ToString());
                    L.SubItems.Add(PubThisTopic.ToString());

                    // Non-Web-Wt...by Naeem                    
                    NonWebWt = 0;
                    NonWebWt += Citation / PubCount;
                    NonWebWt += PubCount / coAuthNet;
                    NonWebWt += PubCount / xYearPub;
                    NonWebWt += PubThisTopic / PubCount ;
                    L.SubItems.Add(NonWebWt.ToString());                        

                    // sum up web wt..
                    WebWt = 0;
                    for (i = 9; i < Arr.Length-1; i++)
                    {
                        WebWt += Double.Parse(Arr[i]);
                        WebWtDetail += Arr[i] + Tab;
                    }
                        L.SubItems.Add(WebWt.ToString());
                        L.SubItems[7].Tag = WebWtDetail; // for graphical representation
                    
                    Score = NonWebWt + WebWt;
                    L.SubItems.Add(Score.ToString());
                    
                    
                    // Final Weight by Bilal
     

                    j++;               
                }
                Marginalize_All();
                lvw_Authors.Refresh();

        }
        #endregion

        #region Marginalize All
        private void Marginalize_All()
        {
            int i=0,j=0;
            Double MaxPub = Double.MinValue;
            Double MaxCitation = Double.MinValue;
            Double MaxXYearPub = Double.MinValue;
            Double MaxCoAuthNet = Double.MinValue;
            Double MaxThisTopic = Double.MinValue;
            
            ListViewItem L;
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {
                L = lvw_Authors.Items[i];
                MaxPub = Math.Max(MaxPub, Double.Parse(L.SubItems[1].Text));
                MaxCitation  = Math.Max(MaxCitation, Double.Parse(L.SubItems[2].Text));
                MaxCoAuthNet = Math.Max(MaxCoAuthNet, Double.Parse(L.SubItems[3].Text));
                MaxXYearPub  = Math.Max(MaxXYearPub, Double.Parse(L.SubItems[4].Text));                
                MaxThisTopic = Math.Max(MaxThisTopic, Double.Parse(L.SubItems[5].Text));
            }

            lvw_Marginalized.Items.Clear();
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {                
                L = lvw_Marginalized.Items.Add(lvw_Authors.Items[i].Text);
                L.SubItems.Add( (Double.Parse(lvw_Authors.Items[i].SubItems[1].Text) / MaxPub).ToString());   
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[2].Text) / MaxCitation).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[3].Text) / MaxCoAuthNet).ToString());
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[4].Text) / MaxXYearPub).ToString());                
                L.SubItems.Add((Double.Parse(lvw_Authors.Items[i].SubItems[5].Text) / MaxThisTopic).ToString());                  
                
            }            
            for (i = 0; i < lvw_Marginalized.Items.Count; i++)
            {
                Double Sum = 0;
                for (j = 1; j < 6; j++)
                {
                    Sum += Double.Parse( lvw_Marginalized.Items[i].SubItems[j].Text);
                }
                Sum += Double.Parse(lvw_Marginalized.Items[i].SubItems[5].Text); // Double Time Sum Up MaxthisTopic
                lvw_Marginalized.Items[i].SubItems.Add (Sum.ToString());
            }
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
                String[] A = Arr[i].Split(Tilda.ToCharArray());
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

        #region tbc_Chart_Selected
        private void tbc_Chart_Selected(Object sender, TabControlEventArgs e)
        {
            if (lvw_Authors.Items.Count == 0) return;
            if (lvw_Authors.SelectedItems.Count == 0) return;
            tbc_Chart.Tag = e.TabPageIndex.ToString();
            switch (e.TabPageIndex)
            {
                case 1:
                    {
                        Populate_Chart_Year_Wise(lvw_Authors.SelectedItems[0].SubItems[4].Tag.ToString()); // Number of Publ. Year-wise.
                        break;
                    }
                case 2:
                    {
                        //cht_CoAuthor_Network.Visible = true;
                        break;
                    }
                case 3:
                    {
                       // cht_Pub_Citation.Visible = true;
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

        #region lvw_Authors_Click
        private void lvw_Authors_Click(object sender, EventArgs e)
        {
            TabControlEventArgs te = new TabControlEventArgs(tabPage1, 1, TabControlAction.Selected);
            int Which_Tab = int.Parse(tbc_Chart.Tag.ToString()); 
            if ( Which_Tab  == 1)
              te = new TabControlEventArgs(tabPage1, 1, TabControlAction.Selected);
            else if ( Which_Tab  == 2)
                te = new TabControlEventArgs(tabPage2, 2, TabControlAction.Selected);
            
            tbc_Chart_Selected(null, te);
        }
        #endregion
    }


}
