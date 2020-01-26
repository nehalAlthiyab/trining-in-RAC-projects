using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dolist.Models
{
    public class addNewTask
    {
        [Display (Name = "Task")]
        public string Work { get; set; }
        [Display (Name ="day from")]
        [DataType(DataType.Date)]
        public string From { get; set; }
        [Display(Name = "day from")]
        [DataType(DataType.Date)]
        public string To { get; set; }
    }
}