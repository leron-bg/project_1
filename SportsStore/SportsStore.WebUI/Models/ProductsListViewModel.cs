namespace SportsStore.WebUI.Models
{
	using SportsStore.Domain.Entities;
	using System.Collections.Generic;

	public class ProductsListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}