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


    public class ReceptorSatelitaController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<ReceptoresSatelitales> Get()
        {
            ReceptoresSatelitales db = new ReceptoresSatelitales();
            return Context.ReceptoresSatelitales.ToList();
            
        }

        [HttpGet]
        public ReceptoresSatelitales Get(System.Guid id)
        {
            return Context.ReceptoresSatelitales.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddReceptoresSatelitales([FromBody] ReceptoresSatelitales itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.ReceptoresSatelitales.ToList().Find(c => c.ReceptorSatelitalId == itemPlaza.ReceptorSatelitalId);
                 
                if (plaza == null)
                {
                    Context.ReceptoresSatelitales.Add(itemPlaza);
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("El Microfono generado correctamente (OK)"));
                }
                else
                {                    
                    return Ok(new ResponseApiWeb("COD-001", "El Microfono Id ya existe en la base de datos"));
                }                
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IHttpActionResult PutReceptoresSatelitales(System.Guid id, [FromBody] ReceptoresSatelitales plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.ReceptoresSatelitales.Find(id);

                if (itemplaza != null)
                {
                     
                    itemplaza.ActivoFijo = plaza.ActivoFijo;
                    itemplaza.Serie = plaza.Serie;
                    itemplaza.FechaCompra = plaza.FechaCompra;
                    itemplaza.ModeloId = plaza.ModeloId;

                    Context.Entry(itemplaza).State = EntityState.Modified;                    
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("EncodersIP actualizado correctamente (OK)"));
                   
                }
                else
                {
                    return Ok(new ResponseApiWeb("COD-002", "El EncodersId no existe en la base de datos"));
                }
            }
            else
            {
                return BadRequest();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRadioEnlaces(System.Guid id)
        {

            var plaza = Context.RadioEnlaces.Find(id);
            if (plaza != null)
            {
                Context.RadioEnlaces.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("RadioEnlaces eliminado correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "El RadioEnlace Id no existe en la base de datos"));
            } 
        }

    }
}
