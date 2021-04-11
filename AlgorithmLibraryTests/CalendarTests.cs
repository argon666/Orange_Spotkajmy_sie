using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibraryTests
{
    [TestClass()]
    public class CalendarTests
    {
        [TestMethod()]
        public void Free_time_correct()
        {
            Calendar calendar = new Calendar();
            calendar.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            List<TimeInterval> result = calendar.Free_time();

            List<TimeInterval> expected = new List<TimeInterval>();
            expected.Add(new TimeInterval { start = DateTime.Parse("10:30"), end = DateTime.Parse("12:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("13:00"), end = DateTime.Parse("16:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("18:00"), end = DateTime.Parse("19:55") });

            CollectionAssert.AreEqual(result, expected);

            calendar.working_hours = new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("18:30") };
            calendar.planned_meeting.Clear();
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("11:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:30"), end = DateTime.Parse("14:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("14:30"), end = DateTime.Parse("15:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("17:00") });

            expected.Clear();
            expected.Add(new TimeInterval { start = DateTime.Parse("11:30"), end = DateTime.Parse("12:30") });
            expected.Add(new TimeInterval { start = DateTime.Parse("15:00"), end = DateTime.Parse("16:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("17:00"), end = DateTime.Parse("18:30") });

            result = calendar.Free_time();
            CollectionAssert.AreEqual(result, expected);

            expected.Clear();

            expected.Add(new TimeInterval { start = DateTime.Parse("17:00"), end = DateTime.Parse("18:30") });

            result = calendar.Free_time(90);

            CollectionAssert.AreEqual(result, expected);


            calendar = new Calendar();
            calendar.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("10:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            result = calendar.Free_time();

            expected.Clear();
            expected.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("10:30"), end = DateTime.Parse("12:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("13:00"), end = DateTime.Parse("16:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("18:00"), end = DateTime.Parse("19:55") });
            CollectionAssert.AreEqual(result, expected);
        }
        [TestMethod()]
        public void Free_time_no_free_time_retun_empty_list()
        {

            Calendar calendar = new Calendar();
            calendar.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:30"), end = DateTime.Parse("13:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("13:00"), end = DateTime.Parse("19:55") });

            List<TimeInterval> result = calendar.Free_time();

            Assert.AreEqual(result.Count, 0);

            calendar = new Calendar();
            calendar.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            result = calendar.Free_time(240);

            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod()]
        public void Free_time_empty_working_hours_return_empty_list()
        {
            Calendar calendar = new Calendar();
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:30"), end = DateTime.Parse("13:00") });
            calendar.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("13:00"), end = DateTime.Parse("19:55") });

            var result = calendar.Free_time(30);

            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod()]
        public void Free_time_empty_meetings()
        {

            Calendar calendar = new Calendar();
            calendar.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            var result = calendar.Free_time(30);
            List<TimeInterval> expected = new List<TimeInterval>();
            expected.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") });
            CollectionAssert.AreEqual(result, expected);
        }
    }
}
