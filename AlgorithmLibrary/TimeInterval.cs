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
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TimeInterval other = obj as TimeInterval;
            if (start.Equals(other.start) && end.Equals(other.end)) return true;
            return false;
        }
    }
}
