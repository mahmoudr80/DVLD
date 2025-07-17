using DVLD.Applicant.Service;
using DVLD.Common.Controller;
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
using System.Xml.Linq;

namespace DVLD.Applicant.Controller
{
    public partial class RegisterController : Form
    {
        public RegisterController()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void RegisterController_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = RegisterService.GetAllCountries();
            comboBox2.DataSource = new List<string> { "male", "female" };
            textBox5.PasswordChar = '*';
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_AreFieldsValid())
            {
                if (RegisterService.CheckPersonEmail(textBox4.Text))
                {
                    textBox4.Focus();
                    MessageBox.Show("Contact Email already Exists!");
                    return;
                }
                if (RegisterService.CheckApplicantEmail(textBox2.Text))
                {
                    textBox2.Focus();
                    MessageBox.Show("email already Exists!");
                    return;
                }
                clsApplicant applicant = new clsApplicant(textBox2.Text,txtFName.Text,txtSName.Text,txtTName.Text,txtLName.Text,
                    textBox4.Text,textBox3.Text,comboBox1.Text,dateTimePicker1.Value,comboBox2.Text,
                    textBox1.Text);
                applicant.SetPassword(textBox5.Text);
                int ApplicantID = RegisterService.Register(applicant);   
                MessageBox.Show("Registered successfully with ID = " + ApplicantID);


                this.Hide(); // hide current form
                using (var frm = new LoginController())
                {
                    frm.ShowDialog(); // show next form modally
                }
                this.Show(); // show current form again after form2 closes


             
            }
        }

        private bool _AreFieldsValid()
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text))
            {
                MessageBox.Show("First Name is required.");
                txtFName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSName.Text))
            {
                MessageBox.Show("Second Name is required.");
                txtSName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTName.Text))
            {
                MessageBox.Show("Third Name is required.");
                txtTName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("Last Name is required.");
                txtLName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Contact Email is required.");
                textBox4.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("National Number is required.");
                textBox3.Focus();
                return false;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Nationality is required.");
                comboBox1.Focus();
                return false;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Gender is required.");
                comboBox2.Focus();
                return false;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Nationality is required.");
                comboBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Phone Number is required.");
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Email is required.");
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Password is required.");
                textBox5.Focus();
                return false;
            }
            return true;
        }
    }
}
