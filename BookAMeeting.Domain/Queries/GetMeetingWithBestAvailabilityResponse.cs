namespace BookAMeeting.Domain.Queries
{
    public class GetMeetingWithBestAvailabilityResponse
    {
        public int PeopleAvailable { get; set; }
        public int? MeetingSlotTime { get; set; }
    }
}
