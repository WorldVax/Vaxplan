using System;
using System.Collections.Generic;
using Vaxplan.Model;
using Vaxplan.Testcases;

namespace Vaxplan.Services
{
    public class AdministeredAntigenFactory
    {
        public static IEnumerable<AdministeredAntigen> Prepare(IEnumerable<AdministeredDose> administered)
        {
            foreach (var dose in administered)
            {
                var antigens = Refdata.CvxToAntigen(dose.Cvx);
                foreach (var antigen in antigens)
                {
                    yield return new AdministeredAntigen
                    {
                        AdministeredDate = DateTime.Parse(dose.DateAdministered),
                        Antigen = antigen,
                        Cvx = dose.Cvx,
                        Mvx = dose.Mvx
                    };
                }
            }
        }
    }
}
