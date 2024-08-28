using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Areas.Identity.Data;
using SneakersShop.Models;
using SneakersShop.Models.ViewModels;

namespace SneakersShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public int PageSize = 9;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int productpage = 1)
        {
            /*var applicationDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Gender).Include(p => p.Size);*/
            return View(new ProductListViewModel
            {
                Products = _context.Products.Skip((productpage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = productpage,
                    TotalItem = _context.Products.Count()
                }

            });
        }

		[HttpPost]
		public async Task<IActionResult> Search(string keywords, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.ProductName.Contains(keywords))
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}
			});
		}

		[HttpGet]
		public async Task<IActionResult> ProductsByCat(int categoryId, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.CategoryId == categoryId)
				.Include(p => p.Category)
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}

			});
		}

		[HttpGet]
		public async Task<IActionResult> ProductsBySize(int sizeId, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.SizeId == sizeId)
				.Include(p => p.Size)
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}

			});
		}
		[HttpGet]
		public async Task<IActionResult> ProductsByBrand(int brandId, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.BrandId == brandId)
				.Include(p => p.Brand)
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}

			});
		}

		[HttpGet]
		public async Task<IActionResult> ProductsByColor(int colorId, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.ColorId == colorId)
				.Include(p => p.Color)
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}

			});
		}
		[HttpGet]
		public async Task<IActionResult> ProductsByGender(int genderId, int productpage = 1)
		{
			return View("Index", new ProductListViewModel
			{
				Products = _context.Products
				.Where(p => p.GenderId == genderId)
				.Include(p => p.Gender)
				.Skip((productpage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurrentPage = productpage,
					TotalItem = _context.Products.Count()
				}

			});
		}


		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Gender)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

		// GET: Products/Create
		[Authorize]
		public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorName");
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,ProductPirce,ProductPhoto,BestSeller,CategoryId,BrandId,ColorId,GenderId,SizeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName", product.GenderId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

		// GET: Products/Edit/5
		[Authorize]
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName", product.GenderId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,ProductPirce,ProductPhoto,BestSeller,CategoryId,BrandId,ColorId,GenderId,SizeId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName", product.GenderId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

		// GET: Products/Delete/5
		[Authorize]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Gender)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize]
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
    }
}
