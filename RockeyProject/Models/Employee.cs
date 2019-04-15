using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyProject.Models
{
	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string Email { get;}
		public string PhoneNumber { get; set; }
		public string Position { get; set; }
		public string Photo { get; set; }
		public Employee(string FName,string LName, string PhoneNumberParamater,string PositionParameter)
		{
			FirstName = FName;
			LastName = LName;
			Email = $"{FName}.{LName}@Rockeys.com";
			FullName = $"{FName} {LName}";
			Photo = $"{FName}.png";
			PhoneNumber = PhoneNumberParamater;
			Position = PositionParameter;

		}
	}
}
