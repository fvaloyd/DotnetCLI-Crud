using System.ComponentModel.DataAnnotations;

namespace Practica.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(50)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(200)]
        public string? Descripcion { get; set; }
        [Display(Name ="Precio en RD")]
        public double Precio { get; set; }
        public bool Activo { get; set; }
        [Display(Name ="Fecha de alta")]
        public DateTime FechaDeAlta { get; set; }  
    }
}