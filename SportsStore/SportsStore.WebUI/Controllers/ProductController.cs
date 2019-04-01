namespace SportsStore.WebUI.Controllers
{
	using SportsStore.Domain.Abstract;
	using System.Web.Mvc;
	using System.Linq;
	using SportsStore.WebUI.Models;

	public class ProductController : Controller
    {
		private IProductRepository _repository;
		public int pageSize = 4;

		public ProductController(IProductRepository repository)
		{
			_repository = repository;
		}

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

		public ViewResult List(int page = 1)
		{
			var model = new ProductsListViewModel
			{
				Products = _repository.Products
					.OrderBy(p => p.ProductID)
					.Skip((page - 1) * pageSize)
					.Take(pageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = pageSize,
					TotalItems = _repository.Products.Count()
				}
			};

			return View(model);
		}
    }
}