using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElempleoApiRest.Models
{
    public class CiudadModel
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<VendedorModel> Vendedores { get; set; }
    }
}