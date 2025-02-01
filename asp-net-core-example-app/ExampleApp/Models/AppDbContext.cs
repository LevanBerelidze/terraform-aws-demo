using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id);
                entity.Property(x => x.Email).HasMaxLength(50).IsRequired();
                entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(x => x.LastName).HasMaxLength(50).IsRequired();
                entity.Property(x => x.BirthDate).HasColumnType("date");

                entity.HasIndex(x => x.Email).IsUnique();
            });

            modelBuilder.UseSnakeCaseDatabaseNames();
        }
    }
}
