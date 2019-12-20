using System.Net;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ThreeFourteen.QuickService
{
    public abstract class ServiceStartup
    {
        protected ServiceStartup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = SerilogBuilder.Build(configuration);
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            services.AddControllers(ConfigureMvcOptions);
            services.AddResponseCompression(options => { options.EnableForHttps = true; });
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(GetType().Assembly);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var env = serviceProvider.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();

            app.UseRouting();
            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureMvcOptions(MvcOptions options)
        {
        }
    }
}
