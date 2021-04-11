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
            IMeetingDurationConverter meetingDurationConverter = new MeetingDurationConverter();
            
            Calendar calendar1 = loadCalendar.GetCalendar();
            Calendar calendar2 = loadCalendar.GetCalendar();
            int duration = meetingDurationConverter.DurationToInt();

            var AvaibleTimes = meetingPlaner.PlanMeeting(calendar1, calendar2, duration);
            Console.WriteLine("Avaible dates for meeting");
            Console.WriteLine(displayCalendar.PossibleMeetingsToString(AvaibleTimes));
            Console.ReadKey();

        }
    }
}
