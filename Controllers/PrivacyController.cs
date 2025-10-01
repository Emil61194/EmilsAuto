using Microsoft.AspNetCore.Mvc;

namespace EmilsAuto.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
