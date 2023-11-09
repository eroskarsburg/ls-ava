using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WepAppAva.Pages
{
    public class NotasModel : PageModel
    {
        private readonly ILogger<NotasModel> _logger;

        public NotasModel(ILogger<NotasModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}