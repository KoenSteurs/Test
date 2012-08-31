using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;

namespace KartingApp.WebUI.Controllers
{
    public class DriverController : Controller
    {
        private IDriverRepository repository;

        public DriverController(IDriverRepository driverRepository)
        {
            repository = driverRepository;
        }

        public ViewResult List()
        {
            return View(repository.Drivers);
        }
    }
}
