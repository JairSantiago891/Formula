using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homer_MVC.Models
{
    public class PlazaModel
    {

        public PlazaModel()
        {

        }
        public PlazaModel(JsonRequest v)
        {
            if (v!= null)
            {
                PlazaId = v.PlazaId;
                this.NombrePlaza = v.NombrePlaza;
                this.NombreCorto = v.NombreCorto;
                this.NombreDirector = v.NombreDirector;
                this.TelefonoDirector = v.TelefonoDirector;
                this.CorreoDirector = v.CorreoDirector;
                this.NombreIngeniero = v.NombreIngeniero;
                this.TelefonoIngeniero = v.TelefonoIngeniero;
                this.CorreoIngeniero = v.CorreoIngeniero;
                this.PlazaActiva = v.PlazaActiva;
                if (v.Logo != null)
                    this.Logotipo = "data:image/jpeg;base64," + Convert.ToBase64String(v.Logo);
            } 
        }

        
        public System.Guid PlazaId { get; set; }
        [Required]
        public string NombrePlaza { get; set; }
        [Required]
        public string NombreCorto { get; set; }
        [Required]
        public string NombreDirector { get; set; }
        [Required]
        public string TelefonoDirector { get; set; }
        [Required]
        public string CorreoDirector { get; set; }
        [Required]
        public string NombreIngeniero { get; set; }
        [Required]
        public string TelefonoIngeniero { get; set; }
        [Required]
        public string CorreoIngeniero { get; set; }
        [Required]
        public bool PlazaActiva { get; set; }
        [Required]
        public HttpPostedFileBase Logo { get; set; }
        public String Logotipo { get; set; }
        public   TipoAccion Accion{ get; set; }


}
public enum TipoAccion
    {
    Alta,
    Baja,
    Eliminacion
}

}
