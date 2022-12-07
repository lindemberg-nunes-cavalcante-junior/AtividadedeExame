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
    public class TelefoneDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Telefone> ObterTelefones()
        {
            return context.Telefones.OrderBy(b => b.TelefoneId);
        }
        public Telefone ObterVeterinarioPorId(long Id)
        {
            return context.Telefones.Where(f => f.TelefoneId == Id).First();
        }
        public void GravarTelefone(Telefone a)
        {
            if (a.TelefoneId == 0)
            {
                context.Telefones.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Telefone EliminarTelefone(Telefone telefone)
        {
            context.Telefones.Remove(telefone);
            context.SaveChanges();
            return telefone;
        }
    }
}
