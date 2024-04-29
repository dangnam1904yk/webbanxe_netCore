using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbanxe.Models
{
    public class Order
    {
        [Key] 
        public long IdOrder { get; set; }

        [Required]
        [MaxLength(13)]
        public string NumberPhone { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        [Required]
        [StringLength(200)]
        public string OrderStatus { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public long IdCart { get; set; }
        [ValidateNever]
        public virtual Cart Cart { get; set; }  

    }
}
