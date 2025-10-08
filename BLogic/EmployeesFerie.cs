using BetacomTeamStats_2025_10_08.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.BLogic
{
    internal class EmployeesFerie
    {
        public static List<Employees> PrintEmployeesFerie()
        {
            List<Employees> listEmployeesFerie = [];
            List<EmployeesActivities> listEmployeesActivitiesFerie = [];

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

                listEmployeesFerie.Add(new Employees
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
                listEmployeesActivitiesFerie.Add(new EmployeesActivities
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

            foreach (var employeeActivity in listEmployeesActivitiesFerie)
            {
                if (employeeActivity.Luogo == "Ferie")
                {
                    foreach (var employee in listEmployeesFerie)
                    {
                        if (employeeActivity.Matricola == employee.Matricola)
                        {
                            Console.WriteLine($"Il dipendente {employee.NomeCognome} n° {employee.Matricola} ha fatto ferie in data {employeeActivity.Data}");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(rowSeparator);
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();

            return listEmployeesFerie;
        }
    }
}
