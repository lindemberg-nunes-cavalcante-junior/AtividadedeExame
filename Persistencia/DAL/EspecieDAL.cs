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
    public class EspecieDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Especie> ObterEspecies()
        {
            return context.Especies.OrderBy(b => b.Id);
        }
        public Especie ObterEspeciePorId(long Id)
        {
            return context.Especies.Where(f => f.Id == Id).First();
        }
        public void GravarEspecie(Especie a)
        {
            if (a.Id == 0)
            {
                context.Especies.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Especie EliminarEspecie(Especie especie)
        {
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}
