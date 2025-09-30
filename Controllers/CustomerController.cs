using EmilsAuto.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmilsAuto.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ISqlCustomer customerRepository;

        public CustomerController(ISqlCustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            //customerRepository.GetCustomer("Audrye");
            return View();
        }
    }

    public class CustomerViewModel
    {

    }
}
