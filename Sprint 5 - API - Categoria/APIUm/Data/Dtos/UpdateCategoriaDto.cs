using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIUm.Data.Dtos
{
    public class UpdateCategoriaDto
    {
        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(128, ErrorMessage = "Informe uma categoria de até 128 caaracteres")]
        [RegularExpression(@"^[a-zA-Zà-úÁ-Ù' '\s]{1,40}$", ErrorMessage = "Informe uma categoria somente com letras")]
        public string Nome { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public string DataModificacao { get; set; } = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss");

    }
}
