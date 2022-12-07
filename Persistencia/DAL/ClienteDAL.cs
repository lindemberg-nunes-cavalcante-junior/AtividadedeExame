using Modelo;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Cliente> ObterClientes()
        {
            return context.Clientes.OrderBy(b => b.Id);
        }
        public Cliente ObterClientesPorId(long Id)
        {
            return context.Clientes.Where(f => f.Id == Id).First();
        }
        public void GravarCliente(Cliente a)
        {
            if (a.Id == 0)
            {
                context.Clientes.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Cliente EliminarCliente(Cliente cliente)
        {
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}
