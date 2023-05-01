using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoAPI.Modelos.Dtos
{
    public class CrearCuentaDto
    {

        [Required]
        public string NumeroCuenta { get; set; }

        [Required]
        public string TipoCuenta { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal SaldoInicial { get; set; }

        [Required]
        public bool Estado { get; set; }

    }
}
