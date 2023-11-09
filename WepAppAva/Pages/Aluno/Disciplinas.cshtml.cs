using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WepAppAva.Pages
{
    public class DisciplinasModel : PageModel
    {
        private readonly ILogger<DisciplinasModel> _logger;

        public DisciplinasModel(ILogger<DisciplinasModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}