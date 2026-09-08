using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using ProjetoCrud.Models;


/*
/*
!TELA DE CADASTRO
* Neste Controller é feito o gerenciamento de login e autenticação de usuários.
* No primeiro bloco (POST), é feita a comparação de emails: se o email já foi 
* cadastrado, retorna uma mensagem de erro.
* Caso o email não esteja cadastrado, o sistema insere no banco o cargo, o email 
* e a senha — sendo que, antes de ser inserida, a senha passa por uma transformação 
* usando a biblioteca BCrypt, que a converte em hash (não é mais salva em texto puro).

!TELA DE LOGIN
* No POST (Autenticar), é feita a verificação de login: primeiro confirma se o 
* email existe no banco. Se existir, compara a senha digitada com o hash salvo, 
* usando a função Verify() do BCrypt. Se o email não for encontrado ou a senha 
* não bater com o hash, retorna erro de autenticação.
*/ 

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

            usuarios.SENHA = BCrypt.Net.BCrypt.HashPassword(usuarios.SENHA);


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
            
            bool senhaCerta = BCrypt.Net.BCrypt.Verify(login.senha, usuario.SENHA);

            if (!senhaCerta)
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

