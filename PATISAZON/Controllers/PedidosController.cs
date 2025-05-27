using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PATISAZON.Models;
using PagedList;

namespace PATISAZON.Controllers
{
    public class PedidosController : Controller
    {

        // GET: Pedidos
        [Authorize(Roles = "Administrador")]
        public ActionResult Pedidos(int? pageSize, int? page)
        {
            List<Pedidos>pedidos;
            pageSize = (pageSize ?? 12);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pedidos = db.Pedidos.ToList();
            }
            return View(pedidos.OrderByDescending(p => p.id).ToPagedList(page.Value, pageSize.Value));
        }

        // GET: Pedidos/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedidos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            List<Platillos>comidas = null;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                comidas = db.Platillos.ToList();
            }
            ViewBag.comidas = comidas;
            
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Pedidos pedidos)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View(pedidos);
                }
                try
                {
                    db.Pedidos.Add(pedidos);
                    db.SaveChanges();
                    return Redirect("~/Pedidos/Pedidos");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(pedidos);
                }
            }
        }

        // GET: Pedidos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(int id)
        {
            if (id < 0)
            {
                return Redirect("~/Pedidos/Pedidos");
            }
            Pedidos pedidos = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pedidos = db.Pedidos.Find(id);
            }
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Editar(int id, Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return View(pedidos);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("~/Pedidos/Pedidos");
            }
        }

        // GET: Pedidos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Eliminar(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var pedidos = db.Pedidos.Find(id);
                db.Pedidos.Remove(pedidos);
                db.SaveChanges();

            }
            return Redirect("~/Pedidos/Pedidos");
        }
    }
}
