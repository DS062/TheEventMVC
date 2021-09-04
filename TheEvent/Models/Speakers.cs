using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheEvent.Models
{
    public class Speakers
    {
        // Speakers
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Display(Name = "Age")]
        public string Age { get; set; }


        [Display(Name = "Language")]
        public string Language { get; set; }

    }
}
