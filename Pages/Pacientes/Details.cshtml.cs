using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Pacientes
{
    public class DetailsModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public DetailsModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        public Paciente Paciente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            else
            {
                Paciente = paciente;
            }
            return Page();
        }
    }
}
