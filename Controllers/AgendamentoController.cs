using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        
        
        
        public AgendamentoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        // Endpoint POST api/Agendamento: cadastra um novo agendamento.
        [HttpPost]
        public async Task<IActionResult> CriarAgendamento(MED_AGENDAMENTO agendamento)
        {
            _appDbContext.Add(agendamento);
            await _appDbContext.SaveChangesAsync();

            return Ok(agendamento);
        }
        // Endpoint GET api/Agendamento: retorna a lista de agendamentos com os
        // dados relacionados de paciente, médico e especialidade já resolvidos.
        [HttpGet]
        public async Task<IActionResult> ConsultarAgendamento()
        {
            // Faz JOIN de agendamento -> paciente -> médico -> especialidade
            // para montar um resultado legível, em vez de retornar apenas IDs.
            var agendamentos = await (
                from ag in _appDbContext.MED_AGENDAMENTO
                join pac in _appDbContext.MED_PACIENTE on ag.ID_PAC_RG_CIN equals pac.ID_PAC_RG_CIN
                join med in _appDbContext.MED_MEDICO_DADOS on ag.ID_MED_CRM equals med.ID_MED_CRM
                join esp in _appDbContext.MED_TAB_ESPECIALIDADE on med.ID_MED_TAB_ESPECIALIDADE equals esp.ID_MED_TAB_ESPECIALIDADE
                
                // Projeta apenas os campos necessários em um objeto anônimo.
                select new
                {
                    AgendamentoId = ag.ID_MED_AGENDAMENTO,
                    Data = ag.MED_AGENDAMENTO_DATA,
                    Horario = ag.MED_AGENDAMENTO_HORARIO,
                    Paciente = pac.PAC_NOME_COMPLETO,
                    Medico = med.MED_NOME_COMPLETO,
                    Especialidade = esp.MED_TAB_ESPECIALIDADE_DESCRICAO,
                }
                    ).ToListAsync(); // Executa a consulta de forma assíncrona.
                return Ok(agendamentos);
        }


        [HttpGet("paciente/{idLogin}")]
        public async Task<IActionResult> ConsultarAgendamentoPorPaciente(int idLogin)
        {
            var agendamentos = await (
                from ag in _appDbContext.MED_AGENDAMENTO
                join pac in _appDbContext.MED_PACIENTE on ag.ID_PAC_RG_CIN equals pac.ID_PAC_RG_CIN
                join med in _appDbContext.MED_MEDICO_DADOS on ag.ID_MED_CRM equals med.ID_MED_CRM
                join esp in _appDbContext.MED_TAB_ESPECIALIDADE on med.ID_MED_TAB_ESPECIALIDADE equals esp.ID_MED_TAB_ESPECIALIDADE
                where pac.ID_LOGIN == idLogin
                select new
                {
                    AgendamentoId = ag.ID_MED_AGENDAMENTO,
                    Data = ag.MED_AGENDAMENTO_DATA,
                    Horario = ag.MED_AGENDAMENTO_HORARIO,
                    Paciente = pac.PAC_NOME_COMPLETO,
                    Medico = med.MED_NOME_COMPLETO,
                    Especialidade = esp.MED_TAB_ESPECIALIDADE_DESCRICAO,
                }
            ).ToListAsync();

    return Ok(agendamentos);
}


        // Endpoint PUT api/Agendamento/{id}: atualiza um agendamento existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAgendamento(int id, MED_AGENDAMENTO agendamento)
        {
            var agendamentoExistente = await _appDbContext.MED_AGENDAMENTO.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }

            agendamentoExistente.MED_AGENDAMENTO_HORARIO = agendamento.MED_AGENDAMENTO_HORARIO;
            agendamentoExistente.MED_AGENDAMENTO_DATA = agendamento.MED_AGENDAMENTO_DATA;

            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoExistente);
        }
        // Endpoint DELETE api/Agendamento/{id}: remove um agendamento pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAgendamento(int id)
        {
            var agendamentoExistente = await _appDbContext.MED_AGENDAMENTO.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }
            _appDbContext.MED_AGENDAMENTO.Remove(agendamentoExistente);
            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoExistente);
        }
    }
}
