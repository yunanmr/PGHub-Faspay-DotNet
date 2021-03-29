using Microsoft.EntityFrameworkCore;
using PGHub.Entity;

namespace PGHub.DataAccess
{
    public class PostgreSqlContext: DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Payment> payments { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Transaction>(entity =>
            {
                // Set key for entity
                entity.HasKey(p => p.trx_id);
            });
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
