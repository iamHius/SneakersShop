using Microsoft.AspNetCore.Mvc;

namespace SneakersShop.Components
{
	public class HeroSection : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("Index");
		}
	}
}
