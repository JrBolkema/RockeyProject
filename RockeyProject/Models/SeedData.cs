using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace RockeyProject.Models
{

	public static class SeedData
	{
		public static void Depopulate(IApplicationBuilder services)
		{
			ApplicationDbContext context = services.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			using (SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=RockeyProject;Trusted_Connection=True;MultipleActiveResultSets=true"))
			{
				con.Open();

				string sqlTrunc2 = "DELETE FROM CartLine";
				SqlCommand cmd2 = new SqlCommand(sqlTrunc2, con);
				cmd2.ExecuteNonQuery();

				string sqlTrunc = "DELETE FROM Products";
				SqlCommand cmd = new SqlCommand(sqlTrunc, con);
				cmd.ExecuteNonQuery();

				string sqlTrunc3 = "DELETE FROM Employees";
				SqlCommand cmd3 = new SqlCommand(sqlTrunc3, con);
				cmd3.ExecuteNonQuery();

				con.Close();
			}
		}
		public static void EnsurePopulated(IApplicationBuilder services)
		{
			ApplicationDbContext context = services.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();
		


			if (!context.Employees.Any())
			{
				context.Employees.AddRange(
					new Employee("Mr", "Rocky", "303-314-1551", "CEO and President"),
					new Employee("Jamal", "Murray", "303-270-5428", "CFO"),
					new Employee("Nikola", "Jokic", "303-150-5428", "Vice President"),
					new Employee("Gary", "Harris", "303-140-5428", "CTO"),
					new Employee("Monte", "Morris", "303-110-5428", "Sales Team Leader"),
					new Employee("Malik", "Beasley", "303-250-5428", "Traveling Salesman"),
					new Employee("Mason", "Plumlee", "303-240-5428", "Sales Intern")
					//new Employee("","","","")
					);
			}
			
			if (!context.Products.Any())
			{
				
				context.Products.AddRange(
					new Product
					{
						Name = "Rockey's Window Cleaning T-Shirt",
						Description = "Size: Small",
						Category = "Clothing",
						Price = 10
					},
					new Product
					{
						Name = "Rockey's Window Cleaning T-Shirt",
						Description = "Size: Medium",
						Category = "Clothing",
						Price = 12
					},
					new Product
					{
						Name = "Rockey's Window Cleaning T-Shirt",
						Description = "Size: Large",
						Category = "Clothing",
						Price = 15
					},
					new Product
					{
						Name = "Rockey's Window Cleaning T-Shirt",
						Description = "Size: Extra Large",
						Category = "Clothing",
						Price = 18
					},
					new Product
					{
						Name = "Rockey's Window Cleaning T-Shirt",
						Description = "Size: Moose",
						Category = "Clothing",
						Price = 36
					},
					

					new Product
					{
						Name = "Wagtail Slimline Squeegee",
						Description = "Quick and Concealable",
						Category = "Window Cleaning",
						Price = 22.50m
					},
					new Product
					{
						Name = "Wagtail High Flyer",
						Description = "For heavy duty needs",
						Category = "Window Cleaning",
						Price = 45
					},
					new Product
					{
						Name = "Triumph MK3 - 6in. Scraper",
						Description = "For removing paint and other tricky substances",
						Category = "Window Cleaning",
						Price = 35
					},
					new Product
					{
						Name = "Squidgee 6 Gallon Bucket",
						Description = "Standard Squidgee bucket",
						Category = "Window Cleaning",
						Price = 15
					},
					new Product
					{
						Name = "Ettore Brass Quick Release Handle",
						Description = "Let your neighbors know you mean business",
						Category = "Accessories",
						Price = 12
					},
					new Product
					{
						Name = "Unger ErgoTec SwivelLoc 0° Handle",
						Description = "Reach Those Tricky Angles",
						Category = "Accessories",
						Price = 20
					},
					new Product
					{
						Name = "Level-EZE Automatic Ladder Levelers",
						Description = "Dont let that hill or stair stop you",
						Category = "Accessories",
						Price = 125
					},
					new Product
					{
						Name = "Extra fine Steel Wool Pads",
						Description = "Fun to play with",
						Category = "Accessories",
						Price = 8
					},
					new Product
					{
						Name = "Screen Magic - *32oz Sprayer Bottle",
						Description = "Perfect for your tool belt",
						Category = "Accessories",
						Price = 10
					},
					new Product
					{
						Name = "A-Maz Hard Water Stain Remover",
						Description = "A-Maz-Ing",
						Category = "Cleaning Liquids",
						Price = 14
					},
					new Product
					{
						Name = "EZ Kleen - Pro Glass Glide 1 Gallon",
						Description = "Old Faithful",
						Category = "Cleaning Liquids",
						Price = 30
					},
					new Product
					{
						Name = "EZ Kleen Concrete Dissolver - 3.78L",
						Description = "Keep awawy from children",
						Category = "Cleaning Liquids",
						Price = 35
					},
					new Product
					{
						Name = "EZ Kleen Gutter Cleaner (1 gallon) - Gutter Whitening",
						Description = "Since your teen won't do it",
						Category = "Cleaning Liquids",
						Price = 60
					},
					new Product
					{
						Name = "Peabody-5000 Hourly Rental",
						Description = "Shoots at 5000 Peas per second",
						Category = "Rentals",
						Price = 100
					}
				
					
				);
				context.SaveChanges();
			}
		}
	}
}
