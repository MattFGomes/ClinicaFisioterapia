using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public string? Procedimento { get; set; }
        public string? Observacoes { get; set; }
        public bool Confirmado { get; set; } = false;
    }
}