using DVLD.Applicant.Repository;
using DVLD.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Applicant.Service
{
    public class RegisterService
    {
        public static int Register(clsApplicant applicant) {

        return RegisterRepo.Register(applicant);
        
        }

        public static bool CheckPersonEmail(string email)
        {
            return RegisterRepo.PersonEmailExists(email);
        }

        public static bool CheckApplicantEmail(string email)
        {
            return RegisterRepo.ApplicantEmailExists(email);
        }

        public static List<string> GetAllCountries()
        {
            return RegisterRepo.GetAllCountries();
        }
    }

    

}
