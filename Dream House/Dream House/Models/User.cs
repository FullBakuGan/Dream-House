using hackaton_asp_project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dream_House.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("surname")]
        public string? Surname { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Required]
        [Column("hash_password")]
        public string HashPassword { get; set; }
        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<favorite> favorites { get; set; } = new List<favorite>();
        [Column(TypeName = "timestamp without time zone")]
        public DateTime RegistrationDate { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); // Изменено
    }
}