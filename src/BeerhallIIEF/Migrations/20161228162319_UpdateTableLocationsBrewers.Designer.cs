﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeerhallIIEF.Data;

namespace BeerhallIIEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161228162319_UpdateTableLocationsBrewers")]
    partial class UpdateTableLocationsBrewers
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
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("Price");

                    b.HasKey("BeerId");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Brewer", b =>
                {
                    b.Property<int>("BrewerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime?>("DateEstablished");

                    b.Property<string>("Description");

                    b.Property<string>("LocationPostalCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("BrewerName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Street")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int?>("Turnover");

                    b.HasKey("BrewerId");

                    b.HasIndex("LocationPostalCode");

                    b.ToTable("Brewers");
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
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("CourseId");

                    b.HasIndex("BrewerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Location", b =>
                {
                    b.Property<string>("PostalCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("PostalCode");

                    b.ToTable("Locations");
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
