using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ThreeFourteen.QuickService
{
    public interface IConfigureHost
    {
        void Configure(IHostBuilder hostBuilder);
        void Configure(IWebHostBuilder webHostBuilder);
    }
}