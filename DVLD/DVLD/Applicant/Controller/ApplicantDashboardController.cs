using DVLD.Admin.Service;
using DVLD.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applicant.Controller
{
    public partial class ApplicantDashboardController : Form
    {
        public clsApplicant currentApplicant { get; set; } = null;
        public ApplicantDashboardController(clsApplicant applicant)
        {
            InitializeComponent();
            this.currentApplicant = applicant;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmApplicantDashboard_Load(object sender, EventArgs e)
        {
            clsPerson Person = UserService.GetPersonByNNo("M82");
            ctrlPerson1.FillPersonDetails(Person);
            ctrlPerson1.MakeItEditable();
        }

        private void ctrlPerson1_Load(object sender, EventArgs e)
        {
           

        }
    }
}
