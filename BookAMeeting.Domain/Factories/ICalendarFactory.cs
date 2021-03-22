namespace BookAMeeting.Domain.Factories
{
    using Entities;

    public interface ICalendarFactory
    {
        Calendar Create(string firstName);
    }
}
