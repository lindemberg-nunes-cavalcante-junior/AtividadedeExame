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
        private EspecieDAL Especies = new EspecieDAL();
        // GET: Animal
        public ActionResult IndexEspecie()
        {
            return View(Especies.ObterEspecies());
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

        public ActionResult DetailsEspecie(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = Especies.ObterEspeciePorId((long)Id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }
        public ActionResult EditEspecie(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = Especies.ObterEspeciePorId((long)Id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEspecie(Especie especie)
        {
            if (ModelState.IsValid)
            {
                Especies.GravarEspecie(especie);
                return RedirectToAction("IndexEspecie");
            }
            return View(especie);
        }

        public ActionResult DeleteEspecie(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = Especies.ObterEspeciePorId((long)Id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEspecie(long Id)
        {
            Especie especie = Especies.ObterEspeciePorId((long)Id);
            Especies.EliminarEspecie(especie);
            return RedirectToAction("IndexEspecie");
        }
    }
}