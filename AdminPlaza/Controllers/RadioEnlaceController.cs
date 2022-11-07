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


    public class RadioEnlaceController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<RadioEnlaces> Get()
        {
            RadioEnlaces db = new RadioEnlaces();
            return Context.RadioEnlaces.ToList();
            
        }

        [HttpGet]
        public RadioEnlaces Get(System.Guid id)
        {
            return Context.RadioEnlaces.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddRadioEnlaces([FromBody] RadioEnlaces itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.RadioEnlaces.ToList().Find(c => c.RadioEnlaceId == itemPlaza.RadioEnlaceId);
                 
                if (plaza == null)
                {
                    Context.RadioEnlaces.Add(itemPlaza);
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
        public IHttpActionResult PutRadioEnlaces(System.Guid id, [FromBody] RadioEnlaces plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.RadioEnlaces.Find(id);

                if (itemplaza != null)
                {
                     
                    itemplaza.ActivoFijo = plaza.ActivoFijo;
                    itemplaza.Serie = plaza.Serie;
                    itemplaza.Frecuencia = plaza.Frecuencia;
                    itemplaza.Serie = plaza.Serie;

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
