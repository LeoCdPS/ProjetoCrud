using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using ProjetoCrud.Models;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LoginController(AppDbContext context)
        {
            _appDbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(LOGIN usuarios)
        {
            var existente = await _appDbContext.LOGIN
                .Where(u => u.EMAIL == usuarios.EMAIL)
                .FirstOrDefaultAsync();

            if (existente != null)
            {
                return Conflict(new { erro = "Este e-mail já está cadastrado." });
            }

            _appDbContext.Add(usuarios);
            await _appDbContext.SaveChangesAsync();

            return Ok(usuarios);
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> AutenticarAsync([FromBody] LoginRequest login)
        {
            var usuario = await _appDbContext.LOGIN
                .Where(u => u.EMAIL == login.login)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return Unauthorized(new { erro = "E-mail não cadastrado." });
            }

            if (usuario.SENHA != login.senha)
            {
                return Unauthorized(new { erro = "Senha incorreta." });
            }

            return Ok(new {
                id = usuario.id_USER,
                email = usuario.EMAIL,
                cargo = usuario.CARGO
            });
        }



        [HttpGet]
        public async Task<IActionResult> GetLoginAsync()
        {
            var emails = await _appDbContext.LOGIN.Select(u => u.EMAIL).ToListAsync();
            return Ok(emails);
        }
    } 
}

