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
    }


}