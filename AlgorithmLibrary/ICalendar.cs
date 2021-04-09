using System.Collections.Generic;

namespace AlgorithmLibrary
{
    public interface ICalendar
    {
        List<TimeInterval> Free_time(int min_free_minutes = 0);
    }
}