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
        public int ID { get; set; }
        [Required]
        [Display(Name = "Number of Consecutive Weeks for Pick- Up: ")]
        public string Weeks { get; set; }

        public double Cost { get; set; }

        [ForeignKey("DayID")]
        public Day Day { get; set; }
        [Display(Name = "Day of Pick-Up: ")]
        public int DayID { get; set; }
        public IEnumerable<Day> Days { get; set; }
    }
}