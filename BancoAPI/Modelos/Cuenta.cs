using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoAPI.Modelos
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NumeroCuenta { get; set; }

        [Required]
        public string TipoCuenta { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal SaldoInicial { get; set; }

        [Required]
        public bool Estado { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}