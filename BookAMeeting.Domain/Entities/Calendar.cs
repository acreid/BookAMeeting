namespace BookAMeeting.Domain.Entities
{
    using System.Collections.Generic;

    public class Calendar
    {
        public Person Person { get; set; }
        public IList<MeetingSlot> MeetingSlots { get; set; }
    }
}
