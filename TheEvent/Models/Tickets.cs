using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheEvent.Models
{
    public class Tickets
    {
        // tickets 
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age ")]
        public string Age { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "NumberOfTicket")]
        public string NumberOfTicket { get; set; }

        [Display(Name = "ScheduleId")]
        public int ScheduleId { get; set; }
    }
}
