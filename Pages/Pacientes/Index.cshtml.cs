using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public IndexModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        public IList<Paciente> Paciente { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Paciente = await _context.Pacientes.ToListAsync();
        }
    }
}
