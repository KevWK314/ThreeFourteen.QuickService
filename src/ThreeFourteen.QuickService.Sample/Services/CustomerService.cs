namespace ThreeFourteen.QuickService.Sample.Services
{
    public interface ICustomerService
    {
        string GetCustomerName();
    }

    public class CustomerService : ICustomerService
    {
        public string GetCustomerName()
        {
            return "Charlie Brown";
        }
    }
}
