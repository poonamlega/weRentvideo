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
        public DateTime RDate { get; set; }

    }
}