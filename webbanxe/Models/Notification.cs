using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webbanxe.Models
{
    public class Notification
    {
        [Key] public long IdNotification { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Tiêu đề")]
        public string title { get; set; }
        [Required]
        [StringLength(200)]
        public string content { get; set; }

        [Required]
        [StringLength(200)]
        public string img { get; set; }
        public virtual List<UserNotification> UserNotifications { get; set; }

    }
}
