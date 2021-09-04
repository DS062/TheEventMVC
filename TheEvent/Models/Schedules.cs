using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheEvent.Models
{
    public class Schedules
    {
        // schedule table 
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Schedule")]
        public string Schedule { get; set; }

        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
