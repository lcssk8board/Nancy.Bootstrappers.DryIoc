namespace Nancy.Bootstrappers.DryIoc.Tests
{
    using System;
    using global::DryIoc;
    using Nancy.Bootstrapper;
    using Nancy.Tests.Fakes;
    using DryIoc;
    using Configuration;

    public class FakeDryIocNancyBootstrapper : DryIocNancyBootstrapper
    {
        public bool ApplicationContainerConfigured { get; set; }
        public bool RequestContainerConfigured { get; set; }

        private readonly Func<ITypeCatalog, NancyInternalConfiguration> configuration;

        public FakeDryIocNancyBootstrapper()
            : this(null)
        {
        }

        public FakeDryIocNancyBootstrapper(Func<ITypeCatalog, NancyInternalConfiguration> configuration)
        {
            this.configuration = configuration;
        }

        protected override Func<ITypeCatalog, NancyInternalConfiguration> InternalConfiguration
        {
            get { return configuration ?? base.InternalConfiguration; }

        }

        public IContainer Container
        {
            get { return ApplicationContainer; }
        }

        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            this.ApplicationContainerConfigured = true;
            base.ConfigureApplicationContainer(existingContainer);
        }

        protected override void ConfigureRequestContainer(IContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            RequestContainerConfigured = true;

            container.Register<IFoo, Foo>();
            container.Register<IDependency, Dependency>();
        }
    }

    public class FakeNancyRequestStartup : IRequestStartup
    {
        public void Initialize(IPipelines pipelines, NancyContext context)
        {
            // Observable side-effect of the execution of this IRequestStartup.
            context.ViewBag.RequestStartupHasRun = true;
        }
    }
}