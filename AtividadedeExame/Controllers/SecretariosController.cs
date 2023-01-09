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
    public class SecretariosController : Controller
    {
        private SecretarioDAL secretarioDAL = new SecretarioDAL();
        private ActionResult ObterVisaoSecretarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretario secretario = secretarioDAL.ObterSecretarioPorId((long)id);
            if (secretario == null)
            {
                return HttpNotFound();
            }
            return View(secretario);
        }
        private ActionResult GravarSecretario(Secretario secretario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    secretarioDAL.GravarSecretario(secretario);
                    return RedirectToAction("index");
                }
                return View(secretario);
            }
            catch
            {
                return View(secretario);
            }
        }
        // GET: Secretarios
        public ActionResult Index()
        {
            return View(secretarioDAL.ObterSecretariosClassificadosPorNome());
        }
        // Create get
        public ActionResult Create()
        {
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Secretario secretario)
        {
            return GravarSecretario(secretario);
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Secretario secretario)
        {
            return GravarSecretario(secretario);

        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Secretario secretario = secretarioDAL.EliminarSecretarioPorId(id);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}