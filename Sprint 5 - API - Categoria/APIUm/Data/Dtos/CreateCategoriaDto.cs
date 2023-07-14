using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIUm.Data.Dtos
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(128, ErrorMessage = "Informe uma categoria de até 128 caaracteres")]
        [RegularExpression(@"^[a-zA-Zà-úÁ-Ù' '\s]{1,40}$", ErrorMessage = "Informe uma categoria somente com letras")]
        public string Nome { get; set; }
        [JsonIgnore]
        public bool Status { get; set; } = true;
        [JsonIgnore]
        public string Tipo { get; set; } = "Categoria";
    }
}
