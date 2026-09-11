using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;


        public PacienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Endpoint POST api/Paciente: cadastra um novo paciente.
        [HttpPost]
        public async Task<IActionResult> AdicionarPaciente(MED_PACIENTE paciente)
        {
            _appDbContext.Add(paciente);
            await _appDbContext.SaveChangesAsync();

            return Ok(paciente);
        }
        // Endpoint GET api/Paciente: retorna a lista de todos os pacientes cadastrados.
        [HttpGet]
        public async Task<IActionResult> ObterPacientes()
        {
            var pacientes = await _appDbContext.MED_PACIENTE.ToListAsync();
            return Ok(pacientes);
        }

        // Endpoint GET api/Paciente/porLogin/{idLogin}: retorna o paciente vinculado a um login específico.
        [HttpGet("porLogin/{idLogin}")]
        public async Task<IActionResult> ObterPacientePorLogin(int idLogin)
        {
            var paciente = await _appDbContext.MED_PACIENTE
                .Where(p => p.ID_LOGIN == idLogin)
                .FirstOrDefaultAsync();

            if (paciente == null)
            {
                return NotFound(new { erro = "Nenhum paciente vinculado a este login." });
            }

            return Ok(paciente);
    }


        // Endpoint PUT api/Paciente/{id}: atualiza os dados de um paciente existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, MED_PACIENTE paciente)
        {
            // Busca o paciente pelo ID; retorna 404 se não existir.
            var pacienteExistente = await _appDbContext.MED_PACIENTE.FindAsync(id);
            if (pacienteExistente == null)
            {
                return NotFound();
            }
            // Sobrescreve os campos do paciente existente com os valores recebidos.
            pacienteExistente.ID_PAC_RG_CIN = paciente.ID_PAC_RG_CIN;
            pacienteExistente.PAC_CPF = paciente.PAC_CPF;
            pacienteExistente.PAC_NOME_COMPLETO = paciente.PAC_NOME_COMPLETO;
            pacienteExistente.PAC_SEXO = paciente.PAC_SEXO;
            pacienteExistente.PAC_TELEFONE = paciente.PAC_TELEFONE;
            pacienteExistente.PAC_ENDERECO = paciente.PAC_ENDERECO;
            pacienteExistente.PAC_CEP = paciente.PAC_CEP;
            pacienteExistente.PAC_NUMERO = paciente.PAC_NUMERO;
            pacienteExistente.PAC_BAIRRO = paciente.PAC_BAIRRO;
            pacienteExistente.PAC_CIDADE = paciente.PAC_CIDADE;
            pacienteExistente.PAC_UF = paciente.PAC_UF;
            pacienteExistente.PAC_COMPLEMENTO = paciente.PAC_COMPLEMENTO;
            pacienteExistente.ID_PAC_TAB_CONVENIO = paciente.ID_PAC_TAB_CONVENIO;

            await _appDbContext.SaveChangesAsync();
            return Ok(pacienteExistente);
        }
        // Endpoint DELETE api/Paciente/{id}: remove um paciente pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            var pacienteExistente = await _appDbContext.MED_PACIENTE.FindAsync(id);
            if (pacienteExistente == null)
            {
                return NotFound();
            }

            _appDbContext.MED_PACIENTE.Remove(pacienteExistente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}