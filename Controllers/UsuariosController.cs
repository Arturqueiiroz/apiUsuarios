using apiUsuarios.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiUsuarios.Models;
using apiUsuarios.Services;

namespace apiUsuarios.Controllers
{
    // ApiController é uma annotation que indica que a classe é um controlador de API, o que significa que ela lida com solicitações HTTP e retorna respostas em formato JSON ou XML, em vez de renderizar páginas HTML como um controlador tradicional. A annotation Route("[controller]") define a rota base para os endpoints do controlador, onde [controller] é um placeholder que será substituído pelo nome do controlador (neste caso, "Usuarios"), permitindo que as rotas sejam acessadas usando a URL base seguida pelo nome do controlador (por exemplo, /Usuarios).
    [ApiController]
    // Route é uma annotation que define a rota base para os endpoints do controlador. O placeholder [controller] é substituído pelo nome do controlador, permitindo que as rotas sejam acessadas usando a URL base seguida pelo nome do controlador (por exemplo, /Usuarios).
    // Fica azul para indicar que é uma rota de controlador, e o [controller] é um placeholder que será substituído pelo nome do controlador, permitindo que as rotas sejam acessadas usando a URL base seguida pelo nome do controlador (por exemplo, /Usuarios).
    [Route("[controller]")]
    // Usuario Controller é a classe que representa o controlador de usuários, responsável por lidar com as solicitações relacionadas aos usuários do sistema, como criar um novo usuário, obter a lista de usuários e realizar o login. O controlador utiliza o AppDbContext para acessar o banco de dados e realizar as operações necessárias para gerenciar os usuários.
    // UsuariosController - dever sempre ter o sufixo "Controller" para seguir a convenção do ASP.NET Core, indicando que é um controlador de API. O controlador é responsável por lidar com as solicitações HTTP relacionadas aos usuários, como criar um novo usuário, obter a lista de usuários e realizar o login. Ele utiliza o AppDbContext para acessar o banco de dados e realizar as operações necessárias para gerenciar os usuários.
    // herda de ControllerBase é fundamental para a criação de um controlador de API no ASP.NET Core, pois fornece os métodos e propriedades necessários para lidar com as solicitações HTTP e retornar respostas adequadas, como Ok(), BadRequest(), NotFound() e Unauthorized(), facilitando a construção de endpoints de API robustos e eficientes.
    public class UsuariosController : ControllerBase
    {
        // Injeção de dependência do AppDbContext, que é o contexto do Entity Framework utilizado para acessar o banco de dados. O construtor do controlador recebe uma instância do AppDbContext como parâmetro e a atribui a uma variável privada, permitindo que o controlador utilize o contexto para realizar operações de acesso a dados relacionadas aos usuários.
        private readonly AppDbContext _appDbContext;
        public UsuariosController(AppDbContext appDbContext)
        {
            // O Constructor do controlador recebe uma instância do AppDbContext como parâmetro e a atribui a uma variável privada, permitindo que o controlador utilize o contexto para realizar operações de acesso a dados relacionadas aos usuários. A injeção de dependência é uma prática comum em ASP.NET Core para promover a modularidade e facilitar o teste do código, permitindo que as dependências sejam fornecidas externamente em vez de serem criadas diretamente dentro do controlador.
            // A injeção de dependência é uma prática comum em ASP.NET Core para promover a modularidade e facilitar o teste do código, permitindo que as dependências sejam fornecidas externamente em vez de serem criadas diretamente dentro do controlador. Isso torna o código mais flexível, testável e fácil de manter, pois as dependências podem ser facilmente substituídas por implementações alternativas durante os testes ou em diferentes ambientes de execução.
            _appDbContext = appDbContext;
        }
        // HttpGet é uma annotation que indica que o método GetAllAsync() é um endpoint de API que responde a solicitações HTTP GET, permitindo que os clientes obtenham a lista de usuários do sistema. O método utiliza o AppDbContext para acessar o banco de dados e retornar a lista de usuários em formato JSON.
        // getAllAsync() é um método assíncrono que retorna uma lista de usuários do sistema. Ele utiliza o AppDbContext para acessar o banco de dados e obter a lista de usuários, retornando-a em formato JSON como resposta à solicitação HTTP GET.
        [HttpGet("getAll")]
        // Sufixo async - boa pratica em .Net para indicar que o método é assíncrono, ou seja, ele pode ser executado de forma assíncrona, permitindo que o servidor continue a processar outras solicitações enquanto aguarda a conclusão da operação de acesso ao banco de dados. O uso do sufixo async é uma convenção amplamente adotada na comunidade .NET para melhorar a legibilidade do código e facilitar a identificação de métodos assíncronos.
        // IActionResult é um tipo de retorno que representa o resultado de uma ação em um controlador de API. Ele permite retornar diferentes tipos de respostas HTTP, como Ok(), BadRequest(), NotFound() e Unauthorized(), dependendo do resultado da operação realizada pelo método. O uso de IActionResult torna o código mais flexível e expressivo, permitindo que o controlador retorne respostas adequadas com base no contexto da solicitação.
        public async Task<IActionResult> GetAllAsync()
        {
            // Listando todos os usuários do banco de dados utilizando o AppDbContext e retornando a lista em formato JSON como resposta à solicitação HTTP GET. O método utiliza o método ToListAsync() para obter a lista de  usuários de forma assíncrona, permitindo que o servidor continue a processar outras solicitações enquanto aguarda a conclusão da operação de acesso ao banco de dados. O resultado é retornado usando o método Ok(), indicando que a solicitação foi bem-sucedida e fornecendo a lista de usuários como resposta.
            List<Usuario> userList = await _appDbContext.Usuarios.ToListAsync();
            // returne ok - status code 200, indicando que a solicitação foi bem-sucedida e fornecendo a lista de usuários como resposta. O método Ok() é um método de conveniência que retorna um objeto OkObjectResult, que é uma implementação de IActionResult que representa uma resposta HTTP 200 OK com um corpo de resposta contendo os dados fornecidos (neste caso, a lista de usuários). O uso do método Ok() torna o código mais expressivo e fácil de entender, indicando claramente que a solicitação foi bem-sucedida e fornecendo os dados solicitados como resposta.
            return Ok(userList);
        }
        // HttpPost é uma annotation que indica que o método CreateUserAsync() é um endpoint de API que responde a solicitações HTTP POST, permitindo que os clientes criem um novo usuário no sistema. O método recebe os dados do usuário no corpo da solicitação (usando [FromBody]) e utiliza o AppDbContext para salvar o novo usuário no banco de dados, retornando uma resposta adequada com base no resultado da operação.
        [HttpPost("create")]
        // CreateUserAsync() é um método assíncrono que permite criar um novo usuário no sistema. Ele recebe os dados do usuário no corpo da solicitação (usando [FromBody]) e utiliza o AppDbContext para salvar o novo usuário no banco de dados. O método verifica se os dados fornecidos são válidos e retorna uma resposta adequada com base no resultado da operação, como Ok() para indicar que o usuário foi criado com sucesso ou BadRequest() para indicar que houve um erro ao criar o usuário.
        // CreateUserDTO é um objeto de transferência de dados (DTO) que representa os dados necessários para criar um novo usuário. Ele contém propriedades como Nome, Email, Senha e CPF, que são usadas para receber os dados do usuário no corpo da solicitação HTTP POST. O uso de DTOs é uma prática comum em APIs para separar a representação dos dados de entrada/saída da lógica de negócios, facilitando a validação e a manutenção do código.
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO dadosUsuario )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }
            // criando um novo objeto Usuario com os dados fornecidos no corpo da solicitação.
            string senhaCriptografada = CryptoService.EncryptPassword(dadosUsuario.Senha);
            Usuario usuarioSalvar = new Usuario
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Senha = senhaCriptografada,
                CPF = dadosUsuario.CPF
            };
            //Adiciona o novo usuário ao contexto do banco de dados usando o método Add() do DbSet, e em seguida, salva as alterações no banco de dados usando o método SaveChangesAsync(). O método verifica se a operação foi bem-sucedida (result > 0) e retorna uma resposta adequada, como Ok() para indicar que o usuário foi criado com sucesso ou BadRequest() para indicar que houve um erro ao criar o usuário.
            //add - adiciona o novo usuário ao contexto do banco de dados, preparando-o para ser salvo. O método Add() é um método do DbSet que marca o objeto como adicionado, indicando que ele deve ser inserido no banco de dados quando SaveChangesAsync() for chamado. O uso do método Add() é essencial para garantir que o novo usuário seja corretamente rastreado pelo Entity Framework e incluído na operação de salvamento.
            _appDbContext.Usuarios.Add(usuarioSalvar);
            int result = await _appDbContext.SaveChangesAsync();
            // verifica se a operação de salvamento foi bem-sucedida (result > 0) e retorna uma resposta adequada, como Ok() para indicar que o usuário foi criado com sucesso ou BadRequest() para indicar que houve um erro ao criar o usuário. O método SaveChangesAsync() retorna o número de registros afetados no banco de dados, permitindo que o código determine se a operação foi bem-sucedida ou não com base nesse resultado.
            if (result > 0)
            {
                // Returne Ok - status code 200, indicando que a solicitação foi bem-sucedida e fornecendo uma mensagem de sucesso como resposta. O método Ok() é um método de conveniência que retorna um objeto OkObjectResult, que é uma implementação de IActionResult que representa uma resposta HTTP 200 OK com um corpo de resposta contendo os dados fornecidos (neste caso, a mensagem "Usuario criado com sucesso!"). O uso do método Ok() torna o código mais expressivo e fácil de entender, indicando claramente que a solicitação foi bem-sucedida e fornecendo uma mensagem de confirmação como resposta.
                return Ok("Usuario criado com sucesso!");
            }
            // Se o resultado da operação de salvamento for 0 ou menor, isso indica que houve um erro ao criar o usuário, e o método retorna uma resposta BadRequest() com uma mensagem de erro. O método BadRequest() é um método de conveniência que retorna um objeto BadRequestObjectResult, que é uma implementação de IActionResult que representa uma resposta HTTP 400 Bad Request com um corpo de resposta contendo os dados fornecidos (neste caso, a mensagem "Erro ao criar usuarios"). O uso do método BadRequest() torna o código mais expressivo e fácil de entender, indicando claramente que houve um problema com a solicitação e fornecendo uma mensagem de erro como resposta.
            return BadRequest("Erro ao criar usuarios");
        }
        //  HttpPost é uma annotation que indica que o método LoginAsync() é um endpoint de API que responde a solicitações HTTP POST, permitindo que os clientes realizem o login no sistema. O método recebe os dados de login no corpo da solicitação (usando [FromBody]) e utiliza o AppDbContext para verificar as credenciais do usuário no banco de dados, retornando uma resposta adequada com base no resultado da operação.
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dadosLogin ) { 
        if (!ModelState.IsValid)
            {
                return BadRequest("Dados de login invalidos");
            }
            // O método LoginAsync() é um método assíncrono que permite realizar o login no sistema. Ele recebe os dados de login no corpo da solicitação (usando [FromBody]) e utiliza o AppDbContext para verificar as credenciais do usuário no banco de dados. O método verifica se os dados fornecidos são válidos e retorna uma resposta adequada com base no resultado da operação, como Ok() para indicar que o login foi realizado com sucesso, NotFound() para indicar que o usuário não foi encontrado ou Unauthorized() para indicar que os dados de login estão incorretos.
            // FirstOrDefaultAsync é um método do Entity Framework que retorna o primeiro elemento de uma sequência que satisfaz uma condição especificada ou um valor padrão se nenhum elemento for encontrado. No contexto do método LoginAsync(), ele é usado para buscar o usuário no banco de dados com base no email fornecido nos dados de login. Se um usuário com o email correspondente for encontrado, ele será retornado; caso contrário, o resultado será null, indicando que o usuário não foi encontrado.
            // ? - operador de coalescência nula, que é usado para lidar com valores nulos de forma segura. No contexto do método LoginAsync(), ele é usado para verificar se o resultado da consulta ao banco de dados (usuarioEncontrado) é nulo. Se usuarioEncontrado for nulo, isso significa que nenhum usuário com o email fornecido foi encontrado no banco de dados, e a resposta NotFound() será retornada. Caso contrário, se usuarioEncontrado não for nulo, o código continuará a verificar as credenciais do usuário para determinar se o login foi bem-sucedido ou não.
            Usuario? usuarioEncontrado = await _appDbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosLogin.Email);
            // Verifica se o usuário foi encontrado no banco de dados. Se usuarioEncontrado for nulo, isso significa que nenhum usuário com o email fornecido foi encontrado, e a resposta NotFound() será retornada com uma mensagem indicando que o usuário não foi encontrado. Caso contrário, se usuarioEncontrado não for nulo, o código continuará a verificar as credenciais do usuário para determinar se o login foi bem-sucedido ou não.
            if (usuarioEncontrado == null)
            {
                return NotFound("Usuario não encontrado");
            }
            // Verifica se a senha fornecida nos dados de login corresponde à senha do usuário encontrado no banco de dados
            if (CryptoService.VerifyPassword(dadosLogin.Senha, usuarioEncontrado.Senha))
            {
                return Ok("Login realizado");
            }
            return Unauthorized("Dados de login incorretos");
        }
    }
}
