using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fortnitetutorials.Models
{
    public class category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "You must fill in a name for the category.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage ="The category name must be within a range of 0 to 100.")]
        public string Name { get; set; }

    }
}