using PostSite.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PostSite.Infra.Data.Models
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
