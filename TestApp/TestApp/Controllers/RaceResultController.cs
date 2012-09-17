using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;

namespace KartingApp.WebUI.Controllers
{
    public class RaceResultController : Controller
    {
        private IRaceResultRepository repository;

        public RaceResultController(IRaceResultRepository raceResultRepository)
        {
            repository = raceResultRepository;
        }

        public ViewResult List()
        {
            return View(repository.RaceResults);
        }

        public ViewResult Create(int RaceId = 1)
        {
            ViewData["Driver"] = new SelectList(repository.Drivers.ToList(), "DriverID", "Name");
            ViewData["Race"] = new SelectList(repository.Races.ToList(), "RaceID", "RaceDescription");
            RaceResult rr = new RaceResult();
            rr.RaceID = RaceId;
            return View("Edit", rr);
        }

        [HttpGet]
        public ViewResult Edit(int id = 1)
        {
            RaceResult rr = repository.RaceResults.FirstOrDefault(p => p.RaceResultID == id);

            ViewData["Driver"] = new SelectList(repository.Drivers.ToList(), "DriverID", "Name", rr.DriverID);
            ViewData["Race"] = new SelectList(repository.Races.ToList(), "RaceID", "RaceDescription", rr.RaceID);

            return View("Edit", rr);
        }

        [HttpPost]
        public ActionResult Delete(RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                RaceResult rr = repository.RaceResults.FirstOrDefault(p => p.RaceResultID == raceResult.RaceResultID);
                repository.DeleteRaceResult(rr);
                return RedirectToRoute(new { controller = "Race", action = "Edit", id = rr.RaceID });
            }
            else
            {
                RaceResult rr = repository.RaceResults.FirstOrDefault(p => p.RaceResultID == raceResult.RaceResultID);
                return View(rr);
            }
        }

        [HttpPost]
        public ActionResult Edit(RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRaceResult(raceResult);
                TempData["message"] = "RaceResult has been saved.";
                return RedirectToRoute(new { controller = "Race", action = "Edit", id = raceResult.RaceID });
            }
            else
            {
                return Edit(raceResult.RaceResultID);
            }
        }

    }
}