using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Admin.Controller
{
    public partial class AddPersonController : Form
    {
        public AddPersonController()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void ManagePersonController_Load(object sender, EventArgs e)
        {
            StyleButton(button1, "Add", Color.SeaGreen);
            
        }

        void StyleButton(Button btn, string text, Color backColor)
        {
            btn.Text = text;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(100, 35);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DVLD.Entitiy.clsPerson person = ctrlPerson1.GetPersonDetails();

        }
    }
}
