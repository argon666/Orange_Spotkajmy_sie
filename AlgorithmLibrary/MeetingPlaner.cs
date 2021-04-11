using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public class MeetingPlaner : IMeetingPlaner
    {
        public List<TimeInterval> PlanMeeting(ICalendar calendar1, ICalendar calendar2, int duration)
        {
            List<TimeInterval> possibleMettings = new List<TimeInterval>();
            if (calendar1 == null || calendar2 == null || duration < 1)
            {
                return possibleMettings;
            }
            List<TimeInterval> freeTime1 = calendar1.Free_time(duration);
            List<TimeInterval> freeTime2 = calendar2.Free_time(duration);
            foreach (var item1 in freeTime1)
            {
                foreach (var item2 in freeTime2)
                {
                    var posibleMetting = Overlapping(item1, item2, duration);
                    if (posibleMetting != null)
                    {
                        possibleMettings.Add(posibleMetting);
                    }
                }
            }
            return possibleMettings;

        }
        private TimeInterval Overlapping(TimeInterval t1, TimeInterval t2, int duration)
        {
            DateTime minStart, maxEnd;
            if (t1.start > t2.start)
            {
                minStart = t1.start;
            }
            else
            {
                minStart = t2.start;
            }
            if (t1.end > t2.end)
            {
                maxEnd = t2.end;
            }
            else
            {
                maxEnd = t1.end;
            }
            int min = (int)maxEnd.Subtract(minStart).TotalMinutes;
            if (min >= duration)
            {
                return new TimeInterval { start = minStart, end = maxEnd };
            }
            else
            {
                return null;
            }
        }
    }
}
