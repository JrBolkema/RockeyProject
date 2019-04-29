
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RockeyProject.Models
{
	public class EFCustomerRepository : ICustomerRepository
	{
		private ApplicationDbContext context;

		public EFCustomerRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}
		public IQueryable<Customer> Customers => context.Customers;

		public Customer DeleteCustomer(int CustomerID)
		{
			throw new NotImplementedException();
		}

		public async void SaveCustomer(Customer Customer,UserManager<IdentityUser> userManager)
		{
			if (Customer.CustomerID == 0)
			{
				context.Customers.Add(Customer);
			}
			else
			{
				//IdentityUser user = await userManager.FindByIdAsync(Customer.Username);

				//if (user == null)
				//{
				//	user = new IdentityUser(Customer.Username);
				//	await userManager.CreateAsync(user, Customer.Password);



				//}
				Customer dbEntry = context.Customers
					.FirstOrDefault(p => p.CustomerID == Customer.CustomerID);
				if (dbEntry != null)
				{
					dbEntry.Username = Customer.Username;
					dbEntry.FirstName = Customer.FirstName;
					dbEntry.LastName = Customer.LastName;
					dbEntry.Email = Customer.Email;
					dbEntry.Password = Customer.Password;
				}
			}
			context.SaveChanges();
		}
	}
}
