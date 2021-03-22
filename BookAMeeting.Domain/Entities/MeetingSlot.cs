namespace BookAMeeting.Domain.Entities
{
    using System;

    public class MeetingSlot
    {
        public int StartTime { get; }
        public bool Booked { get; private set; }

        public MeetingSlot(int startTime, bool booked)
        {
            if (startTime < 9 || startTime > 16)
            {
                throw new ArgumentException($"{startTime} must be between 9 and 16.");
            }

            StartTime = startTime;
            Booked = booked;
        }

        public void Book()
        {
            Booked = true;
        }

        public void UnBook()
        {
            Booked = false;
        }
    }
}
