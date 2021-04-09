using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary
{
    public class Calendar : ICalendar
    {
        public TimeInterval working_hours { get; set; }
        public List<TimeInterval> planned_meetings { get; set; }

        public List<TimeInterval> Free_time(int min_free_minutes = 0)
        {
            List<TimeInterval> free_time = new();
            if (planned_meetings[0].start.Subtract(working_hours.start).TotalMinutes > min_free_minutes) //work time start  to first meeting
            {
                free_time.Add(new TimeInterval { start = working_hours.start, end = planned_meetings[0].start });
            }
            for (int i = 0; i < planned_meetings.Count - 1; i++) // end of meeting "i" to start of meeting "i+1"
            {
                if (planned_meetings[i + 1].start.Subtract(planned_meetings[i].end).TotalMinutes > min_free_minutes)
                {
                    free_time.Add(new TimeInterval { start = planned_meetings[i].end, end = planned_meetings[i + 1].start });
                }
            }
            if (working_hours.end.Subtract(planned_meetings[planned_meetings.Count - 1].end).TotalMinutes > min_free_minutes) // End of last meeting to end of work time
            {
                free_time.Add(new TimeInterval { start = planned_meetings[planned_meetings.Count - 1].end, end = working_hours.end });
            }
            return free_time;
        }
    }
}
