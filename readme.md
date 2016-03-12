A [bootstrapper](https://github.com/NancyFx/Nancy/wiki/Bootstrapper) implementation, for the [Nancy](http://nancyfx.org) framework, based on the StructureMap inversion of control container.

## Usage

When Nancy detects that the `StructureMapNancyBootstrapper` type is available in the AppDomain of your application, it will assume you want to use it, rather than the default one.

The easiest way to get the latest version of `StructureMapNancyBootstrapper` into your application is to install the `Nancy.Bootstrappers.StructureMap` nuget.

### Customizing

By inheriting from `StructureMapNancyBootstrapper` you will gain access to the `IContainer` of the application and request containers and can perform what ever reqistations that your application requires.

```c#
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;

public class Bootstrapper : StructureMapNancyBootstrapper
{
    protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
    {
        // No registrations should be performed in here, however you may
        // resolve things that are needed during application startup.
    }

    protected override void ConfigureApplicationContainer(IContainer existingContainer)
    {
        // Perform registation that should have an application lifetime
    }

    protected override void ConfigureRequestContainer(IContainer container, NancyContext context)
    {
        // Perform registrations that should have a request lifetime
    }

    protected override void RequestStartup(IContainer container, IPipelines pipelines, NancyContext context)
    {
        // No registrations should be performed in here, however you may
        // resolve things that are needed during request startup.
    }
}
```

You can also override the `GetApplicationContainer` method and return a pre-existing container instance, instead of having Nancy create one for you. This is useful if Nancy is co-existing with another application and you want them to share a single container.

```c#
protected override IContainer GetApplicationContainer()
{
    // Return application container instance
}
```

## Contributors

* [Andreas Håkansson](http://github.com/thecodejunkie)
* [Andy Pike](http://github.com/andypike)
* [David Alpert](http://github.com/davidalpert)
* [Steven Robbins](http://github.com/grumpydev)

## Copyright

Copyright © 2010 Andreas Håkansson, Steven Robbins and contributors

## License

Nancy.Bootstrappers.StructureMap is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to license.txt for more information.
