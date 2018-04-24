using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fortnitetutorials.Models
{
    public class Guide
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="The guide must have a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="The guide must have a description.")]
        public string Description { get; set; }

        public string ImageFile { get; set; }

        public int? CategoryID { get; set; }
        public virtual category Category { get; set; }
    }
}