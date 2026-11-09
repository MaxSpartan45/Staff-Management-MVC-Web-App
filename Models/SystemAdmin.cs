using System.ComponentModel.DataAnnotations;

namespace EHA_Assessment.Models
{
    public class SystemAdmin
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}