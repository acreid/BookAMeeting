namespace BookAMeeting.Domain.Repositories
{
    using System.Collections.Generic;
    using Entities;
    using Factories;

    public class CalendarsRepository : ICalendarsRepository
    {
        private readonly ICalendarFactory _calendarFactory;
        private IList<Calendar> _calendars = new List<Calendar>();

        public CalendarsRepository(ICalendarFactory calendarFactory)
        {
            _calendarFactory = calendarFactory;

            Seed();
        }

        public IList<Calendar> Get()
        {
            return _calendars;
        }

        private void Seed()
        {
            var adamCalendar = _calendarFactory.Create("Adam");

            adamCalendar.MeetingSlots[0].UnBook();
            adamCalendar.MeetingSlots[1].UnBook();
            adamCalendar.MeetingSlots[2].UnBook();
            adamCalendar.MeetingSlots[3].Book();
            adamCalendar.MeetingSlots[4].Book();
            adamCalendar.MeetingSlots[5].UnBook();
            adamCalendar.MeetingSlots[6].UnBook();
            adamCalendar.MeetingSlots[7].UnBook();


            var blairCalendar = _calendarFactory.Create("Blair");

            blairCalendar.MeetingSlots[0].Book();
            blairCalendar.MeetingSlots[1].Book();
            blairCalendar.MeetingSlots[2].Book();
            blairCalendar.MeetingSlots[3].Book();
            blairCalendar.MeetingSlots[4].Book();
            blairCalendar.MeetingSlots[5].Book();
            blairCalendar.MeetingSlots[6].Book();
            blairCalendar.MeetingSlots[7].Book();

            var chrisCalendar = _calendarFactory.Create("Chris");

            chrisCalendar.MeetingSlots[0].UnBook();
            chrisCalendar.MeetingSlots[1].Book();
            chrisCalendar.MeetingSlots[2].UnBook();
            chrisCalendar.MeetingSlots[3].UnBook();
            chrisCalendar.MeetingSlots[4].UnBook();
            chrisCalendar.MeetingSlots[5].UnBook();
            chrisCalendar.MeetingSlots[6].Book();
            chrisCalendar.MeetingSlots[7].UnBook();

            var sophieCalendar = _calendarFactory.Create("Sophie");

            sophieCalendar.MeetingSlots[0].UnBook();
            sophieCalendar.MeetingSlots[1].UnBook();
            sophieCalendar.MeetingSlots[2].Book();
            sophieCalendar.MeetingSlots[3].Book();
            sophieCalendar.MeetingSlots[4].Book();
            sophieCalendar.MeetingSlots[5].UnBook();
            sophieCalendar.MeetingSlots[6].Book();
            sophieCalendar.MeetingSlots[7].Book();

            _calendars.Add(adamCalendar);
            _calendars.Add(blairCalendar);
            _calendars.Add(chrisCalendar);
            _calendars.Add(sophieCalendar);
        }
    }
}
