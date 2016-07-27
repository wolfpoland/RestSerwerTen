using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RestSerwerTen.Models;

namespace RestSerwerTen.Migrations
{
    [DbContext(typeof(RestSerwerTenContext))]
    [Migration("20160727135146_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestSerwerTen.Models.Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("haslo");

                    b.Property<string>("imie");

                    b.Property<string>("login");

                    b.Property<string>("nazwisko");

                    b.HasKey("Id");

                    b.ToTable("Uzytkownik");
                });
        }
    }
}
