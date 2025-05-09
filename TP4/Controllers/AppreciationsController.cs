using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WL_TP4.Models.HotelModel;

namespace WL_TP4.Controllers
{
    public class AppreciationsController : Controller
    {
        private readonly HotelModelDbContext _context;

        public AppreciationsController(HotelModelDbContext context)
        {
            _context = context;
        }

        // GET: Appreciations
        public async Task<IActionResult> Index()
        {
            var hotelModelDbContext = _context.Appreciation.Include(a => a.Hotel);
            return View(await hotelModelDbContext.ToListAsync());
        }

        // GET: Appreciations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // GET: Appreciations/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.HotelSet, "Id", "Name");
            return View();
        }

        // POST: Appreciations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersName,Comment,Score,HotelId")] Appreciation appreciation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appreciation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.HotelSet, "Id", "Name", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appreciations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.HotelSet, "Id", "Name", appreciation.HotelId);
            return View(appreciation);
        }

        // POST: Appreciations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PersName,Comment,Score,HotelId")] Appreciation appreciation)
        {
            if (id != appreciation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appreciation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppreciationExists(appreciation.Id))
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
            ViewData["HotelId"] = new SelectList(_context.HotelSet, "Id", "Name", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appreciations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // POST: Appreciations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appreciation = await _context.Appreciation.FindAsync(id);
            if (appreciation != null)
            {
                _context.Appreciation.Remove(appreciation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppreciationExists(string id)
        {
            return _context.Appreciation.Any(e => e.Id == id);
        }
    }
}
