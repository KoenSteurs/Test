using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KartingApp.Domain.Other;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartingApp.Domain.Entities
{
    public class RaceResult
    {
        [HiddenInput(DisplayValue = false)]
        public int RaceResultID { get; set; }

        [ForeignKey("Race")]
        [Required(ErrorMessage = "Please enter a Race")]
        [Display(Name = "Race")]
        public int RaceID { get; set; }
        public virtual Race Race { get; set; }

        [ForeignKey("Driver")]
        [Required(ErrorMessage = "Please enter a Driver")]
        [Display(Name = "Driver")]
        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }

        [Display(Name = "Best Lap")]
        public double BestLap { get; set; }

        public string RaceResultDescription
        { get { return this.Driver.Name + " - " + this.BestLap; } }

        public string RaceResultDescriptionForDriver
        { get { return this.Race.RaceDescription + ": " + this.PlaceInRace + " (" + this.BestLap +")"; } }

        public int PlaceInRace
        { get { return new Calculations().PlaceInRace(this); } }
    }
}
