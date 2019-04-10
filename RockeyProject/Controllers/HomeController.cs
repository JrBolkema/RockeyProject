using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RockeyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		public ViewResult Contact()
		{
			return View();
		}

		[AllowAnonymous]
		public ViewResult About()
		{
			return View();
		}
		[AllowAnonymous]
		public ViewResult Homepage()
		{
			return View();
		}
	}
}