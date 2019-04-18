using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models
{
	public class EFEmployeeRepository :IEmployeeRepository
	{
		private ApplicationDbContext context;

		public EFEmployeeRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}

		public IQueryable<Employee> Employees => context.Employees;
	}
}
