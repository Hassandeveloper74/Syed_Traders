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
    public class ProductsListController : Controller
    {
        private readonly ImsContext _context;

        public ProductsListController(ImsContext context)
        {
            _context = context;
        }

        // GET: ProductsList
        public async Task<IActionResult> Index()
        {
            var imsContext = _context.Products.Include(p => p.Category);
            return View(await imsContext.ToListAsync());
        }

        // GET: ProductsList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsList/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ProductsCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: ProductsList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile img)
        {


            string filename = Path.GetFileName(img.FileName);
            string ext = Path.GetExtension(img.FileName);
            if (ext.ToLower() == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".jpeg")
            {
                string Filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/data", filename);
                using (var fs = new FileStream(Filepath, FileMode.Create))
                {
                    await img.CopyToAsync(fs);
                    product.Image = filename;
                }
            }
            else
            {
                TempData["Title"] = "Error";
                TempData["Message"] = "Please Select a Valid Image File";
                TempData["Icon"] = "error";

                return View(product);
            }



           
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: ProductsList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductsCategories, "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        // POST: ProductsList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile img)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (img == null)
            {
                TempData["Title"] = "Error";
                TempData["Message"] = "Image file cannot be null.";
                TempData["Icon"] = "error";
                return View(product);
            }

            // Check other potential nulls
            if (product == null)
            {
                return NotFound();
            }

            string filename = Path.GetFileName(img.FileName);
            string ext = Path.GetExtension(img.FileName);
            if (ext.ToLower() == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".jpeg")
            {
                string Filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/data", filename);
                using (var fs = new FileStream(Filepath, FileMode.Create))
                {
                    await img.CopyToAsync(fs);
                    product.Image = filename;
                }
            }
            else
            {
                TempData["Title"] = "Error";
                TempData["Message"] = "Please Select a Valid Image File";
                TempData["Icon"] = "error";
                return View(product);
            }

            try
            {
                _context.Update(product); // Use Update instead of Add for editing
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
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


        // GET: ProductsList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // GET: ProductsList/ViewProduct
        public async Task<IActionResult> ViewProduct()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }


    }
}
