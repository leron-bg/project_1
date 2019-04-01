namespace SportsStore.Domain.Abstract
{
	using System.Collections.Generic;
	using SportsStore.Domain.Entities;

	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
	}
}
