using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using System.Data;

namespace KartingApp.Domain.Concrete
{
    public class EFTrackRepository : ITrackRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Track> Tracks
        {
            get {  return context.Tracks.Include("Races"); }
        }

        public void SaveTrack(Track track)
        {
            if (track.TrackID == 0)
            {
                context.Tracks.Add(track);
            }
            else
            {
                context.Entry(track).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void DeleteTrack(Track track)
        {
            context.Entry(track).State = EntityState.Deleted;
            context.Tracks.Remove(track);
            context.SaveChanges();
        }
    }
}
