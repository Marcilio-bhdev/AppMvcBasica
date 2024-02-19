using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Models
{
    public class PrecoModel
    {
        public double Custo { get; set; }
        public double CustoAquisicao { get; set; }
        public DateTime Validade { get; set; }
        public DateTime ValidadeExpira { get; set; }
        public bool Refrigeracao { get; set; }
    }
}
