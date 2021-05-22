using System;
using System.Collections.Generic;
using System.Text;
using CompanyApi;

namespace CompanyApiSetup
{
    class CompanyApiImplementation
    {
        private Company company;

        public CompanyApiImplementation()
        {
            company = new Company();
        }

        public void addExampleData()
        {

        }

        public void addEmployeeProcess()
        {
            string level;
            string firstName;
            string lastName;
            string position;
            int salary;

            Console.WriteLine("Provide the level of the employee:");
            level = Console.ReadLine();

            Console.WriteLine("Provide the first name of the employee:");
            firstName = Console.ReadLine();

            Console.WriteLine("Provide the last name of the employee:");
            lastName = Console.ReadLine();

            Console.WriteLine("Provide the name of the position of the employee:");
            position = Console.ReadLine();

            Console.WriteLine("Provide the amount of renumeration of the employee:");
            salary = Convert.ToInt32(Console.ReadLine());

            company.addEmployee(level, firstName, lastName, position, salary);
        }

        public void removeEmployeeByIdProcess()
        {
            int id;

            Console.WriteLine("Provide the id of the employee:");
            id = Convert.ToInt32(Console.ReadLine());

            company.removeEmployeeById(id);
        }

        public void removeEmployeeByFirstNameProcess()
        {
            string firstName;

            Console.Write("Provide the first name of the employee:");
            firstName = Console.ReadLine();

            company.removeEmployeeByFirstName(firstName);
        }

        public void removeEmployeeByLastNameProcess()
        {
            string lastName;

            Console.Write("Provide the last name of the employee:");
            lastName = Console.ReadLine();

            company.removeEmployeeByLastName(lastName);
        }

        public void removeEmployeeByLevelProcess()
        {
            string level;

            Console.Write("Provide the level of the employee:");
            level = Console.ReadLine();

            company.removeEmployeeByLevel(level);
        }

        public void removeAllEmployeesProcess()
        {
            company.removeAllEmployees();
        }

        public void getEmployeeByIdProcess()
        {
            int id;

            Console.WriteLine("Provide the id of the employee:");
            id = Convert.ToInt32(Console.ReadLine());

            company.getEmployeeById(id).print();
        }

        public void getEmployeeByLevelProcess()
        {
            string level;

            Console.Write("Provide the level of the employee:");
            level = Console.ReadLine();

            company.getEmployeeByLevel(level).print();
        }

        public void getEmployeeByFirstNameProcess()
        {
            string firstName;

            Console.Write("Provide the first name of the employee:");
            firstName = Console.ReadLine();

            company.getEmployeeByFirstName(firstName).print();
        }

        public void getEmployeeByLastNameProcess()
        {
            string lastName;

            Console.Write("Provide the last name of the employee:");
            lastName = Console.ReadLine();

            company.getEmployeeByLastName(lastName).print();
        }

        public void getEmployeeWithSubordinatesProcess()
        {
            string level;

            Console.Write("Provide the level of the parent employee:");
            level = Console.ReadLine();

            company.getEmployeeWithSubordinates(level).ForEach(emp => emp.print());
        }

        public void getAllEmployeesProcess()
        {
            company.getAllEmployees().ForEach(emp => emp.print());
        }

        public void getMaxSalaryProcess()
        {
            Console.WriteLine(company.getMaxSalary());
        }

        public void getAverageSalaryProcess()
        {
            Console.WriteLine(company.getAverageSalary());
        }
    }
}
