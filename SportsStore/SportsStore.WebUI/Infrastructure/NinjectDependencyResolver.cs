namespace SportsStore.WebUI.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;
	using Moq;
	using Ninject;
	using SportsStore.Domain.Abstract;
	using SportsStore.Domain.Entities;

	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel _kernel;
		public NinjectDependencyResolver(IKernel kernel)
		{
			_kernel = kernel;
			AddBindings();
		}
		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}
		private void AddBindings()
		{
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<Product>
			{
				new Product { Name = "Football", Price = 25 },
				new Product { Name = "Surf board", Price = 179 },
				new Product { Name = "Running shoes", Price = 95 }
			});

			_kernel.Bind<IProductRepository>().ToConstant(mock.Object);
		}
	}
}