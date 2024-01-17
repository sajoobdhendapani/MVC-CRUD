using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class LocationRepostory : ILocationRepostory
    {
        string connectionString;
        public LocationRepostory(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        public IEnumerable<Locations> LocationDetails()
        {

            try
            {


                var con = new SqlConnection(connectionString);
                con.Open();
                var locations = con.Query<Locations>($"exec selectLocation");
                con.Close();
                return locations.ToList();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
