using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webbanxe.Areas.Admin.Models;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.Authentications;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly DataContext _context;

        public PaymentController (DataContext context)
        {
            _context = context;
        }
        [Authentication]
        public IActionResult Index()
        {
            var payment = from i in _context.Payments join u in _context.Users on i.IdUser equals u.IdUser 
                          join o in _context.Order on i.IdOrder equals o.IdOrder 
                          select new
                          {
                              Payment = i,
                              User = u,
                              Order =o
                          };
            List<InforPaymentBill> inforPaymentBills  = new List<InforPaymentBill>();
            foreach(var item in payment)
            {
                InforPaymentBill inforPaymentBill = new InforPaymentBill();
                inforPaymentBill.Payment = item.Payment;
                inforPaymentBill.User = item.User;
                inforPaymentBill.Order = item.Order;
                inforPaymentBills.Add(inforPaymentBill);
            }
            return View(inforPaymentBills);
        }
    }
}
