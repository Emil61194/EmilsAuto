using Microsoft.AspNetCore.Mvc;

namespace EmilsAuto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class HomeViewModel
    {

    }
}
