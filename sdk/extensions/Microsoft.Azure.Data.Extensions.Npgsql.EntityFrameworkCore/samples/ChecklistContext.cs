using Microsoft.EntityFrameworkCore;
using Sample.Repository.Model;

namespace Sample.Repository
{
    public class ChecklistContext : DbContext
    {

        public DbSet<Checklist>? Checklists { get; set; }
        public DbSet<CheckItem>? CheckItems { get; set; }

        public ChecklistContext(DbContextOptions<ChecklistContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>()
                .HasKey(c => c.ID);
            modelBuilder.Entity<CheckItem>()
                .HasKey(ci => ci.ID);
            modelBuilder.Entity<Checklist>()
                .HasMany(c => c.CheckItems)
                .WithOne(ci => ci.Checklist)
                .HasForeignKey(ci => ci.ChecklistID);
        }
    }
}
