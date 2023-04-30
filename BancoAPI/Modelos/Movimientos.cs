using System.ComponentModel.DataAnnotations;

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
        public decimal Valor { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
