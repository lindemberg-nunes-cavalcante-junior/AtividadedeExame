using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persistencia.DAL;
using Modelo;
using System.Net;

namespace AtividadedeExame.Controllers
{
    public class ConsultaController: Controller
    {
        private ConsultaDAL Consultas = new ConsultaDAL();
        // GET: Exame
        public ActionResult Index()
        {
            return View(Consultas.ObterConsulta());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            Consultas.GravarConsulta(consulta);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = Consultas.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                Consultas.GravarConsulta(consulta);
                return RedirectToAction("Index");
            }
            return View(consulta);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = Consultas.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = Consultas.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Consulta consulta = Consultas.ObterConsultaPorId(id);
            Consultas.EliminarConsulta(consulta);
            return RedirectToAction("Index");
        }
    }
}