using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public class TimeInterval
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public override string ToString()
        {
            return start.Hour + ":" + start.Minute + " " + end.Hour + ":" + (end.Minute);
        }
        public int Interval_in_minutes()
        {
            return (int)end.Subtract(start).TotalMinutes;
        }
    }
}
