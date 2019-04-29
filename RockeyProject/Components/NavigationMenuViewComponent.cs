using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RockeyProject.Models;

namespace RockeyProject.Components
{
	// For Creating the nav bar for products
	public class NavigationMenuViewComponent : ViewComponent
	{
		private IProductRepository repository;

		public NavigationMenuViewComponent(IProductRepository repo)
		{
			repository = repo;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x));
		}
	}
}
