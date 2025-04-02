using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Data
{
    public class ClinicaFisioterapidaDbContext : DbContext
    {
        public ClinicaFisioterapidaDbContext(DbContextOptions<ClinicaFisioterapidaDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=ClinicaFisioterapia.db");
            }
        }
    }
}
