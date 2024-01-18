﻿using Microsoft.EntityFrameworkCore;
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
                _context.Database.ExecuteSqlRaw($"exec InsertRegister '{register.UserName}','{register.Password}'");
            }
            catch (Exception ex)
            {
                throw;
            }
            

        }
        public bool Login(string Username ,string Password)
        {
            try
            {

                var result = _context.Registration.FromSqlRaw<Registration>($" exec checkpassword'{Username}','{Password}'").ToList();
                if (result.Count > 0 & result!= null)
                    return true;
                else
                    return false;
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
                IEnumerable<Registration> all = _context.Registration.FromSqlRaw<Registration>($"exec Getallas");
                return all.ToList();
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
                var update =_context.Database.ExecuteSqlRaw($"exec UpdateRecord {Id},'{value.UserName}','{value.Password}'");

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Registration GetById(long number)
        {
            try
            {
 
                var result = _context.Registration.FromSqlRaw<Registration>($"exec Getbyid={number}").ToList().FirstOrDefault(); 
                return result;
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
                var result = _context.Database.ExecuteSqlRaw($"exec DeleteRegistration {id} ");
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
                var result = _context.Registration.FromSqlRaw<Registration>($"exec CheckRegistration '{register.UserName}','{register.Password}'").ToList();
                if (result.Count > 0 && result != null)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
