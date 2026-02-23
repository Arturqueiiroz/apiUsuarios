using System.ComponentModel.DataAnnotations;

namespace apiUsuarios.Models
{
    // Entidade contruida para representar os usuarios do sistema, com as seguintes propriedades: como ID, Nome, Email, Senha, CPF e Data de Criação.
    // Entidade será criada mo Banco de dados utilizando o Entity Framework Core, onde a propriedade ID será a chave primária e as outras propriedades terão restrições de validação, como obrigatoriedade, tamanho máximo e formato de email.
    public class Usuario
    {
        [Key] // Annotation que especifica uma chave primaria
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(100, MinimumLength =3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve possui de 3 a 100 caracteres")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "CPF é um campo obrigatorio")]
        [StringLength(11, MinimumLength = 3, ErrorMessage = "O CPF deve conter exatamente 11 caracteres")]
        public string CPF { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;

    }
}
