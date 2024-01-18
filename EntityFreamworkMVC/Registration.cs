using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFrameworkMVC
{
    public class Registration
    {
        [Key]
        public long RegistrationId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
       
    }
}

