using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Concrete;
using KartingApp.Domain.Entities;

namespace KartingApp.Domain.Other
{
    class Calculations
    {
        public int PlaceInRace(RaceResult raceResult)
        {
            EFRaceResultRepository rep = new EFRaceResultRepository();
            IEnumerable<RaceResult> results = rep.RaceResults.AsEnumerable();
            return results.Where(x => x.RaceID == raceResult.RaceID).Where(x => x.BestLap < raceResult.BestLap).Count() + 1;
        }
    }
}
