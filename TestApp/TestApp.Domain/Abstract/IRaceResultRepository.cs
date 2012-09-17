using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Entities;

namespace KartingApp.Domain.Abstract
{
    public interface IRaceResultRepository
    {
        IQueryable<RaceResult> RaceResults { get; }
        IQueryable<Driver> Drivers { get; }
        IQueryable<Race> Races { get; }
        void SaveRaceResult(RaceResult raceResult);
        void DeleteRaceResult(RaceResult raceResult);
    }
}
