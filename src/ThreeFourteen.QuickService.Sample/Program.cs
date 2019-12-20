using System.Threading.Tasks;

namespace ThreeFourteen.QuickService.Sample
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var service = new ServiceHost();
            return service.Run<Startup>(args);
        }
    }
}
