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
using DVLD.Common.Service;
using DVLD.Status;
using DVLD.Admin.Controller;
using DVLD.Applicant.Controller;
namespace DVLD.Common.Controller
{
    public partial class LoginController : Form
    {
        public LoginController()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            { // Login as Admin
                // Here you would typically validate the admin credentials
               if(LoginService.Login(textBox2.Text, textBox1.Text, Permissions.Admin))
                {
                    MessageBox.Show("Admin login successful!");

                    this.Hide();
                    using(var frm = new AdminDashboardController(LoginService.currentAdmin))
                    {
                        frm.ShowDialog();
                    }
                    this.Show();
                }
                else {MessageBox.Show("Invalid admin credentials. Please try again.");
                    return;
                }

            }
            else if (radioButton2.Checked)
            {
                // Login as Applicant
                // Here you would typically validate the applicant credentials
                if (LoginService.Login(textBox2.Text, textBox1.Text, Permissions.Applicant))
                {
                    MessageBox.Show("Applicant login successful!");
                    this.Hide();
                    using (var frm = new ApplicantDashboardController(LoginService.currentApplicant))
                    {
                        frm.ShowDialog();
                    }
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid applicant credentials. Please try again.");
                    return;
                }
            
            }
            else
            {
                MessageBox.Show("Please select a role to login.");
            }
        }
    }
}
