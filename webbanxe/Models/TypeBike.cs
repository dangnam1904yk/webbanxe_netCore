using System.ComponentModel.DataAnnotations;

namespace webbanxe.Models
{
    public class TypeBike
    {
        [Key] 
        public long IdType { get; set; }
        [Required]
        [StringLength(300)]
        public string NameType { get; set; }
        public virtual List<Bike> Bike { get; set; }
    }
}
