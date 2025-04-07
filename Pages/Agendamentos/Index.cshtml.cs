using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Agendamentos
{
    public class IndexModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public IndexModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        public IList<Agendamento> Agendamento { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Agendamento = await _context.Agendamentos
                .Include(a => a.Paciente)
                .ToListAsync();
        }
    }
}