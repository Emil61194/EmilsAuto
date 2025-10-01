using Microsoft.AspNetCore.Mvc;

namespace EmilsAuto.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
