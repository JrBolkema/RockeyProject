using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models;
using RockeyProject.Models.ViewModels;

namespace RockeyProject.Controllers
{

	public class CartController : Controller
	{
		private IProductRepository repository;
		private Cart cart;

		public CartController(IProductRepository repo, Cart cartService)
		{
			repository = repo;
			cart = cartService;
		}

		// Returns view of cart
		public ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = cart,
				ReturnUrl = returnUrl
			});
		}

		// Adds a given product to the current cart
		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			Product product = repository.Products
				.FirstOrDefault(p => p.ProductID == productId);
			if (product != null)
			{
				cart.AddItem(product, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		// Removes an item from cart given the product id
		public RedirectToActionResult RemoveFromCart(int productId,
				string returnUrl)
		{
			Product product = repository.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				cart.RemoveLine(product);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
	}
}