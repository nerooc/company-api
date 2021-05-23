using System;
using System.Collections.Generic;
using System.Text;
using CompanyApi;

namespace CMAPI
{
    class CompanyApiImplementation
    {
        private Company cmp;

        public CompanyApiImplementation()
        {
            cmp = new Company();
        }

        public void addExampleData()
        {
            try
            {
                cmp.addEmployee("/", "Janusz", "Kielecki", "CEO", 12500);
                cmp.addEmployee("/1/", "Krystyna", "Baranowska", "Kierownik marketingu", 11600);
                cmp.addEmployee("/2/", "Kamil", "Jasiński", "Kierownik designu", 12300);
                cmp.addEmployee("/3/", "Olaf", "Lewandowski", "Kierownik deweloperów", 11800);
                cmp.addEmployee("/1/1/", "Aureliusz", "Kaźmierczak", "Analista marketingowy", 6300);
                cmp.addEmployee("/1/2/", "Cyprian", "Jasiński", "Konsultant marketingowy", 5900);
                cmp.addEmployee("/1/3/", "Joanna", "Dąbrowska", "Koordynator marketingowy", 6500);
                cmp.addEmployee("/2/1/", "Jakub", "Kowalczyk", "Projektant UX", 7300);
                cmp.addEmployee("/2/2/", "Cezary", "Chmielewski", "Projektant UI", 5600);
                cmp.addEmployee("/2/3/", "Mateusz", "Wiśniewski", "Projektant graficzny", 6000);
                cmp.addEmployee("/2/3/1/", "Agnieszka", "Zakrzewska", "Projektant stazysta", 3300);
                cmp.addEmployee("/3/1/", "Leszek", "Ostrowski", "Frontend deweloper", 7500);
                cmp.addEmployee("/3/2/", "Remigiusz", "Malinowski", "Backend deweloper", 7900);
                cmp.addEmployee("/3/3/", "Adrianna", "Pawlak", "Fullstack deweloper", 8500);
                cmp.addEmployee("/3/3/1/", "Kamil", "Zakrzewski", "Deweloper stazysta", 3500);
                Console.WriteLine("\nPrzykladowe dane zostaly dodane!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Dodanie przykladowych danych wywoluje blad! \nNajpierw usun wszystkich pracownikow!");
            }
        }

        public void addEmployeeProcess()
        {
            string level;
            string firstName;
            string lastName;
            string position;
            int salary;

            Console.WriteLine("Podaj poziom pracownika (np. '/', '/1/' itp.):");
            level = Console.ReadLine();

            Console.WriteLine("Podaj imie pracownika:");
            firstName = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko pracownika:");
            lastName = Console.ReadLine();

            Console.WriteLine("Podaj nazwe stanowiska pracownika:");
            position = Console.ReadLine();

            Console.WriteLine("Podaj wielkosc wyplaty pracownika:");
            salary = Convert.ToInt32(Console.ReadLine());

            cmp.addEmployee(level, firstName, lastName, position, salary);
        }

        public void removeEmployeeByIdProcess()
        {
            int id;

            Console.WriteLine("Podaj ID pracownika:");
            id = Convert.ToInt32(Console.ReadLine());

            try
            {
                cmp.removeEmployeeById(id);
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void removeEmployeeByFirstNameProcess()
        {
            string firstName;

            Console.Write("Podaj imie pracownika:");
            firstName = Console.ReadLine();

            try
            {
                cmp.removeEmployeeByFirstName(firstName);
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void removeEmployeeByLastNameProcess()
        {
            string lastName;

            Console.Write("Podaj nazwisko pracownika:");
            lastName = Console.ReadLine();

            try
            {
                cmp.removeEmployeeByLastName(lastName);
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void removeEmployeeByLevelProcess()
        {
            string level;

            Console.Write("Podaj poziom pracownika:");
            level = Console.ReadLine();

            try
            {
                cmp.removeEmployeeByLevel(level);
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void removeAllEmployeesProcess()
        {
            cmp.removeAllEmployees();
        }

        public void getEmployeeByIdProcess()
        {
            int id;

            Console.WriteLine("Podaj ID pracownika:");
            id = Convert.ToInt32(Console.ReadLine());

            try
            {
                cmp.getEmployeeById(id).print();
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void getEmployeeByLevelProcess()
        {
            string level;

            Console.Write("Podaj poziom pracownika:");
            level = Console.ReadLine();

            try
            {
                cmp.getEmployeeByLevel(level).print();
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void getEmployeeByFirstNameProcess()
        {
            string firstName;

            Console.Write("Podaj imie pracownika:");
            firstName = Console.ReadLine();

            try
            {
                cmp.getEmployeeByFirstName(firstName).print();
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void getEmployeeByLastNameProcess()
        {
            string lastName;

            Console.Write("Podaj nazwisko pracownika:");
            lastName = Console.ReadLine();

            try
            {
                cmp.getEmployeeByLastName(lastName).print();
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void getEmployeeWithSubordinatesProcess()
        {
            string level;

            Console.Write("Podaj poziom pracownika-zwierzchnika:");
            level = Console.ReadLine();

            try
            {
                cmp.getEmployeeWithSubordinates(level).ForEach(emp => emp.print());
            }
            catch (Exception e)
            {
                Console.Write("Brak pracownikow pasujacych do zapytania!");
            }
        }

        public void getAllEmployeesProcess()
        {
            if (cmp.getAllEmployees() == null || cmp.getAllEmployees().Count == 0)
            {
                cmp.getAllEmployees().ForEach(emp => emp.print());
            }
            else
            {
                Console.Write("Nie znaleziono pracowników!\n");
            }
        }

        public void getMaxSalaryProcess()
        {
            Console.WriteLine(cmp.getMaxSalary());
        }

        public void getAverageSalaryProcess()
        {
            Console.WriteLine(cmp.getAverageSalary());
        }
    }
}
