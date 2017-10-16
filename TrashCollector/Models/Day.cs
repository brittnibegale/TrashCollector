using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Day
    {
        [Key]
        public int ID { get; set; }

        public string DayChoice { get; set; }

    }
}