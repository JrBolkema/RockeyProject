using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models;
using System.Linq;
using RockeyProject.Models.ViewModels;

namespace RockeyProject.Controllers
{
	[ResponseCache(Duration = 60)]

	public class ProductController : Controller
	{
		private IProductRepository repository;
		//Determines how many items will appear per page
		public int PageSize = 4;

		//Repo init
		public ProductController(IProductRepository repo)
		{
			repository = repo;
		}

		//Returns all products in a given category
		public ViewResult List(string category, int productPage = 1)
			=> View(new ProductsListViewModel
			{
				Products = repository.Products
					.Where(p => category == null || p.Category == category)
					.OrderBy(p => p.ProductID)
					.Skip((productPage - 1) * PageSize)
					.Take(PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = PageSize,
					TotalItems = category == null ?
						repository.Products.Count() :
						repository.Products.Where(e =>
							e.Category == category).Count()
				},
				CurrentCategory = category
			});
	}
}
