using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCrud.Migrations
{
    /// <inheritdoc />
    public partial class AddIdLoginToPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MED_MEDICO_DADOs",
                table: "MED_MEDICO_DADOs");

            migrationBuilder.RenameTable(
                name: "MED_MEDICO_DADOs",
                newName: "MED_MEDICO_DADOS");

            migrationBuilder.RenameColumn(
                name: "ID_MED_TAB_Especialidade",
                table: "MED_MEDICO_DADOS",
                newName: "ID_MED_TAB_ESPECIALIDADE");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "MED_MEDICO_DADOS",
                newName: "MED_UF");

            migrationBuilder.RenameColumn(
                name: "Teleofone",
                table: "MED_MEDICO_DADOS",
                newName: "MED_TELEFONE");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "MED_MEDICO_DADOS",
                newName: "MED_SEXO");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "MED_MEDICO_DADOS",
                newName: "MED_NUMERO");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MED_MEDICO_DADOS",
                newName: "MED_NOME_COMPLETO");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "MED_MEDICO_DADOS",
                newName: "MED_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "MED_MEDICO_DADOS",
                newName: "MED_CPF");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "MED_MEDICO_DADOS",
                newName: "MED_COMPLEMENTO");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "MED_MEDICO_DADOS",
                newName: "MED_CIDADE");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "MED_MEDICO_DADOS",
                newName: "MED_CEP");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "MED_MEDICO_DADOS",
                newName: "MED_BAIRRO");

            migrationBuilder.RenameColumn(
                name: "ID_CRM",
                table: "MED_MEDICO_DADOS",
                newName: "ID_MED_CRM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MED_MEDICO_DADOS",
                table: "MED_MEDICO_DADOS",
                column: "ID_MED_CRM");

            migrationBuilder.CreateTable(
                name: "CONEVENIO_TAB_STATUS",
                columns: table => new
                {
                    ID_PAC_TAB_CONVENIO_STATUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PAC_TAB_CONVENIO_STATUS_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONEVENIO_TAB_STATUS", x => x.ID_PAC_TAB_CONVENIO_STATUS);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LOGIN",
                columns: table => new
                {
                    id_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CARGO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGIN", x => x.id_USER);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_AGENDA",
                columns: table => new
                {
                    ID_MED_AGENDASUPERKEY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_MED_CRM = table.Column<int>(type: "int", nullable: false),
                    ID_MED_TAB_AGENDA_PERIODO = table.Column<int>(type: "int", nullable: false),
                    MED_AGENDA_DIA_SEMANA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MED_AGENDA_HORA_INICIAL = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    MED_AGENDA_HORA_FINAL = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    MED_AGENDA_QTDE_MAXIMA = table.Column<int>(type: "int", nullable: false),
                    MED_AGENDA_TEMPO_CONSULTA = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_AGENDA", x => x.ID_MED_AGENDASUPERKEY);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_AGENDAMENTO",
                columns: table => new
                {
                    ID_MED_AGENDAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_PAC_RG_CIN = table.Column<int>(type: "int", nullable: false),
                    ID_MED_TAB_AGENDA_PERIODO = table.Column<int>(type: "int", nullable: false),
                    ID_MED_CRM = table.Column<int>(type: "int", nullable: false),
                    MED_AGENDAMENTO_HORARIO = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    MED_AGENDAMENTO_DATA = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ID_MED_AGENDAMENTO_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_AGENDAMENTO", x => x.ID_MED_AGENDAMENTO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_AGENDAMENTO_STATUS",
                columns: table => new
                {
                    ID_MED_AGENDAMENTO_STATUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MED_AGENDAMENTO_STATUS_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MED_AGENDAMENTO_STATUS_OCULTA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_AGENDAMENTO_STATUS", x => x.ID_MED_AGENDAMENTO_STATUS);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_TAB_AGENDA_PERIODO",
                columns: table => new
                {
                    ID_MED_TAB_AGENDA_PERIODO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MED_TAB_AGENDA_PERIODO_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MED_TAB_AGENDA_PERIODO_OCULTA = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_TAB_AGENDA_PERIODO", x => x.ID_MED_TAB_AGENDA_PERIODO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_TAB_ESPECIALIDADE",
                columns: table => new
                {
                    ID_MED_TAB_ESPECIALIDADE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MED_TAB_ESPECIALIDADE_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MED_TAB_ESPECIALIDADE_OCULTA = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_TAB_ESPECIALIDADE", x => x.ID_MED_TAB_ESPECIALIDADE);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_TAB_STATUS",
                columns: table => new
                {
                    ID_MED_TAB_STATUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MED_TAB_STATUS_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MED_TAB_STATUS_OCULTA = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_TAB_STATUS", x => x.ID_MED_TAB_STATUS);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PAC_TAB_CONVENIO",
                columns: table => new
                {
                    ID_PAC_TAB_CONVENIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PAC_TAB_CONVENIO_DESCRICAO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_TAB_CONVENIO_OCULTA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ID_PAC_TAB_CONVENIO_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAC_TAB_CONVENIO", x => x.ID_PAC_TAB_CONVENIO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MED_PACIENTE",
                columns: table => new
                {
                    ID_PAC_RG_CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PAC_NOME_COMPLETO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_SEXO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_TELEFONE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_ENDERECO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_CEP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_NUMERO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_COMPLEMENTO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_BAIRRO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_CIDADE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAC_UF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ID_PAC_TAB_CONVENIO = table.Column<int>(type: "int", nullable: false),
                    ID_LOGIN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MED_PACIENTE", x => x.ID_PAC_RG_CIN);
                    table.ForeignKey(
                        name: "FK_MED_PACIENTE_LOGIN_ID_LOGIN",
                        column: x => x.ID_LOGIN,
                        principalTable: "LOGIN",
                        principalColumn: "id_USER");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MED_PACIENTE_ID_LOGIN",
                table: "MED_PACIENTE",
                column: "ID_LOGIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONEVENIO_TAB_STATUS");

            migrationBuilder.DropTable(
                name: "MED_AGENDA");

            migrationBuilder.DropTable(
                name: "MED_AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "MED_AGENDAMENTO_STATUS");

            migrationBuilder.DropTable(
                name: "MED_PACIENTE");

            migrationBuilder.DropTable(
                name: "MED_TAB_AGENDA_PERIODO");

            migrationBuilder.DropTable(
                name: "MED_TAB_ESPECIALIDADE");

            migrationBuilder.DropTable(
                name: "MED_TAB_STATUS");

            migrationBuilder.DropTable(
                name: "PAC_TAB_CONVENIO");

            migrationBuilder.DropTable(
                name: "LOGIN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MED_MEDICO_DADOS",
                table: "MED_MEDICO_DADOS");

            migrationBuilder.RenameTable(
                name: "MED_MEDICO_DADOS",
                newName: "MED_MEDICO_DADOs");

            migrationBuilder.RenameColumn(
                name: "ID_MED_TAB_ESPECIALIDADE",
                table: "MED_MEDICO_DADOs",
                newName: "ID_MED_TAB_Especialidade");

            migrationBuilder.RenameColumn(
                name: "MED_UF",
                table: "MED_MEDICO_DADOs",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "MED_TELEFONE",
                table: "MED_MEDICO_DADOs",
                newName: "Teleofone");

            migrationBuilder.RenameColumn(
                name: "MED_SEXO",
                table: "MED_MEDICO_DADOs",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "MED_NUMERO",
                table: "MED_MEDICO_DADOs",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "MED_NOME_COMPLETO",
                table: "MED_MEDICO_DADOs",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "MED_ENDERECO",
                table: "MED_MEDICO_DADOs",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "MED_CPF",
                table: "MED_MEDICO_DADOs",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "MED_COMPLEMENTO",
                table: "MED_MEDICO_DADOs",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "MED_CIDADE",
                table: "MED_MEDICO_DADOs",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "MED_CEP",
                table: "MED_MEDICO_DADOs",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "MED_BAIRRO",
                table: "MED_MEDICO_DADOs",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "ID_MED_CRM",
                table: "MED_MEDICO_DADOs",
                newName: "ID_CRM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MED_MEDICO_DADOs",
                table: "MED_MEDICO_DADOs",
                column: "ID_CRM");
        }
    }
}
