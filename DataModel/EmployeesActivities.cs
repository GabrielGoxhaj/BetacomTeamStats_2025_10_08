using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomTeamStats_2025_10_08.DataModel
{
    internal class EmployeesActivities
    {
        public string Data { get; set; }
        public string Luogo { get; set; }
        public int OreLavorative { get; set; }
        [MinLength(4), MaxLength(4)]
        public string Matricola { get; set; }

    }
}
