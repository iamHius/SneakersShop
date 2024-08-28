using Microsoft.AspNetCore.Mvc;
using SneakersShop.Areas.Identity.Data;

namespace SneakersShop.Components
{
	public class GenderList : ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public GenderList(ApplicationDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View("Index", _context.Genders.ToList());
		}
	}
}
