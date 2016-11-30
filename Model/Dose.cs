using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Model
{
    public class Dose
    {
        public string Cvx { get; set; }
        public DateTime DateAdministered { get; set; }
        public string EvaluationReason { get; set; }
        public string EvaluationStatus { get; set; }
        public string Mvx { get; set; }
        public string VaccineName { get; set; }
    }
}
