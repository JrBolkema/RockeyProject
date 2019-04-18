using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models.ViewModels
{
	public class EmployeeListViewModel
	{
		public IEnumerable<Employee> Employee { get; set; }
	}
}
