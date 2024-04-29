using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbanxe.Models
{
    public class Payment
    {
        [Key]
        public long IdPayment { get; set; }
        public long status { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]
        public long IdOrder { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public string maCode { get; set; }
        [Required]
        public string maGiaoDich { get; set; }

        [Required]
        public long maMerchant { get; set; }
        [Required]
        public string maVnpTransactionStatus { get; set; }

        [Required]
        public string tenNganHang { get; set; }
        [Required]
        public long  tongTien { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public long IdUser { get; set; }
        public string content { get; set; }

    }
}
