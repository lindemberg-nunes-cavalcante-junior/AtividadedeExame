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
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Consulta> ObterConsultas()
        {
            return context.Consultas.OrderBy(b => b.Id);
        }
        public Exame ObterConsultaPorId(long Id)
        {
            return context.Exames.Where(f => f.Id == Id).First();
        }
        public void GravarConsulta(Consulta a)
        {
            if (a.Id == 0)
            {
                context.Consultas.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsulta(Consulta consulta)
        {
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }
    }
}
