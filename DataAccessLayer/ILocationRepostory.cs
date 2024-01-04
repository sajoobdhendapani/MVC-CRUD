using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ILocationRepostory
    {
        public IEnumerable<Locations> LocationDetails();
        //public Locations LocationUpdate(long id, Locations prd);
    }
}
