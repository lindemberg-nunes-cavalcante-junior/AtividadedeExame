using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia.DAL;
using Persistencia.Contexts;

namespace AtividadedeExame.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        // GET: Usuarios
        public ActionResult IndexUsuario()
        {
            return View(usuarioDAL.ObterUsuariosClassificadosPorNome());
        }

        // GET: Usuarios/Details/5
        public ActionResult DetailsUsuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult CreateUsuario()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult CreateUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarUsuario(usuario);
                    return RedirectToAction("IndexUsuario");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult EditUsuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarUsuario(usuario);
                    return RedirectToAction("IndexUsuario");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult DeleteUsuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsuario(long id)
        {
            try
            {
                Usuario usuario = usuarioDAL.EliminarUsuarioPorId(id);
                return RedirectToAction("Indexusuario");
            }
            catch
            {
                return View();
            }
        }
    }
}