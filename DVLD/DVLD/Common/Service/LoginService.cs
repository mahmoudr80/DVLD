using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Entitiy;
using DVLD.Status;
namespace DVLD.Common.Service
{
    public static class LoginService
    {
        public static clsAdmin currentAdmin { get; set; } = null;
        public static clsApplicant currentApplicant { get; set; } = null;

        public static bool Login (string Email, string Password, Permissions permission)
        {
            Password = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Password));
            switch (permission)
            {
                case Permissions.Admin:
                    currentAdmin = DVLD.Common.Repository.LoginRepo.LoginAsAdmin(Email, Password);
                    if (currentAdmin != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case Permissions.Applicant:
                    currentApplicant = DVLD.Common.Repository.LoginRepo.LoginAsApplicant(Email, Password);
                    if (currentApplicant != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    throw new Exception("Invalid permission type.");
            }
        }
    }
}
