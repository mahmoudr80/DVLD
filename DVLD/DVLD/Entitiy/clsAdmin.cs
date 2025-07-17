using DVLD.Status;
using System;

namespace DVLD.Entitiy
{
    public class clsAdmin:clsPerson
    {
        public int AdminID { get; }
        public string Email { get; set; }
        private string _PasswordHash;

        public Permissions Permission { get; set; }

        public Activation Status { set; get; }

        public EntityStatus AdminStatus { set; get; }
        

        public clsAdmin()
        {
            Email = "";
            Permission = Permissions.Admin;
            Status = Activation.Active;
            AdminStatus = EntityStatus.New;
        }
        public clsAdmin(string Email, string FName, string SName, string TName, string LName, string ConEmail,
            string NNo, string Nation,DateTime Date, string Gend, string PhoneNo)
            :base(FName,SName,TName,LName,ConEmail,NNo,Nation,Date,Gend,PhoneNo)
        {
            AdminStatus = EntityStatus.Exists;
            this.Email = Email;
            this.Permission = Permissions.Admin;
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
    }
}
