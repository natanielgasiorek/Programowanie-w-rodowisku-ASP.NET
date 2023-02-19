﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrzychodniaFinal.DataAccess;

namespace PrzychodniaFinal.Migrations
{
    [DbContext(typeof(PrzychodniaDBContext))]
    partial class PrzychodniaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrzychodniaFinal.Models.Lekarze", b =>
                {
                    b.Property<int>("LekarzeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumerGabinetu")
                        .HasColumnType("int");

                    b.Property<string>("Specjalizacja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LekarzeID");

                    b.ToTable("Lekarzes");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Pacjenci", b =>
                {
                    b.Property<int>("PacjenciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresZamieszkania")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("PacjenciID");

                    b.ToTable("Pacjencis");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Pracownicy", b =>
                {
                    b.Property<int>("PracownicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresZamieszkania")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataZatrudnienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("KoniecKontraktu")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LekarzeID")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("PracownicyID");

                    b.HasIndex("LekarzeID");

                    b.ToTable("Pracownicies");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Wizyty", b =>
                {
                    b.Property<int>("ChorobyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataWizyty")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacjentID")
                        .HasColumnType("int");

                    b.Property<int>("PracownikID")
                        .HasColumnType("int");

                    b.Property<string>("PrzebiegChoroby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChorobyID");

                    b.ToTable("Wizyties");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Pracownicy", b =>
                {
                    b.HasOne("PrzychodniaFinal.Models.Lekarze", "Lekarze")
                        .WithMany()
                        .HasForeignKey("LekarzeID");

                    b.Navigation("Lekarze");
                });
#pragma warning restore 612, 618
        }
    }
}
