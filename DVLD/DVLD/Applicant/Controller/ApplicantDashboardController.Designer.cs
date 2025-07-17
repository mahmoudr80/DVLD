namespace DVLD.Applicant.Controller
{
    partial class ApplicantDashboardController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicantDashboardController));
            this.ctrlPerson1 = new DVLD.User_Controllers.ctrlPerson();
            this.SuspendLayout();
            // 
            // ctrlPerson1
            // 
            this.ctrlPerson1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlPerson1.BackgroundImage")));
            this.ctrlPerson1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlPerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPerson1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPerson1.Name = "ctrlPerson1";
            this.ctrlPerson1.Size = new System.Drawing.Size(1335, 528);
            this.ctrlPerson1.TabIndex = 0;
            // 
            // ApplicantDashboardController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 528);
            this.Controls.Add(this.ctrlPerson1);
            this.Name = "ApplicantDashboardController";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmApplicantDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controllers.ctrlPerson ctrlPerson1;
    }
}