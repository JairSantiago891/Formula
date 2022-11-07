using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPlaza.Models.Plaza
{
    public class Plaza
    {
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