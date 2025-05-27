using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PATISAZON.Models;
using System.Web.Helpers;
using System.Data.Entity;
using System.Net;

namespace PATISAZON.Controllers
{
    public class PlatillosController : Controller
    {
        // GET: Platillos
        [Authorize(Roles = "Administrador")]
        public ActionResult Platillos()
        {
            List<Platillos> comidas;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                comidas = db.Platillos.ToList();
            }
            return View(comidas);
        }

        // GET: Platillos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Platillos/Create
        [Authorize(Roles ="Administrador")]
        [HttpPost]
        public ActionResult Agregar(Platillos comidas)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View(comidas);
                }
                try
                {
                    db.Platillos.Add(comidas);
                    db.SaveChanges();
                    return Redirect("~/Platillos/Platillos");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("" ,e.Message);
                    return View(comidas);
                }
            }
            
        }

        // GET: Platillos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(int id)
        {
            if (id < 0)
            {
                return Redirect("~/Platillos/Platillos");
            }
            Platillos comidas = null;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                comidas = db.Platillos.Find(id);
            }
            return View(comidas);
        }

        // POST: Platillos/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Editar(int id, Platillos comidas)
        {
            if (!ModelState.IsValid)
            {
                return View(comidas);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(comidas).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("~/Platillos/Platillos");
            }
        }

        // GET: Platillos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Eliminar(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var comidas = db.Platillos.Find(id);
                db.Platillos.Remove(comidas);
                db.SaveChanges();

            }
            return Redirect("~/Platillos/Platillos");
        }

    }
}
