namespace BookAMeeting.Domain.Factories
{
    using System.Collections.Generic;
    using Entities;

    public class NineToFourCalendarFactory : ICalendarFactory
    {
        public Calendar Create(string firstName)
        {
            return new Calendar
            {
                Person = new Person(firstName),
                MeetingSlots = new List<MeetingSlot>
                {
                    new MeetingSlot(9, false),
                    new MeetingSlot(10, false),
                    new MeetingSlot(11, false),
                    new MeetingSlot(12, false),
                    new MeetingSlot(13, false),
                    new MeetingSlot(14, false),
                    new MeetingSlot(15, false),
                    new MeetingSlot(16, false)
                }
            };
        }
    }
}
