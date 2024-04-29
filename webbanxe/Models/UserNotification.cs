using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webbanxe.Models
{
    public class UserNotification

    {
        [Key] public long Id { get; set; }
        [Required]
        [ForeignKey(nameof(Notification))]
        public long IdNotification { get; set; }
        public virtual Notification Notification { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long IdUser { get; set; }

        public virtual User User { get; set; }


    }
}
