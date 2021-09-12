using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weRentvideo.Models;

namespace weRentvideo.ViewModels
{
    public class GenreDropDownViewModel
    {

        public MovieModels Movie { get; set; }
        public List<int> GenreIds { get; set; }

    }
}