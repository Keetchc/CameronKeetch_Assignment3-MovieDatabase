using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CameronKeetch_Assignment3.Models
{
    public class MovieResponse
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string  Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        
        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Please keep your note under 25 characters.")]
        public string Note { get; set;  }
    }
}
