using System.Linq;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;

namespace KartingApp.WebUI.Controllers
{
    public class RaceController : Controller
    {
        private IRaceRepository repository;

        public RaceController(IRaceRepository raceRepository)
        {
            repository = raceRepository;
        }

        public ViewResult List()
        {
            return View(repository.Races.OrderByDescending(p => p.Date ));
        }

        public ViewResult Detail(int id = 1)
        {
            Race race = repository.Races.FirstOrDefault(p => p.RaceID == id);
            
            return View(race);
        }

        public ViewResult Create()
        {
            ViewData["Track"] = new SelectList(repository.Tracks.ToList(), "TrackID", "Description", null);
            
            return View("Edit", new Race());
        }

        [HttpGet]
        public ViewResult Edit(int id = 1)
        {
            Race race = repository.Races.FirstOrDefault(p => p.RaceID == id);

            ViewData["Track"] = new SelectList(repository.Tracks.ToList(), "TrackID", "Description", race.TrackID);

            return View("Edit", race);
        }

        [HttpPost]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                // save the entity
                repository.SaveRace(race);
                // add a message to the viewbag
                TempData["message"] = string.Format("Race has been saved");
                // return the user to the list
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(race);
            }
        }

        [HttpPost]
        public ActionResult Delete(Race race)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteRace(race);
                return RedirectToRoute(new { controller = "Race", action = "List" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Race", action = "Edit", id = race.RaceID });
            }
        }



    }
}
