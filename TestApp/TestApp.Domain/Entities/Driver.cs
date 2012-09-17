using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KartingApp.Domain.Entities
{
    public class Driver
    {
        [HiddenInput(DisplayValue = false)]
        public int DriverID { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        public string Hometown { get; set; }

        public ICollection<RaceResult> RaceResults { get; set; }
    }
}
