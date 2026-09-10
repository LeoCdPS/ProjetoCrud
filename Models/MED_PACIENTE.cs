using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoCrud.Models
{
    public class MED_PACIENTE
    {
        [Key]
        public int ID_PAC_RG_CIN { get; set; } // Primary key
        public string PAC_NOME_COMPLETO { get; set; }
        public string  PAC_CPF { get; set; }
        public string  PAC_SEXO { get; set; }
        public string PAC_TELEFONE { get; set; }
        public string PAC_ENDERECO { get; set; }
        public string  PAC_CEP { get; set; }
        public string PAC_NUMERO { get; set; }
        public string PAC_COMPLEMENTO { get; set; }
        public string PAC_BAIRRO { get; set; }
        public string PAC_CIDADE { get; set; }
        public string PAC_UF { get; set; }
        public int ID_PAC_TAB_CONVENIO { get; set; } //FOREIGN KEY
        public int? ID_LOGIN { get; set; }

        [ForeignKey("ID_LOGIN")]
        public LOGIN Login { get; set; }
    }
}