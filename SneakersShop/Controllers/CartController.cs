﻿using Microsoft.AspNetCore.Mvc;
using SneakersShop.Areas.Identity.Data;
using SneakersShop.Infrastructure;
using SneakersShop.Models;
using Microsoft.AspNetCore.Authorization;
namespace SneakersShop.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		public Cart? Cart { get; set; }
		private readonly ApplicationDbContext _context;
		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View("Cart", HttpContext.Session.GetJSon<Cart>("cart"));
		}

		public IActionResult AddToCart(int productId)
		{
			Product? product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJSon<Cart>("cart") ?? new Cart();
				Cart.AddItem(product, 1);
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}

		public IActionResult UpdateCart(int productId)
		{
			Product? product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJSon<Cart>("cart") ?? new Cart();
				Cart.AddItem(product, -1);
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}

		public IActionResult RemoveFromCart(int productId)
		{
			Product? product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJSon<Cart>("cart");
				Cart.RemoveLine(product);
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}
	}
}
