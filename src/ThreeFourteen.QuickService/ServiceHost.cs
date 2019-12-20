using System.IO;
using System.Security.Authentication;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ThreeFourteen.QuickService
{
    public class ServiceHost
    {
        public Task Run<TStartup>(string[] args) where TStartup : class
        {
            return CreateHostBuilder<TStartup>(args, null).RunAsync();
        }

        public Task Run<TStartup>(string[] args, IConfigureHost configureHost) where TStartup : class
        {
            return CreateHostBuilder<TStartup>(args, configureHost).RunAsync();
        }

        public static IHost CreateHostBuilder<TStartup>(string[] args, IConfigureHost configureHost) where TStartup : class
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(options =>
                        {
                            options.ConfigureHttpsDefaults(httpsOptions =>
                            {
                                httpsOptions.SslProtocols = SslProtocols.Tls12;
                            });
                            options.Limits.MaxResponseBufferSize = 52_428_800;
                            options.AddServerHeader = false;
                        })
                        .UseStartup<TStartup>()
                        .UseSerilog();

                    configureHost?.Configure(webBuilder);
                });

            configureHost?.Configure(hostBuilder);

            return hostBuilder.Build();
        }
    }
}
