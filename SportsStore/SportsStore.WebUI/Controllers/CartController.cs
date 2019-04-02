namespace SportsStore.WebUI.Controllers
{
	using SportsStore.Domain.Abstract;
	using SportsStore.Domain.Concrete;
	using SportsStore.WebUI.Models;
	using System.Linq;
	using System.Web.Mvc;

	public class CartController : Controller
    {
		private IProductRepository _repository;

		public CartController(IProductRepository repository)
		{
			_repository = repository;
		}

		public ViewResult Index(string returnUrl) => View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });

		public RedirectToRouteResult AddToCart(int productId, string returnUrl)
		{
			var product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				GetCart().AddItem(product, 1);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
		{
			var product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
			if (product != null)
			{
				GetCart().RemoveLine(product);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		private Cart GetCart()
		{
			Cart cart = (Cart)Session["Cart"];
			if (cart == null)
			{
				cart = new Cart();
				Session["Cart"] = cart;
			}
			return cart;
		}
	}
}