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
    public class ProcedimentosController : Controller
    {
        private ExameDAL Exames = new ExameDAL();
        private ConsultaDAL Consultas = new ConsultaDAL();
        // GET: Procedimentos
        public ActionResult IndexExame()
        {
            return View(Exames.ObterExames());
        }
        public ActionResult ExameCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameCreate(Exame a)
        {
            Exames.GravarExame(a);
            return RedirectToAction("IndexExame");
        }

        public ActionResult ExameDetails(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        public ActionResult ExameEdit(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameEdit(Exame exame)
        {
            if (ModelState.IsValid)
            {
                Exames.GravarExame(exame);
                return RedirectToAction("IndexExame");
            }
            return View(exame);
        }
        public ActionResult ExameDelete(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameDelete(long Id)
        {
            Exame exame = Exames.ObterExamePorId((long)Id);
            Exames.EliminarExame(exame);
            return RedirectToAction("IndexExame");
        }










        //Parte de Consulta

        /*public ActionResult IndexConsulta()
        {
            ViewBag.Exame = new SelectList(Exames.ObterExames());
            return View(Consultas.ObterConsultas());
        }
        public ActionResult ConsultaCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameCreate(Exame a)
        {
            Exames.GravarExame(a);
            return RedirectToAction("IndexExame");
        }

        public ActionResult ExameDetails(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        public ActionResult ExameEdit(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameEdit(Exame exame)
        {
            if (ModelState.IsValid)
            {
                Exames.GravarExame(exame);
                return RedirectToAction("IndexExame");
            }
            return View(exame);
        }
        public ActionResult ExameDelete(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = Exames.ObterExamePorId((long)Id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExameDelete(long Id)
        {
            Exame exame = Exames.ObterExamePorId((long)Id);
            Exames.EliminarExame(exame);
            return RedirectToAction("IndexExame");
        }*/
    }
}