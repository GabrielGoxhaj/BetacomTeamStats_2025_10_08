using BetacomTeamStats_2025_10_08.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.BLogic
{
    internal class EmployeesLazzaroni
    {
        public static List<Employees> PrintEmployeesLazzaroni()
        {
            List<Employees> listEmployees = [];
            List<EmployeesActivities> listEmployeesActivitiesLazzaroni = [];
            List<Employees> listEmployeesLazzaroni = [];

            string rowSeparator = new string('-', 100);

            string fileNameEmployees = "Employees.txt";
            string fileNameEmployeesActivities = "EmployeesActivities.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeTxt = File.ReadAllLines(Path.Combine(filePath, fileNameEmployees));
            string[] employeeActivitiesTxt = File.ReadAllLines(Path.Combine(filePath, fileNameEmployeesActivities));

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

            foreach (string line in employeeActivitiesTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                string[] fields = line.Split(';');
                if (fields.Length < 4)
                {
                    continue;
                }
                listEmployeesActivitiesLazzaroni.Add(new EmployeesActivities
                {
                    Data = fields[0],
                    Luogo = fields[1],
                    OreLavorative = Convert.ToInt16(fields[2]),
                    Matricola = fields[3],
                });
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lavoratori in ferie di Betacom Group");
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;

            List<string> listMatricoleLavoratrici = new();
            List<string> listLavoratoriLazzaroni = new();

            foreach (var employeeActivity in listEmployeesActivitiesLazzaroni)
            {
                listMatricoleLavoratrici.Add(employeeActivity.Matricola);
            }
            listMatricoleLavoratrici = listMatricoleLavoratrici.Distinct().ToList();

            foreach (var employee in listEmployees)
            {
                if (!listMatricoleLavoratrici.Contains(employee.Matricola))
                {
                    Console.WriteLine($"{employee.NomeCognome} n° {employee.Matricola} è un lazzarone nullafacente");
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(rowSeparator);
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();
            return listEmployeesLazzaroni;
        }
    }
}