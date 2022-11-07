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


    public class TelefonoController : ApiController
    { 
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<Telefonos> Get()
        {
            Telefonos db = new Telefonos();
            return Context.Telefonos.ToList();
            
        }

        [HttpGet]
        public Telefonos Get(System.Guid id)
        {
            return Context.Telefonos.ToList().Find(c => c.PlazaId == id);
        }
        [HttpPost]
        public IHttpActionResult AddTelefonos([FromBody] Telefonos itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.Telefonos.ToList().Find(c => c.TelefonoId == itemPlaza.TelefonoId);
                 
                if (plaza == null)
                {
                    Context.Telefonos.Add(itemPlaza);
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
        public IHttpActionResult PutTelefonos(System.Guid id, [FromBody] Telefonos plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.Telefonos.Find(id);

                if (itemplaza != null)
                {
                    itemplaza.Numero = plaza.Numero;
                    itemplaza.MarcaId = plaza.MarcaId;
                    itemplaza.Internet = plaza.Internet;
                    itemplaza.Internet = plaza.Internet;
                    itemplaza.AnchoBanda = plaza.AnchoBanda;
                    itemplaza.TipoTelefono = plaza.TipoTelefono; 


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
        public IHttpActionResult DeleteTelefonos(System.Guid id)
        {

            var plaza = Context.Telefonos.Find(id);
            if (plaza != null)
            {
                Context.Telefonos.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("Telefonos eliminado correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "El Telefono Id no existe en la base de datos"));
            } 
        }

    }
}
