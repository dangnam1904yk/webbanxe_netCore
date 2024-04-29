using webbanxe.Models;

namespace webbanxe.Areas.Admin.Models
{
    public class InforPaymentBill
    {
        public Order Order {  get; set; }
        public Payment Payment { get; set; }
        public User User { get; set; }

    }
}
