using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace list.Models
{
    public class addNewTask
    {
        [Display(Name ="New task:")]
        public string Work { get; set; }
    }
}