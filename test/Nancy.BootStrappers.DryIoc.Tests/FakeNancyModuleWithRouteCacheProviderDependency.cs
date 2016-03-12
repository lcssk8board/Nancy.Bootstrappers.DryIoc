namespace Nancy.Bootstrappers.DryIoc.Tests
{
    using Nancy.Routing;

    public class FakeNancyModuleWithRouteCacheProviderDependency : NancyModule
    {
        public IRouteCacheProvider RouteCacheProvider { get; private set; }

        public FakeNancyModuleWithRouteCacheProviderDependency(IRouteCacheProvider routeCacheProvider)
        {
            RouteCacheProvider = routeCacheProvider;
        }
    }
}