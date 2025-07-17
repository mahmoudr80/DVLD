using System;
using DVLD.Entitiy;
using System.Data.SqlClient;
using DVLD.Connection;

namespace DVLD.Common.Repository
{
    public class LoginRepo
    {




        static public clsAdmin LoginAsAdmin(string Email, string Password)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            clsAdmin admin = null;
            try
            {
                conn.Open();
                string query = "SELECT top 1 Person.FirstName, Person.SecondName, Person.ThirdName, " +
                    "Person.LastName, Person.NationalNumber, Person.Email, Admin.Email AS AdminEmail, " +
                    "Gender.Gender, countries.country_enNationality, Person.DateOfBirth,Person.Phone\r\nFROM     Admin " +
                    "INNER JOIN\r\n Person ON Admin.PersonID = Person.PersonID INNER JOIN\r\n " +
                    "Gender ON Person.GenderID = Gender.GenderID INNER JOIN\r\n " +
                    "countries ON Person.Nationality = countries.country_code\r\n\t\t\t\t  " +
                    "group by Person.FirstName, Person.SecondName, Person.ThirdName, Person.LastName, " +
                    "Person.NationalNumber, Person.Email, Admin.Email, Gender.Gender, countries.country_enNationality," +
                    " Person.DateOfBirth,Person.Phone,Admin.Password " +
                    "\r\n\t\t\t\thaving Admin.Email = @Email AND Admin.Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                SqlDataReader reader = cmd.ExecuteReader();
            
                if (reader.Read())
                {
                    admin = new clsAdmin(
                    reader["AdminEmail"].ToString(),
                    reader["FirstName"].ToString(),
                    reader["SecondName"].ToString(),
                    reader["ThirdName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["NationalNumber"].ToString(),
                    reader["country_enNationality"].ToString(),
                    Convert.ToDateTime(reader["DateOfBirth"]),
                    reader["Gender"].ToString(),
                    reader["Phone"].ToString());
                }
                else
                {
                    return admin;
                  
                }
                }
            catch (Exception ex)
            {  
                throw new Exception("Error during admin login: " + ex.Message);
            }
            finally
            {
                conn.Close();
               
            }
            return admin;
        }

        static public clsApplicant LoginAsApplicant(string Email, string Password)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            clsApplicant applicant = null;
            try
            {
                conn.Open();
                string query = "\r\nSELECT  Person.FirstName, Person.SecondName, Person.ThirdName, Person.LastName," +
                    " Person.NationalNumber, Person.Email, Gender.Gender, countries.country_enNationality, Person.DateOfBirth," +
                    " Person.Phone, \r\n   Applicant.Email AS ApplicantEmail\r\nFROM  Person" +
                    " INNER JOIN\r\n Gender ON Person.GenderID = Gender.GenderID INNER JOIN\r\n  " +
                    "countries ON Person.Nationality = countries.country_code INNER JOIN\r\n " +
                    "Applicant ON Person.PersonID = Applicant.PersonID\r\n " +
                    "GROUP BY  Person.FirstName, Person.SecondName, Person.ThirdName, Person.LastName," +
                    " Person.NationalNumber, Person.Email, Gender.Gender, countries.country_enNationality," +
                    " Person.DateOfBirth, Person.Phone, \r\n  Applicant.Email,Applicant.Password\r\n " +
                    "having Applicant.Email = @Email AND Applicant.Password = @Password\r\n";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    applicant = new clsApplicant(
                    reader["ApplicantEmail"].ToString(),
                    reader["FirstName"].ToString(),
                    reader["SecondName"].ToString(),
                    reader["ThirdName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["NationalNumber"].ToString(),
                    reader["country_enNationality"].ToString(),
                    Convert.ToDateTime(reader["DateOfBirth"]),
                    reader["Gender"].ToString(),
                    reader["Phone"].ToString());
                }
                else
                {
                    return applicant;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during admin login: " + ex.Message);

            }
            finally
            {
                conn.Close();

            }
            return applicant;
        }

    }
}
