using Homer_MVC.Common;
using Homer_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace Homer_MVC.Controllers
{
    public class MainController : Controller
    {
        private string ApiPlaza = "http://webapi-prod-formula.us-east-2.elasticbeanstalk.com/Api/Plaza";
        private string imageDummy = "data:image/jpeg;base64,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";
        public ActionResult Index()
        {
            Session["plaza"] = ApiConnect.GetPlaza();
            ViewBag.Logo = imageDummy;
            Session["logo"] = imageDummy;
            ViewBag.edit = "disabled";
            return View();
        }
        public ActionResult Detalle(Guid valor)
        {


            var v = ApiConnect.GetPlaza(valor);

            if (v == null)
            {
                return RedirectToAction("Index", "Main", null);
            }
            ViewBag.PlazaId = v.PlazaId;
            ViewBag.NombrePlaza = v.NombrePlaza;
            ViewBag.NombreCorto = v.NombreCorto;
            ViewBag.NombreDirector = v.NombreDirector;
            ViewBag.TelefonoDirector = v.TelefonoDirector;
            ViewBag.CorreoDirector = v.CorreoDirector;
            ViewBag.NombreIngeniero = v.NombreIngeniero;
            ViewBag.TelefonoIngeniero = v.TelefonoIngeniero;
            ViewBag.CorreoIngeniero = v.CorreoIngeniero;
            ViewBag.PlazaActiva = v.PlazaActiva;
            ViewBag.Logo = v.Logo != null ? String.Format("data:image/png;base64,{0}", ApiConnect.GetB64(v.Logo)) : imageDummy;
            ViewBag.edit = "";
            Session["IdPlaza"] = v;
            return View("Index");
        }


        public ActionResult Create( )
        {
            ViewBag.imageDummy = imageDummy;
            return PartialView();
        }

        [HttpPost]
        public ActionResult file(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(PlazaModel nuevo)
        { 
            if (nuevo.PlazaId ==  new Guid ())
            {
                nuevo.PlazaId = Guid.NewGuid();
                var instancia = new ResponsePlaza();
                if (ApiConnect.ConnectRest( ApiPlaza,
                     nuevo, ref instancia))
                {
                    return RedirectToAction("Index", "Main", null);
                }
            }
            else
            { 
                var instancia = new ResponsePlaza();
                if (ApiConnect.ActualizaConnectRest(ApiPlaza,
                     nuevo, ref instancia))
                {
                    return RedirectToAction("Index", "Main", null);
                }
                
            }
           
            return PartialView();

        }

        public ActionResult Edit()
        {
            PlazaModel model =  new PlazaModel ((JsonRequest) Session["IdPlaza"]) ;

            @ViewBag.imageDummy = model.Logotipo;
            return PartialView(model);
        }

         
        [HttpPost]
        public ActionResult Edit(PlazaModel nuevo)
        { 
            var instancia = new ResponsePlaza();
            if (ApiConnect.ConnectRest(ApiPlaza,
                 nuevo, ref instancia))
            {
                return RedirectToAction("Index", "Main", null);
            }
            return PartialView();
        } 
            public ActionResult Delete()
        {
            PlazaModel model = new PlazaModel((JsonRequest)Session["IdPlaza"]); 
            @ViewBag.imageDummy = model.Logotipo;
            return PartialView(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(PlazaModel elimina)
        {
              elimina = new PlazaModel((JsonRequest)Session["IdPlaza"]);
            var instancia = new ResponsePlaza();
            if (ApiConnect.DeleteConnectRest (ApiPlaza,
                 elimina, ref instancia))
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Page2()
        {
            return View();
        }

        public ActionResult Plaza(bool status)
        {
            return View("Index");
        }

        public class ImageUpload
        {
            public int ID { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            [AllowHtml]
            public string Contents { get; set; }

            public byte[] Image { get; set; }
        }


    }
}
