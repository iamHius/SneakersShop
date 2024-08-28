using Microsoft.AspNetCore.Mvc;

namespace SneakersShop.Components
{
	public class GenderSection : ViewComponent
	{
		public IViewComponentResult Invoke()

		{  
			return View("Index"); 
		}

	}
}
