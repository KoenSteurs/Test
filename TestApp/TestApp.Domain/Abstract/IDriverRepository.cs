using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Entities;

namespace KartingApp.Domain.Abstract
{
    public interface IDriverRepository
    {
        IQueryable<Driver> Drivers { get; }
        void SaveDriver(Driver driver);
        void DeleteDriver(Driver driver);
    }
}
