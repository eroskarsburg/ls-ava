using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ls_ava_web.Pages
{
    public class LoginModel : PageModel
    {
        public IActionResult LoginPage()
        {
            return Page();
        }
    }
}
