using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Date
{
    public interface IInterval
    {
        Intervals Unit { get; }
        int Value { get; }
    }
}
