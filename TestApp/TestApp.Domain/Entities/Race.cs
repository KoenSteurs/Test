using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartingApp.Domain.Entities
{
    public class Race
    {
       
        [HiddenInput(DisplayValue = false)]
        public int RaceID { get; set; }

        [Display(Name = "Track")]
        [ForeignKey("Track")]
        [Required(ErrorMessage = "Please select a Track")]
        public int TrackID { get; set; }

        public virtual Track Track { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime Date { get; set; }

        public ICollection<RaceResult> RaceResults { get; set; }

        public string RaceDescription
        {
            get 
            {
                if (Track != null)
                {
                    return (string.Format("{0:dd/MM/yyyy}", Date) + ", " + Track.Description);
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
