using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class CarritoCompraController : Controller
    {
        // GET: CarritoCompra
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc);
        }
    }
}