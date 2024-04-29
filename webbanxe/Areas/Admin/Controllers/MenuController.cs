using Microsoft.AspNetCore.Mvc;
using webbanxe.Data;
using webbanxe.Models.Authentications;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }
        [Authentication]
        public IActionResult Index()
        {
            var mnList = _context.Menus.OrderBy(m=>m.MenuID).ToList();
            return View(mnList);
        }
    }
}
