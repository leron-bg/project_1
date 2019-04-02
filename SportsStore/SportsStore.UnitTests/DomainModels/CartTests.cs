namespace SportsStore.UnitTests.DomainModels
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SportsStore.Domain.Concrete;
	using SportsStore.Domain.Entities;

	/// <summary>
	/// Summary description for CartTests
	/// </summary>
	[TestClass]
	public class CartTests
	{

		[TestMethod]
		public void Can_Add_New_Lines()
		{
			// arrange
			var p1 = new Product { ProductID = 1, Name = "P1" };
			var p2 = new Product { ProductID = 2, Name = "P2" };

			var cart = new Cart();

			// act
			cart.AddItem(p1, 1);
			cart.AddItem(p2, 1);
			var results = cart.Lines.ToArray();

			// assert
			Assert.AreEqual(results.Length, 2);
			Assert.AreEqual(results[0].Product, p1);
			Assert.AreEqual(results[1].Product, p2);
		}

		[TestMethod]
		public void Can_Add_Quantity_For_Existing_Lines()
		{
			// arrange
			var p1 = new Product { ProductID = 1, Name = "P1" };
			var p2 = new Product { ProductID = 2, Name = "P2" };

			var cart = new Cart();

			// act
			cart.AddItem(p1, 1);
			cart.AddItem(p2, 1);
			cart.AddItem(p1, 10);
			var results = cart.Lines.OrderBy(c => c.Product.ProductID).ToArray();

			// assert
			Assert.AreEqual(results.Length, 2);
			Assert.AreEqual(results[0].Quantity, 11);
			Assert.AreEqual(results[1].Quantity, 1);
		}

		[TestMethod]
		public void Can_Remove_Line()
		{
			// arrange
			Product p1 = new Product { ProductID = 1, Name = "P1" };
			Product p2 = new Product { ProductID = 2, Name = "P2" };
			Product p3 = new Product { ProductID = 3, Name = "P3" };

			var cart = new Cart();
			cart.AddItem(p1, 1);
			cart.AddItem(p2, 3);
			cart.AddItem(p3, 5);
			cart.AddItem(p2, 1);

			// act
			cart.RemoveLine(p2);

			// assert
			Assert.AreEqual(cart.Lines.Where(c => c.Product == p2).Count(), 0);
			Assert.AreEqual(cart.Lines.Count(), 2);
		}

		[TestMethod]
		public void Calculate_Cart_Total()
		{
			// arrange
			Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
			Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

			var cart = new Cart();
			cart.AddItem(p1, 1);
			cart.AddItem(p2, 1);
			cart.AddItem(p1, 3);

			// act
			var result = cart.ComputeTotalValue();

			// assert
			Assert.AreEqual(result, 450M);
		}

		[TestMethod]
		public void Can_Clear_Contents()
		{
			// arrange
			Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
			Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

			var cart = new Cart();
			cart.AddItem(p1, 1);
			cart.AddItem(p2, 1);

			// act
			cart.Clear();

			// assert
			Assert.AreEqual(cart.Lines.Count(), 0);
		}
	}
}
