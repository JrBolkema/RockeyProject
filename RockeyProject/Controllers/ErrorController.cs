using Microsoft.AspNetCore.Mvc;

namespace RockeyProject.Controllers
{

	public class ErrorController : Controller
	{
		//Returns error view
		public ViewResult Error() => View();
	}
}
