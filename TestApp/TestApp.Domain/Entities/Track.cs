using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KartingApp.Domain.Entities
{
    public class Track
    {
        [HiddenInput(DisplayValue = false)]
        public int TrackID { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }

        public ICollection<Race> Races { get; set; }
    }
}
