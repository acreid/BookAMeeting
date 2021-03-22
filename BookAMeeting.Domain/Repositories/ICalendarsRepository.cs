namespace BookAMeeting.Domain.Repositories
{
    using System.Collections.Generic;
    using Entities;

    public interface ICalendarsRepository
    {
        IList<Calendar> Get();
    }
}
