using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Entities;

namespace KartingApp.Domain.Abstract
{
    public interface ITrackRepository
    {
        IQueryable<Track> Tracks { get; }
        void SaveTrack(Track track);
        void DeleteTrack(Track track);
    }
}
