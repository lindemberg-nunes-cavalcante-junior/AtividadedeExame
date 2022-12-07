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
        private PetDAL Pets = new PetDAL();
        private ClienteDAL Clientes = new ClienteDAL();
       public ActionResult IndexPet()
        {
            ViewBag.EspecieId = new SelectList(Especies.ObterEspecies(), "Id", "nome");
            //ViewBag.ClienteId = new SelectList(Clientes.ObterClientes(), "Id", "nome");
            return View(Pets.ObterPets());
        }
        public ActionResult CreatePet()
        {
            ViewBag.EspecieId = new SelectList(Especies.ObterEspecies(), "Id", "nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePet(Pet a)
        {
            Pets.GravarPet(a);
            return RedirectToAction("IndexPet");
        }
        public ActionResult DetailsPet(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = Pets.ObterPetPorId((long)Id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieId = new SelectList(Especies.ObterEspecies(), "Id", "nome");
            return View(pet);
        }
        public ActionResult EditPet(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = Pets.ObterPetPorId((long)Id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieId = new SelectList(Especies.ObterEspecies(), "Id", "nome");
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPet(Pet pet)
        {
            if (ModelState.IsValid)
            {
                Pets.GravarPet(pet);
                return RedirectToAction("IndexPet");
            }
            return View(pet);
        }

        public ActionResult DeletePet(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = Pets.ObterPetPorId((long)Id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieId = new SelectList(Especies.ObterEspecies(), "Id", "nome");
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePet(long Id)
        {
            Pet pet = Pets.ObterPetPorId((long)Id);
            Pets.Eliminarpet(pet);
            return RedirectToAction("IndexPet");
        }
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