using System.ComponentModel.DataAnnotations;

namespace DreamQuest.Models
{
    public class Voo
    {
        [Key]
        public int VooId { get; set; }

        [Required(ErrorMessage = "Escreve a companhia")]
        public string CompanhiaAerea { get; set; }

        [Required(ErrorMessage = "Escreve a origem")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "Escreve o destino")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Escolhe a data")]
        public DateTime DataHoraPartida { get; set; }

        [Required]
        public int LugaresDisponiveis { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}