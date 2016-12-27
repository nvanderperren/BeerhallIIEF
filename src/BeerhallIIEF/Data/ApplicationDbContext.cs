using BeerhallIIEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallIIEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Beer> Beers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewer>(MapBrewer);
            modelBuilder.Entity<Beer>(MapBeer);
        }

        private void MapBeer(EntityTypeBuilder<Beer> b)
        {
            b.ToTable("Beers");

            //PK
            b.HasKey(t => t.BeerId);

            //Properties
            b.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            b.Property(t => t.BeerId)
                .ValueGeneratedOnAdd();
        }

        private static void MapBrewer(EntityTypeBuilder<Brewer> b)
        {
            b.ToTable("Brewers");

            //PK
            b.HasKey(t => t.BrewerId);

            //Properties
            b.Property(t => t.Name)
                .HasColumnName("BrewerName")
                .IsRequired()
                .HasMaxLength(100);

            b.Property(t => t.ContactEmail)
                .HasMaxLength(100);

            b.Property(t => t.Street)
                .HasMaxLength(100);

            b.Property(t => t.BrewerId)
                .ValueGeneratedOnAdd();
        }
    }
}
