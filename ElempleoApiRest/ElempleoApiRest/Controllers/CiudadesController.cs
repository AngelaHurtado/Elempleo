using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElempleoApiRest.Controllers
{
    public class CiudadesController : Controller
    {
        // GET: Ciudades
        public ActionResult Index()
        {
            ViewBag.Title = "Registrar Ciudad";
            return View();
        }
    }
}