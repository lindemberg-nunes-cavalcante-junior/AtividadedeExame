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
    public class ExameController : Controller
    {
        private ExameDAL Exames = new ExameDAL();
        private ConsultaDAL consultas = new ConsultaDAL();
        // GET: Exame
        public ActionResult Index()
        {
            
            return View(Exames.ObterExames());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exame exame)
        {
            Exames.GravarExame(exame);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)id);
            if(exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exame exame)
        {
            if (ModelState.IsValid)
            {
                Exames.GravarExame(exame);
                return RedirectToAction("Index");
            }
            return View(exame);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)id);
            if(exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)id);
            if(exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Exame exame = Exames.ObterExamePorId(id);
            Exames.EliminarExame(exame);
            return RedirectToAction("Index");
        }
    }
}