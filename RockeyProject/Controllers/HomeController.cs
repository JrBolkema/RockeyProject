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

		public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		public ViewResult Contact()
		{
			return View();
		}
		public HomeController(IEmployeeRepository repo)
		{
			repository = repo;
		}

		[AllowAnonymous]
		public ViewResult About(string category, int productPage = 1)
			=> View(new EmployeeListViewModel
			{
				Employee = repository.Employees
					.OrderBy(p => p.EmployeeID),
			});
		[AllowAnonymous]
		public ViewResult Homepage()
		{
			return View();
		}
	}
}