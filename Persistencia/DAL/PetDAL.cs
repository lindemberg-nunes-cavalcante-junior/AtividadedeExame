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
        private EFContext context = new EFContext();

        public IQueryable<Pet> ObterPets()
        {
            return context.Pets.OrderBy(b => b.PetId);
        }
        public Pet ObterPetPorId(long Id)
        {
            return context.Pets.Where(f => f.PetId == Id).First();
        }
        public void GravarPet(Pet a)
        {
            if (a.PetId == 0)
            {
                context.Pets.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Pet Eliminarpet(Pet pet)
        {
            context.Pets.Remove(pet);
            context.SaveChanges();
            return pet;
        }
    }
}
