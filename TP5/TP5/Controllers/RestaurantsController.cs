using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP5.Models.RestosModel;

namespace TP5.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestosDbContext _context;

        public RestaurantsController(RestosDbContext context)
        {
            _context = context;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var restosDbContext = _context.Restaurants.Include(r => r.LeProprio);
            return View(await restosDbContext.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.LeProprio)
                .FirstOrDefaultAsync(m => m.CodeResto == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            ViewData["NumProp"] = new SelectList(_context.Proprietaires, "Numero", "Nom");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeResto,NomResto,Specialite,Ville,Tel,NumProp")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumProp"] = new SelectList(_context.Proprietaires, "Numero", "Nom", restaurant.NumProp);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewData["NumProp"] = new SelectList(_context.Proprietaires, "Numero", "Nom", restaurant.NumProp);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeResto,NomResto,Specialite,Ville,Tel,NumProp")] Restaurant restaurant)
        {
            if (id != restaurant.CodeResto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.CodeResto))
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
            ViewData["NumProp"] = new SelectList(_context.Proprietaires, "Numero", "Email", restaurant.NumProp);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.LeProprio)
                .FirstOrDefaultAsync(m => m.CodeResto == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.CodeResto == id);
        }

        public async Task<IActionResult> ListeAvisParResto()
        {
            var restos = await _context.Restaurants
                .Include(r => r.LesAvis)
                .ToListAsync();

            return View(restos);
        }


        public async Task<IActionResult> AvisDuResto(int codeResto)
        {
            var resto = await _context.Restaurants
                .Include(r => r.LesAvis)
                .FirstOrDefaultAsync(r => r.CodeResto == codeResto);

            if (resto == null) return NotFound();

            return View(resto);
        }

        public async Task<IActionResult> RestosBienNotes()
        {
            var restos = await _context.Restaurants
                .Where(r => r.LesAvis.Any())
                .Select(r => new
                {
                    Resto = r,
                    Moyenne = r.LesAvis.Average(a => a.Note)
                })
                .Where(x => x.Moyenne >= 3.5)
                .ToListAsync();

        

            return View(restos);
        }


    }

}
