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


    public class ProcesadorAudioController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<ProcesadoresAudio> Get()
        {
            ProcesadoresAudio db = new ProcesadoresAudio();
            return Context.ProcesadoresAudio.ToList();
            
        }

        [HttpGet]
        public ProcesadoresAudio Get(System.Guid id)
        {
            return Context.ProcesadoresAudio.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddProcesadoresAudio([FromBody] ProcesadoresAudio itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.ProcesadoresAudio.ToList().Find(c => c.ProcesadorAudioId == itemPlaza.ProcesadorAudioId);
     
                if (plaza == null)
                {
                    Context.ProcesadoresAudio.Add(itemPlaza);
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
        public IHttpActionResult PutProcesadoresAudio(System.Guid id, [FromBody] ProcesadoresAudio plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.Microfonos.Find(id);

                if (itemplaza != null)
                {
                     
                    itemplaza.ActivoFijo = plaza.ActivoFijo;
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
        public IHttpActionResult DeleteProcesadoresAudio(System.Guid id)
        {

            var plaza = Context.ProcesadoresAudio.Find(id);
            if (plaza != null)
            {
                Context.ProcesadoresAudio.Remove(plaza);
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
