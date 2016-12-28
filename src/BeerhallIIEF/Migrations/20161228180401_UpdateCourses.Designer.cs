using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeerhallIIEF.Data;
using BeerhallIIEF.Models;

namespace BeerhallIIEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161228180401_UpdateCourses")]
    partial class UpdateCourses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerhallIIEF.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("AlcoholByVolume");

                    b.Property<int?>("BrewerId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.HasKey("BeerId");

                    b.HasIndex("BrewerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Brewer", b =>
                {
                    b.Property<int>("BrewerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DateEstablished");

                    b.Property<string>("Description");

                    b.Property<string>("LocationPostalCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("BrewerName")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<int?>("Turnover");

                    b.HasKey("BrewerId");

                    b.HasIndex("LocationPostalCode");

                    b.ToTable("Brewers");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.BrewerCategory", b =>
                {
                    b.Property<int>("BrewerId");

                    b.Property<int>("CategoryId");

                    b.HasKey("BrewerId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BrewerCategory");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrewerId");

                    b.Property<int?>("Credits");

                    b.Property<int>("Language");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("CourseId");

                    b.HasIndex("BrewerId");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("Type").HasValue("Course");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Location", b =>
                {
                    b.Property<string>("PostalCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PostalCode");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.OnlineCourse", b =>
                {
                    b.HasBaseType("BeerhallIIEF.Models.Course");

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.ToTable("OnlineCourse");

                    b.HasDiscriminator().HasValue("Online");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.OnsiteCourse", b =>
                {
                    b.HasBaseType("BeerhallIIEF.Models.Course");

                    b.Property<TimeSpan?>("From");

                    b.Property<int>("NumberOfDays");

                    b.Property<DateTime>("StartDate")
                        .HasAnnotation("BackingField", "_startDate");

                    b.Property<TimeSpan?>("Till");

                    b.ToTable("OnsiteCourse");

                    b.HasDiscriminator().HasValue("Onsite");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Beer", b =>
                {
                    b.HasOne("BeerhallIIEF.Models.Brewer")
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Brewer", b =>
                {
                    b.HasOne("BeerhallIIEF.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationPostalCode");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.BrewerCategory", b =>
                {
                    b.HasOne("BeerhallIIEF.Models.Brewer", "Brewer")
                        .WithMany()
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerhallIIEF.Models.Category", "Category")
                        .WithMany("BCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Course", b =>
                {
                    b.HasOne("BeerhallIIEF.Models.Brewer", "Brewer")
                        .WithMany("Courses")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
