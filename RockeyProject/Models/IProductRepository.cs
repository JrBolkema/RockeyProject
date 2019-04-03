﻿using System.Linq;

namespace RockeyProject.Models
{

	public interface IProductRepository
	{

		IQueryable<Product> Products { get; }

		void SaveProduct(Product product);

		Product DeleteProduct(int productID);
	}
}
