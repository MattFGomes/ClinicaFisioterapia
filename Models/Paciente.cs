using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; } = string.Empty;

        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
    }
}
