using System.ComponentModel.DataAnnotations;

namespace BancoAPI.Modelos
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(20)]
        public string Genero { get; set; }
        [Required]
        [MaxLength(3)]
        public string Edad { get; set; }

        [Required]
        [MaxLength(10)]
        public string Identificacion { get; set; }
        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }
    }
}
