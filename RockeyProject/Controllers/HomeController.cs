using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models.ViewModels;
using RockeyProject.Models;

namespace RockeyProject.Controllers
{
    public class HomeController : Controller
    {
		private IEmployeeRepository repository;

		//Directs the index view
		public IActionResult Index()
        {
            return View();
        }
		// Returns the contact view
		[AllowAnonymous]
		public ViewResult Contact()
		{
			return View();
		}
		public HomeController(IEmployeeRepository repo)
		{
			repository = repo;
		}
		// Returns the about view, takes employees from database
		[AllowAnonymous]
		public ViewResult About(string category, int productPage = 1)
			=> View(new EmployeeListViewModel
			{
				Employee = repository.Employees
					.OrderBy(p => p.EmployeeID),
			});

		// Returns Homepage view
		[AllowAnonymous]
		public ViewResult Homepage()
		{
			return View();
		}

		// Returns PDF of user manual
		[AllowAnonymous]
		public VirtualFileResult Peabody()
		{
			return File("~lib/PDFs/Peabody.pdf","application/pdf");
		}

		// Returns the login view
		[AllowAnonymous]
		public ViewResult Login(string returnUrl)
		{
			return View(new LoginModel
			{
				ReturnUrl = returnUrl
			});
		}

		// Redirects to signup view and creates a new customer for model
		[AllowAnonymous]
		public ViewResult Signup() => View("Signup", new Customer());

	}
}