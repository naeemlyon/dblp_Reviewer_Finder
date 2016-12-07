using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace dblp_Reviewer_Finder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_dblp_Reviewer());
         //  Application.Run(new frm_Visualization());
         // Application.Run(new frmExpert());


        }
    }
}
