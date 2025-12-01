using Microsoft.EntityFrameworkCore;
using DreamQuest.Models;

namespace DreamQuest.Data
{
    public class AgenciaDbContext : DbContext
    {
        public AgenciaDbContext(DbContextOptions<AgenciaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}