using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models
{
	public class Customer
	{

		public int CustomerID { get; set; } = 0;
		[Required(ErrorMessage = "Please enter your first name")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Please enter your first name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter your last name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please enter your email")]
		[RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter a password")]
		public string Password { get; set; }
	}
}
