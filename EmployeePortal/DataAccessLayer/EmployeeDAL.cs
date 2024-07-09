using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataAccessLayer
{
    public class EmployeeDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id,Name,Address,Mobile,DOB FROM Employees", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        Mobile = reader["Mobile"].ToString(),
                        DOB = (DateTime)reader["DOB"]
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }
        public Employee Get(int? id)
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                Employee employee = null;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id,Name,Address,Mobile,DOB FROM Employees where id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeId = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            DOB = (DateTime)reader["DOB"]
                        };
                    }
                }
                return employee;
            }
        }
        public void Add(Employee emp)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO EMPLOYEES (Name,Address,Mobile,DOB) VALUES (@Name,@Address,@Mobile,@DOB)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE EMPLOYEES SET Name=@Name, Address=@Address, Mobile=@Mobile, DOB=@DOB WHERE ID=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM EMPLOYEES WHERE ID=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
                
        }
    }
}