using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using webbanxe.Constant;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.ModelView;
using webbanxe.Payments;
using Microsoft.AspNetCore.Http;
using webbanxe.Models.Authentications;

namespace webbanxe.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<OrdersController> _logger;
        private readonly IConfiguration _configuration;

        public OrdersController(DataContext context, ILogger<OrdersController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;

        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //return _context.Order != null ? 
            //            View(await _context.Order.ToListAsync()) :
            //            Problem("Entity set 'DataContext.Order'  is null.");

            var result = from o in _context.Order join c in _context.Carts on o.IdCart equals c.IdCart
                         join b in _context.Bike on c.IdBike equals b.IdBike
                         join u in _context.Users on c.IdUser equals u.IdUser
                         where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser"))
                         select new
                         {
                             Order = o,
                             Cart = c,
                             Bike = b,
                             User= u
                         };

            var result1 = from o in _context.Order
                         join c in _context.Carts on o.IdCart equals c.IdCart
                         join b in _context.Accessaries on c.IdAccessary equals b.IdAccessary
                         join u in _context.Users on c.IdUser equals u.IdUser
                         where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser"))
                         select new
                         {
                             Order = o,
                             Cart = c,
                             Accessary = b,
                             User = u
                         };
            List<ViewOrder> listViewOrder = new List<ViewOrder>();
            if (result != null)
            {
                foreach (var i in result)
                {
                    ViewOrder viewCart = new ViewOrder();
                    viewCart.Cart = i.Cart;
                    viewCart.User = i.User;
                    viewCart.Bike = i.Bike;
                    viewCart.Order = i.Order;
                    listViewOrder.Add(viewCart);
                }
            }
            if (result1 != null)
            {
                foreach (var i in result1)
                {
                    ViewOrder viewCart = new ViewOrder();
                    viewCart.Cart = i.Cart;
                    viewCart.User = i.User;
                    viewCart.Accessary = i.Accessary;
                    viewCart.Order = i.Order;
                    listViewOrder.Add(viewCart);
                }
            }
            var a = listViewOrder;
            return View(listViewOrder);
        }


        [HttpGet("Orders/Cancal-Order/{id:int}")]
        public async Task<IActionResult> Cancal_Order(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            
                
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(m => m.IdCart == order.IdCart);
                var bike = await _context.Bike.FirstOrDefaultAsync(m => m.IdBike == cart.IdBike);
                var acc = await _context.Accessaries.FirstOrDefaultAsync(m => m.IdAccessary == cart.IdAccessary);
                if(bike!= null)
                {
                    bike.Quantity = bike.Quantity + cart.QuantityPurchased;
                    _context.Bike.Update(bike);
                }
               if( acc != null)
                {
                    acc.Quantity = acc.Quantity + cart.QuantityPurchased;
                    _context.Accessaries.Update(acc);
                }
                order.OrderStatus = STATUS.CANCEL.ToString();
                _context.Order.Update(order);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Orders/Payment-Order/{id:int}")]
        [Authentication]
        public async Task<IActionResult> Payment_Order(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            var result = from o in _context.Order
                         join c in _context.Carts on o.IdCart equals c.IdCart
                         join b in _context.Bike on c.IdBike equals b.IdBike
                         join u in _context.Users on c.IdUser equals u.IdUser
                         where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser")) && o.IdOrder == id
                         select new
                         {
                             Order = o,
                             Cart = c,
                             Bike = b,
                             User = u
                         };

            var result1 = from o in _context.Order
                          join c in _context.Carts on o.IdCart equals c.IdCart
                          join b in _context.Accessaries on c.IdAccessary equals b.IdAccessary
                          join u in _context.Users on c.IdUser equals u.IdUser
                          where c.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser")) && o.IdOrder == id
                          select new
                          {
                              Order = o,
                              Cart = c,
                              Accessary = b,
                              User = u
                          };
            ViewOrder viewCart = new ViewOrder();
            if (result != null)
            {
                foreach (var i in result)
                {
                    viewCart.Cart = i.Cart;
                    viewCart.User = i.User;
                    viewCart.Bike = i.Bike;
                    viewCart.Order = i.Order;
                }
            }
            if (result1 != null)
            {
                foreach (var i in result1)
                {
                    viewCart.Cart = i.Cart;
                    viewCart.User = i.User;
                    viewCart.Accessary = i.Accessary;
                    viewCart.Order = i.Order;
                }

            }
            double amount = 0;
            if (viewCart.Accessary != null)
            {
                amount = (viewCart.Accessary.Price -( viewCart.Accessary.Price * viewCart.Accessary.PricePromotion)) * viewCart.Cart.QuantityPurchased;
            }
            if(viewCart.Bike != null)
            {
                amount = (viewCart.Bike.price - (viewCart.Bike.price * viewCart.Bike.PricePromotion)) * viewCart.Cart.QuantityPurchased;
            }
            VnPay vnpay = new VnPay();
            string vnpUrl = _configuration["Vnpay:vnp_Url"];
            string vnpApi = _configuration["Vnpay:vnp_Api"];
            string vnpTmnCode = _configuration["Vnpay:vnp_TmnCode"];
            string vnpHashSecret = _configuration["Vnpay:vnp_HashSecret"];
            string vnpReturnUrl = _configuration["Vnpay:vnp_Returnurl"];
            vnpay.AddRequestData("vnp_Version", VnPay.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnpTmnCode);
            vnpay.AddRequestData("vnp_Amount", (amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.IdOrder);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_ReturnUrl", vnpReturnUrl);
            vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1");
            vnpay.AddRequestData("vnp_TxnRef", order.IdOrder.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss")); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            Console.WriteLine(_configuration["vnp_TmnCode"]);
            _logger.LogInformation("order {}",order.ToString());

            //Add Params of 2.1.0 Version
            //Billing
            string paymentUrl = vnpay.CreateRequestUrl(vnpUrl, vnpHashSecret);
            _logger.LogInformation("VNPAY URL: {0}", paymentUrl);
           return Redirect(paymentUrl);

        }


        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        [HttpGet("Orders/Create/{IdCart:long}")]
        public async Task<IActionResult> Create(long IdCart)
        {
            if(HttpContext.Session.GetString("idUser") != null)
            {
                if (IdCart != 0 || IdCart != null)
                {
                    User user = await _context.Users.FirstOrDefaultAsync(m => m.IdUser == Int32.Parse(HttpContext.Session.GetString("idUser")));
                    Cart cart = await _context.Carts.FirstOrDefaultAsync(m => m.IdCart == IdCart);
                    Order order = new Order();
                    order.IdCart = IdCart;
                    order.OrderStatus = STATUS.PENDING.ToString();
                    order.Address = "";
                    order.NumberPhone = user.Phone;
                  
                    return View(order);
                 }
            }
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,NumberPhone,Address,OrderStatus,IdCart")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                var cart = await _context.Carts.FindAsync(order.IdCart);
               
                var bike= await _context.Bike.FindAsync(cart.IdBike);
                var accessary = await _context.Accessaries.FindAsync(cart.IdAccessary);
                if (bike != null)
                {
                    bike.Quantity = bike.Quantity - cart.QuantityPurchased;
                    if (bike.Quantity >= 0)
                    {
                        _context.Bike.Update(bike);
                    }
                }
                if (accessary != null)
                {
                    accessary.Quantity = accessary.Quantity - cart.QuantityPurchased;
                    if(accessary.Quantity >= 0)
                    {
                        _context.Accessaries.Update(accessary);
                    }
                }
               
                if(bike?.Quantity >=0 || accessary?.Quantity >= 0)
                {
                    await _context.SaveChangesAsync();
                }
              
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,NumberPhone,Address,OrderStatus,IdCart")] Order order)
        {
            if (id != order.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.IdOrder))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'DataContext.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(long id)
        {
          return (_context.Order?.Any(e => e.IdOrder == id)).GetValueOrDefault();
        }
    }
}
