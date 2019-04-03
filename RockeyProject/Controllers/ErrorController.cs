using Microsoft.AspNetCore.Mvc;

namespace RockeyProject.Controllers
{

	public class ErrorController : Controller
	{

		public ViewResult Error() => View();
	}
}
