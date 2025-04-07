using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Agendamentos
{
    public class EditModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public EditModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agendamento Agendamento { get; set; } = default!;

        public SelectList Pacientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }
            Agendamento = agendamento;
            CarregarPacientes();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CarregarPacientes();
                return Page();
            }

            _context.Attach(Agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(Agendamento.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AgendamentoExists(int id)
        {
            return (_context.Agendamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private void CarregarPacientes()
        {
            var pacientes = _context.Pacientes.OrderBy(p => p.Nome).ToList();
            Pacientes = new SelectList(pacientes, "Id", "Nome");
        }
    }
}