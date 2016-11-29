using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaxplan;
using Vaxplan.SupportingData;
using Vaxplan.Testcases;

namespace DoseHistory
{
    public class AdministeredAntigenFactory
    {
        public IEnumerable<AdministeredAntigen> Prepare(IEnumerable<SeriesDataContract> administered)
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
