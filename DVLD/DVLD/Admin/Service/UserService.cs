using DVLD.Admin.Repository;
using DVLD.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Admin.Service
{
    public static class UserService
    {
        public static bool DeletePerson(string NNo)
        {
            return UserRepository.DeletePerson(NNo);
        }
        public static int GetPersonID(string NNo)
        {
            return UserRepository.GetPersonID(NNo);
        }
        public static clsPerson GetPersonByNNo(string NNo)
        {
            return UserRepository.GetPersonByNNo(NNo);
        }
    }
}
