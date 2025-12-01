using System.ComponentModel.DataAnnotations;

namespace DreamQuest.Models
{
    public class Utilizador
    {
        [Key]
        public int UtilizadorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? Role { get; set; } = "Passageiro";

        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}