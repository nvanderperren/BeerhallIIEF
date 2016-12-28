using System;
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
        public DbSet<Category> Categories { get; set; }

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
            modelBuilder.Entity<Category>(MapCategory);
            modelBuilder.Entity<BrewerCategory>(MapBrewerCategory);
            modelBuilder.Entity<OnlineCourse>(MapOnlineCourse);
            modelBuilder.Entity<OnsiteCourse>(MapOnsiteCourse);

        }

        private void MapOnlineCourse(EntityTypeBuilder<OnlineCourse> c)
        {
            //Properties
            c.Property(t => t.Url).HasMaxLength(100);
        }

        private void MapOnsiteCourse(EntityTypeBuilder<OnsiteCourse> c)
        {
            //Properties
            c.Property(t => t.StartDate).HasAnnotation("BackingField", "_startDate");
        }

        private void MapCategory(EntityTypeBuilder<Category> c)
        {
            //PK
            c.HasKey(t => t.CategoryId);
            
            //Properties
            c.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            c.Ignore(t => t.Brewers);

           

        }

        private void MapBrewerCategory(EntityTypeBuilder<BrewerCategory> bc)
        {
            //PK
            bc.HasKey(t => new {t.BrewerId, t.CategoryId});

            //Associaties
            bc.HasOne(t => t.Brewer)
                .WithMany()
                .HasForeignKey(t => t.BrewerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            bc.HasOne(t => t.Category)
                .WithMany(c => c.BCategory)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

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

            //inheritance
            c.HasDiscriminator<string>("Type")
                .HasValue<OnlineCourse>("Online")
                .HasValue<OnsiteCourse>("Onsite");

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

            b.HasIndex(t => t.Name).IsUnique(true);
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
