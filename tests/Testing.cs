using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CMAPI;

namespace CMAPI_Testing
{
    [TestClass]
    public class ApiTesting
    {
        public Company cmp;

        [TestInitialize]
        public void initialTestData()
        {
            // Nowy obiekt klasy Company
            cmp = new Company();

            // Usuwamy wszystkich pracowników
            cmp.removeAllEmployees();

            // Dodaję przykladowe dane do bazy                
            cmp.addEmployee("/", "Tomasz", "Gajda", "CEO", 12500);
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
        }

        [TestMethod]
        public void testAddEmployee()
        {
            // Sprawdzam ilosc pracownikow przed dodaniem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Dodaje pracownika
            cmp.addEmployee("/4/", "Krystian", "Testowy", "Kierownik rekrutacji", 11200);

            // Po dodaniu sprawdzam czy ilosc zwiekszyla sie o 1
            Assert.AreEqual(cmp.getAllEmployees().Count, 16);
        }

        [TestMethod]
        public void testRemoveEmployeeById()
        {
            // Sprawdzam ilosc pracownikow przed usunięciem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Usuwam pracownika
            cmp.removeEmployeeById(1);

            // Po usunieciu sprawdzam czy ilosc zmniejszyla sie o 1
            Assert.AreEqual(cmp.getAllEmployees().Count, 14);
        }

        [TestMethod]
        public void testRemoveEmployeeByFirstName()
        {
            // Sprawdzam ilosc pracownikow przed usunięciem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Usuwam pracownika
            cmp.removeEmployeeByFirstName("Tomasz");

            // Po usunieciu sprawdzam czy ilosc zmniejszyla sie o 1
            Assert.AreEqual(cmp.getAllEmployees().Count, 14);
        }

        [TestMethod]
        public void testRemoveEmployeeByLastName()
        {
            // Sprawdzam ilosc pracownikow przed usunięciem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Usuwam pracownika
            cmp.removeEmployeeByLastName("Gajda");

            // Po usunieciu sprawdzam czy ilosc zmniejszyla sie o 1
            Assert.AreEqual(cmp.getAllEmployees().Count, 14);
        }

        [TestMethod]
        public void testRemoveEmployeeByLevel()
        {
            // Sprawdzam ilosc pracownikow przed usunięciem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Usuwam pracownika
            cmp.removeEmployeeByLevel("/");

            // Po usunieciu sprawdzam czy ilosc zmniejszyla sie o 1
            Assert.AreEqual(cmp.getAllEmployees().Count, 14);
        }

        [TestMethod]
        public void testRemoveAllEmployees()
        {
            // Sprawdzam ilosc pracownikow przed usunięciem
            Assert.AreEqual(cmp.getAllEmployees().Count, 15);

            // Usuwam wszystkich pracowników
            cmp.removeAllEmployees();

            // Po usunieciu sprawdzam czy ilosc wynosi 0
            Assert.AreEqual(cmp.getAllEmployees().Count, 0);
        }

        [TestMethod]
        public void testGetEmployeeById()
        {
            // Pobieram pracownika z ID = 1
            Employee emp = cmp.getEmployeeById(1);

            // Sprawdzam czy jego dane się zgadzają
            Assert.AreEqual(emp.firstName, "Tomasz");
            Assert.AreEqual(emp.lastName, "Gajda");
            Assert.AreEqual(emp.position, "CEO");
            Assert.AreEqual(emp.level.ToString(), "/");
            Assert.AreEqual(emp.salary, 12500);
        }

        [TestMethod]
        public void testGetEmployeeByFirstName()
        {
            // Pobieram pracownika o imieniu Tomasz
            Employee emp = cmp.getEmployeeByFirstName("Tomasz");

            // Sprawdzam czy jego dane się zgadzają
            Assert.AreEqual(emp.firstName, "Tomasz");
            Assert.AreEqual(emp.lastName, "Gajda");
            Assert.AreEqual(emp.position, "CEO");
            Assert.AreEqual(emp.level.ToString(), "/");
            Assert.AreEqual(emp.salary, 12500);
        }

        [TestMethod]
        public void testGetEmployeeByLastName()
        {
            // Pobieram pracownika o nazwisku Gajda
            Employee emp = cmp.getEmployeeByLastName("Gajda");

            // Sprawdzam czy jego dane się zgadzają
            Assert.AreEqual(emp.firstName, "Tomasz");
            Assert.AreEqual(emp.lastName, "Gajda");
            Assert.AreEqual(emp.position, "CEO");
            Assert.AreEqual(emp.level.ToString(), "/");
            Assert.AreEqual(emp.salary, 12500);
        }

        [TestMethod]
        public void testGetEmployeeByLevel()
        {
            // Pobieram pracownika o poziomie "/"
            Employee emp = cmp.getEmployeeByLastName("/");

            // Sprawdzam czy jego dane się zgadzają
            Assert.AreEqual(emp.firstName, "Tomasz");
            Assert.AreEqual(emp.lastName, "Gajda");
            Assert.AreEqual(emp.position, "CEO");
            Assert.AreEqual(emp.level.ToString(), "/");
            Assert.AreEqual(emp.salary, 12500);
        }

        [TestMethod]
        public void testGetEmployeeWithSubordinates()
        {
            // Pobieram pracownika o poziomie "/" wraz z podwładnymi
            List<Employee> emps = cmp.getEmployeeWithSubordinates("/1/");

            // Sprawdzam czy ilość rekordów się zgadza
            Assert.AreEqual(emps.Count, 4);
        }

        [TestMethod]
        public void testGetAllEmployees()
        {
            // Pobieram wszystkich pracowników
            List<Employee> emps = cmp.getAllEmployees();

            // Sprawdzam czy ilość rekordów się zgadza
            Assert.AreEqual(emps.Count, 15);
        }

        [TestMethod]
        public void testGetMaxSalary()
        {
            // Pobieram najwyzsze wynagrodzenie
            int maxSalary = cmp.getMaxSalary();

            // Sprawdzam czy zgadza się z prawdą
            Assert.AreEqual(maxSalary, 12500);
        }

        [TestMethod]
        public void testGetAverageSalary()
        {
            // Pobieram średnie wynagrodzenie
            int avgSalary = cmp.getAverageSalary();

            // Sprawdzam czy zgadza się z prawdą
            Assert.AreEqual(avgSalary, 7766);
        }


        [TestCleanup]
        public void clearAfterTesting()
        {
            // Czyszczę bazę usuwając wszystkich pracowników
            cmp.removeAllEmployees();
        }
    }
}
