using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using webbanxe.Data;
using webbanxe.Help;
using webbanxe.Models;
using webbanxe.Models.ModelView;

namespace webbanxe.Controllers
{
    public class CartController : Controller
    {

        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("idUser") != null)
            {
                var idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
                var listCart2 = from c in _context.Carts
                                join
                                u in _context.Users on c.IdUser equals u.IdUser
                                join b in _context.Bike on c.IdBike equals b.IdBike
                                where c.IdUser == idUser
                                select new
                                {
                                    Cart = c,
                                    Bike = b,
                                    User = u
                                };
                
                var listCart1 = from c in _context.Carts
                                join
                                u in _context.Users on c.IdUser equals u.IdUser
                                join b in _context.Accessaries on c.IdAccessary equals b.IdAccessary
                                where c.IdUser == idUser
                                select new
                                {
                                    Cart = c,
                                    Accessary = b,
                                    User = u
                                };
                var listOrder = from i in _context.Order.ToList() select i;
                List<ViewCart> listViewCart = new List<ViewCart>();

                if (listCart2 != null)
                {
                    foreach (var i in listCart2)
                    {
                        ViewCart viewCart = new ViewCart();
                        viewCart.Cart = i.Cart;
                        viewCart.User = i.User;
                        viewCart.Bike = i.Bike;
                        listViewCart.Add(viewCart);

                        foreach (var item in listOrder)
                        {

                            if (i.Cart.IdCart == item.IdCart)
                            {
                                listViewCart.Remove(viewCart);
                                break;
                            }
                        }
                    }

                }

                if (listCart1 != null)
                {
                    foreach (var i in listCart1)
                    {
                        ViewCart viewCart = new ViewCart();
                        viewCart.Cart = i.Cart;
                        viewCart.User = i.User;
                        viewCart.Accessary = i.Accessary;
                        listViewCart.Add(viewCart);

                        foreach (var item in listOrder)
                        {

                            if (i.Cart.IdCart == item.IdCart)
                            {
                                listViewCart.Remove(viewCart);
                                break;
                            }
                        }
                    }

                }
                var a = listViewCart;
                return View(listViewCart);
            }
            else
            {
            return RedirectToAction("login", "Account");
            }
        }

        [Route("/add-to-cart/{idBike:int}.html")]
        [Route("/add-to-cart-accesary/{idAccesary:int}.html")]
        public IActionResult actionResult([FromRoute] int idBike, int idAccesary)
        {
            if (HttpContext.Session.GetString("idUser") != null)
            {
                Cart cart= new Cart();
                cart.IdUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
                cart.QuantityPurchased = 1;
                cart.IdBike = idBike ==0 ? null : idBike;
                cart.IdAccessary = idAccesary==0 ? null : idAccesary;
                _context.Carts.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("login", "Account");
            }
        }

        [HttpGet("/cart/update/{id:int}")]
        public async Task<IActionResult> Modify( long id)
        {
            
            if (HttpContext.Session.GetString("idUser") != null)
            {
               
                var oldCart = await _context.Carts.FindAsync(id);
                if(oldCart != null)
                {
                    var bike = await _context.Bike.FindAsync(oldCart.IdBike);
                      ViewBag.Bike=bike;
                    var access = await _context.Accessaries.FindAsync(oldCart.IdAccessary);
                    ViewBag.Accessarie = access;
                }

                return View(oldCart);
            }
            else
            {
                return RedirectToAction("login", "Account");
            }
        }

        [HttpPost("/cart/update")]
        public IActionResult UpdateCart(Cart cart)
        {

            if (HttpContext.Session.GetString("idUser") != null)
            {
                _context.Carts.Update(cart);
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("login", "Account");
            }
        }


        [HttpGet("/cart/delete/{id:int}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            if (HttpContext.Session.GetString("idUser") != null)
            {

                var oldCart = await _context.Carts.FindAsync(id);
                if(oldCart != null)
                {
                    _context.Carts.Remove(oldCart);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("login", "Account");
            }
        }
    }
}
