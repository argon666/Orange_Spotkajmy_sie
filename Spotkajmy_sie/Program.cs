using System;
using System.Collections.Generic;
using System.Text.Json;
using AlgorithmLibrary;
using Newtonsoft.Json;

namespace Spotkajmy_sie
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoadCalendar loadCalendar = new LoadCalendar();
            IMeetingPlaner meetingPlaner = new MeetingPlanerV2();
            IDisplayCalendar displayCalendar = new DisplayCalendar();
            Calendar calendar1=loadCalendar.GetCalendar();
            Calendar calendar2 = loadCalendar.GetCalendar();
            var AvaibleTimes = meetingPlaner.PlanMetting(calendar1, calendar2, 30);
            Console.WriteLine(displayCalendar.PossibleMeetingsToString(AvaibleTimes));

  
            Console.ReadKey();
        }
    }
}
