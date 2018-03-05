using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using TaskWebApplication.Infrastructure.Abstract;
using TaskWebApplication.Infrastructure.Implementation;

namespace TaskWebApplication.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IActivityTypeRepository>().To<ActivityTypeRepository>();
            kernel.Bind<IOrganizationRepository>().To<OrganizationRepository>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}