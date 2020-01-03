# ThreeFourteen QuickService

Create an (opinionated) ASP.NET Core 3.0 service... quickly.

## Intro

There is a fair amount of boilerplate code required to set up a service. This is an attempt to not have to repeat the process over and over. 

I'm hoping this will be helpful as a prototyping tool to get a working service up and running in very short order.

## What is Used

To get there, this library is opinionated on what dependencies to use.

### AutoFac

The IoC container is [AutoFac](https://autofac.org). And if you define [Modules](https://autofaccn.readthedocs.io/en/latest/configuration/modules.html) in your (launch) project they should be automatically loaded.

### Serilog

[Serilog](https://serilog.net/) is used for logging. 

With no configuration in appSettings.json logging should still work but will only log to Console. You can override the default behavour (i.e. use additional sinks) by adding configuraiton to [appSettings.json](https://github.com/serilog/serilog-settings-configuration#serilogsettingsconfiguration--).

Serilog plugs in very nicely to the [Logging Extensions](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1#create-logs) which decouples you nicely from the selected logging library.
