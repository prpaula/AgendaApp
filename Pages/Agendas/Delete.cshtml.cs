using AgendaApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Pages.Agendas
{
    public class DeleteModel : PageModel
    {
        private readonly AgendaApp.Data.AgendaAppContext _context;

        public DeleteModel(AgendaApp.Data.AgendaAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Agenda == null)
            {
                return NotFound();
            }
            var agenda = await _context.Agenda.FindAsync(id);

            if (agenda != null)
            {
                Agenda = agenda;
                _context.Agenda.Remove(Agenda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
