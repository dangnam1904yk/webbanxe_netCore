using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    
    public class PostsController : Controller
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Posts
        [Authentication]
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Posts.Include(p => p.menu);
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/Posts/Details/5
        [Authentication]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.menu)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
       // [Authentication]
        public async Task<IActionResult> CreateOrUpdate(int id)
        {
            var post = await _context.Posts
                .Include(p => p.menu)
                .FirstOrDefaultAsync(m => m.PostID == id);
            return post!=null ? View(post) : View(new Post());
        }


        [HttpPost]
       // [Authentication]
        public async Task<IActionResult> CreateOrUpdate(Post post)
        {
            if (ModelState.IsValid)
            {
                if (post.PostID == 0)
                {
                    if (post.ImageFile != null)
                    {
                       post.Images = Functions.saveSingleImage(post.ImageFile);
        
                    }
                    post.MenuID = 1;
                    _context.Posts.Add(post);
                }
                else
                {
                    var oldPost = await _context.Posts
                          .FirstOrDefaultAsync(m => m.PostID == post.PostID);

                    if (post.ImageFile != null)
                    {
                        post.Images = Functions.saveSingleImage(post.ImageFile);
                        Functions.deleteSingleImage(oldPost.Images);
                    }
                    else
                    {
                        post.Images = oldPost.Images;
                    }
                    post.MenuID = 1;
                    _context.Posts.Update(post);
                }
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Create([Bind("PostID,Title,Abstract,Contents,Images,Link,Author,CreatedDate,IsActive,PostOrder,Category,Status,MenuID")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuID"] = new SelectList(_context.Menus, "MenuID", "MenuID", post.MenuID);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        [Authentication]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["MenuID"] = new SelectList(_context.Menus, "MenuID", "MenuID", post.MenuID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(long id, [Bind("PostID,Title,Abstract,Contents,Images,Link,Author,CreatedDate,IsActive,PostOrder,Category,Status,MenuID")] Post post)
        {
            if (id != post.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
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
            ViewData["MenuID"] = new SelectList(_context.Menus, "MenuID", "MenuID", post.MenuID);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.menu)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'DataContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            Functions.deleteSingleImage(post.Images);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(long id)
        {
          return (_context.Posts?.Any(e => e.PostID == id)).GetValueOrDefault();
        }
    }
}
