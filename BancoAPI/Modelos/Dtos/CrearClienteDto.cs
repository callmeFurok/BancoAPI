using System.ComponentModel.DataAnnotations;

namespace BancoAPI.Modelos.Dtos
{
    public class CrearClienteDto
    {

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(3)]
        public string Edad { get; set; }

        [Required]
        [MaxLength(20)]
        public string Genero { get; set; }

        [Required]
        [MaxLength(10)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string Contrasenia { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
