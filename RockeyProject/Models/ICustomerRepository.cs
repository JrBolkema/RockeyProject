using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models
{
	public interface ICustomerRepository
	{
		
		IQueryable<Customer> Customers { get; }

		void SaveCustomer(Customer Customer);

		Customer DeleteCustomer(int CustomerID);
	}
}

