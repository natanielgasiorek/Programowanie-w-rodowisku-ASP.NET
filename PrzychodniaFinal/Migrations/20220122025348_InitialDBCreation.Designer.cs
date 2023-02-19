﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrzychodniaFinal.DataAccess;

namespace PrzychodniaFinal.Migrations
{
    [DbContext(typeof(PrzychodniaDBContext))]
    [Migration("20220122025348_InitialDBCreation")]
    partial class InitialDBCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrzychodniaFinal.Models.Choroby", b =>
                {
                    b.Property<int>("ChorobyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdChoroby")
                        .HasColumnType("int");

                    b.Property<int>("IdPacjenta")
                        .HasColumnType("int");

                    b.Property<int?>("IdPracownikaNavigationLekarzeID")
                        .HasColumnType("int");

                    b.Property<int>("PacjenciID")
                        .HasColumnType("int");

                    b.Property<int>("PracownicyID")
                        .HasColumnType("int");

                    b.Property<string>("PrzebiegChoroby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChorobyID");

                    b.HasIndex("IdChoroby");

                    b.HasIndex("IdPracownikaNavigationLekarzeID");

                    b.HasIndex("PacjenciID");

                    b.ToTable("Chorobies");
                });

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataZatrudnienia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KoniecKontraktu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LekarzeID")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("PracownicyID");

                    b.HasIndex("LekarzeID");

                    b.ToTable("Pracownicies");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Recepty", b =>
                {
                    b.Property<int>("IdChoroby")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataWystawienia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRecepty")
                        .HasColumnType("int");

                    b.Property<string>("Lek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacjenciID")
                        .HasColumnType("int");

                    b.HasKey("IdChoroby");

                    b.HasIndex("PacjenciID");

                    b.ToTable("Recepties");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Choroby", b =>
                {
                    b.HasOne("PrzychodniaFinal.Models.Recepty", "Id")
                        .WithMany("Chorobies")
                        .HasForeignKey("IdChoroby");

                    b.HasOne("PrzychodniaFinal.Models.Lekarze", "IdPracownikaNavigation")
                        .WithMany()
                        .HasForeignKey("IdPracownikaNavigationLekarzeID");

                    b.HasOne("PrzychodniaFinal.Models.Pacjenci", "IdPacjentaNavigation")
                        .WithMany("Chorobies")
                        .HasForeignKey("PacjenciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id");

                    b.Navigation("IdPacjentaNavigation");

                    b.Navigation("IdPracownikaNavigation");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Pracownicy", b =>
                {
                    b.HasOne("PrzychodniaFinal.Models.Lekarze", "Lekarze")
                        .WithMany()
                        .HasForeignKey("LekarzeID");

                    b.Navigation("Lekarze");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Recepty", b =>
                {
                    b.HasOne("PrzychodniaFinal.Models.Pacjenci", null)
                        .WithMany("Recepties")
                        .HasForeignKey("PacjenciID");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Pacjenci", b =>
                {
                    b.Navigation("Chorobies");

                    b.Navigation("Recepties");
                });

            modelBuilder.Entity("PrzychodniaFinal.Models.Recepty", b =>
                {
                    b.Navigation("Chorobies");
                });
#pragma warning restore 612, 618
        }
    }
}
