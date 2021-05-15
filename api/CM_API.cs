using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace companyApi{
    // Klasa Employee
    internal class Employee{
        public int id;
        public SqlHierarchyId level;
        public string firstName;
        public string lastName;
        public string position;
        public int salary;
        // Konstruktor klasy Employee
        public Employee(int id, SqlHierarchyId level, string firstName, string lastName, string position, int salary){
            this.id = id;
            this.level = level;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.salary = salary;
        }

        public void print(){
            Console.WriteLine($"#{id}: {level} - {firstName} {lastName} - {position} - {salary}");
        }

        // Klasa opisująca firmę - zawierająca metody z API
        internal class Company {
            public SqlConnection apiConnection = null;

            public Company(){
                string connection = @"Data Source=XXX; Initial Catalog=XXX; User ID=XXX; Password=XXX";

                apiConnection = new SqlConnection(connection);
                apiConnection.Open();
            }   

            public void addEmployee(int id, string level, string firstName, string lastName, string position, int salary){
                SqlCommand addCommand = new SqlCommand("AddEmployee", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };

                addCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                addCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;
                addCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
                addCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                addCommand.Parameters.Add("@position", SqlDbType.VarChar).Value = position;
                addCommand.Parameters.Add("@salary", SqlDbType.Int).Value = salary;

                addCommand.ExecuteNonQuery();
            }

            public void removeEmployeeById(int id){
                SqlCommand removeCommand = new SqlCommand("RemoveEmployeeById", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };
                
                removeCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                removeCommand.ExecuteNonQuery();
            }

            public void removeEmployeeByFirstName(string firstName){
                SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByFirstName", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };
                
                removeCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;

                removeCommand.ExecuteNonQuery();
            }

            public void removeEmployeeByLastName(string lastName){
                SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByLastName", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };
                
                removeCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;

                removeCommand.ExecuteNonQuery();
            }

            public void removeEmployeeByLevel(string level){
                SqlCommand removeCommand = new SqlCommand("RemoveEmployeeByLevel", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };
                
                removeCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level;

                removeCommand.ExecuteNonQuery();
            }

            public void removeAllEmployees(){
                SqlCommand removeCommand = new SqlCommand("RemoveAllEmployees", apiConnection){
                    CommandType = CommandType.StoredProcedure
                };
                
                removeCommand.ExecuteNonQuery();
            }
        }
    }


}