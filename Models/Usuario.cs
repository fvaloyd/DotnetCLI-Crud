using System.ComponentModel.DataAnnotations;

namespace Practica.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        
    }
}