using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Common.Controller;
namespace DVLD
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
   
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide(); // hide current form
            using (var frm = new LoginController())
            {
                frm.ShowDialog(); // show next form modally
            }
            this.Show(); // show current form again after form2 closes

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide(); // hide current form
            using (var frm = new DVLD.Applicant.Controller.RegisterController())
            {
                frm.ShowDialog(); // show next form modally
            }
            this.Show(); // show current form again after form2 closes

         
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
      
        }
    }
}
