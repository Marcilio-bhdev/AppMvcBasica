using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Models
{
    public class PrecoModel
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "O valor de compra é obrigatório")]
        public double Custo { get; set; }

        
        [Required(ErrorMessage = "A validade é obrigatório")]
        [DateLessThanOrEqualToToday]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }
        public bool Refrigeracao { get; set; }
        public double PrecoSugerido { get; set; }


        public class DateLessThanOrEqualToToday : ValidationAttribute
        {
            public override string FormatErrorMessage(string name)
            {
                return "A data inserida não pode ser anterior a data de hoje";
            }

            protected override ValidationResult IsValid(object objValue,ValidationContext validationContext)
            {
                var dateValue = objValue as DateTime? ?? new DateTime();

                if (dateValue.Date < DateTime.Now.Date)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                return ValidationResult.Success;
            }
        }
    }
}
