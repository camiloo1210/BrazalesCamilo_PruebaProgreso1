using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrazalesCamilo_PruebaProgreso1.Models
{
    public class Celular
    {
        [Key]
        public int Id_celular { get; set; }
        [Required]
        [DisplayName("Modelo")]
        public string CelularNombre { get; set; }
        [Required]
        public int anio { get; set; }
        [Required]
        public double precio { get; set; }
    }
}
