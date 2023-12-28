﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestDetail
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Enter Your Subject  Name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [Display(Name = " Subject Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Subject Number")]
        [Display(Name = " Subject Number")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Enter Your Subject Duration")]
        [Display(Name = " Subject Duration")]
        [Compare("Score")]
        public double Duration { get; set; }
        [Required(ErrorMessage = "Enter Your Subject Score ")]
        [Display(Name = " Subject Score")]
        public long Score { get; set; }
        [Required(ErrorMessage = "Enter Your Subject StartDate")]
        [Display(Name = " Subject StartDate")]
        public DateTime StartDate { get; set; }
        

    }
}
