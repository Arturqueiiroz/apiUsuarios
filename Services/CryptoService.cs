using BCrypt.Net;
namespace apiUsuarios.Services
{
    public class CryptoService
    {
        // Gerar um hash da senha fornecida utilizando o método HashPassword da biblioteca BCrypt.Net. O hash gerado é retornado como resultado, permitindo que a senha seja armazenada de forma segura no banco de dados.
        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        // Verifica se a senha fornecida corresponde à senha criptografada armazenada, utilizando o método Verify da biblioteca BCrypt.Net. Retorna true se as senhas corresponderem e false caso contrário.
        public static bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }


    }
}
