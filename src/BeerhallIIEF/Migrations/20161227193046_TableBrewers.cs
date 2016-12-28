using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallIIEF.Migrations
{
    public partial class TableBrewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "BrewerId",
                table: "Beers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BrewerId",
                table: "Beers",
                column: "BrewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BrewerId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BrewerId",
                table: "Beers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: true);
        }
    }
}
