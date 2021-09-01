using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocadoraCRUD.Models
{
    public class Cliente
    {
        public enum SituacaoCliente
        {
            Bloqueado,
            Cadastrado,
            Locado
        }

        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter no máximo {1} carateres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo \"{0}\" deve ser preenchido com 11 dígitos numéricos.")]
        [MaxLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [MinLength(11, ErrorMessage = "O campo \"{0}\" deve conter no mínimo {1} caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [RegularExpression(@"([0-9]){11}$", ErrorMessage = "O campo \"{0}\" deve ser preenchido com 11 dígitos numéricos.")]
        [MaxLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [MinLength(11, ErrorMessage = "O campo \"{0}\" deve conter no mínimo {1} caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "O campo \"{0}\" deve conter um endereço de e-mail válido.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("Situação")]
        public SituacaoCliente Situacao { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public bool Ativo { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }
    }
}
