using System.ComponentModel.DataAnnotations;

namespace Practica.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaDeAlta { get; set; }  
    }
}