namespace BookAMeeting.Domain.Tests.Queries
{
    using System.Collections.Generic;
    using Domain.Queries;
    using Entities;
    using NUnit.Framework;
    using Repositories;
    using FakeItEasy;

    [TestFixture]
    public class GetMeetingWithBestAvailabilityQueryHandlerTests
    {
        private ICalendarsRepository _mockRepository;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _mockRepository = A.Fake<ICalendarsRepository>();
        }

        [Test]
        public void CallingHandleWithNullCalendars_ReturnsModelWithZeroPeopleAvailable()
        {
            IList<Calendar> calendars = null;

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(0));
            Assert.That(result.MeetingSlotTime, Is.Null);
        }

        [Test]
        public void CallingHandleWithEmptyCalendars_ReturnsModelWithZeroPeopleAvailable()
        {
            IList<Calendar> calendars = new List<Calendar>();

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(0));
            Assert.That(result.MeetingSlotTime, Is.Null);
        }

        [Test]
        public void CallingHandleWithNullCalendarObjects_ReturnsModelWithZeroPeopleAvailable()
        {
            IList<Calendar> calendars = new List<Calendar>();
            calendars.Add(null);
            calendars.Add(null);
            calendars.Add(null);

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(0));
            Assert.That(result.MeetingSlotTime, Is.Null);
        }

        [Test]
        public void CallingHandleWithNoPeopleAvailable_ReturnsModelWithZeroPeopleAvailable()
        {
            var calendars = new List<Calendar>
            {
                new Calendar
                {
                    Person = new Person("Tina"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Peter"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Lara"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
            };

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(0));
            Assert.That(result.MeetingSlotTime, Is.Null);
        }

        [Test]
        public void CallingHandleWithOnePersonAvailable_ReturnsModelWithCorrectAvailability()
        {
            var calendars = new List<Calendar>
            {
                new Calendar
                {
                    Person = new Person("Tina"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Peter"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, false),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Lara"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
            };

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(1));
            Assert.That(result.MeetingSlotTime, Is.EqualTo(12));
        }

        [Test]
        public void CallingHandleWithMultiplePeopleAvailable_ReturnsModelWithCorrectAvailability()
        {
            var calendars = new List<Calendar>
            {
                new Calendar
                {
                    Person = new Person("Tina"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Peter"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, false)
                    }
                },
                new Calendar
                {
                    Person = new Person("Lara"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, false)
                    }
                },
            };

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);
            
            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(2));
            Assert.That(result.MeetingSlotTime, Is.EqualTo(16));
        }

        [Test]
        public void CallingHandleWithFullAvailability_ReturnsModelWithCorrectAvailability()
        {
            var calendars = new List<Calendar>
            {
                new Calendar
                {
                    Person = new Person("Tina"),
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
                },
                new Calendar
                {
                    Person = new Person("Peter"),
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
                },
                new Calendar
                {
                    Person = new Person("Lara"),
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
                },
            };

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(3));
            Assert.That(result.MeetingSlotTime, Is.EqualTo(9));
        }

        [Test]
        public void CallingHandleWithCalendarsWithDifferentNumberOfSlots_ReturnsModelWithBestAvailability()
        {
            var calendars = new List<Calendar>
            {
                new Calendar
                {
                    Person = new Person("Tina"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(10, false),
                        new MeetingSlot(11, false),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, false)
                    }
                },
                new Calendar
                {
                    Person = new Person("Peter"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(11, false),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, true)
                    }
                },
                new Calendar
                {
                    Person = new Person("Lara"),
                    MeetingSlots = new List<MeetingSlot>
                    {
                        new MeetingSlot(9, true),
                        new MeetingSlot(11, true),
                        new MeetingSlot(12, true),
                        new MeetingSlot(13, true),
                        new MeetingSlot(14, true),
                        new MeetingSlot(15, true),
                        new MeetingSlot(16, false)
                    }
                },
            };

            A.CallTo(() => _mockRepository.Get()).Returns(calendars);
            var sut = new GetMeetingWithBestAvailabilityQueryHandler(_mockRepository);

            var result = sut.Handle();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PeopleAvailable, Is.EqualTo(2));
            Assert.That(result.MeetingSlotTime, Is.EqualTo(11));
        }
    }
}
