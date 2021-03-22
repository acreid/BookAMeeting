namespace BookAMeeting.Domain.DependencyResolution
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Factories;

    public class FactoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ICalendarFactory>()
                    .ImplementedBy<NineToFourCalendarFactory>()
                    .LifeStyle.Singleton);
        }
    }
}
