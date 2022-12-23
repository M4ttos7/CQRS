using System.ComponentModel.DataAnnotations;

namespace NSE.Identidade.API.Models
{
    public class UsuarioRegistro
    {
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "o campo {0} está em formato inválido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "o campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; } = null!;

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; } = null!;
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; } = null!;

    }
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; } = null!;
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; } = null!;
    }
    public class UsuarioToken
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IEnumerable<UsuarioClaim> Claims { get; set; } = null!;
    }

    public class UsuarioClaim
    {
        public string Type { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}