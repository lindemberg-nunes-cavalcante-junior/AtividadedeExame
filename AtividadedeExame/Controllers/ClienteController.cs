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
    public class ClienteController : Controller
    {
        private ClienteDAL Clientes = new ClienteDAL();
        private EnderecoDAL Enderecos = new EnderecoDAL();

        public ActionResult IndexEndereco() {
            ViewBag.UsuarioId = new SelectList(Clientes.ObterClientes(), "Id", "nome");
            return View(Enderecos.ObterEnderecos());
        }
        // GET: Cliente
        public ActionResult IndexCliente()
        {
            var clientes = Clientes.ObterClientes();
            return View(clientes);
        }
        public ActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(Cliente a)
        {
            Clientes.GravarCliente(a);
            return RedirectToAction("IndexCliente");
        }

        public ActionResult DetailsCliente(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente a = Clientes.ObterClientePorId((long)Id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        public ActionResult EditCliente(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente a = Clientes.ObterClientePorId((long)Id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(Cliente a)
        {
            if (ModelState.IsValid)
            {
                Clientes.GravarCliente(a);
                return RedirectToAction("IndexCliente");
            }
            return View(a);
        }

        public ActionResult DeleteCliente(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente a = Clientes.ObterClientePorId((long)Id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(long Id)
        {
            Cliente a = Clientes.ObterClientePorId((long)Id);
            Clientes.EliminarCliente(a);
            return RedirectToAction("IndexCliente");
        }
    }
}