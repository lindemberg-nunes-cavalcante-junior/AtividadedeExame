using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Telefone
    {
        public long Id { get; set; }
        public string ddd { get; set; }
        public string numero { get; set; }
        public Cliente cliente;
        public long? ClienteId;
    }
}
