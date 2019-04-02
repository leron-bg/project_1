namespace SportsStore.Domain.Concrete
{
	using SportsStore.Domain.Entities;
	using System.Collections.Generic;
	using System.Linq;

	public class Cart
	{
		private List<CartLine> _cartLine = new List<CartLine>();

		public void AddItem(Product product, int quantity)
		{
			var line = _cartLine
				.Where(p => p.Product.ProductID == product.ProductID)
				.FirstOrDefault();

			if (line == null)
			{
				_cartLine.Add(new CartLine { Product = product, Quantity = quantity });
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Product product) => _cartLine.RemoveAll(p => p.Product.ProductID == product.ProductID);

		public decimal ComputeTotalValue() => _cartLine.Sum(e => e.Product.Price * e.Quantity);

		public void Clear() => _cartLine.Clear();

		public IEnumerable<CartLine> Lines
		{
			get
			{
				return _cartLine;
			}
		}
	}

	public class CartLine
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
