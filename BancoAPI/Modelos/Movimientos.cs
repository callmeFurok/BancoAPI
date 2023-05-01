using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoAPI.Modelos
{
    public class Movimientos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string TipoMovimiento { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal Valor { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal Saldo { get; set; }

        [Required]
        public int CuentaId { get; set; }

        public Cuenta Cuenta { get; set; }
    }
}