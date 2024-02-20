using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Models
{
    public class PrecoModel
    {
        public string NomeProduto { get; set; }       
        public double Custo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }
        public bool Refrigeracao { get; set; }
        public double PrecoSugerido { get; set; }
     
    }
}
