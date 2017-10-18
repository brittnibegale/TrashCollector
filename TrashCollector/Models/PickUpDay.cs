using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUpDay
    {
        [Key]
        public int Id { get; set; }
        public double Cost { get; set; }
        [Display(Name = "I would like to not have pick up from this day:")]
        public DateTime day1 { get; set; }

        [Display(Name = "to this day:")]
        public DateTime day2 { get; set; }

        [Required]
        [Display(Name = "Number of Consecutive Weeks for Pick- Up: ")]
        public string Weeks { get; set; }

        [ForeignKey("DayID")]
        public Day Day { get; set; }
        [Required]
        [Display(Name = "Day of Pick-Up: ")]
        public int DayID { get; set; }

        public IEnumerable<Day> Days { get; set; }
    }
}