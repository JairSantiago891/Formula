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


    public class EncoderController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<EncodersIP> Get()
        {
            EncodersIP db = new EncodersIP();
            return Context.EncodersIP.ToList();
            
        }

        [HttpGet]
        public EncodersIP Get(System.Guid id)
        {
            return Context.EncodersIP.ToList().Find(c => c.PlazaId  == id);
        }
        [HttpPost]
        public IHttpActionResult AddEncodersIP([FromBody] EncodersIP itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.EncodersIP.ToList().Find (c=> c.EncoderId == itemPlaza.EncoderId ) ;
                if (plaza == null)
                {
                    Context.EncodersIP.Add(itemPlaza);
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("Plaza generada correctamente (OK)"));
                }
                else
                {                    
                    return Ok(new ResponseApiWeb("COD-001", "La plazaId ya existe en la base de datos"));
                }                
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IHttpActionResult PutEncodersIP(System.Guid id, [FromBody] EncodersIP plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.EncodersIP.Find(id);

                if (itemplaza != null)
                {
                     
                    itemplaza.ActivoFijo = plaza.ActivoFijo;
                    itemplaza.Serie = plaza.Serie;
                    itemplaza.FechaCompra = plaza.FechaCompra; 


                    Context.Entry(itemplaza).State = EntityState.Modified;                    
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("EncodersIP actualizado correctamente (OK)"));
                    //return Ok(itemplaza);
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
        public IHttpActionResult DeleteEncodersIP(System.Guid id)
        {

            var plaza = Context.EncodersIP.Find(id);
            if (plaza != null)
            {
                Context.EncodersIP.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("EncodersIP eliminado correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "El EncodersIP no existe en la base de datos"));
            }
            return NotFound();
        }

    }
}
