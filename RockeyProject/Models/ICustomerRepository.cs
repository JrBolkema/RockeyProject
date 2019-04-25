using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RockeyProject.Models
{
	public interface ICustomerRepository
	{
		
		IQueryable<Customer> Customers { get; }

		void SaveCustomer(Customer Customer,UserManager<IdentityUser> userManager);

		Customer DeleteCustomer(int CustomerID);
	}
}

