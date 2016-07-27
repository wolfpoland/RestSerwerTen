using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestSerwerTen.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "haslo",
                table: "Uzytkownik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "login",
                table: "Uzytkownik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "haslo",
                table: "Uzytkownik");

            migrationBuilder.DropColumn(
                name: "login",
                table: "Uzytkownik");
        }
    }
}
