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
        public long? TelefoneId { get; set; }
        public long? EnderecoId { get; set; }
        public long? PetId
        {
            get; set;
        }
       public ICollection<Endereco> Enderecos { get; set; }
    }
}
