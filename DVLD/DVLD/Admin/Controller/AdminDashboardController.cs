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

namespace DVLD.Admin.Controller
{
    public partial class AdminDashboardController : Form
    {
        public  clsAdmin currentAdmin { get; set; } = null;
        public AdminDashboardController(clsAdmin admin)
        {
            this.currentAdmin = admin;
            InitializeComponent();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var frm = new AddPersonController())
            {
                frm.ShowDialog();
            }
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var frm = new UpdatePersonController())
            {
                frm.ShowDialog();
            }
            this.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var frm = new DeletePersonController())
            {
                frm.ShowDialog();
            }
            this.Show();

        }
    }
}
