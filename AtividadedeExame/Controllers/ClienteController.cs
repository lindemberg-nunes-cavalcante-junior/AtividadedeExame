using System.Net;
using System.Web.Mvc;
using Modelo;
using Persistencia.DAL;

namespace AtividadedeExame.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteDAL clienteDAL = new ClienteDAL();
        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteDAL.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        public ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteDAL.GravarCliente(cliente);
                    return RedirectToAction("index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        // GET: Clientes
        public ActionResult Index()
        {
            return View(clienteDAL.ObterClientesClassificadosPorCPF());
            
        }
        // Create get
        public ActionResult Create()
        {
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            
            GravarCliente(cliente);
            return RedirectToAction("../Telefones/Create", new { idCliente = cliente.UsuarioId });
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);

        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = clienteDAL.EliminarClientePorId(id);
                TempData["Message"] = "Cliente " + cliente.Cpf.ToUpper() + " foi removido";
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}