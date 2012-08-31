using System;
using System.Configuration;
using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;
using Ninject;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using KartingApp.Domain.Concrete;
using System.Collections.Generic;

namespace KartingApp.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IDriverRepository>().To<EFDriverRepository>();
        }
    }
}