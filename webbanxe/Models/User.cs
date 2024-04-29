using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbanxe.Models
{
    public class User
    {
        public User()
        {
        }

        public User(int idUser)
        {
            IdUser = idUser;
        }

        [Key]
        public long IdUser { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [StringLength(50)]
        [MinLength(4)]
        public string DisplayName { get; set; }
        
        [StringLength(13)]
        public string Phone { get; set; }

        [Required]
        [ForeignKey(nameof(Roles))]
        public long RoleId { get; set; }
        public virtual Roles Roles { get; set; }

        public virtual List<Cart> Cart { get; set; }

        public virtual List<UserNotification> UserNotifications { get; set; }
        public virtual List<Payment> Payments { get; set; }


    }
}
