using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models
{
    public class ResponsePlaza
    { 
        public string Code { get; set; }
        public string Message { get; set; }
        public bool  isError { get; set; } 
    }
}