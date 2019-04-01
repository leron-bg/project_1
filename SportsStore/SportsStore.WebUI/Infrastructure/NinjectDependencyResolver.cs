namespace SportsStore.WebUI.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;
	using Moq;
	using Ninject;
	using SportsStore.Domain.Abstract;
	using SportsStore.Domain.Entities;
	using SportsStore.Domain.Concrete;

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
			_kernel.Bind<IProductRepository>().To<EFProductRepository>();
		}
	}
}