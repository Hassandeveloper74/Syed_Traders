using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syed_Traders.Models;

namespace Syed_Traders.Controllers
{
    public class ProductsCategoriesController : Controller
    {
        private readonly ImsContext _context;

        public ProductsCategoriesController(ImsContext context)
        {
            _context = context;
        }

        // GET: ProductsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsCategories.ToListAsync());
        }

        // GET: ProductsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (productsCategory == null)
            {
                return NotFound();
            }

            return View(productsCategory);
        }

        // GET: ProductsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] ProductsCategory productsCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsCategory);
        }

        // GET: ProductsCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategories.FindAsync(id);
            if (productsCategory == null)
            {
                return NotFound();
            }
            return View(productsCategory);
        }

        // POST: ProductsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] ProductsCategory productsCategory)
        {
            if (id != productsCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsCategoryExists(productsCategory.CategoryId))
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
            return View(productsCategory);
        }

        // GET: ProductsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsCategory = await _context.ProductsCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (productsCategory == null)
            {
                return NotFound();
            }

            return View(productsCategory);
        }

        // POST: ProductsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsCategory = await _context.ProductsCategories.FindAsync(id);
            if (productsCategory != null)
            {
                _context.ProductsCategories.Remove(productsCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsCategoryExists(int id)
        {
            return _context.ProductsCategories.Any(e => e.CategoryId == id);
        }
    }
}
