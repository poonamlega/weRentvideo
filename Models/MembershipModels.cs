 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weRentvideo.Models
{
    public class MembershipModels
    {
        [Key]
        public int Id { get; set; }
        public string MembershipName { get; set; }
        public int SignUpFees { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}