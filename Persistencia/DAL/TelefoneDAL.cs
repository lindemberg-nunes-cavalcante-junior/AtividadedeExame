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
        private EFContext Telefone = new EFContext();

        public IQueryable<Telefone> ObterTelefone()
        {
            return Telefone.Telefones.OrderBy(b => b.Id);
        }
        public Telefone ObterTelefonePorId(long id)
        {
            return Telefone.Telefones.Where(f => f.Id == id).First();
        }
        public void GravarTelefone(Telefone a)
        {
            if (a.Id == 0)
            {
                Telefone.Telefones.Add(a);
            }
            else
            {
                Telefone.Entry(a).State = EntityState.Modified;
            }
            Telefone.SaveChanges();
        }
        public Telefone EliminarTelefone(Telefone a)
        {
            Telefone.Telefones.Remove(a);
            Telefone.SaveChanges();
            return a;
        }
    }
}
