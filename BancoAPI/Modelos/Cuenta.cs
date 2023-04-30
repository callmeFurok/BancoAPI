using System.ComponentModel.DataAnnotations;

namespace BancoAPI.Modelos
{
    public class Cuenta
    {
        public int Id { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }
        [Required]
        public string TipoCuenta { get; set; }
        [Required]
        public decimal SaldoInicial { get; set; }
        [Required]
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
