using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models
{
	public interface IEmployeeRepository
	{
		IQueryable<Employee> Employees { get; }

		//void SaveEmployee(Employee Employee);

		//Employee DeleteEmployee(int EmployeeID);
	}
}
