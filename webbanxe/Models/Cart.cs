using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace webbanxe.Models
{
    public class Cart
    {
        [Key] public long IdCart { get; set; }
        [Required] public long QuantityPurchased  { get; set; }

        [ForeignKey(nameof(Bike))]
        public long? IdBike { get; set; }
        public virtual Bike Bike { get; set; }

        [ForeignKey(nameof(User))]
        public long IdUser {  get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Accessary))]
        public long? IdAccessary { get; set; }
        public virtual Accessary Accessary { get; set; }

        
    }
}
