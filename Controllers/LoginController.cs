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
            _appDbContext.Add(usuarios);
            await _appDbContext.SaveChangesAsync();

            return Ok(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> GetLoginAsync()
        {
            var usuarios = await _appDbContext.LOGIN.ToListAsync();
            return Ok(usuarios);
        }
    } 
}

