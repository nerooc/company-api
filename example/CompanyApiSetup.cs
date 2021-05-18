using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApi{
    class CompanyApiImplementation{
        private Company company;
       
        public CompanyApiImplementation(){
            company = new Company();
        }

        public void addEmployeeProcess(){
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
            Salary = Convert.ToInt32(Console.ReadLine());

            company.AddEmployee(level, firstName, lastName, position, salary);
        }

        public void removeEmployeeByIdProcess(){
            int id;
            
            Console.WriteLine("Provide the id of the employee:");
            id = Console.ReadLine();

            company.removeEmployeeById(id);
        }

        public void removeEmployeeByFirstNameProcess(){
            string firstName;

            Console.Write("Provide the first name of the employee:");
            firstName = Console.ReadLine();

            company.removeEmployeeByFirstName(firstName);
        }

        public void removeEmployeeByLastNameProcess(){
            string lastName;

            Console.Write("Provide the last name of the employee:");
            lastName = Console.ReadLine();

            company.removeEmployeeByLastName(lastName);
        }

        public void removeEmployeeByLevelProcess(){
            string level;

            Console.Write("Provide the level of the employee:");
            level = Console.ReadLine();

            company.removeEmployeeByLevel(level);
        }

        public void removeAllEmployeesProcess(){
            company.removeAllEmployees();
        }

        public void getEmployeeByIdProcess(){
            int id;
            
            Console.WriteLine("Provide the id of the employee:");
            id = Console.ReadLine();

            company.getEmployeeById(id).Print();
        }

        public void getEmployeeByLevelProcess(){
            string level;

            Console.Write("Provide the level of the employee:");
            level = Console.ReadLine();

            company.getEmployeeByLevel(level).Print();
        }

        public void getEmployeeByFirstNameProcess(){
            string firstName;

            Console.Write("Provide the first name of the employee:");
            firstName = Console.ReadLine();

            company.getEmployeeByFirstName(firstName).Print();
        }

        public void getEmployeeByLastNameProcess(){
            string lastName;

            Console.Write("Provide the last name of the employee:");
            lastName = Console.ReadLine();

            company.getEmployeeByLastName(lastName).Print();
        }

        public void getEmployeeWithSubordinatesProcess(){
            string level;

            Console.Write("Provide the level of the parent employee:");
            level = Console.ReadLine();

            company.getEmployeeWithSubordinates(level).Print();
        }

        public void getAllEmployeesProcess(){
            company.getAllEmployees().ForEach(emp => emp.Print());
        }
        
        public void getMaxSalaryProcess(){
            company.getMaxSalary().Print();
        }

        public void getAverageSalaryProcess(){
            company.getAverageSalary().Print();
        }

    }
}
