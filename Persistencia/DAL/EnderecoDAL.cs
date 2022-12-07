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
        private EFContext context = new EFContext();

        public IQueryable<Endereco> ObterEnderecos()
        {
            return context.Enderecos.OrderBy(b => b.EnderecoId);
        }
        public Endereco ObterEnderecoPorId(long Id)
        {
            return context.Enderecos.Where(f => f.EnderecoId == Id).First();
        }
        public void GravarEndereco(Endereco a)
        {
            if (a.EnderecoId == 0)
            {
                context.Enderecos.Add(a);
            }
            else
            {
                context.Entry(a).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Endereco EliminarEndereco(Endereco endereco)
        {
            context.Enderecos.Remove(endereco);
            context.SaveChanges();
            return endereco;
        }
    }
}
