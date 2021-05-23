using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using CompanyApiSetup;

namespace CMAPI
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
                Console.WriteLine("======== Konsolowa aplikacja testująca CMAPI ======\nDostępne komendy:\n");
                Console.WriteLine(" 1. Dodaj nowego pracownika");
                Console.WriteLine(" 2. Usuń pracownika po ID");
                Console.WriteLine(" 3. Usuń pracownika po imieniu");
                Console.WriteLine(" 4. Usuń pracownika po nazwisku");
                Console.WriteLine(" 5. Usuń pracownika po hierarchii");
                Console.WriteLine(" 6. Usuń wszystkich pracowników");
                Console.WriteLine(" 7. Zwróć pracownika po ID");
                Console.WriteLine(" 8. Zwróć pracownika po hierarchii");
                Console.WriteLine(" 9. Zwróć pracownika po imieniu");
                Console.WriteLine(" 10. Zwróć pracownika po nazwisku");
                Console.WriteLine(" 11. Zwróć pracownika z podwładnymi (po hierarchii)");
                Console.WriteLine(" 12. Zwróć wszystkich pracowników");
                Console.WriteLine(" 13. Zwróć największą wypłatę");
                Console.WriteLine(" 14. Zwróć średnią wypłatę");
                Console.WriteLine(" 15. Dodaj przykładowe dane");
                Console.WriteLine(" 16. Zakończ działanie aplikacji \n");

                Console.WriteLine("Wybierz numer komendy:");
                chosenCommand = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nNumer wybranej komendy: " + chosenCommand);

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
                    case 16:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("Naciśnij E by zakończyć, lub inny klawisz by zrestartować...");
                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
