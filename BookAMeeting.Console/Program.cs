namespace BookAMeeting.Console
{
    using System;
    using Domain.Queries;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                Startup.ConfigureApp();

                ConsoleWriter.DisplayWelcomeMessage();

                ExecuteCore();
            }
            catch (Exception e)
            {
                // Log exception
                Console.WriteLine("Sorry, we encountered an error. Please try again or contact our support team.");
            }

            Console.ReadLine();
        }

        private static void ExecuteCore()
        {
            IGetMeetingWithBestAvailabilityQueryHandler handler = null;

            try
            {
                handler = Startup.Container.Resolve<IGetMeetingWithBestAvailabilityQueryHandler>();
                
                var response = handler.Handle();
                
                ConsoleWriter.Display($"{response.PeopleAvailable} people have availability at {response.MeetingSlotTime}:00");

            }
            finally
            {
                if (Startup.Container.Kernel.HasComponent(typeof(IGetMeetingWithBestAvailabilityQueryHandler)))
                {
                    Startup.Container.Release(handler);
                }
            }
        }
    }
}