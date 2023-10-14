using Microsoft.EntityFrameworkCore;
using questor_challenge.Models;

namespace questor_challenge.Data
{
    public class QuestorContext : DbContext
    {
        /// <summary>
        /// Represents a database context for the Questor challenge.
        /// </summary>
        public QuestorContext(DbContextOptions<QuestorContext> options) : base(options) { }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
    }
}
