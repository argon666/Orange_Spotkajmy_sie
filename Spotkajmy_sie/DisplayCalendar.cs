using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLibrary;
namespace Spotkajmy_sie
{
    public class DisplayCalendar : IDisplayCalendar
    {
        public string PossibleMeetingsToString(List<TimeInterval> possiblemeetings)
        {
            string text = "[";
            for (int i = 0; i < possiblemeetings.Count - 1; i++)
            {
                text += possiblemeetings[i].ToString() + ", ";
            }
            text += possiblemeetings[possiblemeetings.Count - 1].ToString() + "]";
            return text;
        }
    }
}
