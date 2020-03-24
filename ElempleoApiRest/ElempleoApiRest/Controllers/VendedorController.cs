using ElempleoApiRest.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace ElempleoApiRest.Controllers
{
    public class VendedorController : ApiController
    {
        ELEMPLEOEntities oEntities = new ELEMPLEOEntities();

        [HttpGet]
        public IEnumerable<VendedorModel> Get()
        {
            using (ELEMPLEOEntities oVendedorEntities = new ELEMPLEOEntities())
            {
                List<VENDEDOR> oVendedores = oVendedorEntities.VENDEDOR.ToList();
                List<VendedorModel> oVenModel = new List<VendedorModel>();
                foreach(VENDEDOR oVendedor in oVendedores)
                {
                    VendedorModel oVende = new VendedorModel();
                    oVende.Codigo = oVendedor.codigo;
                    oVende.Nombre = oVendedor.nombre;
                    oVende.Apellido = oVendedor.apellido;
                    oVende.Numero_Identificacion = oVendedor.numero_identificacion;
                    CiudadModel oCiudadModel = new CiudadModel();
                    oCiudadModel.Codigo = oVendedor.codigo_ciudad;
                    CiudadController oController = new CiudadController();
                    CIUDAD oCiudad = oController.Get(oCiudadModel.Codigo);
                    oCiudadModel.Descripcion = oCiudad.descripcion;
                    oVende.Codigo_Ciudad = oCiudadModel;
                    oVenModel.Add(oVende);
                }
                return oVenModel.ToList();
            }
        }

        [HttpGet]
        public VENDEDOR Get(int codigo)
        {
            using (ELEMPLEOEntities oVendedorEntities = new ELEMPLEOEntities())
            {
                return oVendedorEntities.VENDEDOR.FirstOrDefault(e => e.codigo == codigo);
            }
        }

        [HttpPost]
        public IHttpActionResult AddVendedor(VENDEDOR oVendedor)
        {
            if (ModelState.IsValid)
            {
                oVendedor.nombre = oVendedor.nombre;
                oVendedor.apellido = oVendedor.apellido;
                oVendedor.numero_identificacion = oVendedor.numero_identificacion;
                oVendedor.codigo_ciudad = oVendedor.codigo_ciudad;
                oEntities.VENDEDOR.Add(oVendedor);
                oEntities.SaveChanges();
                return Ok(oVendedor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateVendedor(int codigo, VENDEDOR oVendedor)
        {
            if (ModelState.IsValid)
            {
                bool oVendedorExist = oEntities.VENDEDOR.Count(c => c.codigo == codigo) > 0;
                if (oVendedorExist)
                {
                    oEntities.Entry(oVendedor).State = EntityState.Modified;
                    oEntities.SaveChanges();
                    return Ok(oVendedor);
                }
                else
                {
                    return BadRequest("El Vendedor no existe, o ocurrio un problema interno");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteVendedor(int codigo)
        {
            var oVendedor = oEntities.VENDEDOR.Find(codigo);
            if (oVendedor != null)
            {
                oEntities.VENDEDOR.Remove(oVendedor);
                oEntities.SaveChanges();
                return Ok(oVendedor);
            }
            else
            {
                return BadRequest("No se puede eliminar el Vendedor");
            }
        }
        
        public bool isVendedor(int idCiudad)
        {
            using (ELEMPLEOEntities oVendedorEntities = new ELEMPLEOEntities())
            {
                return oVendedorEntities.VENDEDOR.FirstOrDefault(e => e.codigo_ciudad == idCiudad) != null;
            }
        }
    }
}
