using DVLD.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.Applicant.Repository
{
    public static class RegisterRepo
    {
        public static  int Register(clsApplicant applicant)
        {
            int GenID, PersonID;

            GenID = applicant.Gender.ToLower()=="male"?1:2;

            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            
            try
            {
                
                conn.Open();
                string PersonQuery = "INSERT INTO Person ( [FirstName] ,[SecondName] , [ThirdName] , [LastName] " +
                    ", [NationalNumber] , [Email] , [GenderID] , [DateOfBirth] , [Nationality] , [Phone]) VALUES " +
                    "(@FName,@SName,@TName,@LName,@NNo,@email,@GenID,@Date,@Nation,@Phone) SELECT SCOPE_IDENTITY(); ";

                SqlCommand cmd = new SqlCommand(PersonQuery, conn);

                cmd.Parameters.AddWithValue("@FName", applicant.FirstName);
                cmd.Parameters.AddWithValue("@SName", applicant.SecondName);
                cmd.Parameters.AddWithValue("@TName", applicant.ThirdName);
                cmd.Parameters.AddWithValue("@LName", applicant.LastName);
                cmd.Parameters.AddWithValue("@NNo", applicant.NationalNumber);
                cmd.Parameters.AddWithValue("@email", applicant.ContactEmail);
                cmd.Parameters.AddWithValue("@GenID", GenID);
                cmd.Parameters.AddWithValue("@Date", applicant.DateOfBirth);
                cmd.Parameters.AddWithValue("@Nation", applicant.Nationality);
                cmd.Parameters.AddWithValue("@Phone", applicant.PhoneNumbers);

                object result = cmd.ExecuteScalar();
                PersonID= Convert.ToInt32(result);

                string ApplicantQuery = "INSERT INTO [dbo].[Applicant] ([Email] , [Password] ,[PersonID]) VALUES " +
                    "( @email , @pass , @ID); SELECT SCOPE_IDENTITY();";

                SqlCommand cmd2 = new SqlCommand(ApplicantQuery, conn);

                cmd2.Parameters.AddWithValue("@email", applicant.Email);
                cmd2.Parameters.AddWithValue("@pass", applicant.GetPassword());
                cmd2.Parameters.AddWithValue("@ID", PersonID);
               

                object result2 = cmd2.ExecuteScalar();
                int ApplicantID = Convert.ToInt32(result);
                conn.Close();
                return ApplicantID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during admin login: " + ex.Message);

            }
            finally
            {
                conn.Close();

            }
           
        }

        public static bool PersonEmailExists(string email)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            try
            {
                conn.Open();
                string query = "select email from Person where Email= @email";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                conn.Close() ;
                return true;
                }
                else
                {
                    conn.Close();
                    return false;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during check PersonEmailExists: " + ex.Message);

            }
            finally
            {
                conn.Close();

            }
        }
        public static bool ApplicantEmailExists(string email)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            try
            {
                conn.Open();
                string query = "select email from applicant where Email= @email";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during check ApplicantEmailExists: " + ex.Message);

            }
            finally
            {
                conn.Close();

            }
        }

        public static List<string> GetAllCountries()
        {
            List <string> countries = new List<string>();

            SqlConnection conn = new SqlConnection(Connection.Connection.ConnectionString);
            try
            {
                conn.Open();
                string query = "select country_code from countries";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    countries.Add(reader["country_code"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error during Extracting Countries: " + ex.Message);

            }
            finally
            {
                conn.Close();

            }

            return countries;
        }

    }
}
