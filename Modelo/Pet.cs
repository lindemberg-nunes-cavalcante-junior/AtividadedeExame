using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pet
    {
        public long Id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public Cliente cliente;
        public TipoSexo sexo;
    }
}
