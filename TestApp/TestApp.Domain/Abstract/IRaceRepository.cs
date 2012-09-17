using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Entities;

namespace KartingApp.Domain.Abstract
{
    public interface IRaceRepository
    {
        IQueryable<Race> Races { get; }
        IQueryable<Track> Tracks { get; }
        //IQueryable<RaceResult> RaceResults { get; }
        void SaveRace(Race race);
        void DeleteRace(Race race);
    }
}
