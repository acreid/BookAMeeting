namespace BookAMeeting.Domain.Tests.Factories
{
    using System.Linq;
    using Domain.Factories;
    using Entities;
    using NUnit.Framework;

    [TestFixture]
    public class NineToFourCalendarFactoryTests
    {
        private string _name = "Dave";
        private NineToFourCalendarFactory _sut;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _sut = new NineToFourCalendarFactory();
        }

        [Test]
        public void CallingCreate_ShouldReturnACalendar()
        {
            var result = _sut.Create(_name);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(Calendar)));
        }

        [Test]
        public void CallingCreate_ShouldReturnACalendarWithACorrectlyConfiguredPerson()
        {
            var result = _sut.Create(_name);

            Assert.That(result.Person, Is.Not.Null);
            Assert.That(result.Person.FirstName, Is.EqualTo(_name));
        }

        [Test]
        public void CallingCreate_ShouldReturnACalendarWithTheCorrectNumberOfMeetingSlots()
        {
            var result = _sut.Create(_name);

            Assert.That(result.MeetingSlots, Is.Not.Null);
            Assert.That(result.MeetingSlots.Count, Is.EqualTo(8));
        }

        [Test]
        public void CallingCreate_ShouldReturnACalendarWithTheCorrectStartTimes()
        {
            var result = _sut.Create(_name);

            Assert.That(result.MeetingSlots[0].StartTime, Is.EqualTo(9));
            Assert.That(result.MeetingSlots[1].StartTime, Is.EqualTo(10));
            Assert.That(result.MeetingSlots[2].StartTime, Is.EqualTo(11));
            Assert.That(result.MeetingSlots[3].StartTime, Is.EqualTo(12));
            Assert.That(result.MeetingSlots[4].StartTime, Is.EqualTo(13));
            Assert.That(result.MeetingSlots[5].StartTime, Is.EqualTo(14));
            Assert.That(result.MeetingSlots[6].StartTime, Is.EqualTo(15));
            Assert.That(result.MeetingSlots[7].StartTime, Is.EqualTo(16));
        }

        [Test]
        public void CallingCreate_ShouldReturnACalendarWhereAllMeetingSlotsAreAvailable()
        {
            var result = _sut.Create(_name);

            var distinctBookedValues = result
                .MeetingSlots
                .Select(slot => slot.Booked)
                .Distinct()
                .ToList();

            Assert.That(distinctBookedValues.Count(), Is.EqualTo(1));
            Assert.That(distinctBookedValues.First(), Is.EqualTo(false));
        }
    }
}
