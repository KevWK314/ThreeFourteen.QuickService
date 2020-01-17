# ThreeFourteen QuickService

Create an (opinionated) ASP.NET Core API service quickly.

## Intro

There is a fair amount of boilerplate code required to set up a service. This is an attempt to not have to repeat the process over and over. 

I'm hoping this will be helpful as a prototyping tool to get a working service up and running in very short order.

## What is used

To get there, this library is opinionated on what dependencies to use.

### AutoFac

The IoC container is [AutoFac](https://autofac.org). And if you define [Modules](https://autofaccn.readthedocs.io/en/latest/configuration/modules.html) in your (launch) project they should be automatically loaded.

### Serilog

[Serilog](https://serilog.net/) is used for logging. 

With no configuration in appSettings.json logging should still work but will only log to Console. You can override the default behavour (i.e. use additional sinks) by adding configuraiton to [appSettings.json](https://github.com/serilog/serilog-settings-configuration#serilogsettingsconfiguration--).

Serilog plugs in very nicely to the [Logging Extensions](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1#create-logs) which decouples you nicely from the selected logging library.

## How to use

1. Create a NET Core Console application and target framework netcoreapp3.0. 
   1. Update the project file to use the SDK "Microsoft.NET.Sdk.Web".
   2. Install the nuget package ThreeFourteen.QuickService (Nuget package still pending).
2. Create a Startup.cs file (name it what you want) and inherit from ServiceStartup
   1. You'll have to create a constructor that takes IConfigurationManager and pass that to the base constructor.
3. Add the below code to your Program class.
```c#
public static Task Main(string[] args)
{
    var service = new ServiceHost();
    return service.Run<Startup>(args);
}
```
4. Run your service!

## What else

You'll then want to start adding "stuff".

1. Add an appsettings.json file. This will allow you to further configure logging and add [configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1) for your service.
2. Add Controllers. Otherwise your service is a not overly useful.
3. Add Modules. This will allow you to configure Dependency Injection.

## Customise

There are a few ways to customise the default behavour of the service.
1. ServiceHost.Run() has an overload that allows you to inject an implementation of IConfigureHost which will allow for changes to be made to the [IHostBuilder](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1) and [IWebHostBuilder](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-3.1).
2. In your class that inherits from ServiceStartup, you can override some methods.
   1. [Configure() and ConfigureService()](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1).
   2. [ConfigureMvcOptions()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.mvcoptions?view=aspnetcore-3.1).
   3. ConfigureContainer() if you want to manually handle the building of your Container.
