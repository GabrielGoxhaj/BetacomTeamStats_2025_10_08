using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.DataModel
{
    internal class Employees
    {
        [Key]
        [MinLength(4), MaxLength(4)]
        public string Matricola { get; set; }
        public string NomeCognome { get; set; }
        public string Mansione { get; set; }
        public string Reparto { get; set; }
        public int Età { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string Provincia { get; set; }
        public int CAP { get; set; }
        public int Telefono { get; set; }
        public List<EmployeesActivities> Activities { get; set; } = [];
        internal static void Add(Employees employee)
        {
            throw new NotImplementedException();
        }
    }
}
