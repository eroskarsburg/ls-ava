using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ls_ava_web.Pages.Home
{
    public class Home : PageModel
    {
        public IActionResult TelaInicial()
        {
            return Page();
        }
    }
}
