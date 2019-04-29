using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RockeyProject.Models.ViewModels;
using RockeyProject.Models;

namespace RockeyProject.Controllers
{

	[Authorize]
	public class AccountController : Controller
	{
		private UserManager<IdentityUser> userManager;
		private SignInManager<IdentityUser> signInManager;
		private ICustomerRepository repository;

		// Initiates all the stuff
		public AccountController(UserManager<IdentityUser> userMgr,SignInManager<IdentityUser> signInMgr, ICustomerRepository repo)
		{
			repository = repo;
			userManager = userMgr;
			signInManager = signInMgr;
			
			IdentitySeedData.EnsurePopulated(userMgr).Wait();
			
		}
		
		// Directs to Signup view and check model data
		[AllowAnonymous]
		[HttpPost]
		public IActionResult Signup(Customer customer)
		{
			if (ModelState.IsValid)
			{
				repository.SaveCustomer(customer,userManager);
				TempData["message"] = $"Thank you {customer.FirstName}, your account has been created";
				return RedirectToAction("List", "Product");
			}
			else
			{
				// there is something wrong with the data values
				return RedirectToAction("Signup", "Home");
			}
		}

		// Returns login view and checks logs them in or doesnt
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user =
					await userManager.FindByNameAsync(loginModel.Name);
				if (user != null)
				{
					await signInManager.SignOutAsync();
					if ((await signInManager.PasswordSignInAsync(user,
							loginModel.Password, false, false)).Succeeded)
					{
						return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
					}
				}
			}
			ModelState.AddModelError("", "Invalid name or password");
			return View(loginModel);
		}

		// Redirects to signup view
		public IActionResult Create()
		{
			return RedirectToAction("Signup","Home");
		}

		// Logs user out
		public async Task<RedirectResult> Logout(string returnUrl = "/")
		{
			await signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}


	
	}
}
