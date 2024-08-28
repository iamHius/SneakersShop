using Microsoft.AspNetCore.Mvc;
using SneakersShop.Areas.Identity.Data;

namespace SneakersShop.Components
{
	public class BrandSection : ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public BrandSection(ApplicationDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View("Index",_context.Brands.ToList());
		}
	}
}
