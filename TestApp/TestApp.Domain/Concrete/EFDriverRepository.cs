using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using System.Data;

namespace KartingApp.Domain.Concrete
{
    public class EFDriverRepository : IDriverRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<RaceResult> RaceResults
        {
            get { return context.RaceResults; }
        }

        public void SaveDriver(Driver driver)
        {
            if (driver.DriverID == 0)
            {
                context.Drivers.Add(driver);
            }
            else
            {
                context.Entry(driver).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public IQueryable<Driver> Drivers
        {
            get { return context.Drivers.Include("RaceResults"); }
        }

        public void DeleteDriver(Driver driver)
        {
            context.Entry(driver).State = EntityState.Deleted;
            context.Drivers.Remove(driver);
            context.SaveChanges();
        }
    }
}
