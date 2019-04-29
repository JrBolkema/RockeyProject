using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace RockeyProject.Controllers
{

	[Authorize]
	public class AdminController : Controller
	{
		private IProductRepository repository;

		public AdminController(IProductRepository repo)
		{
			repository = repo;
		}

		//Returns a list of all products 
		public ViewResult Index() => View(repository.Products);

		// Returns edit view given a product
		public ViewResult Edit(int productId) =>
			View(repository.Products
				.FirstOrDefault(p => p.ProductID == productId));
		
		// Saves changes to the given product
		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				repository.SaveProduct(product);
				TempData["message"] = $"{product.Name} has been saved";
				return RedirectToAction("Index");
			}
			else
			{
				// there is something wrong with the data values
				return View(product);
			}
		}

		// Returns view for creating a product
		public ViewResult Create() => View("Edit", new Product());

		// Deletes product given a product id
		[HttpPost]
		public IActionResult Delete(int productId)
		{
			Product deletedProduct = repository.DeleteProduct(productId);
			if (deletedProduct != null)
			{
				TempData["message"] = $"{deletedProduct.Name} was deleted";
			}
			return RedirectToAction("Index");
		}

		//[HttpPost]
		//public IActionResult SeedDatabase()
		//{
		//	SeedData.EnsurePopulated(HttpContext.RequestServices);
		//	return RedirectToAction(nameof(Index));
		//}
	}
}
