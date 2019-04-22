using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RockeyProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RockeyProject
{

	public class Startup
	{

		public Startup(IConfiguration configuration) =>
			Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration["Data:RockeyProjectProducts:ConnectionString"]));

			services.AddDbContext<AppIdentityDbContext>(options =>
				options.UseSqlServer(
					Configuration["Data:RockeyProjectIdentity:ConnectionString"]));

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AppIdentityDbContext>()
				.AddDefaultTokenProviders();
				//.AddUserManager<IdentityUser>();
			services.AddTransient<IProductRepository, EFProductRepository>();
			services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IOrderRepository, EFOrderRepository>();
			services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			//app.UseIdentity();
			app.UseSession();
			app.UseAuthentication();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "Error", template: "Error",
					defaults: new { controller = "Error", action = "Error" });
				routes.MapRoute(
					name: "Default",
					template: "",
					defaults: new { controller = "Home", action = "Homepage" }
				);
				routes.MapRoute(
					name: null,
					template: "{category}/Page{productPage:int}",
					defaults: new { controller = "Product", action = "List" }
				);

				routes.MapRoute(
					name: null,
					template: "Page{productPage:int}",
					defaults: new { controller = "Product", action = "List", productPage = 1 }
				);

				routes.MapRoute(
					name: null,
					template: "{category}",
					defaults: new { controller = "Product", action = "List", productPage = 1 }
				);

				routes.MapRoute(
					name: null,
					template: "",
					defaults: new { controller = "Product", action = "List", productPage = 1 });

				routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
			});
			//SeedData.Depopulate(app);
			//SeedData.EnsurePopulated(app);
			//IdentitySeedData.EnsurePopulated(app);
		}
	}
}
