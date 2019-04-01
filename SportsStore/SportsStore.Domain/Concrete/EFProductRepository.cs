namespace SportsStore.Domain.Concrete
{
	using System.Collections.Generic;
	using SportsStore.Domain.Abstract;
	using SportsStore.Domain.Entities;
	using System.Linq;

	public class EFProductRepository : IProductRepository
	{
		private EFDbContext _context = new EFDbContext();
		public IEnumerable<Product> Products
		{
			get
			{
				return _context.Products;
			}
		}
	}
}
