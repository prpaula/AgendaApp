using AgendaApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaApp.Pages.Agendas
{
    public class CreateModel : PageModel
    {
        private readonly AgendaApp.Data.AgendaAppContext _context;

        public CreateModel(AgendaApp.Data.AgendaAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Agenda Agenda { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Agenda == null || Agenda == null)
            {
                return Page();
            }

            _context.Agenda.Add(Agenda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
