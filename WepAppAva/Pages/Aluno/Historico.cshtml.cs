using Application.Services.Disciplinas.Service;
using Application.Shared.Context;
using Application.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WepAppAva.Pages
{
    public class HistoricoModel : PageModel
    {
        private readonly ILogger<HistoricoModel> _logger;
        public Dictionary<int, List<Disciplina>>? DisciplinasPorModulo;

        public HistoricoModel(ILogger<HistoricoModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            DbContext.DBConnect();
            DisciplinasPorModulo = DisciplinaService.ReturnDisciplinas();
            return Page();
        }
    }
}