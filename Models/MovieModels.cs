using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace weRentvideo.Models
{
    public class MovieModels
    {   
        [Key]
        public int Id { get; set; }
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RDate { get; set; }
        public int NumberInStock { get; set; }
       

        [ForeignKey("GenreId")]
        public virtual GenreModels GMId { get; set; }


    }
}