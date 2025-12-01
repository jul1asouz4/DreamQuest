using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamQuest.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public DateTime DataReserva { get; set; } = DateTime.Now;

        public int UtilizadorId { get; set; }
        [ForeignKey("UtilizadorId")]
        public virtual Utilizador Utilizador { get; set; }

        public int VooId { get; set; }
        [ForeignKey("VooId")]
        public virtual Voo Voo { get; set; }
    }
}