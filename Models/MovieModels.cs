using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weRentvideo.Models
{
    public class MovieModels
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RDate { get; set; }
        public string Genre { get; set; }
        public int NumberInStock{ get; set; }

    }
}