using System.Linq;

namespace RockeyProject.Models
{

	public interface IOrderRepository
	{

		IQueryable<Order> Orders { get; }
		void SaveOrder(Order order);
	}
}
