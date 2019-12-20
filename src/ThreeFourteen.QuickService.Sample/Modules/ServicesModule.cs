using Autofac;
using ThreeFourteen.QuickService.Sample.Services;

namespace ThreeFourteen.QuickService.Sample.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
        }
    }
}
