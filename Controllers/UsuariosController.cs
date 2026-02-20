using apiUsuarios.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiUsuarios.Models;

namespace apiUsuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public UsuariosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Usuario> userList = await _appDbContext.Usuarios.ToListAsync();
            return Ok(userList);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO dadosUsuario )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }
            Usuario usuarioSalvar = new Usuario
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Senha = dadosUsuario.Senha,
                CPF = dadosUsuario.CPF
            };

            _appDbContext.Usuarios.Add(usuarioSalvar);
            int result = await _appDbContext.SaveChangesAsync();
            if (result > 0)
            {
                return Ok("Usuario criado com sucesso!");
            }

            return BadRequest("Erro ao criar usuarios");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dadosLogin ) { 
        if (!ModelState.IsValid)
            {
                return BadRequest("Dados de login invalidos");
            }
            Usuario? usuarioEncontrado = await _appDbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosLogin.Email);
            if (usuarioEncontrado == null)
            {
                return NotFound("Usuario não encontrado");
            }
            if (usuarioEncontrado.Senha == dadosLogin.Senha)
            {
                return Ok("Login realizado");
            }
            return Unauthorized("Dados de login incorretos");
        }
    }
}
