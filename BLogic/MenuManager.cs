using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.BLogic
{
    public class MenuManager
    {
        public static void MainMenu()
        {
            string rowSeparator = new string('-', 100);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========= Gestionale Lavoratori Betacom v2 =========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Mostra i lavoratori con età compresa tra i 40 e 50 anni");
            Console.WriteLine("2. Mostra i lavoratori che hanno fatto ferie");
            Console.WriteLine("3. Mostra i lavoratori che sono stati in ufficio");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9. Chiudere il programma");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;

            int scelta = Convert.ToInt16(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    FileManager.PrintBetween4050AgeEmployees();
                    break;
                case 2:
                    EmployeesFerie.PrintEmployeesFerie();
                    break;
                case 3:
                    EmployeesUfficio.PrintEmployeesUfficio();
                    break;
                case 4:
                    //FileManager.ReadActivitiesFile();
                    break;
                case 5:
                    //FindEmployee.FindEmployeebyId();
                    break;
                case 6:
                    //FindEmployee.FindEmployeebyId();
                    break;
                case 7:
                    //FindEmployee.FindEmployeebyId();
                    break;
                case 9:
                    Console.WriteLine("Adieau e buon caffè");
                    break;
                default:
                    Console.WriteLine("Non hai inserito un valore corretto");
                    MenuManager.MainMenu();
                    break;
            }
        }

    }
}
