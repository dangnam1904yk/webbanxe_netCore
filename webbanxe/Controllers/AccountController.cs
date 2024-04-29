using Microsoft.AspNetCore.Mvc;
using webbanxe.Data;
using webbanxe.Help;
using webbanxe.Models;

namespace webbanxe.Controllers
{
    public class AccountController : Controller
    {
        private const int ROLE_ADMIN = 1;
        private const int ROLE_USER = 2;
        private readonly ILogger<AccountController> _logger;
        private readonly DataContext _context;

        public AccountController(ILogger<AccountController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public IActionResult Login(User u)
        {

            if (HttpContext.Session.GetString("username") == null)
            {
                var user = _context.Users.Where(x => x.UserName.Equals(u.UserName)
                && x.Password.Equals(EncryptPassword.EncrytMd5(u.Password))).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetString("idUser", user.IdUser.ToString());
                    HttpContext.Session.SetString("role", user.RoleId.ToString());

                    if (Int32.Parse(HttpContext.Session.GetString("role")) == ROLE_ADMIN)
                    {
                        var routeValues = new RouteValueDictionary
                        {
                            {"area","Admin" }
                        };
                        return RedirectToAction("Index", "Home", routeValues);

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            u.Password = EncryptPassword.EncrytMd5(u.Password);
            u.Roles = new Roles(2, "User");
            _context.Roles.Update(u.Roles);
            _context.Users.Add(u);
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Index", "Home");
        }

        [Route("/Admin/logout")]
        public IActionResult LogoutAdmin()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Index", "Home");
        }
    }
}
