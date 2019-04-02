namespace SportsStore.WebUI.Controllers
{
	using SportsStore.Domain.Abstract;
	using System.Collections.Generic;
	using System.Web.Mvc;
	using System.Linq;

	public class NavController : Controller
    {
		private IProductRepository _repository;

		public NavController(IProductRepository repository) => _repository = repository;

		public PartialViewResult Menu(string category = null)
        {
			ViewBag.SelectedCategory = category;

			IEnumerable<string> categories = _repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);

			return PartialView(categories);
        }
    }
}