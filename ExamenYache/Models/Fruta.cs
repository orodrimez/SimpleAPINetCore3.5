using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenYache.Models
{
    public class Fruta
    {
        //Id, Clave, Nombre, Precios[], Estatus, FechaRegistro, FechaModificacion
        [Key]
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public enum TipoPrecio { PrecioKilo, PrecioMedioKilo, PrecioDocena, PrecioCaja}
        public TipoPrecio PrecioPor { get; set; }
        public decimal Precio{get;set;}
        public bool Estatus { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
