using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public long Id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; } 
        public string email { get; set; }
    }
}
