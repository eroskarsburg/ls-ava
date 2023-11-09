using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WepAppAva.Pages
{
    public class MatriculaModel : PageModel
    {
        private readonly ILogger<MatriculaModel> _logger;

        public MatriculaModel(ILogger<MatriculaModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}