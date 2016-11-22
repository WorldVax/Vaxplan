using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaxplan.Refdata;
using Vaxplan.Testcases;

namespace DoseHistory
{
    public class AdministeredAntigenFactory
    {
        public IEnumerable<AdministeredAntigen> Prepare(IEnumerable<SeriesDataContract> administered)
        {
            foreach(var d in administered)
            {
                var antigens = SupportingData.GetSupportingData().cvxToAntigenMap.
                // todo get the antigens in the dose
                // for each antigen create an administered antigen
                var a = new AdministeredAntigen();
                yield return a;
            }
        }
    }
}
I