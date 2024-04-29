using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbanxe.Models
{
    public class Accessary
    {
        [Key]
        public long IdAccessary { get; set; }

        [Required]
        [MaxLength(500)]  
        public string NameAccessary { get; set; }
        [Required]
        public string DescriptionAccessary { get; set;}

        [Required]
        [StringLength(700)]
        [ValidateNever]
        public string ImageAccessary { get; set; }

        public double Price { get; set; }
        public double PricePromotion { get; set; }

        public long Quantity { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        [ValidateNever]
        public List<IFormFile> ImageFile { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
