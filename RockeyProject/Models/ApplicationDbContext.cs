using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace RockeyProject.Models
{

	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
	
	}

	public class ApplicationDbContextFactory
			: IDesignTimeDbContextFactory<ApplicationDbContext>
	{

		public ApplicationDbContext CreateDbContext(string[] args) =>
			Program.BuildWebHost(args).Services
				.GetRequiredService<ApplicationDbContext>();
	}	
}
