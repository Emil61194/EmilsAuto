using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmilsAuto.Pages.Home
{
    public class ShoppingBasket : PageModel
    {
        private readonly ILogger<ShoppingBasket> _logger;

        public ShoppingBasket(ILogger<ShoppingBasket> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //_logger.LogInformation("Hey There");
        }
    }
}
