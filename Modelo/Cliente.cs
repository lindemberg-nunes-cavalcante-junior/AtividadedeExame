using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente:Usuario
    {
        public string cpf { get; set; }
        public Telefone telefone;
        public Endereco endereco;
        public Pet pet;
    }
}
