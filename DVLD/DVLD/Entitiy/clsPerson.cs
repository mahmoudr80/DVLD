using DVLD.Status;
using System;
using System.IO;
using System.Security.Policy;

namespace DVLD.Entitiy
{
    public class clsPerson
    {
        public int Id { get;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string NationalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string PhoneNumbers { get; set; }

        public EntityStatus EntityStatus { get; set; }

        public clsPerson()
        {
            EntityStatus = EntityStatus.New;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            ContactEmail = "";
            NationalNumber = "";
            Nationality = "";
            DateOfBirth = DateTime.Now;
            Gender = "Unknown";
            PhoneNumbers = null;
        }

        public clsPerson(string FName, string SName, string TName, string LName , string ConEmail, string NNo, string Nation, 
            DateTime Date, string Gend, string PhoneNo)
        {
            this.EntityStatus = EntityStatus.Exists;
            this.FirstName = FName;
            this.SecondName = SName;
            this.ThirdName = TName;
            this.LastName = LName;
            this.ContactEmail = ConEmail;
            this.NationalNumber = NNo;
            this.Nationality = Nation;
            this.DateOfBirth = Date;
            this.Gender = Gend;
            this.PhoneNumbers = PhoneNo;
        }
        public string FullName()
        {
            return FirstName+" " + SecondName + " " + ThirdName + " " + LastName;
        }
    }
}
