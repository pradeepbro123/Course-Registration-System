using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required, EmailAddress] 
        public string Email { get; set; }

        [Required] public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }

    }
}
