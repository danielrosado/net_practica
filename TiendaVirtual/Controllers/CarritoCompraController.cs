using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    [Authorize]
    public class CarritoCompraController : Controller
    {
        private TiendaVirtualContainer db = new TiendaVirtualContainer();

        // GET: CarritoCompra
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc);
        }

        public ActionResult VolcarCarrito(CarritoCompra cc)
        {
           
            foreach (Producto producto in cc)
            {
                if (producto.Cantidad > 0)
                {
                    Pedido pedido = new Pedido();
                    pedido.IdProducto = producto.Id;
                    // TODO cantidad
                    pedido.Usuario = User.Identity.Name;
                    pedido.Fecha = DateTime.Now;

                    db.Pedidos.Add(pedido);
                    Producto prod = db.Productos.Find(producto.Id);
                    prod.Cantidad--;
                }
            }

            cc.Clear();
            db.SaveChanges();

            return RedirectToAction("Index", "Productos");
        }
    }
}