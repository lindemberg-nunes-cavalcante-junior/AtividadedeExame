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
    public class AnimalController : Controller
    {
        private EspeciesDAL Especies = new EspeciesDAL();
        // GET: Animal
        public ActionResult IndexEspecie()
        {
            return View(Especies.ObterEspecie());
        }
        public ActionResult CreateEspecie()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEspecie(Especie a)
        {
            Especies.GravarEspecie(a);
            return RedirectToAction("IndexEspecie");
        }
        public ActionResult EditEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie a = Especies.ObterEspeciePorId((long)id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEspecie(Especie a)
        {
            if (ModelState.IsValid)
            {
                Especies.GravarEspecie(a);
                return RedirectToAction("IndexEspecie");
            }
            return View(a);
        }
        public ActionResult DetailsEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie a = Especies.ObterEspeciePorId((long)id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        public ActionResult DeleteEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie a = Especies.ObterEspeciePorId((long)id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEspecie(long id)
        {
            Especie a = Especies.ObterEspeciePorId(id);
            Especies.EliminarEspecie(a);
            return RedirectToAction("IndexEspecie");
        }


        // A partir daqui é de PET
        public ActionResult IndexAnimal()
        {
            return View();
        }
    }
}