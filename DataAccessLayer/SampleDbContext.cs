using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions options) 
        {

        }
        public DbSet<Registration> Registration { get; set; }
    }
}
