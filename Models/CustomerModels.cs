using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weRentvideo.Models
{
    public class CustomerModels
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        [Required]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}