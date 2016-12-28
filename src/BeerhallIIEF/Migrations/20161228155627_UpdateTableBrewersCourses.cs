using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallIIEF.Migrations
{
    public partial class UpdateTableBrewersCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Brewers_BrewerId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Brewers_BrewerId",
                table: "Courses",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Brewers_BrewerId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Brewers_BrewerId",
                table: "Courses",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
