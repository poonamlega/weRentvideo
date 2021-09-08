using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weRentvideo.Models;

namespace weRentvideo.ViewModels
{
    public class EditViewModel
    {
        public CustomerModels customer { get; set; }
        public List<int> membershipIds { get; set; }
    }
}