using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ExamenYache.Models.Fruta;

namespace ExamenYache.Models.Dto
{
    public class FrutaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        public TipoPrecio PrecioPor { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Precio { get; set; }
        public bool Estatus { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
