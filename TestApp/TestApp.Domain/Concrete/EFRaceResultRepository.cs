using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using System.Data;

namespace KartingApp.Domain.Concrete
{
    public class EFRaceResultRepository : IRaceResultRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<RaceResult> RaceResults
        {
            get { return context.RaceResults.Include("Race"); }
        }

        public IQueryable<Driver> Drivers
        {
            get { return context.Drivers; }
        }

        public IQueryable<Race> Races
        {
            get { return context.Races.Include("RaceResults").OrderByDescending(x => x.Date); }
        }

        public void SaveRaceResult(RaceResult raceResult)
        {
            if (raceResult.RaceResultID == 0)
            {
                context.RaceResults.Add(raceResult);
            }
            else
            {
                context.Entry(raceResult).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void DeleteRaceResult(RaceResult raceResult)
        {
            context.RaceResults.Remove(raceResult);
            context.SaveChanges();
        }

    }
}
