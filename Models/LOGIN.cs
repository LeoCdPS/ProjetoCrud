using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


namespace ProjetoCrud.Models
{
    public class LOGIN
    {
        [Key]
        public int id_USER { get; set; }
        public string CARGO { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
    }
}