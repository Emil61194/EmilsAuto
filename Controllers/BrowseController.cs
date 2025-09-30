using EmilsAuto.Classes;
using EmilsAuto.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmilsAuto.Controllers
{
    public class BrowseController : Controller
    {
        private readonly IProducts productRepository;
        
        public BrowseController(IProducts productRepository)
        {
            this.productRepository = productRepository;
        }
        
        public IActionResult Index()
        {
            List<Cars> cars = productRepository.GetCars();
            return View("BrowseCars");
        }
    }

    public class BrowseViewModel
    {

    }
}
