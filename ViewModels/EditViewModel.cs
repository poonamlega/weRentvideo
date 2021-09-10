using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weRentvideo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weRentvideo.ViewModels
{
    public class EditViewModel
    {
        public CustomerModels customer { get; set; }
        public List<int> MembershipIds { get; set; }
       
    }
}