using System;
using System.Configuration;
using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;
using Ninject;
using Moq;
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
            //Mock implementation of the IDriverRepository Interface
            //Mock<IDriverRepository> mock = new Mock<IDriverRepository>();
            //mock.Setup(m => m.Drivers).Returns(new List<Driver> {
            //    new Driver { Name = "Koen", Hometown = "Duffel" },
            //    new Driver { Name = "Joeri", Hometown = "Beveren" },
            //    new Driver { Name = "Jan", Hometown = "Rupelmonde" }
            //}.AsQueryable());
            //ninjectKernel.Bind<IDriverRepository>().ToConstant(mock.Object);

            ninjectKernel.Bind<IDriverRepository>().To<EFDriverRepository>();
            ninjectKernel.Bind<ITrackRepository>().To<EFTrackRepository>();
            ninjectKernel.Bind<IRaceRepository>().To<EFRaceRepository>();
            ninjectKernel.Bind<IRaceResultRepository>().To<EFRaceResultRepository>();
        }
    }
}