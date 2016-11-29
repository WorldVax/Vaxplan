using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Date
{
   public static class DateTimeExtensions
    {
                public static DateTime Adjust(this DateTime dt, IEnumerable<IInterval> intervals)
        {
            var adjusted = dt;
            foreach(var interval in intervals.OrderBy(x => x.Unit))
            {
                adjusted = adjusted.Adjust(interval);
            }
            return adjusted;
        }

        public static DateTime Adjust(this DateTime dt, IInterval interval)
        {
            switch (interval.Unit)
            {
                case Intervals.Year:
                    return dt.AddYears(interval.Value);
                case Intervals.Month:
                    return dt.AddMonths(interval.Value);
                case Intervals.Week:
                    return dt.AddDays(7 * interval.Value);
                case Intervals.Day:
                    return dt.AddDays(interval.Value);
                default:
                    return dt;

            }
        }

        public static DateTime Zero(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }
    }    
}
