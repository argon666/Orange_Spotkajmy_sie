using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public class MeetingPlanerV2 : IMeetingPlaner
    {
        public List<TimeInterval> PlanMetting(ICalendar calendar1, ICalendar calendar2, int minDuration)
        {
            int i = 0;
            List<TimeInterval> free_time1 = calendar1.Free_time(minDuration);
            List<TimeInterval> free_time2 = calendar2.Free_time(minDuration);
            List<TimeInterval> possibleMeetings = new();
            int n=0, m=0;
            while(n<free_time1.Count && m<free_time2.Count)
            {
                i++;
                var start = free_time1[n].start > free_time2[m].start ? free_time1[n].start : free_time2[m].start;
                var end = free_time1[n].end < free_time2[m].end ? free_time1[n].end : free_time2[m].end;
                var minutes = end.Subtract(start).TotalMinutes;
                if(minutes>=minDuration)
                {
                    possibleMeetings.Add(new TimeInterval { start = start, end = end });

                }
                if (free_time1[n].end == end)
                {
                    n++;
                }
                else
                {
                    m++;
                }
            }
            Console.WriteLine(i);
            return possibleMeetings;
        }
    }
}
