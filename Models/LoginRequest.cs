using System.ComponentModel.DataAnnotations; 
using System.Security.AccessControl;


namespace ProjetoCrud.Models
{
    public class LoginRequest
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
    }
}