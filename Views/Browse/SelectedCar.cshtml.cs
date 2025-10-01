using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmilsAuto.Pages.Browse
{
    public class SelectedCarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public SelectedCarModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //_logger.LogInformation("Hey There");
        }
    }
}
