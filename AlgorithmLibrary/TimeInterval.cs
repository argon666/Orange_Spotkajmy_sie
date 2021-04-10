using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    
    public class TimeInterval : IComparable<TimeInterval>
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public override string ToString()
        {
            return "[\"" + start.ToString("HH:mm") + "\",\"" + end.ToString("HH:mm") + "\"]";
        }
        public int Interval_in_minutes()
        {
            return (int)end.Subtract(start).TotalMinutes;
        }
        public int CompareTo(TimeInterval other)
        {
            return (int)start.Subtract(other.start).TotalMinutes;

        }
    }
}
