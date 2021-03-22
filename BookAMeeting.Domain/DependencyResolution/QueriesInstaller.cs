namespace BookAMeeting.Domain.DependencyResolution
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Queries;

    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IGetMeetingWithBestAvailabilityQueryHandler>()
                    .ImplementedBy<GetMeetingWithBestAvailabilityQueryHandler>()
                    .LifeStyle.Transient);
        }
    }
}
