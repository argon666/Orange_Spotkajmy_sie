using AlgorithmLibrary;
using System.Collections.Generic;

namespace Spotkajmy_sie
{
    public interface IDisplayCalendar
    {
        string PossibleMeetingsToString(List<TimeInterval> possiblemeetings);
    }
}