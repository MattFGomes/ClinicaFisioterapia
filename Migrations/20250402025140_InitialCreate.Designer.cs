﻿// <auto-generated />
using System;
using ClinicaFisioterapia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicaFisioterapia.Migrations
{
    [DbContext(typeof(ClinicaFisioterapidaDbContext))]
    [Migration("20250402025140_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("ClinicaFisioterapia.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Confirmado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Procedimento")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ClinicaFisioterapia.Models.Agendamento", b =>
                {
                    b.HasOne("ClinicaFisioterapia.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
