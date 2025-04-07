using ClinicaFisioterapia.Data;
using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ClinicaFisioterapia.Pages.Pacientes
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
            return Page();
        }

        [BindProperty]
        public Paciente Paciente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pacientes == null || Paciente == null)
            {
                return Page();
            }

            _context.Pacientes.Add(Paciente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
