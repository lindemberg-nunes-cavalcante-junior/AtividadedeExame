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
    public class VeterinarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Veterinario> ObterVeterinarios()
        {
            return context.Veterinarios.OrderBy(b => b.Id);
        }
        public Veterinario ObterVeterinarioPorId(long Id)
        {
            return context.Veterinarios.Where(f => f.Id == Id).First();
        }
        public void GravarVeterinario(Veterinario a)
        {
            if (a.Id == 0)
            {
                context.Veterinarios.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Veterinario EliminarVeterinario(Veterinario veterinario)
        {
            context.Veterinarios.Remove(veterinario);
            context.SaveChanges();
            return veterinario;
        }
    }
}
