using DVLD.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Admin.Repository
{
    public static class UserRepository
    {
        public static  bool DeletePerson(string NNo)
        {
            int PersonID = GetPersonID(NNo);
            if (PersonID != -1) 
            {
                string sql = @"
        DELETE FROM [dbo].Admin WHERE PersonID = 28;
        DELETE FROM [dbo].Applicant WHERE PersonID = 28;
        DELETE FROM [dbo].[Person] WHERE NationalNumber = 'S80';
    ";

                try
                {
                    SqlConnection connection = new SqlConnection(DVLD.Connection.Connection.ConnectionString);
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0) return true;
                        else return false;
                    }

                }
                catch {
                    return false;
                }
                finally
                {

                }
            }
            else
            {
                return false;
            }
           
        }

        public static int GetPersonID(string NNo)
        {
            SqlConnection connection = null;
            int ID = -1;
            string query = "select PersonID FROM [dbo].[Person] WHERE NationalNumber = @NNo";
            try
            {
                 connection = new SqlConnection(DVLD.Connection.Connection.ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NNo", NNo);

                object result = cmd.ExecuteScalar();
                 ID = (result != null) ? Convert.ToInt32(result) : -1;
                connection.Close();
                return ID;
            }
            finally
            {
                connection.Close();
              

            }
      
        }

        public static clsPerson GetPersonByNNo(string NNo)
        {
            SqlConnection connection = null;
         
            string query = "select * FROM [dbo].[Person] WHERE NationalNumber = @NNo";
            try
            {
                connection = new SqlConnection(DVLD.Connection.Connection.ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NNo", NNo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string gender = Convert.ToInt16(reader["GenderID"].ToString()) == 1 ? "male" : "female";


                    return new clsPerson(reader["FirstName"].ToString(), reader["SecondName"].ToString(),
                        reader["ThirdName"].ToString(), reader["LastName"].ToString(), reader["Email"].ToString(),
                        reader["NationalNumber"].ToString(), reader["Nationality"].ToString(),
                        (DateTime)reader["DateOfBirth"], gender, reader["Phone"].ToString());
                }
                else return null;
            }
            catch 
            {
                connection.Close();
                return null;
            }
            finally
            {
                connection.Close();


            }

        }
    }
}
