namespace BookAMeeting.Console
{
    using System;

    public class ConsoleWriter
    {
        public static void Display(string value)
        {
            Console.WriteLine(value);
        }

        public static void DisplayWelcomeMessage()
        {
            Display("***************************************");
            Display("*   WELCOME TO BOOK A MEETING . COM   *");
            Display("***************************************");
        }
    }
}
