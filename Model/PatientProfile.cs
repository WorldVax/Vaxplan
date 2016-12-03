using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Model
{
    public class PatientProfile
    {
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string MedHistoryCode { get; set; }
        public string MedHistoryCodeSys { get; set; }
        public string MedHistoryText { get; set; }
        public List<AdministeredDose> Series { get; set; }
    }

}
