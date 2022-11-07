using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models
{
    public class JsonRequest
    {

        public JsonRequest()
        {

        }
        public JsonRequest(PlazaModel v)
        {
            MemoryStream ms = new MemoryStream();
            v.Logo.InputStream.CopyTo(ms);
            PlazaId = Guid.NewGuid();
            this.NombrePlaza = v.NombrePlaza;
            this.NombreCorto = v.NombreCorto;
            this.NombreDirector = v.NombreDirector;
            this.TelefonoDirector = v.TelefonoDirector;
            this.CorreoDirector = v.CorreoDirector;
            this.NombreIngeniero = v.NombreIngeniero;
            this.TelefonoIngeniero = v.TelefonoIngeniero;
            this.CorreoIngeniero = v.CorreoIngeniero;
            this.PlazaActiva = v.PlazaActiva; 
            this.Logo = ms.ToArray();
        }
        public System.Guid PlazaId { get; set; }
        public string NombrePlaza { get; set; }
        public string NombreCorto { get; set; }
        public string NombreDirector { get; set; }
        public string TelefonoDirector { get; set; }
        public string CorreoDirector { get; set; }
        public string NombreIngeniero { get; set; }
        public string TelefonoIngeniero { get; set; }
        public string CorreoIngeniero { get; set; }
        public bool PlazaActiva { get; set; }
        public byte[] Logo { get; set; }
    } 
       
}
     
 