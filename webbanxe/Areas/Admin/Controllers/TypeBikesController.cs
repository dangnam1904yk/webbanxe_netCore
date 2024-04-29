using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbanxe.Data;
using webbanxe.Models;
using webbanxe.Models.Authentications;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TypeBikesController : Controller
    {
        private readonly DataContext _context;

        public TypeBikesController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/TypeBikes
        [Authentication]
        public async Task<IActionResult> Index()
        {
              return _context.TypeBike != null ? 
                          View(await _context.TypeBike.ToListAsync()) :
                          Problem("Entity set 'DataContext.TypeBike'  is null.");
        }

        // GET: Admin/TypeBikes/Details/5
        [Authentication]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeBike == null)
            {
                return NotFound();
            }

            var typeBike = await _context.TypeBike
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (typeBike == null)
            {
                return NotFound();
            }

            return View(typeBike);
        }

        // GET: Admin/TypeBikes/Create
        [Authentication]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeBikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Create([Bind("IdType,NameType")] TypeBike typeBike)
        {
                _context.Add(typeBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Admin/TypeBikes/Edit/5
        [Authentication]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeBike == null)
            {
                return NotFound();
            }

            var typeBike = await _context.TypeBike.FindAsync(id);
            if (typeBike == null)
            {
                return NotFound();
            }
            return View(typeBike);
        }

        // POST: Admin/TypeBikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(int id, [Bind("IdType,NameType")] TypeBike typeBike)
        {
            if (id != typeBike.IdType)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(typeBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeBikeExists(typeBike.IdType))
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

        // GET: Admin/TypeBikes/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeBike == null)
            {
                return NotFound();
            }

            var typeBike = await _context.TypeBike
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (typeBike == null)
            {
                return NotFound();
            }

            return View(typeBike);
        }

        // POST: Admin/TypeBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeBike == null)
            {
                return Problem("Entity set 'DataContext.TypeBike'  is null.");
            }
            var typeBike = await _context.TypeBike.FindAsync(id);
            if (typeBike != null)
            {
                _context.TypeBike.Remove(typeBike);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeBikeExists(long id)
        {
          return (_context.TypeBike?.Any(e => e.IdType == id)).GetValueOrDefault();
        }
    }
}
