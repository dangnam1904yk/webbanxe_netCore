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
using webbanxe.Models.ModelView;
using webbanxe.Utilities;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccessariesController : Controller
    {
        private readonly DataContext _context;

        public AccessariesController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Accessaries
        [Authentication]
        public async Task<IActionResult> Index()
        {
              return _context.Accessaries != null ? 
                          View(await _context.Accessaries.ToListAsync()) :
                          Problem("Entity set 'DataContext.Accessaries'  is null.");
        }

        // GET: Admin/Accessaries/Details/5
        [Authentication]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accessaries == null)
            {
                return NotFound();
            }

            var accessary = await _context.Accessaries
                .FirstOrDefaultAsync(m => m.IdAccessary == id);
            if (accessary == null)
            {
                return NotFound();
            }

            return View(accessary);
        }

        // GET: Admin/Accessaries/CreateOrUpdate
        [Authentication]
        public async Task<IActionResult> CreateOrUpdate(int? id)
        {
            return await _context.Accessaries.FirstOrDefaultAsync(m => m.IdAccessary == id)!= null
                ?
                View(await _context.Accessaries.FirstOrDefaultAsync(m => m.IdAccessary == id)):
                View(new Accessary());
        }


        // POST: Admin/Accessaries/CreateOrUpdate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> CreateOrUpdate( Accessary accessary)
        {
            if (ModelState.IsValid)
            {
                if (accessary.IdAccessary == 0)
                {
                    if (accessary.ImageFile != null)
                    {
                      accessary.ImageAccessary =  Functions.saveMutiImage(accessary.ImageFile);
                    }
                    _context.Accessaries.Add(accessary);
                }
                else
                {
                    var oldAccessaries = await _context.Accessaries.FindAsync(accessary.IdAccessary);
                    if (accessary.ImageFile != null)
                    {
                        accessary.ImageAccessary = Functions.saveMutiImage(accessary.ImageFile);
                        Functions.deleteMutiImage(oldAccessaries.ImageAccessary);
                    }
                    else
                    {
                        accessary.ImageAccessary = oldAccessaries.ImageAccessary;
                    }

                    _context.Accessaries.Update(accessary);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(accessary);
            }
        }

        // GET: Admin/Accessaries/Edit/5
        [Authentication]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accessaries == null)
            {
                return NotFound();
            }

            var accessary = await _context.Accessaries.FindAsync(id);
            if (accessary == null)
            {
                return NotFound();
            }
            return View(accessary);
        }

        // POST: Admin/Accessaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(int id, [Bind("IdAccessary,NameAccessary,DescriptionAccessary,ImageAccessary,Price,PricePromotion")] Accessary accessary)
        {
            if (id != accessary.IdAccessary)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessaryExists(accessary.IdAccessary))
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
            return View(accessary);
        }

        // GET: Admin/Accessaries/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accessaries == null)
            {
                return NotFound();
            }

            var accessary = await _context.Accessaries
                .FirstOrDefaultAsync(m => m.IdAccessary == id);
            if (accessary == null)
            {
                return NotFound();
            }

            return View(accessary);
        }

        // POST: Admin/Accessaries/Delete/5
        [Authentication]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accessaries == null)
            {
                return Problem("Entity set 'DataContext.Accessaries'  is null.");
            }
            var accessary = await _context.Accessaries.FindAsync(id);
            if (accessary != null)
            {
                _context.Accessaries.Remove(accessary);
            }
            Functions.deleteMutiImage(accessary.ImageAccessary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessaryExists(long id)
        {
          return (_context.Accessaries?.Any(e => e.IdAccessary == id)).GetValueOrDefault();
        }
    }
}
