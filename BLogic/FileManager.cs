using BetacomTeamStats_2025_10_08.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.BLogic
{
    internal class FileManager
    {
        public static List<Employees> ReadEmployeesFile()
        {
            List<Employees> listEmployees = [];
            string rowSeparator = new string('-', 100);

            string fileName = "Employees.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            Console.Clear();
            foreach (string line in employeeTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');

                if (fields.Length < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Riga Ignorata (campi: {fields.Length} / 10): {line}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                listEmployees.Add(new Employees
                {
                    Matricola = fields[0],
                    NomeCognome = fields[1],
                    Mansione = fields[2],
                    Reparto = fields[3],
                    Età = Convert.ToInt16(fields[4]),
                    Indirizzo = fields[5],
                    Città = fields[6],
                    Provincia = fields[7],
                    CAP = Convert.ToInt32(fields[8]),
                    Telefono = Convert.ToInt32(fields[9]),
                    Activities = new List<EmployeesActivities>(),
                });
            }

            foreach (var employee in listEmployees)
            {
                Console.WriteLine($"{employee.NomeCognome} n° {employee.Matricola} - " +
                    $"{employee.Mansione} presso {employee.Reparto} - " +
                    $"Anni: {employee.Età} - " +
                    $"Residente a {employee.Indirizzo}, {employee.Città} ({employee.Provincia}) {employee.CAP} - " +
                    $"Numero di telefono: {employee.Telefono}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(rowSeparator);
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();

            return listEmployees;
        }

        public static List<EmployeesActivities> ReadActivitiesFile()
        {
            List<EmployeesActivities> listEmployeesActivities = [];
            string rowSeparator = new string('-', 100);

            string fileName = "EmployeesActivities.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeActivitiesTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            Console.Clear();
            foreach (string line in employeeActivitiesTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');

                if (fields.Length < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Riga Ignorata (campi: {fields.Length} / 10): {line}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                listEmployeesActivities.Add(new EmployeesActivities
                {
                    Data = fields[0],
                    Luogo = fields[1],
                    OreLavorative = Convert.ToUInt16(fields[2]),
                    Matricola = fields[3]
                });
            }

            foreach (var employeeActivities in listEmployeesActivities)
            {
                Console.WriteLine($"Matricola: {employeeActivities.Matricola} ha lavorato {employeeActivities.OreLavorative} ore in data {employeeActivities.Data} presso {employeeActivities.Luogo}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(rowSeparator);
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();

            return listEmployeesActivities;
        }

        public static List<Employees> PrintBetween4050AgeEmployees()
        {
            List<Employees> listEmployees40_50 = [];
            string rowSeparator = new string('-', 100);

            string fileName = "Employees.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            Console.Clear();
            foreach (string line in employeeTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');

                if (fields.Length < 10)
                {

                    continue;
                }

                listEmployees40_50.Add(new Employees
                {
                    Matricola = fields[0],
                    NomeCognome = fields[1],
                    Mansione = fields[2],
                    Reparto = fields[3],
                    Età = Convert.ToInt16(fields[4]),
                    Indirizzo = fields[5],
                    Città = fields[6],
                    Provincia = fields[7],
                    CAP = Convert.ToInt32(fields[8]),
                    Telefono = Convert.ToInt32(fields[9]),
                    Activities = new List<EmployeesActivities>(),
                });
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lavoratori over 40 ed under 50 di Betacom Group");
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var employee in listEmployees40_50)
            {
                if (employee.Età >= 40 && employee.Età <= 50)
                {
                    Console.WriteLine($"{employee.NomeCognome} n° {employee.Matricola} - Anni: {employee.Età}");
                }
                else
                {
                    continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(rowSeparator);
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();

            return listEmployees40_50;
        }
    }
}