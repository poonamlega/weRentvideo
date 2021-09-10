using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string FullName
        {
            get
            {
                return Name + " " + LastName;
            }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }
      
        [Required]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int MembershipFK { get; set; }

        [ForeignKey("MembershipFK")]
        public virtual MembershipModels MembershipModelsId { get; set; }      
        //public int DeptID { get; set; } //<-- You forgot to add this
        //[ForeignKey("DeptID")]
        //public virtual DepartmentModel DID { get; set; }
    }
}