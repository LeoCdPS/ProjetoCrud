using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AgendarController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AgendarController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Endpoint POST api/Agenda: cadastra um novo registro de agenda.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_AGENDA agenda)
        {
            _appDbContext.Add(agenda);
            await _appDbContext.SaveChangesAsync();

            return Ok(agenda);
        }
        // Endpoint GET api/Agenda: retorna a lista de todas as agendas cadastradas.
        [HttpGet]
        public async Task<IActionResult> GetActionResultAsync()
        {
            var agenda = await _appDbContext.MED_AGENDA.ToListAsync();

            return Ok(agenda);
        }
        // Endpoint PUT api/Agenda/{id}: atualiza os dados de uma agenda existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_AGENDA agenda)
        {
            // Busca a agenda pelo ID; retorna 404 se não existir.
            var agendaExistente = await _appDbContext.MED_AGENDA.FindAsync(id);

            if (agendaExistente == null)
            {
                return NotFound();
            }
            // Sobrescreve os campos da agenda existente com os valores recebidos.
            agendaExistente.ID_MED_CRM = agenda.ID_MED_CRM;
            agendaExistente.ID_MED_TAB_AGENDA_PERIODO = agenda.ID_MED_TAB_AGENDA_PERIODO;
            agendaExistente.MED_AGENDA_DIA_SEMANA = agenda.MED_AGENDA_DIA_SEMANA;
            agendaExistente.MED_AGENDA_HORA_INICIAL = agenda.MED_AGENDA_HORA_INICIAL;
            agendaExistente.MED_AGENDA_HORA_FINAL = agenda.MED_AGENDA_HORA_FINAL;
            agendaExistente.MED_AGENDA_QTDE_MAXIMA = agenda.MED_AGENDA_QTDE_MAXIMA;
            agendaExistente.MED_AGENDA_TEMPO_CONSULTA = agenda.MED_AGENDA_TEMPO_CONSULTA;

            await _appDbContext.SaveChangesAsync();

            return Ok(agendaExistente);
        }

        // Endpoint DELETE api/Agenda/{id}: remove uma agenda pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agendaExistente = await _appDbContext.MED_AGENDA.FindAsync(id);

            if (agendaExistente == null)
            {
                return NotFound();
            }

            _appDbContext.MED_AGENDA.Remove(agendaExistente);
            await _appDbContext.SaveChangesAsync();

            return Ok(agendaExistente);
        }
    }
}