using Microsoft.EntityFrameworkCore;
using questor_challenge.Models;

namespace questor_challenge.Data
{
    /// <summary>
    /// Represents a database context for the Questor challenge.
    /// </summary>
    public class QuestorContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestorContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public QuestorContext(DbContextOptions<QuestorContext> options) : base(options) { }

        public DbSet<Boleto>? Boletos { get; set; }
        public DbSet<Banco>? Bancos { get; set; }
    }
}
