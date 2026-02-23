namespace apiUsuarios.Models
{
    public class LoginDto
    {
        // DTO (Data Transfer Object) criado para representar os dados de login, com as seguintes propriedades: Email e Senha. O DTO é utilizado para transferir os dados de login entre a camada de apresentação (como um controlador) e a camada de negócios ou serviço, permitindo uma estrutura clara e organizada para os dados de login.
        // Facilita a validação e o processamento dos dados de login, garantindo que as informações necessárias sejam fornecidas e formatadas corretamente antes de serem utilizadas para autenticação ou outras operações relacionadas ao login.
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
