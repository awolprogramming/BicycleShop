using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BicycleShop.Entities;

namespace BicycleShop.Controllers
{
    public class BicycleShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BicycleShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BicycleShop
        public async Task<IActionResult> Index()
        {
            return View(await _context.BicycleShop.ToListAsync());
        }

        // GET: BicycleShop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleShopEntity = await _context.BicycleShop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicycleShopEntity == null)
            {
                return NotFound();
            }

            return View(bicycleShopEntity);
        }

        // GET: BicycleShop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BicycleShop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,PhoneNumber")] BicycleShopEntity bicycleShopEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicycleShopEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicycleShopEntity);
        }

        // GET: BicycleShop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleShopEntity = await _context.BicycleShop.FindAsync(id);
            if (bicycleShopEntity == null)
            {
                return NotFound();
            }
            return View(bicycleShopEntity);
        }

        // POST: BicycleShop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,PhoneNumber")] BicycleShopEntity bicycleShopEntity)
        {
            if (id != bicycleShopEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycleShopEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleShopEntityExists(bicycleShopEntity.Id))
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
            return View(bicycleShopEntity);
        }

        // GET: BicycleShop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleShopEntity = await _context.BicycleShop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicycleShopEntity == null)
            {
                return NotFound();
            }

            return View(bicycleShopEntity);
        }

        // POST: BicycleShop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicycleShopEntity = await _context.BicycleShop.FindAsync(id);
            if (bicycleShopEntity != null)
            {
                _context.BicycleShop.Remove(bicycleShopEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleShopEntityExists(int id)
        {
            return _context.BicycleShop.Any(e => e.Id == id);
        }
    }
}
