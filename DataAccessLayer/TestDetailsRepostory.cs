using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class TestDetailsRepostory : ITestDetailsRepostory
    {
        public string connectionString;
        public TestDetailsRepostory(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }

        public TestDetail InsertSP(TestDetail details)
        {
            try
            {

                var con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec InsertTeasDetails @Name='{details.Name}',@Number={details.Number},@Duration={details.Duration},@Score={details.Score},@StartDate='{details.StartDate.ToString("MM-dd-yyyy")}',@LocationId={details.LocationId}");
                con.Close();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
            return details;

        }
        public IEnumerable<TestDetail> ReadSP()
        {
            try
            {

                var con = new SqlConnection(connectionString);
                con.Open();
                var TestDetail = con.Query<TestDetail>($"exec ReadAllTestDetails ");
                con.Close();


                return TestDetail.ToList();

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
        public TestDetail DeleteSP(long id)
        {
            try
            {

                var con = new SqlConnection(connectionString);
                con.Open();
                var TestDetails = con.QueryFirstOrDefault<TestDetail>($"exec DeleteTestDetails @Id={id}");
                con.Close();
                return TestDetails;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public TestDetail UpdateSP(long id, TestDetail updtdetails)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var TestDetails = con.QueryFirstOrDefault<TestDetail>($"exec UpdateTestDetails @id={id}, @Name='{updtdetails.Name}',@Number={updtdetails.Number},@Duration={updtdetails.Duration},@Score={updtdetails.Score},@StartDate='{updtdetails.StartDate.ToString("MM-dd-yyyy")}'");
                con.Close();
                return updtdetails;
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
        public TestDetail ReadByNumberSP(long id)
        {
            try
            {

                var con = new SqlConnection(connectionString);
                con.Open();
                var TestDetails = con.QueryFirstOrDefault<TestDetail>($"exec ReadByNumber @Id={id}");
                con.Close();
                return TestDetails;
            }
            catch (SqlException ex)
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
