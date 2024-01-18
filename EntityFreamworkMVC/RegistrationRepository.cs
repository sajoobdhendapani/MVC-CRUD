using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrameworkMVC
{
    public class RegistrationRepository:IRegistrationRepository
    {
        private readonly SampleDbContext _context;

        public RegistrationRepository(SampleDbContext context)
        {
            _context = context;
        }

        public void Insert(Registration register)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"insert into Registration value Username='{register.UserName}',Password='{register.Password}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Login(Registration check)
        {
            try
            {

                var result = _context.Registration.FromSqlRaw<Registration>($"select * from Registration where Username='{check.UserName}'").ToList();
                if (result == null || result.Count > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<Registration> GetAllRegistrations()
        {
            try
            {
                var result = _context.Registration.FromSqlRaw<Registration>($"select * from Registration");
                return result.ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void Update(long Id, Registration value)
        {
            try
            {
             var result = _context.Database.ExecuteSqlRaw($"Update Registration set Username='{value.UserName}',Password='{value.Password}'where Registration={Id} ");

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public Registration GetById(long id)
        {
            try
            {
 
                var result = _context.Registration.FromSqlRaw<Registration>($"select from Registration where RegistrationId={id}");
                return result.ToList().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void Delete(long id)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"delete Registration where RegistrationId={id} ");
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool Register(Registration register)
        {
            try
            {
                var result = _context.Registration.FromSqlRaw<Registration>($"Select * from Registration where Username='{register.UserName}'And Password='{register.Password}' ").ToList();
                if(result.Count==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
