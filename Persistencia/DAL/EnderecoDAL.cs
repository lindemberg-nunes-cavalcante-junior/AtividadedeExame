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
    public class EnderecoDAL
    {
        private EFContext Endereco = new EFContext();

        public IQueryable<Endereco> ObterEndereco()
        {
            return Endereco.Enderecos.OrderBy(p => p.Id);
        }
        public Endereco ObterEnderecoporId(long a)
        {
            return Endereco.Enderecos.Where(f => f.Id == a).First();
        }
        public void GravarEndereco(Endereco a)
        {
            if (a.Id == 0)
            {
                Endereco.Enderecos.Add(a);
            }
            else
            {
                Endereco.Entry(a).State = EntityState.Modified;
            }
            Endereco.SaveChanges();
        }
        public Endereco EliminarEndereco(Endereco a)
        {
            Endereco.Enderecos.Remove(a);
            Endereco.SaveChanges();
            return a;
        }
    }
}

