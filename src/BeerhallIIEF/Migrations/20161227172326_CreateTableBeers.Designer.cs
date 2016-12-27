using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeerhallIIEF.Data;

namespace BeerhallIIEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161227172326_CreateTableBeers")]
    partial class CreateTableBeers
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

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("BeerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerhallIIEF.Models.Brewer", b =>
                {
                    b.Property<int>("BrewerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail");

                    b.Property<DateTime?>("DateEstablished");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Street");

                    b.Property<int?>("Turnover");

                    b.HasKey("BrewerId");

                    b.ToTable("Brewers");
                });
        }
    }
}
