using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using System.Data;

namespace KartingApp.Domain.Concrete
{
    public class EFRaceRepository : IRaceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Track> Tracks
        {
            get { return context.Tracks; }
        }

        public IQueryable<Race> Races
        {
            get { return context.Races.Include("RaceResults").Include("Track"); }
        }

        //public IQueryable<RaceResult> RaceResults
        //{
        //    get { return context.RaceResults; }
        //}

        public void SaveRace(Race Race)
        {
            if (Race.RaceID == 0)
            {
                context.Races.Add(Race);
            }
            else
            {
                context.Entry(Race).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void DeleteRace(Race Race)
        {
            context.Entry(Race).State = EntityState.Deleted;
            context.Races.Remove(Race);
            context.SaveChanges();
        }
    }
}
