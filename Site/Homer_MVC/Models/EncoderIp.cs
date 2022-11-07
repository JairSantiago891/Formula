using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models
{
    public class EncoderIp
    {
        public EncoderIp()
        {

        }
        public EncoderIp(string catalogo)
        {
            
            this.Catalogo = catalogo;
        }

        public EncoderIp(Guid  id)
        {

            this.PlazaId = id;
        }
        [Required]
        public Guid EncoderId { get; set; }
        [Required]
        public string Catalogo { get; set; }
        [Required]
        public Guid PlazaId { get; set; }
        [Required]
        public string ActivoFijo { get; set; }
        [Required]
        public string Serie { get; set; }
        [Required]
        public int  TipoTransmisor { get; set; }
        [Required]
        public string Frecuencia { get; set; }
        [Required]
        public double  PotenciaMaxima { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public string PlacaActiva { get; set; }
    }
}