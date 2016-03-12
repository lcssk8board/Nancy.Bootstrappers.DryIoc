#if !__MonoCS__ 
namespace Nancy.Bootstrappers.DryIoc.Tests
{
    using global::DryIoc;

    using Nancy.Bootstrapper;
    using DryIoc;
    using Nancy.Tests.Unit.Bootstrapper.Base;

    public class BootstrapperBaseFixture : BootstrapperBaseFixtureBase<IContainer>
    {
        private readonly DryIocNancyBootstrapper bootstrapper;

        public BootstrapperBaseFixture()
        {
            this.bootstrapper = new FakeDryIocNancyBootstrapper(this.Configuration);
        }

        protected override NancyBootstrapperBase<IContainer> Bootstrapper
        {
            get { return this.bootstrapper; }
        }
    }
}
#endif