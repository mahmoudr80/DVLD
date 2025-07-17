using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Admin.Service;
using DVLD.Common.Controller;
using DVLD.Entitiy;
namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new frmStart());
          
            Application.Run(new DVLD.Admin.Controller.AdminDashboardController(new clsAdmin()));
        }
    }
}
