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
    public class PetDAL
    {
        private EFContext Pet = new EFContext();

        public IQueryable<Pet> ObtePets()
        {
            return Pet.Pets.OrderBy(p => p.id);
        }
        public Pet ObterPetPorId(long a)
        {
            return Pet.Pets.Where(f => f.id == a).First();
        }
        public void GravarPet(Pet a)
        {
            if (a.id == 0)
            {
                Pet.Pets.Add(a);
            }
            else
            {
                Pet.Entry(a).State = EntityState.Modified;
            }
            Pet.SaveChanges();
        }
        public Pet EliminarPet(Pet a)
        {
            Pet.Pets.Remove(a);
            Pet.SaveChanges();
            return a;
        }
    }
}
