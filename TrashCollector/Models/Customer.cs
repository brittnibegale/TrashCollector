using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Address")]
        public virtual List<Address> Address { get; set; }
        [Required]
        [Display(Name = "Pick up day")]
        public virtual List<Day> PickDay { get; set; }
    }
}