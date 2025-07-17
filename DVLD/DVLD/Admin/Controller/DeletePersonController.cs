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
    public partial class DeletePersonController : Form
    {
        public DeletePersonController()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void DeletePersonController_Load(object sender, EventArgs e)
        {
            StyleButton(button1, "Delete", Color.Firebrick);
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

    }
}
