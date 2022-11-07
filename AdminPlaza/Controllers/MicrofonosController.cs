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


    public class MicrofonosController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<Microfonos> Get()
        {
            Microfonos db = new Microfonos();
            return Context.Microfonos.ToList();
            
        }

        [HttpGet]
        public Microfonos Get(System.Guid id)
        {
            return Context.Microfonos.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddMicrofonos([FromBody] Microfonos itemPlaza)
        {
            if (ModelState.IsValid)
            { 
                var plaza = Context.Microfonos.ToList().Find(c => c.MicrofonoId == itemPlaza.MicrofonoId);
                if (plaza == null)
                {
                    Context.Microfonos.Add(itemPlaza);
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
        public IHttpActionResult PutMicrofonos(System.Guid id, [FromBody] Microfonos plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.Microfonos.Find(id);

                if (itemplaza != null)
                {
                     
                    itemplaza.ActivoFijo = plaza.ActivoFijo;
                    itemplaza.Serie = plaza.Serie;
                    itemplaza.FechaCompra = plaza.FechaCompra; 


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
        public IHttpActionResult DeleteMicrofonos(System.Guid id)
        {

            var plaza = Context.Microfonos.Find(id);
            if (plaza != null)
            {
                Context.Microfonos.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("Microfonos eliminado correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "El Microfonos Id no existe en la base de datos"));
            } 
        }

    }
}
