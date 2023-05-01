using System.ComponentModel.DataAnnotations;

namespace BancoAPI.Modelos
{
    public class Cliente : Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contrasenia { get; set; }

        [Required]
        public bool Estado { get; set; }


    }
}