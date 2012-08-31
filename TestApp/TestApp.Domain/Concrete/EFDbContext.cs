using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using KartingApp.Domain.Entities;
using MySql.Data.MySqlClient;

namespace KartingApp.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
    }
}

