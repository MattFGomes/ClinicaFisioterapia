using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicaFisioterapia.Pages.Agendamentos
{
    public class CreateModel : PageModel
    {
        private readonly ClinicaFisioterapidaDbContext _context;

        public CreateModel(ClinicaFisioterapidaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CarregarPacientes();
            return Page();
        }

        [BindProperty]
        public Agendamento Agendamento { get; set; } = default!;

        public SelectList Pacientes { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Agendamentos == null || Agendamento == null)
            {
                CarregarPacientes();
                return Page();
            }

            _context.Agendamentos.Add(Agendamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void CarregarPacientes()
        {
            var pacientes = _context.Pacientes.OrderBy(p => p.Nome).ToList();
            Pacientes = new SelectList(pacientes, "Id", "Nome");
        }
    }
}