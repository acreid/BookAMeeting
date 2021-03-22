namespace BookAMeeting.Domain.DependencyResolution
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Repositories;

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ICalendarsRepository>()
                    .ImplementedBy<CalendarsRepository>()
                    .LifeStyle.Transient);
        }
    }
}
