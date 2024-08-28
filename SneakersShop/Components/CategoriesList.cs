using Microsoft.AspNetCore.Mvc;
using SneakersShop.Areas.Identity.Data;

namespace SneakersShop.Components
{
	public class CategoriesList : ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public CategoriesList(ApplicationDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View("Index", _context.Categories.ToList());
		}
	}
}
