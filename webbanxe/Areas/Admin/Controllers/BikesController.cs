using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.Authentications;
using webbanxe.Models.ModelView;
using webbanxe.Utilities;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BikesController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        


        public BikesController(DataContext context, ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _logger = logger;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Bikes
        [Authentication]
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Bike.Include(b => b.TypeBike);
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/Bikes/Details/5
        [Authentication]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.TypeBike)
                .FirstOrDefaultAsync(m => m.IdBike == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }


        [HttpGet]
        [Authentication]
        public IActionResult CreateOrUpdate(int? id)
        {
            
            ViewBike viewBike = new ViewBike();
            viewBike.Bike = new Bike();
            viewBike.ListTypeBike = _context.TypeBike.ToList().Select( m=>
            new SelectListItem { Text = m.NameType, Value = m.IdType.ToString() });

            var data = _context.TypeBike.ToList();
            ViewBag.TypeBike = new SelectList(data, "IdType", "NameType");
            if( id == null || id == 0)
            {
                return View(viewBike);
            }
            else
            {
                var bike = from m in _context.Bike where m.IdBike == id select m;
                foreach( var item in bike)
                {
                    viewBike.Bike.IdBike = item.IdBike;
                    viewBike.Bike.NameBike = item.NameBike;
                    viewBike.Bike.price = item.price;
                    viewBike.Bike.PricePromotion = item.PricePromotion;
                    viewBike.Bike.DescriptionBike   = item.DescriptionBike;
                    viewBike.Bike.IdType = item.IdType;
                    viewBike.Bike.Quantity = item.Quantity;
                }
                return View(viewBike);
            }
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> CreateOrUpdate(ViewBike viewBike)
        {
            if (ModelState.IsValid)
            {
                if (viewBike.Bike.IdBike == 0)
                {
                    if (viewBike.Bike.ImageFile != null)
                    {
                        viewBike.Bike.ImageBike = Functions.saveMutiImage(viewBike.Bike.ImageFile);
                    }
                    _context.Bike.Add(viewBike.Bike);

                }
                else
                {

                    var oldBike = await _context.Bike.FindAsync(viewBike.Bike.IdBike);

                    if (viewBike.Bike.ImageFile != null)
                    {
                        viewBike.Bike.ImageBike = Functions.saveMutiImage(viewBike.Bike.ImageFile);
                        Functions.deleteMutiImage(oldBike.ImageBike);
                    }
                    else
                    {
                         viewBike.Bike.ImageBike = oldBike.ImageBike;
                    }
                   
                    _context.Bike.Update(viewBike.Bike);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewBike);
            }
               
        }

        // GET: Admin/Bikes/Edit/5
        [Authentication]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            ViewData["IdType"] = new SelectList(_context.TypeBike, "IdType", "NameBike", bike.IdType);
            return View(bike);
        }

        // POST: Admin/Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(int id, [Bind("IdBike,NameBike,price,PricePromotion,Quantity,bike.ImageBike,DescriptionBike,IdType")] Bike bike)
        {
            if (id != bike.IdBike)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.IdBike))
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
            ViewData["IdType"] = new SelectList(_context.TypeBike, "IdType", "NameBike", bike.IdType);
            return View(bike);
        }

        // GET: Admin/Bikes/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.TypeBike)
                .FirstOrDefaultAsync(m => m.IdBike == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Admin/Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bike == null)
            {
                return Problem("Entity set 'DataContext.Bike'  is null.");
            }
            var bike = await _context.Bike.FindAsync(id);
            if (bike != null)
            {
                _context.Bike.Remove(bike);
            }
            Functions.deleteMutiImage(bike.ImageBike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(long id)
        {
          return (_context.Bike?.Any(e => e.IdBike == id)).GetValueOrDefault();
        }
    }
}
