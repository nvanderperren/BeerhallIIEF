using BeerhallIIEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallIIEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewer>(MapBrewer);
            modelBuilder.Entity<Beer>(MapBeer);
            modelBuilder.Entity<Course>(MapCourse);
            modelBuilder.Entity<Location>(MapLocation);
        }

        private void MapLocation(EntityTypeBuilder<Location> l)
        {
            l.ToTable("Locations");

            //PK
            l.HasKey(t => t.PostalCode);

            //Properties
            l.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();
            

        
        }

        private void MapCourse(EntityTypeBuilder<Course> c)
        {
            c.ToTable("Courses");

            //PK
            c.HasKey(t => t.CourseId);

            //Properties
            c.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            //Associaties

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

            //Relaties
            b.HasMany(t => t.Beers)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            b.HasMany(t => t.Courses)
                .WithOne(t => t.Brewer)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(t => t.Location)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
