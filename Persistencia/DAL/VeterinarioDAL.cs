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
        private EFContext Veterinario = new EFContext();

        public IQueryable<Veterinario> ObterVeterinario()
        {
            return Veterinario.Veterinarios.OrderBy(p => p.id);
        }
        public Veterinario ObterVeterinairoPorcrm(string a)
        {
            return Veterinario.Veterinarios.Where(f => f.crmv == a).First();
        }
        public void GravarVeterinario(Veterinario a)
        {
            if (a.id == 0)
            {
                Veterinario.Veterinarios.Add(a);
            }
            else
            {
                Veterinario.Entry(a).State = EntityState.Modified;
            }
            Veterinario.SaveChanges();
        }
        public Veterinario EliminarVeterinario(Veterinario a)
        {
            Veterinario.Veterinarios.Remove(a);
            Veterinario.SaveChanges();
            return a;
        }
    }

}
