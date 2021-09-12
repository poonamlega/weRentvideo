using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weRentvideo.Models
{
    public class GenreModels
    {
        [Key]
        public int Id { get; set; }
        public string GenreType { get; set; }


    }
}