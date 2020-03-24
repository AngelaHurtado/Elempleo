using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElempleoApiRest.Controllers
{
    public class VendedoresController : Controller
    {
        // GET: Vendedores
        public ActionResult Index()
        {
            ViewBag.Title = "Registrar Vendedor";
            return View();
        }
    }
}