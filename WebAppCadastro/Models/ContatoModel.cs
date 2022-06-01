using System.ComponentModel.DataAnnotations;

namespace WebAppCadastro.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail digitado é invalido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone deve ser preenchido!")]
        [Phone(ErrorMessage = "O telefone celular não é valido!")]
        public string Telefone { get; set; }
    }
}
