using BetacomTeamStats_2025_10_08.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.BLogic
{
    internal class EmployeesGroupByAge_Range10
    {
        public static List<Employees> PrintEmployeesByGroupOfAge()
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

            List<Employees> listEmployeesAged20_29 = [];
            List<Employees> listEmployeesAged30_39 = [];
            List<Employees> listEmployeesAged40_49 = [];
            List<Employees> listEmployeesAged50_59 = [];
            List<Employees> listEmployeesAged60_69 = [];
            List<Employees> listEmployeesAged70_79 = [];

            foreach (var employee in listEmployees)
            {
                if (employee.Età >= 20 && employee.Età <= 29)
                {
                    listEmployeesAged20_29.Add(employee);
                }
                else if (employee.Età >= 30 && employee.Età <= 39)
                {
                    listEmployeesAged30_39.Add(employee);
                    listEmployeesAged30_39 = listEmployeesAged30_39.OrderBy(e => employee.Età).ToList();
                }
                else if (employee.Età >= 40 && employee.Età <= 49)
                {
                    listEmployeesAged40_49.Add(employee);
                    listEmployeesAged40_49 = listEmployeesAged40_49.OrderBy(e => employee.Età).ToList();
                }
                else if (employee.Età >= 50 && employee.Età <= 59)
                {
                    listEmployeesAged50_59.Add(employee);
                    listEmployeesAged50_59 = listEmployeesAged50_59.OrderBy(e => employee.Età).ToList();
                }
                else if (employee.Età >= 60 && employee.Età <= 69)
                {
                    listEmployeesAged60_69.Add(employee);
                    listEmployeesAged60_69 = listEmployeesAged60_69.OrderBy(e => employee.Età).ToList();
                }
                else if (employee.Età >= 70 && employee.Età <= 79)
                {
                    listEmployeesAged70_79.Add(employee);
                    listEmployeesAged70_79 = listEmployeesAged70_79.OrderBy(e => employee.Età).ToList();
                }
            }

            Console.WriteLine("Lavoratori Betacom divisi per fasce di età");

            if (listEmployeesAged20_29.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 20 e i 29 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged20_29.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (listEmployeesAged30_39.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 30 e i 39 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged30_39.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (listEmployeesAged40_49.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 40 e i 49 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged40_49.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (listEmployeesAged50_59.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 50 e i 59 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged50_59.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (listEmployeesAged60_69.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 60 e i 69 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged60_69.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (listEmployeesAged70_79.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lavoratori con età tra i 70 e i 79 anni");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var employee in listEmployeesAged70_79.OrderBy(e => e.Età))
                    Console.WriteLine($"{employee.NomeCognome} - Età {employee.Età}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Loading.LoadingMenu();

            return listEmployees;
        }


    }

}
