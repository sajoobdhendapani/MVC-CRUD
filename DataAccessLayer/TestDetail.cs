using System;
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
        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [Display(Name = " Subject Name")]
        public string Name { get; set; }
        [Display(Name = " Subject Number")]
        public int Number { get; set; }
        //[Compare("score")]
        public double Duration { get; set; }
        public long Score { get; set; }
        public DateTime StartDate { get; set; }

    }
}
