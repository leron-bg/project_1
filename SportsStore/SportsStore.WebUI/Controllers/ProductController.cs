namespace SportsStore.WebUI.Controllers
{
	using SportsStore.Domain.Abstract;
	using System.Web.Mvc;

	public class ProductController : Controller
    {
		private IProductRepository _repository;

		public ProductController(IProductRepository repository)
		{
			_repository = repository;
		}

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

		public ViewResult List() => View(_repository.Products);
    }
}