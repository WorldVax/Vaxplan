using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vaxplan.Date
{
    public enum Intervals { Year, Month, Week, Day };

    public class Interval : IInterval
    {
        public Intervals Unit { get; private set; }
        public int Value { get; private set; }

        public static IEnumerable<IInterval> Parse(string input)
        {
            var re = new Regex("[-+0-9]");
            var value = new StringBuilder();
            foreach (var token in input.Split(' '))
            {
               var current = token.TrimEnd('s');
                if (re.IsMatch(current))
                {
                    value.Append(current);
                }
                else
                {
                    int v = Convert.ToInt32(value.ToString());
                    Intervals i = (Intervals)Enum.Parse(typeof(Intervals), current, true);
                    yield return new Interval { Value = v, Unit = i };
                    value = new StringBuilder();
                }
            }
        }
    }
}
