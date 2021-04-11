using System.Collections.Generic;

namespace AlgorithmLibrary
{
    public interface IMeetingPlanner
    {
        List<TimeInterval> PlanMeeting(ICalendar calendar1, ICalendar calendar2, int minDuration);
    }
}