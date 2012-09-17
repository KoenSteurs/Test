using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;

namespace KartingApp.WebUI.Controllers
{
    public class TrackController : Controller
    {
        private ITrackRepository repository;

        public TrackController(ITrackRepository trackRepository)
        {
            repository = trackRepository;
        }

        public ViewResult List()
        {
            return View(repository.Tracks);
        }

        public ViewResult Create()
        {
            return View("Edit", new Track());
        }

        [HttpGet]
        public ViewResult Edit(int id = 1)
        {
            Track track = repository.Tracks.FirstOrDefault(p => p.TrackID == id);

            return View("Edit", track);
        }

        public ViewResult Detail(int id = 1)
        {
            Track track = repository.Tracks.FirstOrDefault(p => p.TrackID == id);

            return View(track);
        }

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                // save the entity
                repository.SaveTrack(track);
                // add a message to the viewbag
                TempData["message"] = string.Format("{0} has been saved", track.Description);
                // return the user to the list
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(track);
            }
        }

        [HttpPost]
        public ActionResult Delete(Track track)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteTrack(track);
                return RedirectToRoute(new { controller = "Track", action = "List" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Track", action = "Edit", id = track.TrackID });
            }
        }

    }
}