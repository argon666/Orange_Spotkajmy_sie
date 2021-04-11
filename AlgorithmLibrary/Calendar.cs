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
        public List<TimeInterval> planned_meeting { get; set; } = new List<TimeInterval>();

        public List<TimeInterval> Free_time(int min_free_minutes = 1)
        {
            List<TimeInterval> free_time = new();
            if (working_hours==null)
            {
                return free_time;
            }
            if(planned_meeting.Count==0)
            {
                free_time.Add(new TimeInterval { start = working_hours.start, end = working_hours.end });
                return free_time;
            }
            //Sorting planned meetings by start time
            planned_meeting.Sort();
            //work time start  to first meeting
            if (planned_meeting[0].start.Subtract(working_hours.start).TotalMinutes >= min_free_minutes)
            {
                free_time.Add(new TimeInterval { start = working_hours.start, end = planned_meeting[0].start });
            }

            // end of meeting "i" to start of meeting "i+1"
            for (int i = 0; i < planned_meeting.Count - 1; i++)
            {
                if (planned_meeting[i + 1].start.Subtract(planned_meeting[i].end).TotalMinutes >= min_free_minutes)
                {
                    free_time.Add(new TimeInterval { start = planned_meeting[i].end, end = planned_meeting[i + 1].start });
                }
            }

            // End of last meeting to end of work time
            if (working_hours.end.Subtract(planned_meeting[planned_meeting.Count - 1].end).TotalMinutes >= min_free_minutes)
            {
                free_time.Add(new TimeInterval { start = planned_meeting[planned_meeting.Count - 1].end, end = working_hours.end });
            }
            return free_time;
        }
    }
}
