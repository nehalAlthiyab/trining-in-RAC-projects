using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace todolist.Models
{
    public class addNewTask
    {
        public int Id { get; set; }
        [Display(Name="Task:")]
        public string Work { get; set; }
        [Display(Name = "From:")]
        [DataType(DataType.DateTime), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.DateTime), Required]
        [Display(Name = "To:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }

        public int Completed { get; set; }



    }
}