using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APILocadoraCRUD.Models
{
    public class Locacao
    {
        [Key]
        public int IdLocacao { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("Data da Locação")]
        [DataType(DataType.Date, ErrorMessage = "O campo \"{0}\" deve conter uma data válida.")]
        public DateTime DataDaLocacao { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdFilme { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdFilme")]
        public Filme Filme { get; set; }

    }
}
