using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoAPI.Modelos
{
    public class Movimientos
    {
        [Key]
        public Guid Id { get; set; }

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
        public Guid CuentaId { get; set; }

        public Cuenta Cuenta { get; set; }
    }
}