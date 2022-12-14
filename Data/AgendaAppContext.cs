using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Data
{
    public class AgendaAppContext : DbContext
    {
        public AgendaAppContext(DbContextOptions<AgendaAppContext> options)
            : base(options)
        {
        }

        public DbSet<AgendaApp.Model.Agenda> Agenda { get; set; } = default!;
    }
}
