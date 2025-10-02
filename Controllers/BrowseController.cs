using EmilsAuto.Classes;
using EmilsAuto.Helper;
using EmilsAuto.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Globalization;
using System.Text.Json;

namespace EmilsAuto.Controllers
{
    public class BrowseController : Controller
    {
        private readonly IProducts productRepository;
        private readonly IPagination pagination;

        public BrowseController(IProducts productRepository, IPagination pagination)
        {
            this.productRepository = productRepository;
            this.pagination = pagination;
        }

        [HttpGet("browse/{id?}")]
        public IActionResult Index(int? id)
        {
            BrowseViewModel viewModel = new BrowseViewModel();
            viewModel.Cars = productRepository.GetCars();

            viewModel.pagination.maxPages = pagination.getMaxPages(viewModel.Cars, 5);
            if (id == null || id > viewModel.pagination.maxPages || id < 1) { id = 1; }
            viewModel.pagination.CurrentPage = (int)id;
            viewModel.Cars = pagination.GetPage(5, viewModel.pagination.CurrentPage, viewModel.Cars);

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

        [HttpPost]
        public IActionResult AddCarToBasket(int id)
        {
            var cookies = Request.Cookies["ShoppingBasket"];
            List<int> basket;
            if (cookies != null)
            {
                basket = JsonSerializer.Deserialize<List<int>>(cookies);
            }
            else
            {
                basket = new List<int>();
            }

            if (!basket.Contains(id))
            {
                basket.Add(id);

                var options = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                };

                Response.Cookies.Append("ShoppingBasket", JsonSerializer.Serialize(basket), options);
            }

            return RedirectToAction("SelectedCar", new { id = id });
        }
    }

    public class BrowseViewModel
    {
        public List<Car> Cars;
        public NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;
        public PaginationView pagination = new();
    }
}
