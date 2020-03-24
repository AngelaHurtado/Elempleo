using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElempleoApiRest.Models
{
    public class VendedorModel
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Numero_Identificacion { get; set; }
        public CiudadModel Codigo_Ciudad { get; set; }
    }
}