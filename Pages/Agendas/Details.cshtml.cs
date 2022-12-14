using AgendaApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Pages.Agendas
{
    public class DetailsModel : PageModel
    {
        private readonly AgendaApp.Data.AgendaAppContext _context;

        public DetailsModel(AgendaApp.Data.AgendaAppContext context)
        {
            _context = context;
        }

        public Agenda Agenda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agenda == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }
            else
            {
                Agenda = agenda;
            }
            return Page();
        }
    }
}
