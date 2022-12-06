using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Consulta
    {
        public long? Id { get; set; }
        DateTime data_hora { get; set; }
        public string Sintomas { get; set; }
        public List<Exame> exames { get; set; }
    }
}
