namespace BookAMeeting.Console
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Domain.Repositories;

    public class Startup
    {
        public static IWindsorContainer Container;

        public static void ConfigureApp()
        {
            // Configure logging
            SetupDependencyInjection();
        }

        private static void SetupDependencyInjection()
        {
            CreateContainer();
            InstallDependencies();
        }

        private static void CreateContainer()
        {
            Container = new WindsorContainer();
        }

        private static void InstallDependencies()
        {
            Container.Install(FromAssembly.Containing<CalendarsRepository>());
        }
    }
}
