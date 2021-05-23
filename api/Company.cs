using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Types;
using System.Collections.Generic;

namespace CMAPI
{
    // Klasa opisująca firmę - zawierająca metody z API
    public class Company
    {
        public SqlConnection apiConnection = null;

        public Company()
        {
            string conString = @"Data Source=mssqlserver;Initial Catalog=cmapiDB;Integrated Security=True";
            apiConnection = new SqlConnection(conString);
            apiConnection.Open();
        }

        public void addEmployee(string level, string firstName, string lastName, string position, int salary)
        {
            SqlCommand addCommand = new SqlCommand("AddEmployee", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            addCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;
            addCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
            addCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
            addCommand.Parameters.Add("@position", SqlDbType.VarChar).Value = position;
            addCommand.Parameters.Add("@salary", SqlDbType.Int).Value = salary;

            addCommand.ExecuteNonQuery();
        }

        public void removeEmployeeById(int id)
        {
            SqlCommand removeCommand = new SqlCommand("RemoveEmployeeById", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            removeCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            removeCommand.ExecuteNonQuery();
        }

        public void removeEmployeeByFirstName(string firstName)
        {
            SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByFirstName", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            removeCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;

            removeCommand.ExecuteNonQuery();
        }

        public void removeEmployeeByLastName(string lastName)
        {
            SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByLastName", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            removeCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;

            removeCommand.ExecuteNonQuery();
        }

        public void removeEmployeeByLevel(string level)
        {
            SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByLevel", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            removeCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;

            removeCommand.ExecuteNonQuery();
        }

        public void removeAllEmployees()
        {
            SqlCommand removeCommand = new SqlCommand("RemoveAllEmployees", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            removeCommand.ExecuteNonQuery();
        }

        public Employee getEmployeeById(int id)
        {
            SqlCommand getCommand = new SqlCommand("GetEmployeeById", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            getCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using (SqlDataReader result = getCommand.ExecuteReader())
            {

                try
                {
                    result.Read();

                    Employee employee = new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]);

                    return employee;
                }
                catch (Exception e)
                {
                    return null;
                }

            };
        }

        public Employee getEmployeeByLevel(string level)
        {
            SqlCommand getCommand = new SqlCommand("GetEmployeeByLevel", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            getCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;

            using (SqlDataReader result = getCommand.ExecuteReader())
            {
                try
                {
                    result.Read();

                    Employee employee = new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]);

                    return employee;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public Employee getEmployeeByFirstName(string firstName)
        {
            SqlCommand getCommand = new SqlCommand("GetEmployeeByFirstName", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            getCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;

            using (SqlDataReader result = getCommand.ExecuteReader())
            {
                try
                {
                    result.Read();

                    Employee employee = new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]);

                    return employee;
                }
                catch (Exception e)
                {
                    return null;
                }

            };
        }

        public Employee getEmployeeByLastName(string lastName)
        {
            SqlCommand getCommand = new SqlCommand("GetEmployeeByLastName", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            getCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;

            using (SqlDataReader result = getCommand.ExecuteReader())
            {
                result.Read();

                Employee employee = new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]);

                return employee;
            };
        }

        public List<Employee> getEmployeeWithSubordinates(string level)
        {
            SqlCommand getCommand = new SqlCommand("GetEmployeeWithSubordinates", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            getCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;

            using (SqlDataReader result = getCommand.ExecuteReader())
            {
                List<Employee> employees = new List<Employee>();

                while (result.Read())
                {
                    employees.Add(new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]));
                }

                return employees;
            };
        }

        public List<Employee> getAllEmployees()
        {
            SqlCommand getCommand = new SqlCommand("GetAllEmployees", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using (SqlDataReader result = getCommand.ExecuteReader())
            {
                List<Employee> employees = new List<Employee>();

                while (result.Read())
                {
                    employees.Add(new Employee((int)result["id"], (SqlHierarchyId)result["level"], (string)result["firstName"], (string)result["lastName"], (string)result["position"], (int)result["salary"]));
                }

                return employees;
            }
        }

        public int getMaxSalary()
        {
            SqlCommand command = new SqlCommand("GetMaxSalary", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using (SqlDataReader result = command.ExecuteReader())
            {
                result.Read();

                int salary = (int)result["salary"];
                return salary;
            };

        }

        public int getAverageSalary()
        {
            SqlCommand command = new SqlCommand("GetAverageSalary", apiConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using (SqlDataReader result = command.ExecuteReader())
            {
                result.Read();

                int salary = (int)result["salary"];
                return salary;
            };

        }
    }
}
