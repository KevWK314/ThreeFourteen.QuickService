using Microsoft.AspNetCore.Mvc;
using ThreeFourteen.QuickService.Sample.Services;

namespace ThreeFourteen.QuickService.Sample.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<string> CustomerId()
        {
            return _customerService.GetCustomerName();
        }
    }
}
