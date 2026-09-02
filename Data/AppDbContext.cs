using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Models;

namespace ProjetoCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<MED_MEDICO_DADOS> MED_MEDICO_DADOS {get; set;}

        public DbSet<MED_PACIENTE> MED_PACIENTE {get; set;}

        public DbSet<MED_AGENDAMENTO> MED_AGENDAMENTO {get; set;}
        public DbSet<MED_AGENDAMENTO_STATUS> MED_AGENDAMENTO_STATUS {get; set;}

        public DbSet<MED_TAB_AGENDA_PERIODO> MED_TAB_AGENDA_PERIODO {get; set;}
        public DbSet<MED_TAB_ESPECIALIDADE> MED_TAB_ESPECIALIDADE {get; set;}

        public DbSet<MED_AGENDA> MED_AGENDA {get; set;}

        public DbSet<PAC_TAB_CONVENIO> PAC_TAB_CONVENIO {get; set;}

        public DbSet<CONEVENIO_TAB_STATUS> CONEVENIO_TAB_STATUS {get; set;}

        public DbSet<MED_TAB_STATUS> MED_TAB_STATUS { get; set; }
        public DbSet<LOGIN> LOGIN { get; set; }
    }
}