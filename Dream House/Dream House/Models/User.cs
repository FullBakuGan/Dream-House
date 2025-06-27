using hackaton_asp_project.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dream_House.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Required]
        public int RoleId { get; set; }
        public virtual ICollection<favorite> favorites { get; set; } = new List<favorite>();


        [Column(TypeName = "timestamp without time zone")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
