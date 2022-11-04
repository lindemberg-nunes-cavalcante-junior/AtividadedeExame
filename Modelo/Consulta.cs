using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Consulta
    {
        public long Id;
        public DateTime data_hora;
        public string sintomas;
        public List<Exame> exames;
    }
}
