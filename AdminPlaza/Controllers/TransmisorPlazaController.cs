using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using AdminPlaza.Models.Plaza;
using Database;

namespace AdminPlaza.Controllers
{


    public class TransmisorPlazaController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<TransmisoresPlaza> Get()
        {
            Telefonos db = new Telefonos();
            return Context.TransmisoresPlaza.ToList();
            
        }

        [HttpGet]
        public TransmisoresPlaza Get(System.Guid id)
        {
            return Context.TransmisoresPlaza.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddTTransmisoresPlaza([FromBody] TransmisoresPlaza itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.TransmisoresPlaza.ToList().Find(c => c.TransmisorPlazaId == itemPlaza.TransmisorPlazaId);
                 
                if (plaza == null)
                {
                    Context.TransmisoresPlaza.Add(itemPlaza);
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("El TransmisoresPlaza generado correctamente (OK)"));
                }
                else
                {                    
                    return Ok(new ResponseApiWeb("COD-001", "El TransmisoresPlaza Id ya existe en la base de datos"));
                }                
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IHttpActionResult PutTransmisoresPlaza(System.Guid id, [FromBody] TransmisoresPlaza plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.TransmisoresPlaza.Find(id);

                if (itemplaza != null)
                { 
                    itemplaza.Frecuencia = plaza.Frecuencia;
                    itemplaza.TipoTransmisor = plaza.TipoTransmisor;
                    itemplaza.PlacaActiva = plaza.PlacaActiva;
                    itemplaza.NumeroSerie = plaza.NumeroSerie;
                    itemplaza.PotenciaMaxima = plaza.PotenciaMaxima;
                    itemplaza.FechaRegistro = plaza.FechaRegistro;
                    itemplaza.FechaCompra = plaza.FechaCompra; 


                    Context.Entry(itemplaza).State = EntityState.Modified;                    
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("TransmisoresPlaza actualizado correctamente (OK)"));
                   
                }
                else
                {
                    return Ok(new ResponseApiWeb("COD-002", "El TransmisoresPlaza no existe en la base de datos"));
                }
            }
            else
            {
                return BadRequest();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult DeleteTransmisoresPlaza(System.Guid id)
        {

            var plaza = Context.TransmisoresPlaza.Find(id);
            if (plaza != null)
            {
                Context.TransmisoresPlaza.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("TransmisoresPlaza eliminado correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "El TransmisoresPlaza Id no existe en la base de datos"));
            } 
        }

    }
}
