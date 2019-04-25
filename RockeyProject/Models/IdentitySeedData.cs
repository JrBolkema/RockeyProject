using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RockeyProject.Models
{

	public static class IdentitySeedData
	{
		private const string adminUser = "Admin";
		private const string adminPassword = "Secret123$";

		public static async Task EnsurePopulated(UserManager<IdentityUser> userManager) //UserManager<IdentityUser> userManager
		{
			
			
			//Using the employee tabble in the RockeyProject Database to populate Identity Database.
			using (SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=RockeyProject;Trusted_Connection=True;MultipleActiveResultSets=true"))
			{
				string queryString = "SELECT FirstName,LastName FROM dbo.Employees";
				con.Open();
				SqlCommand cmd = new SqlCommand(queryString,con);
				SqlDataReader DataReader = cmd.ExecuteReader();

				if (DataReader.HasRows)
				{
					while (DataReader.Read())
					{
						string FirstName = DataReader.GetString(0);
						string LastName = DataReader.GetString(1);
						
						string Username = FirstName.Substring(0, Math.Min(FirstName.Length, 3)) + LastName.Substring(0, Math.Min(LastName.Length, 3));
						IdentityUser user = await userManager.FindByIdAsync(Username);

						if (user == null)
						{
							user = new IdentityUser(Username);
							await userManager.CreateAsync(user, adminPassword);
						}
					}
				}
				DataReader.Close();
				con.Close();
			}
		}
	}
}