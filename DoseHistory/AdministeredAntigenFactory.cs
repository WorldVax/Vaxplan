﻿using System.Collections.Generic;
using Vaxplan.Model;

namespace Vaxplan.DoseHistory
{
    public class AdministeredAntigenFactory
    {
        public static IEnumerable<AdministeredAntigen> Prepare(IEnumerable<Series> administered)
        {
            foreach (var d in administered)
            {
                var antigens = Refdata.CvxToAntigen(d.Cvx);
                foreach (var a in antigens)
                {
                    yield return new AdministeredAntigen
                    {
                        AdministeredDate = d.DateAdministered,
                        Antigen = a
                    };
                }
            }
        }
    }
}
