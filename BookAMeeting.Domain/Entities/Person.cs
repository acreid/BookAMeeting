namespace BookAMeeting.Domain.Entities
{
    public class Person
    {
        public string FirstName { get; private set; }
        public Person(string firstName)
        {
            FirstName = firstName;
        }
    }
}
