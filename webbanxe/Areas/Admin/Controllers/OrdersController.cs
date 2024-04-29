using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbanxe.Constant;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.Authentications;
using webbanxe.Models.ModelView;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Orders
        [Authentication]
        public async Task<IActionResult> Index()
        {
            var result = from o in _context.Order
                         join c in _context.Carts on o.IdCart equals c.IdCart
                         join b in _context.Bike on c.IdBike equals b.IdBike
                         join u in _context.Users on c.IdUser equals u.IdUser
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

        [HttpGet("Admin/Orders/Cancal-Order/{id:int}")]
        [Authentication]
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
                if (bike != null)
                {
                    bike.Quantity = bike.Quantity + cart.QuantityPurchased;
                    _context.Bike.Update(bike);
                }
                if (acc != null)
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

        [HttpGet("Admin/Orders/Payment-Order/{id:int}")]
        [Authentication]
        public async Task<IActionResult> Payment_Order(int? id)
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
                order.OrderStatus = STATUS.PAYMENT.ToString();
                _context.Order.Update(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet("Admin/Orders/Approve-Order/{id:int}")]
        [Authentication]
        public async Task<IActionResult> Approve_Order(int? id)
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
                order.OrderStatus = STATUS.APPROVE.ToString();
                _context.Order.Update(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Orders/Delivering-Order/{id:int}")]
        [Authentication]
        public async Task<IActionResult> Delivering_Order(int? id)
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
                if(order.OrderStatus.Equals(STATUS.PAYMENT.ToString()))
                {
                    order.OrderStatus = order.OrderStatus + "," + STATUS.DELIVERING.ToString();
                }
                else
                {
                    order.OrderStatus = STATUS.NO_PAYMENT + "," + STATUS.DELIVERING;
                }
                
                _context.Order.Update(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Orders/Delivered-Order/{id:int}")]
        [Authentication]
        public async Task<IActionResult> Delivered_Order(int? id)
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
                order.OrderStatus =STATUS.PAYMENT.ToString()+","+ STATUS.DELIVERED.ToString();
                _context.Order.Update(order);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        [Authentication]
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
        [Authentication]
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

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.IdOrder == id)).GetValueOrDefault();
        }
    }
}
