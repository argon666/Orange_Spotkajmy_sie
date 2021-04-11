using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Tests
{
    [TestClass()]
    public class IMeetingPlannerTests
    {
        private readonly IMeetingPlanner meetingPlanner = new MeetingPlannerV2();
        [TestMethod()]
        public void PlanMeeting_WhenBothCalendarsAreNull_ReturnsEmptyList()
        {
            Calendar calendar1 = null;
            Calendar calendar2 = null;
            IMeetingPlanner plan = new MeetingPlannerV2();
            var result = plan.PlanMeeting(calendar1, calendar2, 1);
            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod()]
        public void PlanMeeting_WhenDurationIsLessThan1_ReturnsEmptyList()
        {
            Calendar calendar1 = new Calendar();
            calendar1.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            Calendar calendar2 = new Calendar();
            calendar2.working_hours = new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("18:30") };
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("11:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:30"), end = DateTime.Parse("14:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("14:30"), end = DateTime.Parse("15:00") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("17:00") });

            var result = meetingPlanner.PlanMeeting(calendar1, calendar2, 0);
            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod()]
        public void PlanMeeting_WhenCantFindAnswer_ReturnsEmptyList()
        {
            Calendar calendar1 = new Calendar();
            calendar1.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            Calendar calendar2 = new Calendar();
            calendar2.working_hours = new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("18:30") };
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("11:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:30"), end = DateTime.Parse("14:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("14:30"), end = DateTime.Parse("15:00") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("17:00") });

            var result = meetingPlanner.PlanMeeting(calendar1, calendar2, 300);
            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod()]
        public void PlanMeeting_ValidData_ReturnsPossibleMeetings()
        {
            Calendar calendar1 = new Calendar();
            calendar1.working_hours = new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("19:55") };
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("09:00"), end = DateTime.Parse("10:30") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:00"), end = DateTime.Parse("13:00") });
            calendar1.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("18:00") });

            Calendar calendar2 = new Calendar();
            calendar2.working_hours = new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("18:30") };
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("10:00"), end = DateTime.Parse("11:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("12:30"), end = DateTime.Parse("14:30") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("14:30"), end = DateTime.Parse("15:00") });
            calendar2.planned_meeting.Add(new TimeInterval { start = DateTime.Parse("16:00"), end = DateTime.Parse("17:00") });

            List<TimeInterval> expected = new List<TimeInterval>();
            expected.Add(new TimeInterval { start = DateTime.Parse("11:30"), end = DateTime.Parse("12:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("15:00"), end = DateTime.Parse("16:00") });
            expected.Add(new TimeInterval { start = DateTime.Parse("18:00"), end = DateTime.Parse("18:30") });

            List<TimeInterval> result = meetingPlanner.PlanMeeting(calendar1, calendar2, 30);
            CollectionAssert.AreEqual(result, expected);
        }
    }
}