using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.eContactClasses
{
    internal class contactClass
    {
        // Get and setter Properties
        // Acts as a Data Carrier In our Application
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        // Selecting Data from Database
        public DataTable Select()
        {
            // Step 1: Database connection
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable();
            try
            {
                // Step 2: Write SQL Query
                string sql = "SELECT * FROM tbl_contact";
                // Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating SQL DataAdaptor using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

            } 
            finally 
            {
                // Connection close
                conn.Close();
            }
            return dt;
        }

        // Insert Data into Database
        public bool Insert(contactClass c)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;

            // Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                // Step 2: Write SQL Insert Query
                string sql = "INSERT INTO tbl_contact (FirstName, LastName, ContactNo, Address, Gender) VALUES (@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                // Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating Parameters to add Data
                cmd.Parameters.AddWithValue("@FirstName",c.FirstName);
                cmd.Parameters.AddWithValue("@LastName",c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo",c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                // Connection open
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // If the query runs successfully then the value of rows will be greater than zero else its value be 0
                if(rows > 0)
                {
                    isSuccess = true;
                } else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                // Connection close
                conn.Close();
            }

            return isSuccess;
        }

        // Method to update data in Database from app
        public bool Update(contactClass c)
        {
            // Craete a default return type and set its default value to false
            bool isSuccess = false;

            // Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                // Step 2: Write SQL Update Query
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@Lastname, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                // Updating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Updating Parameters
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                // Connection open
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                // If the query runs successfully then the value of rows will be greater than zero else its value be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Connection close
                conn.Close();
            }

            return isSuccess;
        }

        public bool Delete(contactClass c)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;

            // Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                // Step 2: Write SQL DELETE Query
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";
                // Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // DELETE Parameter
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                // Connection open
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // If the query runs successfully then the value of rows will be greater than zero else its value be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Connection close
                conn.Close();
            }

            return isSuccess;
        }
    }
}
