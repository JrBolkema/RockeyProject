using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace RockeyProject.Controllers
{

	public class OrderController : Controller
	{
		private IOrderRepository repository;
		private Cart cart;

		//Initializing stuff
		public OrderController(IOrderRepository repoService, Cart cartService)
		{
			repository = repoService;
			cart = cartService;
		}

		//Redirects to a view of users orders given that they are logged in
		[Authorize]
		public ViewResult List() =>
			View(repository.Orders.Where(o => !o.Shipped));

		[HttpPost]
		[Authorize]
		//Marks an order as shipped given the ID
		public IActionResult MarkShipped(int orderID)
		{
			Order order = repository.Orders
				.FirstOrDefault(o => o.OrderID == orderID);
			if (order != null)
			{
				order.Shipped = true;
				repository.SaveOrder(order);
			}
			return RedirectToAction(nameof(List));
		}

		//Redirects to creating a new order
		public ViewResult Checkout() => View(new Order());

		//Checks validity to return a view of cart
		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			if (cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry, your cart is empty!");
			}
			if (ModelState.IsValid)
			{
				order.Lines = cart.Lines.ToArray();
				repository.SaveOrder(order);
				return RedirectToAction(nameof(Completed));
			}
			else
			{
				return View(order);
			}
		}

		//clears cart and displays succcess message
		public ViewResult Completed()
		{
			cart.Clear();
			return View();
		}
	}
}
