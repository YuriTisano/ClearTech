using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIUm.Data.Dtos
{
    public class ReadCategoriaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(128, ErrorMessage = "Informe uma categoria de até 128 caaracteres")]
        public string Nome { get; set; }
        public string DataEHoradaConsulta { get; set; } = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss");

        public bool Status { get; set; }
        public string Tipo { get; set; } = "Categoria";

    }
}
