using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WepAppAva.Pages
{
    public class ResetSenhaModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ResetSenhaModel> _logger;

        public ResetSenhaModel(ILogger<ResetSenhaModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}