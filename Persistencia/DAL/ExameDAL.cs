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
    public class ExameDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Exame> ObterExames()
        {
            return context.Exames.OrderBy(b => b.Id);
        }
        public Exame ObterExamePorId(long Id)
        {
            return context.Exames.Where(f => f.Id == Id).First();
        }
        public void GravarExame(Exame a)
        {
            if(a.Id == 0)
            {
                context.Exames.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Exame EliminarExame(Exame exame)
        {
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }
    }
}
