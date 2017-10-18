using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display (Name = "Street Number and Name: ")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "City: ")]
        public string City { get; set; }

        [Required]
        [Display (Name = "Zipcode: ")]
        public string Zipcode { get; set; }

    }
}