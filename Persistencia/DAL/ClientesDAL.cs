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
    public class ClientesDAL
    {
        private EFContext Cliente = new EFContext();

        public IQueryable<Cliente> ObterCliente()
        {
            return Cliente.Clientes.OrderBy(p => p.id);
        }
        public Cliente ObterClientePorcpf(string a)
        {
            return Cliente.Clientes.Where(f => f.cpf == a).First();
        }
        public void GravarCliente(Cliente a)
        {
            if (a.id == 0)
            {
                Cliente.Clientes.Add(a);
            }
            else
            {
                Cliente.Entry(a).State = EntityState.Modified;
            }
            Cliente.SaveChanges();
        }
        public Cliente EliminarCliente(Cliente a)
        {
            Cliente.Clientes.Remove(a);
            Cliente.SaveChanges();
            return a;
        }
    }
}

