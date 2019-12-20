using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace ThreeFourteen.QuickService
{
    public static class SerilogBuilder
    {
        public static ILogger Build(IConfiguration configuration)
        {
            if(configuration.GetSection("Serilog").Exists())
            {
                return new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            }

            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
