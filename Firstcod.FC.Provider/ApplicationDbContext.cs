using Firstcod.FC.Provider.Models;
using Microsoft.EntityFrameworkCore;

namespace Firstcod.FC.Provider
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Member> Members { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Member>().ToTable($"App{nameof(this.Members)}");
            builder.Entity<Member>(entity => { entity.HasIndex(s => s.EmailAddress).IsUnique(); });
        }
    }
}
