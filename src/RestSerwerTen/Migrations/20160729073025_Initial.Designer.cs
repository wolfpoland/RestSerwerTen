using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RestSerwerTen.Models;

namespace RestSerwerTen.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20160729073025_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("RestSerwerTen.Models.uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("haslo");

                    b.Property<string>("imie");

                    b.Property<string>("mail");

                    b.Property<string>("nazwisko");

                    b.HasKey("Id");

                    b.ToTable("uzytkowniko");
                });
        }
    }
}
