using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using CompanyApiSetup;

namespace ConsoleApp
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            CompanyApiImplementation api = new CompanyApiImplementation();

            int chosenCommand;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("======== Company API console application. ======\nAvailable commands:\n");
                Console.WriteLine(" 1. Add new employee");
                Console.WriteLine(" 2. Remove employee by ID");
                Console.WriteLine(" 3. Remove employee by first name");
                Console.WriteLine(" 4. Remove empployee by last name");
                Console.WriteLine(" 5. Remove employee by level");
                Console.WriteLine(" 6. Remove all employees");
                Console.WriteLine(" 7. Get employee by ID");
                Console.WriteLine(" 8. Get employee by level");
                Console.WriteLine(" 9. Get employee by first name");
                Console.WriteLine(" 10. Get employee by last name");
                Console.WriteLine(" 11. Get employee with subordinates (by level)");
                Console.WriteLine(" 12. Get all employees");
                Console.WriteLine(" 13. Get max salary");
                Console.WriteLine(" 14. Get average salary");
                Console.WriteLine(" 15. Add example data");

                Console.WriteLine("Choose command's number:");
                chosenCommand = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The command you have chosen: " + chosenCommand);

                switch (chosenCommand)
                {
                    case 1:
                        api.addEmployeeProcess();
                        break;
                    case 2:
                        api.removeEmployeeByIdProcess();
                        break;
                    case 3:
                        api.removeEmployeeByFirstNameProcess();
                        break;
                    case 4:
                        api.removeEmployeeByLastNameProcess();
                        break;
                    case 5:
                        api.removeEmployeeByLevelProcess();
                        break;
                    case 6:
                        api.removeAllEmployeesProcess();
                        break;
                    case 7:
                        api.getEmployeeByIdProcess();
                        break;
                    case 8:
                        api.getEmployeeByLevelProcess();
                        break;
                    case 9:
                        api.getEmployeeByFirstNameProcess();
                        break;
                    case 10:
                        api.getEmployeeByLastNameProcess();
                        break;
                    case 11:
                        api.getEmployeeWithSubordinatesProcess();
                        break;
                    case 12:
                        api.getAllEmployeesProcess();
                        break;
                    case 13:
                        api.getMaxSalaryProcess();
                        break;
                    case 14:
                        api.getAverageSalaryProcess();
                        break;
                    case 15:
                        api.addExampleData();
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
        }
    }
}
