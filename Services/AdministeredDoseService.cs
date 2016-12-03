using System;
using System.Collections.Generic;
using System.Linq;
using Vaxplan.Model;

namespace Vaxplan.Services
{
    public class AdministeredDoseService
    {
        public static IEnumerable<AdministeredAntigen> Prepare(IEnumerable<AdministeredDose> administered)
        {
            return from dose in administered
                   let antigens = Refdata.CvxToAntigen(dose.Cvx)
                   from antigen in antigens
                   select new AdministeredAntigen
                   {
                       AdministeredDate = dose.DateAdministered,
                       Antigen = antigen,
                       Cvx = dose.Cvx,
                       Mvx = dose.Mvx
                   };
        }
    }
}
