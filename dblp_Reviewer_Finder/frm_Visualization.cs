using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace dblp_Reviewer_Finder
{
    public partial class frm_Visualization : Form
    {
        #region Class Level Var

        String[] Clrs = new String[55];
        int Radius = 0;
        Hashtable hAuth = new Hashtable();
        Hashtable hTopic = new Hashtable();

        public frm_Visualization()
        {
            InitializeComponent();
            int i = 50;
            for (i = 50; i <= 1000; i++)
               cbo_Width.Items.Add(i.ToString());
            cbo_Width.SelectedIndex = i - 51;
            for (i = 50; i <= 725; i++)
               cbo_Height.Items.Add(i.ToString());
            cbo_Height.SelectedIndex = i - 51;

            Populate_Authors_Topics("Authors.txt"); 
            Initilize_Colors();            
        }

        private void Initilize_Colors()
        {
            Clrs[0] = "firebrick";
            Clrs[1] = "springgreen";
            Clrs[2] = "aqua";
            Clrs[3] = "greenyellow";
            Clrs[4] = "blue";
            Clrs[5] = "fuchsia";
            Clrs[6] = "gray"; 
            Clrs[7] = "green"; 
            Clrs[8] = "lime"; 
            Clrs[9] = "maroon"; 
            Clrs[10] = "navy";
            Clrs[11] = "olive";
            Clrs[12] = "darkmagenta";
            Clrs[13] = "darkgray";
            Clrs[14] = "coral";
            Clrs[15] = "burlywood";
            Clrs[16] = "darkred";
            Clrs[17] = "darkslategray";
            Clrs[18] = "deeppink";
            Clrs[19] = "dodgerblue";
            Clrs[20] = "fuchsia";
            Clrs[21] = "goldenrod";
            Clrs[22] = "indigo";
            Clrs[23] = "lightcoral";
            Clrs[24] = "lightgreen";
            Clrs[25] = "lightseagreen";
            Clrs[26] = "lightsteelblue";
            Clrs[27] = "mediumblue";
            Clrs[28] = "mediumslateblue";
            Clrs[29] = "olivedrab";
            Clrs[30] = "plum";
            Clrs[31] = "rosybrown";
            Clrs[32] = "sandybrown";
            Clrs[33] = "slategrey";
            Clrs[34] = "cornflowerblue";
            Clrs[35] = "cadetblue";
            Clrs[36] = "darksalmon";
            Clrs[37] = "deepskyblue";
            Clrs[38] = "lawngreen";
            Clrs[39] = "mediumspringgreen";
            Clrs[40] = "mediumorchid";
            Clrs[41] = "maroon";
            Clrs[42] = "lime";
            Clrs[43] = "salmon";
            Clrs[44] = "tomato";
            Clrs[45] = "limegreen";
            Clrs[46] = "orangered";
            Clrs[47] = "blueviolet";
            Clrs[48] = "chocolate";
            Clrs[49] = "crimson";
            Clrs[50] = "chartreuse";
            Clrs[52] = "hotpink";
            Clrs[53] = "violet";
            Clrs[54] = "slateblue";
            
        }


        #endregion

        #region Visualization
        private void btn_Visualization_Click(object sender, EventArgs e)
        {
            tbx_Display.Text = Build_SVG();
        }


        private String Build_SVG()
        {
            String Pth = Application.StartupPath + "\\" + "Out.svg";
            File.Delete(Pth = Application.StartupPath + "\\" + "Out.svg");
            StreamWriter SW = File.AppendText(Pth);
                        
            Double[] X = new Double[50];
            Double[] Y = new Double[50];
            Detail_out_Nodes(ref X, ref Y);
            int i = 1;

            Hashtable C = Random_Colors(lvw_Detail.Items.Count);
            String Clr = String.Empty;
            String Line = String.Empty;
            Double Stroke_Width = 0, R=0;
            #region Header
            SW.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            SW.WriteLine("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"");
            SW.WriteLine("\"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\" >");
            SW.WriteLine("<svg contentScriptType=\"text/ecmascript\" width=\"" + cbo_Width.Text + "px\"");
            SW.WriteLine("xmlns:xlink=\"http://www.w3.org/1999/xlink\" zoomAndPan=\"magnify\"");
            SW.WriteLine("contentStyleType=\"text/css\" viewBox=\"0 0 " + cbo_Width.Text + " " + cbo_Height.Text +    "\" height=\"800px\"");
            SW.WriteLine(" preserveAspectRatio=\"xMidYMid meet\" xmlns=\"http://www.w3.org/2000/svg\"");
            SW.WriteLine(" version=\"1.1\">\""); // end of opening header..
            #endregion

            #region Edges
            
            SW.WriteLine (" <g id=\"edges\">");
            for (i = 1; i <= lvw_Detail.Items.Count; i++)
            {
                Clr = Clrs[int.Parse(C[i].ToString())];
                Line = " <line x1=\"" + X[0].ToString() + "\" y1=\"" + Y[0].ToString() + "\"";
                Line += " x2=\"" + X[i].ToString() + "\" y2=\"" + Y[i].ToString() + "\"";
                SW.Write(Line);
                Stroke_Width = Double.Parse (lvw_Detail.Items[i-1].SubItems[1].Text) * 2;
                SW.WriteLine(" style=\"stroke: " +  Clr +  "; stroke-width: " + Stroke_Width.ToString() + ";\"/>");
            }           
            SW.WriteLine("</g>");
            #endregion

            #region Nodes...
            SW.WriteLine(" <g id=\"nodes\">");
            String Author = lvw_Master.Items[lvw_Master.SelectedItems[0].Index].Text;
            Clr = Clrs [ int.Parse(C[0].ToString())];
            SW.WriteLine(" <circle fill-opacity=\"1.0\" fill=\"" + Clr + "\" r=\"" + Radius.ToString() + "\" cx=\"" + X[0].ToString()  +  "\"");
            SW.WriteLine(" class=\"" + Author + "\" cy=\"" + Y[0].ToString() + "\" stroke=\"#000000\"");
            SW.WriteLine (" stroke-opacity=\"1.0\" stroke-width=\"1.0\"/>");

            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                R = 12 * Double.Parse(lvw_Detail.Items[i].SubItems[1].Text);
                Clr = Clrs[int.Parse(C[i+1].ToString())];
                SW.WriteLine(" <circle fill-opacity=\"1.0\" fill=\"" + Clr + "\" r=\"" + R.ToString() + "\" cx=\"" + X[i+1].ToString() + "\"");
                SW.WriteLine(" class=\"" + lvw_Detail.Items[i].Text + "\" cy=\"" + Y[i+1].ToString() + "\" stroke=\"#000000\"");
                SW.WriteLine(" stroke-opacity=\"1.0\" stroke-width=\"1.0\"/>");
            }
            SW.WriteLine("</g>");
            #endregion

            #region Text

            SW.WriteLine(" <g id=\"node-labels\">");
            SW.WriteLine(" <text font-size=\"28\" x=\"" + X[0].ToString() + "\" y=\"" + Y[0].ToString() + "\" fill=\"#000000\"");
            SW.WriteLine(" style=\"text-anchor: middle; dominant-baseline: central;\"");
            SW.WriteLine(" font-family=\"Arial\" class=\"" + Author + "\">");
            SW.WriteLine(Author);
            SW.WriteLine("</text>");

            for (i = 0; i < lvw_Detail.Items.Count; i++)
            {
                SW.WriteLine(" <text font-size=\"18\" x=\"" + X[i+1].ToString() + "\" y=\"" +Y[i+1].ToString() +  "\" fill=\"#000000\"");
                SW.WriteLine(" style=\"text-anchor: middle; dominant-baseline: central;\"");
                SW.WriteLine(" font-family=\"Arial\" class=\"Data-Mining\">");
                SW.WriteLine(lvw_Detail.Items[i].Text);
                SW.WriteLine("</text>");
            }
            SW.WriteLine("</g>");

            #endregion

            #region Write Close SVG
            SW.WriteLine("</svg>"); // Close SVG
            SW.Close();
            SW.Dispose();
            #endregion

            return "Out.svg created...";

        }
        #endregion

        #region Detail Out the Nodes
        private void Detail_out_Nodes(ref  Double[] X, ref Double[] Y)
        {
            Double cX = double.Parse(cbo_Width.Text) / 2;
            Double cY = double.Parse(cbo_Height.Text) / 3;
                        
            X[0] = cX;
            Y[0] = cY;

            X[1] = cX - 300;
            Y[1] = cY; 

            X[2] = cX + 300;
            Y[2] = cY;

            X[3] = cX;
            Y[3] = cY - 250;

            X[4] = cX ;
            Y[4] = cY + 250;

            X[5] = cX - 300;
            Y[5] = cY - 250;

            X[6] = cX + 300;
            Y[6] = cY + 250;

            X[7] = cX - 300;
            Y[7] = cY +100;

            X[8] = cX + 300;
            Y[8] = cY + 100;

            X[9] = cX - 200;
            Y[9] = cY - 150;

            X[10] = cX + 200;
            Y[10] = cY + 150;

            X[11] = cX - 200;
            Y[11] = cY + 150;

            X[12] = cX + 200;
            Y[12] = cY - 150;

            X[13] = cX - 150;
            Y[13] = cY - 100;

            X[14] = cX + 150;
            Y[14] = cY + 100;

            X[15] = cX - 150;
            Y[15] = cY + 100;

            X[16] = cX + 150;
            Y[16] = cY - 100;

            X[17] = cX - 100;
            Y[17] = cY - 50;

            X[18] = cX + 100;
            Y[18] = cY + 50;
            
            X[19] = cX - 100;
            Y[19] = cY + 50;

            X[20] = cX + 100;
            Y[20] = cY - 50;
            
            X[21] = cX - 50;
            Y[21] = cY - 100;

            X[22] = cX + 50;
            Y[22] = cY + 100;

            X[23] = cX - 50;
            Y[23] = cY + 100;

            X[24] = cX + 50;
            Y[24] = cY - 100;

            X[25] = cX - 310;
            Y[25] = cY - 70;

            X[26] = cX + 310;
            Y[26] = cY + 70;

            X[27] = cX + 310;
            Y[27] = cY - 70;

            X[28] = cX - 310;
            Y[28] = cY + 70;

            X[29] = cX + 130;
            Y[29] = cY + 120;
            
            X[30] = cX - 130;
            Y[30] = cY - 120;

            X[31] = cX + 130;
            Y[31] = cY - 120;
         
            X[32] = cX - 130;
            Y[32] = cY + 120;
         }

        #endregion


        #region Random_Colors
        private Hashtable Random_Colors(int Max_No)
        {
            int U = Clrs.Length;
            int i = 0, randomNumber = 0;
            Hashtable H = new Hashtable();
            Random random = new Random();
            while (H.Count <= Max_No)
            {
                randomNumber = random.Next(0, Clrs.Length-1);
                if (H.Contains(randomNumber) == false)
                    H.Add(i++, randomNumber);
            }
            return H;

        }
        #endregion

        #region Populate with Authors & Topics
        private void  Populate_Authors_Topics(String Pth)
        {
            String Line = String.Empty;
            Hashtable H = new Hashtable();
            String topicS = String.Empty; 
            String Author = String.Empty;
            String Topic = String.Empty;
            String[] Arr = new String[2];
            Pth = Application.StartupPath + "\\" + Pth; 
            StreamReader SR = File.OpenText(Pth);            
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                Arr = Line.Split("\t".ToCharArray());
                Author = Arr[0].Trim();
                Topic = Arr[1].Trim();
                if (H.Contains(Author) == false)
                {
                    H.Add(Author, Topic);
                }
                else
                {
                    topicS = H[Author].ToString();
                    topicS += "\t" + Topic;
                    H[Author] = topicS;
                }
            }
            SR.Close();
            SR.Dispose();
            
            lvw_Detail.Items.Clear();
            lvw_Master.Items.Clear();
            ListViewItem L;            
            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                L = lvw_Master.Items.Add(ID.Key.ToString());
                L.Tag = ID.Value.ToString();               
            }
        }

        private void lvw_Authors_Click(object sender, EventArgs e)
        {
            String strTopic = lvw_Master.SelectedItems[0].Tag.ToString();
            tbx_Display.Text = lvw_Master.SelectedItems[0].Index.ToString() + ": " + lvw_Master.SelectedItems[0].Text;
            String[] Arr = strTopic.Split("\t".ToCharArray());
            int i=0, Cnt=0;
            Hashtable H = new Hashtable();
            for (i = 0; i < Arr.Length; i++)
            {
                if (H.Contains(Arr[i]) == false)
                {
                    H.Add(Arr[i], 1);
                }
                else
                {
                    Cnt = int.Parse(H[Arr[i]].ToString());
                    Cnt++;
                    H[Arr[i]] = Cnt.ToString();
                }
            }

            ListViewItem L;            
            lvw_Detail.Items.Clear();
            Radius = 0;
            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                L = lvw_Detail.Items.Add(ID.Key.ToString());
                L.SubItems.Add(ID.Value.ToString());
                Radius += int.Parse(ID.Value.ToString());
            }
            Radius *= 3;
        }


        #endregion

    


        private void rad_Topics_Click(object sender, EventArgs e)
        {
            lvw_Master.Columns[0].Text = "Authors";
            lvw_Detail.Columns[0].Text = "Topics";
            lvw_Master.BackColor = Color.Beige;
            lvw_Detail.BackColor = Color.Bisque;
            
            
        }

        private void rad_Authors_Click(object sender, EventArgs e)
        {
            lvw_Master.Columns[0].Text = "Topics";
            lvw_Detail.Columns[0].Text = "Authors";
            lvw_Master.BackColor = Color.Beige;
            lvw_Detail.BackColor = Color.Bisque;
        }


        #region Write Down Indiv files of Authors and Keywords for Visualization
        private void btn_Indiv_Files_Click(object sender, EventArgs e)
        {
            String S = String.Empty;
            String[] Arr = new String[2];
            String Line = String.Empty;
            StreamReader SR = File.OpenText(Application.StartupPath + "\\Input_4_Vis.txt");
            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                Arr = Line.Split("\t".ToCharArray());                
                S = Arr[0].Trim() + "," + Arr[1].Trim();
                S += Environment.NewLine;
                // Write down Authors Files //////////
                try
                {
                 File.AppendAllText(Application.StartupPath + "\\Authors\\" + Arr[0].Trim() + ".csv",S);
                }
                catch
                { }
                // Write down Kewords Files //////////
                S = Arr[1].Trim() + "," + Arr[0].Trim();
                S += Environment.NewLine;
                String Tmp = Arr[1].Replace("\\", " ");
                try
                {
                    File.AppendAllText(Application.StartupPath + "\\Keywords\\" + Arr[1].Trim() + ".csv", S);
                }
                catch
                { }

            }
            SR.Close();
            SR.Dispose();
            tbx_Display.Text = "All Done";
            MessageBox.Show("All Done");

        }
        #endregion


        


    }
}
