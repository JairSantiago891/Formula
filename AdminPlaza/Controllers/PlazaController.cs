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


    public class PlazaController : ApiController
    {
        // private PosEntities Context = new PosEntities();
        private GrupoFormulaEntitiesAWS  Context = new GrupoFormulaEntitiesAWS();
        [HttpGet]
        public IEnumerable<Plaza> Get()
        {
            PlazaDao db = new PlazaDao();
            return db.ListaPlaza(null);
            //using (GrupoFormulaEntitiesAWS db = new GrupoFormulaEntitiesAWS())
            //{
            //    return db.PLAZA.ToList();
            //}
        }

        [HttpGet]
        public PLAZA Get(System.Guid id)
        {
            return Context.PLAZA.Find(id);  
        }
        [HttpPost]
        public IHttpActionResult AddPlaza([FromBody] PLAZA itemPlaza)
        {
            if (ModelState.IsValid)
            {
                var plaza = Context.PLAZA.Find(itemPlaza.PlazaId);
                if (plaza == null)
                {
                    Context.PLAZA.Add(itemPlaza);
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
        public IHttpActionResult PutPlaza(System.Guid id, [FromBody] PLAZA plaza)
        {
            if (ModelState.IsValid)
            {
                var itemplaza = Context.PLAZA.Find(id);

                if (itemplaza != null)
                {
                    itemplaza.NombreCorto = plaza.NombreCorto;
                    itemplaza.NombrePlaza = plaza.NombrePlaza;
                    itemplaza.NombreDirector = plaza.NombreDirector;
                    itemplaza.TelefonoDirector = plaza.TelefonoDirector;
                    itemplaza.CorreoDirector = plaza.CorreoDirector;                    
                    itemplaza.TelefonoIngeniero = plaza.TelefonoDirector;
                    itemplaza.CorreoIngeniero = plaza.TelefonoDirector;
                    itemplaza.PlazaActiva  = plaza.PlazaActiva;
                    itemplaza.NombreIngeniero = plaza.NombreIngeniero;
                    itemplaza.Telefonos = plaza.Telefonos;
                    itemplaza.Logo  = plaza.Logo;


                    Context.Entry(itemplaza).State = EntityState.Modified;                    
                    Context.SaveChanges();
                    return Ok(new ResponseApiWeb("Plaza actualizada correctamente (OK)"));
                    //return Ok(itemplaza);
                }
                else
                {
                    return Ok(new ResponseApiWeb("COD-002", "La plazaId no existe en la base de datos"));
                }
            }
            else
            {
                return BadRequest();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult DeletePlaza(System.Guid id)
        {

            var plaza = Context.PLAZA.Find(id);
            if (plaza != null)
            {
                Context.PLAZA.Remove(plaza);
                Context.SaveChanges();
                return Ok(new ResponseApiWeb("Plaza eliminada correctamente (OK)"));
            }
            else
            {
                return Ok(new ResponseApiWeb("COD-002", "La plazaId no existe en la base de datos"));
            }
            return NotFound();
        }

    }
}
