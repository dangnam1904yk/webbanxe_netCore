using Microsoft.AspNetCore.Mvc;
using webbanxe.Data;
using webbanxe.Models.Authentications;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {   
        private readonly DataContext _context;

        [Authentication]
        public IActionResult Index()
        {
            return View();
        }

        
        public  HomeController(DataContext context)
        {
            _context = context;
        }
        
    }
}
