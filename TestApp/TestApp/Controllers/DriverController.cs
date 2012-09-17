using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using KartingApp.Domain.Concrete;

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

        public ViewResult Create()
        {
            return View("Edit", new Driver());
        }        

        [HttpGet]
        public ViewResult Edit(int id = 1)
        {
            Driver driv = repository.Drivers.FirstOrDefault(p => p.DriverID == id);

            return View("Edit", driv);
        }

        public ViewResult Detail(int id = 1)
        {
            Driver driv = repository.Drivers.FirstOrDefault(p => p.DriverID == id);

            return View(driv);
        }

        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                // save the entity
                repository.SaveDriver(driver);
                // add a message to the viewbag
                TempData["message"] = string.Format("{0} has been saved", driver.Name);
                // return the user to the list
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(driver);
            }
        }

        [HttpPost]
        public ActionResult Delete(Driver driver)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteDriver(driver);
                return RedirectToRoute(new { controller = "Driver", action = "List" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Driver", action = "Edit", id = driver.DriverID });
            }
        }

    }
}
