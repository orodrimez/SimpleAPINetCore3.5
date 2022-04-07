using System.ComponentModel.DataAnnotations;
using static ExamenYache.Models.Fruta;

namespace ExamenYache.Models.Dto
{
    public class FrutaCrearDto
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        public TipoPrecio PrecioPor { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Precio { get; set; }


    }
}
