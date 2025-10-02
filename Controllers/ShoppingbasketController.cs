using EmilsAuto.Classes;
using EmilsAuto.Components;
using EmilsAuto.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmilsAuto.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IProducts productRepository;

        public ShoppingBasketController(IProducts productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
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

            ShoppingBasketViewModel viewModel = new ShoppingBasketViewModel();
            List<Car> forSaleCars = productRepository.GetCars();
            viewModel.Cars = forSaleCars
                .Where(x => basket.Contains(x.ProductId))
                .ToList();

            return View(viewModel);
        }
    }
    public class ShoppingBasketViewModel
    {
        public List<Car> Cars;
    }
}
