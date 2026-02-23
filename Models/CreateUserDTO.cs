namespace apiUsuarios.Models
{
    public class CreateUserDTO
    {
        // DTO (Data Transfer Object) criado para representar os dados necessários para criar um novo usuário, com as seguintes propriedades: Nome, Email, Senha e CPF. O DTO é utilizado para transferir os dados de criação de usuário entre a camada de apresentação (como um controlador) e a camada de negócios ou serviço, permitindo uma estrutura clara e organizada para os dados de criação de usuário.
        // facilida a comunicação e a manutenção do codigo, garantindo que as informações necessárias sejam fornecidas e formatadas corretamente antes de serem utilizadas para criar um novo usuário no sistema.
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;

    }
}
