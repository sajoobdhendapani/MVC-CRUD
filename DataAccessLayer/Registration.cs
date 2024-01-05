using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer
{
    public class Registration
    {
        
        public long RegistrationId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

