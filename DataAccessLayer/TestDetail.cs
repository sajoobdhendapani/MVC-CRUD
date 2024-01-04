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
        public TestDetail()
        {
            StartDate = DateTime.Now;
        }
        public long Id { get; set; }

        [Required(ErrorMessage = "Enter Your Subject  Name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [Display(Name = " Subject Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Subject Number")]
        [Display(Name = " Subject Number")]
        [Range(1, 100, ErrorMessage = "0 is not allowed")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Enter Your Subject Duration")]
        [Display(Name = " Subject Duration")]
        [Range(1, 5, ErrorMessage = "1 to 5 hrs  will  allowed")]

        public double Duration { get; set; }

        [Required(ErrorMessage = "Enter Your Subject Score ")]
        [Display(Name = " Subject Score")]
        [Range(1, 101, ErrorMessage = "minimum 50 to 100  subject mark  allowed")]


        public long Score { get; set; }

        [Required(ErrorMessage = "Enter Your Subject StartDate")]
        [Display(Name = " Subject StartDate")]
        public DateTime StartDate { get; set; }

        public long LocationId { get; set; }

        public List<Locations> Locations { get; set; }

    }


}
