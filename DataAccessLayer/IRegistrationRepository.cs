using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
     public interface IRegistrationRepository
     {
        public void Insert(Registration product);
        public Registration Findbynumber(int number);
     }
}
