
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public void SaveCustomer(Customer Customer)
		{
			throw new NotImplementedException();
		}
	}
}
