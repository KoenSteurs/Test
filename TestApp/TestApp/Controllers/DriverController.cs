using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using KartingApp.Domain.Concrete;

namespace TestApp.WebUI.Controllers
{
    public class DriverController : Controller
    {
        private IDriverRepository repository;

        public DriverController()
        {
            repository = new EFDriverRepository();
        }

        public ViewResult List()
        {
            return View(repository.Drivers);
        }
    }
}
