using WebApp3BySijan.Models;
using Microsoft.Data.SqlClient;

namespace WebApp3BySijan.Repositories
{
    public class EmployeeRepo
    {
         public Employee GetSingleEmployeeRecord(int id)
        {
            string conStr = @"Server= LAPTOP-9A4GKMF2\SQLEXPRESS02; database= LabNCC; integrated security=SSPI;TrustServerCertificate=True";
            Employee emp = new Employee();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"SELECT * FROM Employees WHERE id ={id}";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    emp.ID = Convert.ToInt32(rdr["id"]);
                    emp.Name = Convert.ToString(rdr["name"]);
                    emp.Address = Convert.ToString(rdr["adddress"]);
                    emp.Phone = Convert.ToInt64(rdr["phone"]);
                    Console.WriteLine(emp.ID);
                    Console.WriteLine(emp.Name);
                    Console.WriteLine(emp.Address);
                    Console.WriteLine(emp.Phone);
                }
                conn.Close();
            }
            return emp;
        }
        // Read Logic
        public List<Employee> GetAllRecord()
        {
            List<Employee> listOfEmployee = new List<Employee>();

            try
            {
                string conStr = @"server=LAPTOP-9A4GKMF2\SQLEXPRESS02; database=LabNCC; Trusted_Connection=True; TrustServerCertificate=True;";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine("Connection Established");

                string selectQuery = "SELECT * FROM Employees";
                SqlCommand sqlcmd = new SqlCommand(selectQuery, conn);
                // 'rdr' stores the result of SQL Query
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                Console.WriteLine("Record Retrieved Successfully");

                while (rdr.Read())                      // Just like fallocate() in PHP
                {
                    Employee emp = new Employee();
                    // 'rdr's key is database's table column name
                    emp.ID = Convert.ToInt32(rdr["id"]);
                    emp.Name = Convert.ToString(rdr["name"]);
                    emp.Address = Convert.ToString(rdr["address"]);
                    emp.Phone = Convert.ToInt32(rdr["phone"]);
                    Console.WriteLine("Data Check: ");
                    Console.WriteLine(emp.ID);
                    Console.WriteLine(emp.Name);
                    Console.WriteLine(emp.Address);
                    Console.WriteLine(emp.Phone);
                    listOfEmployee.Add(emp);            // Add DB record in the list
                }
                // Good practice to close connection to allow other users to access server 
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Connecting: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Read Complete");
            }

            return listOfEmployee;
        }
        // Create Logic
        public void SetEmployee(Employee s1)
        {
            try
            {
                // Write user name from SSMS software
                //string conStr = @"server=DESKTOP-JAE0FTL\MSSQLSERVER01; database=GiverDB; Trusted_Connection=True; TrustServerCertificate=True;";
                string conStr = @"server=LAPTOP-9A4GKMF2\SQLEXPRESS02; database=labNCC; Trusted_Connection=True; TrustServerCertificate=True;";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine("Connection Established");

                //string selectQuery = $"INSERT INTO Students VALUES({std.Id}, '{std.Name}', '{std.Address}')";
                string selectQuery = $"INSERT INTO Employees VALUES({s1.ID}, '{s1.Name}', '{s1.Address}','{s1.Phone}')";

                SqlCommand sqlcmd = new SqlCommand(selectQuery, conn);
                // 'rdr' stores the result of SQL Query
                int n = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully");
                // Good practice to close connection to allow other users to access server 
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Connecting: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Create Complete");
            }

        }
        // Edit Logic
        public void EditEmployee(int id, string newName, string newAddr,int newPhone)
        {
            try
            {
                // Write user name from SSMS software
                //string conStr = @"server=DESKTOP-JAE0FTL\MSSQLSERVER01; database=GiverDB; Trusted_Connection=True; TrustServerCertificate=True;";
                string conStr = @"server=LAPTOP-9A4GKMF2\SQLEXPRESS02; database=labNCC; Trusted_Connection=True; TrustServerCertificate=True;";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine("Connection Established");

                //string selectQuery = $"UPDATE Students SET name={newName}, address={newAddr} WHERE id={id}";
                string selectQuery = $"UPDATE Employees SET name='{newName}', address='{newAddr}', phone='{newPhone}' WHERE id={id}";

                SqlCommand sqlcmd = new SqlCommand(selectQuery, conn);
                // 'rdr' stores the result of SQL Query
                int n = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Record Updated Successfully");

                // Good practice to close connection to allow other users to access server 
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Connecting: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Update Complete");
            }

        }
        // Delete Logic
        public void DeleteEmployee(int id)
        {
            try
            {
                // Write user name from SSMS software
                //string conStr = @"server=DESKTOP-JAE0FTL\MSSQLSERVER01; database=GiverDB; Trusted_Connection=True; TrustServerCertificate=True;";
                string conStr = @"server=LAPTOP-9A4GKMF2\SQLEXPRESS02; database=LabNCC; Trusted_Connection=True; TrustServerCertificate=True;";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine("Connection Established");

                //string selectQuery = $"DELETE FROM Students id={id}";
                string selectQuery = $"DELETE FROM Employees WHERE id={id}";

                SqlCommand sqlcmd = new SqlCommand(selectQuery, conn);
                // 'rdr' stores the result of SQL Query
                int n = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");

                // Good practice to close connection to allow other users to access server 
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Connecting: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Delete Complete");
            }

        }
    }
}