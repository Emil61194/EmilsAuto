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
            BrowseViewModel viewModel = new BrowseViewModel();
            viewModel.Car = productRepository.GetCar();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult SelectCar([FromForm] int productId)
        {
            
            return View("SelectedCar");
        }
    }

    public class BrowseViewModel
    {
        public List<Car> Car;
    }
}
