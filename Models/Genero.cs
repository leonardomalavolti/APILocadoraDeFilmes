using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocadoraCRUD.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter no máximo {1} carateres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("Data de Criação")]
        [DataType(DataType.Date, ErrorMessage = "O campo \"{0}\" deve conter uma data válida.")]
        public DateTime DataDeCriacao { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public bool Ativo { get; set; }
    }
}
