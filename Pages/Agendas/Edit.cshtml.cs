using AgendaApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Pages.Agendas
{
    public class EditModel : PageModel
    {
        private readonly AgendaApp.Data.AgendaAppContext _context;

        public EditModel(AgendaApp.Data.AgendaAppContext context)
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
            Agenda = agenda;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Agenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(Agenda.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AgendaExists(int id)
        {
            return (_context.Agenda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
