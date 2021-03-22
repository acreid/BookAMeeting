namespace BookAMeeting.Domain.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Repositories;

    public class GetMeetingWithBestAvailabilityQueryHandler : IGetMeetingWithBestAvailabilityQueryHandler
    {
        private readonly ICalendarsRepository _calendarsRepository;

        public GetMeetingWithBestAvailabilityQueryHandler(ICalendarsRepository calendarsRepository)
        {
            _calendarsRepository = calendarsRepository;
        }

        public GetMeetingWithBestAvailabilityResponse Handle()
        {
            var calendars = _calendarsRepository.Get();

            if (CalendarsDoNotExist(calendars))
            {
                return GetResponseModel(0, null);
            }

            return GetMeetingSlotTimeFromCalendars(calendars);
        }

        private static GetMeetingWithBestAvailabilityResponse GetResponseModel(int peopleAvailable, int? meetingSlotTime)
        {
            return new GetMeetingWithBestAvailabilityResponse()
            {
                PeopleAvailable = peopleAvailable,
                MeetingSlotTime = meetingSlotTime
            };
        }

        private static GetMeetingWithBestAvailabilityResponse GetMeetingSlotTimeFromCalendars(ICollection<Calendar> calendars)
        {
            var peopleAvailable = 0;
            int? meetingSlotTime = null;

            for (var peopleRequired = calendars.Count; peopleRequired >= 1; peopleRequired--)
            {
                var slot = TryGetMeetingSlotTime(calendars, peopleRequired);

                if (slot != null)
                {
                    peopleAvailable = peopleRequired;
                    meetingSlotTime = (int)slot;

                    break;
                }
            }

            return GetResponseModel(peopleAvailable, meetingSlotTime);
        }

        private static bool CalendarsDoNotExist(ICollection<Calendar> calendars)
        {
            return calendars == null 
                   || calendars.Count == 0 
                   || calendars.All(cal => cal == null);
        }

        private static int? TryGetMeetingSlotTime(ICollection<Calendar> calendars, int peopleRequired)
        {
            if (peopleRequired < 0)
            {
                throw new ArgumentException($"{nameof(peopleRequired)} cannot be less than zero.");
            }

            if (peopleRequired > calendars.Count)
            {
                throw new ArgumentException($"{nameof(peopleRequired)} cannot be greater than the number of people.");
            }

            var slotTimes = GetMeetingTimesSorted(calendars);

            if (slotTimes != null && slotTimes.Length != 0)
            {
                foreach (var time in slotTimes)
                {
                    if (NumberOfAvailableTimesIsEqualToNumberOfPeopleRequired(calendars, time, peopleRequired))
                    {
                        return time;
                    }
                }
            }

            return null;
        }

        private static int[] GetMeetingTimesSorted(IEnumerable<Calendar> calendars)
        {
            return calendars
                .Where(calendar => calendar != null)
                .SelectMany(calendar => calendar.MeetingSlots)
                .Select(slot => slot.StartTime)
                .Distinct()
                .OrderBy(time => time)
                .ToArray();
        }

        private static bool NumberOfAvailableTimesIsEqualToNumberOfPeopleRequired(IEnumerable<Calendar> calendars, int time, int peopleRequired)
        {
            return CountOfAvailableTimes(calendars, time) == peopleRequired;
        }

        private static int CountOfAvailableTimes(IEnumerable<Calendar> calendars, int slotTime)
        {
            return calendars
                .SelectMany(calendar => calendar.MeetingSlots.Where(slot => slot.StartTime == slotTime))
                .Count(slot => !slot.Booked);
        }
    }
}
