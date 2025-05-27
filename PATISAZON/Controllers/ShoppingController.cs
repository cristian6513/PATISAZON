using PATISAZON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace PATISAZON.Controllers
{
    public class ShoppingController : Controller
    {
        private ApplicationDbContext db;
        public ShoppingController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Shopping
        [Authorize]
        public ActionResult Platillos()
        {
            List<Platillos> comidas;
            comidas = db.Platillos.ToList();
            return View(comidas);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Agregar(int id)
        {
            if (Session["carrito"] == null)
            {
                List<ShoppingCart> carro = new List<ShoppingCart>();
                carro.Add(new ShoppingCart(db.Platillos.Find(id), 1));
                Session["carrito"] = carro;
            }
            else
            {
                List<ShoppingCart> carro = (List<ShoppingCart>)Session["carrito"];
                int existe = GetPlatillos(id);
                if(existe == -1)
                {
                    carro.Add(new ShoppingCart(db.Platillos.Find(id), 1));

                }
                else
                {
                    carro[existe].Cantidad++;
                }
                Session["carrito"] = carro;
            }
            return Redirect("~/Shopping/Platillos");
        }

        private int GetPlatillos(int id)
        {
            List<ShoppingCart> carro = (List<ShoppingCart>)Session["carrito"];
            for(int i = 0; i < carro.Count(); i++)
            {
                if(carro[i].Food.id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        [Authorize]
        public ActionResult Carrito()
        {

            return View();
        }
        [Authorize]
        public ActionResult Eliminar(int id)
        {
            List<ShoppingCart> carro = (List<ShoppingCart>)Session["carrito"];
            carro.RemoveAt(GetPlatillos(id));

            return Redirect("~/Shopping/Carrito");
        }

        public ActionResult Comprar()
        {
            return View();
        }
        [Authorize]
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillos platillos = db.Platillos.Find(id);
            if (platillos == null)
            {
                return HttpNotFound();
            }
            return View(platillos);
        }
        public ActionResult Carrito2()
        {

            return View();
        }

        public ActionResult imagenpedido()
        {
            return new ViewAsImage("Carrito2") { FileName = "Pedido.jpg" };
        }
    }
}