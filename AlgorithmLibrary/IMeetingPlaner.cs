using System.Collections.Generic;

namespace AlgorithmLibrary
{
    public interface IMeetingPlaner
    {
        List<TimeInterval> PlanMetting(ICalendar calendar1, ICalendar calendar2, int minDuration);
    }
}