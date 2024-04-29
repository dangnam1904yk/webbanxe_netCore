
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using webbanxe.Constant;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.Authentications;
using webbanxe.Models.ModelView;
using webbanxe.Payments;

namespace webbanxe.Controllers
{
    public class PaymentController : Controller

    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public PaymentController(IConfiguration configuration, DataContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        [Route("/payment.html", Name = "payment")]
        [Authentication]
        public async Task<IActionResult> Index()
        {
            VnPay vnpay = new VnPay();
            Payment payment = new Payment();
            if (HttpContext.Request.Query.Count > 0)
            {
                
                string vnpHashSecret = _configuration["Vnpay:vnp_HashSecret"];

                var queryStringParams = HttpContext.Request.Query;

                var vnpayData = Request.QueryString;
                foreach (var param in queryStringParams)
                {
                    if (param.Key.Length >0 && param.Key.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(param.Key, param.Value);
                    }
                }

                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

                long maMerChantVNPay = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnp_TransactionNo = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                string vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
                string TerminalID = vnpay.GetResponseData("vnp_TmnCode");
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                string bankCode = vnpay.GetResponseData("vnp_BankCode");

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnpHashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        //Thanh toan thanh cong
                        int  orderIdpaymant = Int32.Parse( vnpay.GetResponseData("vnp_OrderInfo").Split(":")[1]);
                        payment.content = vnpay.GetResponseData("vnp_OrderInfo");
                        payment.maVnpTransactionStatus = vnp_TransactionStatus;
                        payment.status = 1;
                        payment.tenNganHang = bankCode;
                        payment.IdOrder = orderIdpaymant;
                        payment.tongTien = vnp_Amount;
                        payment.maCode = orderIdpaymant+vnpay.GetResponseData("vnp_PayDate");
                        payment.maGiaoDich = vnpay.GetResponseData("vnp_BankTranNo");
                        payment.IdUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
                        payment.maMerchant = maMerChantVNPay;
                        DateTime date;
                        DateTime.TryParseExact(vnpay.GetResponseData("vnp_PayDate"), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out date);
                        payment.Created = date;
                        ViewBag.StatusPayment = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        Console.WriteLine("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", maMerChantVNPay, orderIdpaymant);

                        var order = await _context.Order.FirstOrDefaultAsync(m => m.IdOrder == orderIdpaymant);
                        if (order != null)
                        {
                            order.OrderStatus=STATUS.PAYMENT.ToString();
                        }
                        var resultBike = from o in _context.Order
                                     join c in _context.Carts on o.IdCart equals c.IdCart
                                     join b in _context.Bike on c.IdBike equals b.IdBike
                                     join u in _context.Users on c.IdUser equals u.IdUser
                                     where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser")) && o.IdOrder == orderIdpaymant
                                     select new
                                     {
                                         Order = o,
                                         Cart = c,
                                         Bike = b,
                                         User = u
                                     };

                        var resultAccessries = from o in _context.Order
                                      join c in _context.Carts on o.IdCart equals c.IdCart
                                      join b in _context.Accessaries on c.IdAccessary equals b.IdAccessary
                                      join u in _context.Users on c.IdUser equals u.IdUser
                                      where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser")) && o.IdOrder == orderIdpaymant
                                      select new
                                      {
                                          Order = o,
                                          Cart = c,
                                          Accessary = b,
                                          User = u
                                      };
                        ViewOrder viewCart = new ViewOrder();
                        if (resultBike.IsNullOrEmpty() ==false)
                        {
                            foreach (var i in resultBike)
                            {
                                viewCart.Cart = i.Cart;
                                viewCart.User = i.User;
                                viewCart.Bike = i.Bike;
                                viewCart.Order = i.Order;
                            }
                        }
                        if (resultAccessries.IsNullOrEmpty() ==false)
                        {
                            foreach (var i in resultAccessries)
                            {
                                viewCart.Cart = i.Cart;
                                viewCart.User = i.User;
                                viewCart.Accessary = i.Accessary;
                                viewCart.Order = i.Order;
                            }

                        }
                        Notification notification = new Notification();
                        notification.title = "Thanh toán đơn hàng thành công";
                        notification.img = "";
                        Console.WriteLine(date);
                        if(resultAccessries.IsNullOrEmpty() ==false)
                        {
                            string text = "Đơn hàng " + viewCart.Accessary.NameAccessary + " đã được thanh toán với số tiền " + payment.tongTien + " vào ngày " + date;
                            
                            notification.content = text ;
                        }
                        if (resultBike.IsNullOrEmpty()==false)
                        {
                            notification.content = "Đơn hàng " + viewCart.Bike.NameBike + " đã được thanh toán với số tiền " + payment.tongTien + " vào ngày " +date;
                        }
                        UserNotification userNotification = new UserNotification();
                        userNotification.Notification = notification;
                        userNotification.IdUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
                        _context.UserNotifications.Add(userNotification);
                        _context.Notification.Add(notification);
                        _context.Payments.Add(payment);
                        _context.Order.Update(order);
                        _context.SaveChanges();
                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        ViewBag.StatusPayment = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        Console.WriteLine("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}", maMerChantVNPay, vnp_Amount, vnp_ResponseCode);
                    }
                }
                else
                {
                    ViewBag.StatusPayment= "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View(payment);
        }

        [Authentication]
        [Route("/lich-su-thanh-toan")]
        public async Task<ActionResult> LichSuThanhToan()
        {
            long idUser = long.Parse(HttpContext.Session.GetString("idUser"));
            var payment = from i in _context.Payments where i.IdUser ==idUser select i;
            List<Payment> paymentList = new List<Payment>();
            foreach( var item in payment)
            {
                paymentList.Add(item);
            }
            return View(paymentList);
        }
    }
}
