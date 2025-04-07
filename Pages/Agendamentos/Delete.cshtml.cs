using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Agendamentos
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public DeleteModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agendamento Agendamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (agendamento == null)
            {
                return NotFound();
            }
            else
            {
                Agendamento = agendamento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento != null)
            {
                Agendamento = agendamento;
                _context.Agendamentos.Remove(Agendamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}