using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrazalesCamilo_PruebaProgreso1.Models
{
    public class CBrazales
    {
        [Key]
        public int Id_usuario { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Tiene trabajo")]
        public bool Tiene_trabajo { get; set; }
        [Required]
        public DateTime Ingreso { get; set; }
        [Required]
        public double Salario   { get; set; }
        public Celular? Celular { get; set; }
        [Required]
        [ForeignKey("Celular")]
        public int Id_celular { get; set; }

    }
}
