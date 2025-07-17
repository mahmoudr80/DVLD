using DVLD.Applicant.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.User_Controllers
{
    public partial class ctrlPerson : UserControl
    {
        public ctrlPerson()
        {
            InitializeComponent();
        }

        private void ctrlPerson_Load(object sender, EventArgs e)
        {

        }

        public bool FillPersonDetails(Entitiy.clsPerson person)
        {
            if (person == null) return false;
            txtName.Text = person.FullName();
            txtEmail.Text = person.ContactEmail;
            txtNNo.Text = person.NationalNumber;
            dtDate.Value = person.DateOfBirth;
            cbGender.SelectedText = person.Gender;
            txtPhone.Text = person.PhoneNumbers;
            cbNationality.SelectedText = person.Nationality;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtNNo.ReadOnly = true;
            dtDate.Enabled = false;
            cbGender.Enabled = false;
            cbNationality.Enabled = false;

            return true;
        }

        public bool MakeItEditable()
        {
            cbGender.DataSource = new List<string> { "male", "female" };
            cbNationality.DataSource = RegisterService.GetAllCountries();
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtNNo.ReadOnly = false;
            dtDate.Enabled = true;
            cbGender.Enabled = true;
            cbNationality.Enabled = true;
            return true;
        }

        public Entitiy.clsPerson GetPersonDetails()
        {
            if(!_AreFieldsValid())
            {
                return null;
            }
            else
            {
                List<string> Name = txtName.Text.Split(' ')
              .Select(x => x.Trim())
              .Where(x => !string.IsNullOrEmpty(x))
              .ToList();

                return new Entitiy.clsPerson(FName: Name[0], Name[1], Name[2], Name[3],
                    ConEmail: txtEmail.Text,
                    NNo: txtNNo.Text, Nation: cbNationality.Text, Date: dtDate.Value, Gend: cbGender.Text, PhoneNo: txtPhone.Text);
      
            }
     }


        private bool _AreFieldsValid()
        {
            List<string> Name = txtName.Text.Split(' ')
                          .Select(x => x.Trim())
                          .Where(x => !string.IsNullOrEmpty(x))
                          .ToList();

            if (Name.Count < 4)
            {
                MessageBox.Show("Please enter at least four names separated by spaces.");
                txtName.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Contact Email is required.");
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNNo.Text))
            {
                MessageBox.Show("National Number is required.");
                txtNNo.Focus();
                return false;
            }
            if (cbNationality.SelectedIndex == -1)
            {
                MessageBox.Show("Nationality is required.");
                cbNationality.Focus();
                return false;
            }
            if (cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Gender is required.");
                cbGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone Number is required.");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

    }
}