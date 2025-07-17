using System;
using DVLD.Status;

namespace DVLD.Entitiy
{
    public class clsApplicant : clsPerson
    {
        public int ApplicantID { get; }
        public string Email { get; set; }
        private string _PasswordHash;

        public Permissions Permission { get; }

        public Activation Status { set; get; }

        public EntityStatus ApplicantStatus { set; get; }

        public clsApplicant()
        {
            Email = "";
            Permission = Permissions.Applicant;
            Status = Activation.Active;
            ApplicantStatus= EntityStatus.New;
        }
        public clsApplicant(string Email, string FName, string SName, string TName, string LName, string ConEmail,
            string NNo, string Nation, DateTime Date, string Gend, string PhoneNo)
            : base(FName, SName, TName, LName, ConEmail, NNo, Nation, Date, Gend, PhoneNo)
        {
            ApplicantStatus = EntityStatus.Exists;
            this.Email = Email;
            this.Permission = Permissions.Applicant;
            this.Status = Activation.Active;
        }




        public void SetPassword(string password)
        {
            // Here you would typically hash the password before storing it
            _PasswordHash = HashPassword(password); // This is a placeholder, do not use in production
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public string GetPassword()
        { return _PasswordHash; }


    }
}
