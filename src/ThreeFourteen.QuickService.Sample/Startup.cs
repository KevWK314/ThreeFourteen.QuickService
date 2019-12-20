using Microsoft.Extensions.Configuration;

namespace ThreeFourteen.QuickService.Sample
{
    public class Startup : ServiceStartup
    {
        public Startup(IConfiguration configuration) 
            : base(configuration)
        {
        }
    }
}
