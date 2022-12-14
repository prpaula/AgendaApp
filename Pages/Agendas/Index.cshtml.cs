using AgendaApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Pages.Agendas
{
    public class IndexModel : PageModel
    {
        private readonly AgendaApp.Data.AgendaAppContext _context;

        public IndexModel(AgendaApp.Data.AgendaAppContext context)
        {
            _context = context;
        }

        public IList<Agenda> Agenda { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Agenda != null)
            {
                Agenda = await _context.Agenda.ToListAsync();
            }
        }
    }
}
