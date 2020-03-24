using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ElempleoApiRest.Models;
using System.Data.Entity;

namespace ElempleoApiRest.Controllers
{
    public class CiudadController : ApiController
    {
        ELEMPLEOEntities oEntities = new ELEMPLEOEntities();

        [HttpGet]
        public IEnumerable<CIUDAD> Get()
        {
            using (ELEMPLEOEntities oCiudadEntities = new ELEMPLEOEntities())
            {
                return oCiudadEntities.CIUDAD.ToList();
            }
        }

        [HttpGet]
        public CIUDAD Get(int codigo)
        {
            using (ELEMPLEOEntities oCiudadEntities = new ELEMPLEOEntities())
            {
                return oCiudadEntities.CIUDAD.FirstOrDefault(e => e.codigo == codigo);
            }
        }

        [HttpPost]
        public IHttpActionResult AddCiudad(CIUDAD oCiudad)
        {
            if (ModelState.IsValid)
            {                
                oCiudad.descripcion = oCiudad.descripcion;
                oEntities.CIUDAD.Add(oCiudad);
                oEntities.SaveChanges();
                return Ok(oCiudad);
            }            
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCiudad(int codigo, CIUDAD oCiudad)
        {
            if (ModelState.IsValid)
            {
                bool oCiudadExist = oEntities.CIUDAD.Count(c => c.codigo == codigo) > 0;
                if (oCiudadExist)
                {
                    oEntities.Entry(oCiudad).State = EntityState.Modified;
                    oEntities.SaveChanges();
                    return Ok(oCiudad);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCiudad(int codigo)
        {
            var oCiudad = oEntities.CIUDAD.Find(codigo);
            if(oCiudad != null)
            {
                VendedorController oVenContorller = new VendedorController();
                if(!oVenContorller.isVendedor(codigo))
                {
                    oEntities.CIUDAD.Remove(oCiudad);
                    oEntities.SaveChanges();
                    return Ok(oCiudad);
                }
                else
                {
                    return  BadRequest("No se puede eliminar la Ciudad, esta relacionada con Vendedores");
                }                
            }
            else
            {
                return BadRequest("La ciudad no existe, o ocurrio un problema interno");
            }
        }
    }
}
