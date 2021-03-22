namespace BookAMeeting.Domain.Queries
{
    public interface IGetMeetingWithBestAvailabilityQueryHandler
    {
        GetMeetingWithBestAvailabilityResponse Handle();
    }
}
