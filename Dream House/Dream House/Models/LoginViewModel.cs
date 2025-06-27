using System.ComponentModel.DataAnnotations;

namespace Dream_House.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId {  get; set; }
    }
}
