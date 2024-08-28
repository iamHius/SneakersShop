using Microsoft.AspNetCore.Mvc;
using SneakersShop.Areas.Identity.Data;

namespace SneakersShop.Components
{
	public class SizeList : ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public SizeList(ApplicationDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View("Index", _context.Sizes.ToList());
		}
	}
}
