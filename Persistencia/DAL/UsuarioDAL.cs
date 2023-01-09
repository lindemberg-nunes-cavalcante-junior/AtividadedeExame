using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Usuario> ObterUsuariosClassificadosPorNome()
        {
            return context.Usuarios.OrderBy(b => b.Nome);
        }
        public Usuario ObterUsuariosPorId(long id)
        {
            return context.Usuarios.Where(f => f.UsuarioId == id).First();
        }
        public void GravarUsuario(Usuario usuario)
        {
            if (usuario.UsuarioId == 0)
            {
                context.Usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = ObterUsuariosPorId(id);
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }

    }
}
