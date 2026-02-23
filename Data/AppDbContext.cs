using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using apiUsuarios.Models;
namespace apiUsuarios.Data
{
    public class AppDbContext : DbContext
    {
        // Configura ocontexto do Entity Framework, que é a camada de acesso a dados da aplicação, onde é definido o DbSet para a entidade Usuario, permitindo que as operações de CRUD sejam realizadas no banco de dados utilizando o Entity Framework Core.
        // A herança de DbContext é fundamental para a configuração e uso do Entity Framework Core, pois fornece os métodos e propriedades necessários para interagir com o banco de dados, como consultas, inserções, atualizações e exclusões de dados.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Propriedade do tipo DbSet<Usuario> chamada Usuarios, que representa a coleção de entidades Usuario no banco de dados. Essa propriedade é usada para realizar operações de consulta e manipulação de dados relacionados aos usuários, como criar, ler, atualizar e excluir registros na tabela correspondente no banco de dados. O Entity Framework Core utiliza essa propriedade para mapear a entidade Usuario para a tabela do banco de dados e facilitar as operações de acesso a dados.
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
