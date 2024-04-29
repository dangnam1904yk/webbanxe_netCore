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
using webbanxe.Utilities;

namespace webbanxe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidesController : Controller
    {
        private readonly DataContext _context;

        public SlidesController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Slides
        [Authentication]
        public async Task<IActionResult> Index()
        {
              return _context.Slides != null ? 
                          View(await _context.Slides.ToListAsync()) :
                          Problem("Entity set 'DataContext.Slides'  is null.");
        }

        // GET: Admin/Slides/Details/5
        [Authentication]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slides == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        [HttpGet]
        [Authentication]
        public async Task<IActionResult> CreateOrUpdate(int? id)
        {
            var slide = await _context.Slides.FirstOrDefaultAsync(m => m.Id == id);
            if(slide == null)
            {
                slide = new Slide();
            }
            return View(slide);
        }
            // GET: Admin/Slides/Create
            public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> CreateOrUpdate(Slide slide)
        {
            if (ModelState.IsValid)
            {
                if (slide.Id == 0)
                {
                    if (slide.ImageFile != null)
                    {
                        slide.NameImg =   Functions.saveSingleImage(slide.ImageFile);
                        _context.Slides.Add(slide);
                    }
                }
                else
                {
                    var oldSlide = await _context.Slides
                          .FirstOrDefaultAsync(m => m.Id == slide.Id);

                    if (slide.ImageFile != null)
                    {
                        slide.NameImg = Functions.saveSingleImage(slide.ImageFile);
                        Functions.deleteSingleImage(oldSlide.NameImg);
                    }
                    else
                    {
                        slide.NameImg = oldSlide.NameImg;
                    }    
                    _context.Slides.Update(slide);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        // GET: Admin/Slides/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slides == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slides == null)
            {
                return Problem("Entity set 'DataContext.Slides'  is null.");
            }
            var slide = await _context.Slides.FindAsync(id);

            Functions.deleteSingleImage(slide.NameImg);
            if (slide != null)
            {
                _context.Slides.Remove(slide);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideExists(int id)
        {
          return (_context.Slides?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
