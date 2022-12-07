using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pet
    {
        public long PetId { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public long? EspecieId;
        public long? ClienteId;
        public Especie Especie;
        public Cliente Cliente;
        public TipoSexo sexo;
    }
}
