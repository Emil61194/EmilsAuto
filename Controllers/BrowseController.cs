using EmilsAuto.Classes;
using EmilsAuto.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Globalization;

namespace EmilsAuto.Controllers
{
    public class BrowseController : Controller
    {
        private readonly IProducts productRepository;

        public BrowseController(IProducts productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("browse")]
        public IActionResult Index()
        {
            BrowseViewModel viewModel = new BrowseViewModel();
            viewModel.Cars = productRepository.GetCars();
            return View(viewModel);
        }


        [HttpGet("browse/car/{id}")]
        public IActionResult SelectedCar(int id)
        {
            BrowseViewModel viewModel = new BrowseViewModel();
            List<Car> cars = new List<Car>();
            cars.Add(productRepository.GetCar(id));
            viewModel.Cars = cars;
            return View(viewModel);
        }
    }

    public class BrowseViewModel
    {
        public List<Car> Cars;
        public NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;
    }
}
