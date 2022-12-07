using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AtividadedeExame.Controllers
{
    public class PrestadoresController : Controller
    {
        private VeterinarioDAL Veterinarios = new VeterinarioDAL();
        // GET: Prestadores
        public ActionResult IndexVeterinario()
        {
            return View(Veterinarios.ObterVeterinarios());
        }
        public ActionResult CreateVeterinario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVeterinario(Veterinario a)
        {
            Veterinarios.GravarVeterinario(a);
            return RedirectToAction("IndexVeterinario");
        }
        public ActionResult DetailsVeterinario(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = Veterinarios.ObterVeterinarioPorId((long)Id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }
        public ActionResult EditVeterinario(long? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = Veterinarios.ObterVeterinarioPorId((long)Id);
            if(veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVeterinario(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                Veterinarios.GravarVeterinario(veterinario);
                return RedirectToAction("IndexVeterinario");
            }
            return View(veterinario);
        }
        public ActionResult DeleteVeterinario(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = Veterinarios.ObterVeterinarioPorId((long)Id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVeterinario(long Id)
        {
            Veterinario veterinario = Veterinarios.ObterVeterinarioPorId((long)Id);
            Veterinarios.EliminarVeterinario(veterinario);
            return RedirectToAction("IndexVeterinario");
        }
    }
}