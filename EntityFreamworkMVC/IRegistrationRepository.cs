using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMVC
{
     public interface IRegistrationRepository
     {
        public bool Login(string Username, string Password);
        public IEnumerable<Registration> GetAllRegistrations();
        public void Insert(Registration register);
        public void Update(long Id, Registration value);
        public Registration GetById(long id);
        public void Delete(long id);
        public bool Register(Registration register);
     }
}
