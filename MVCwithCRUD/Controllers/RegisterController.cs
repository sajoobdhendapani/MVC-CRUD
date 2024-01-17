using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EntityFrameworkMVC;


namespace MVCwithCRUD.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegistrationRepository _add;
        private readonly string _connectionstring;
        public RegisterController(IRegistrationRepository add, IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DbConnection");
            _add = add;
            

        }
        
        // GET: RegisterController
        public ActionResult Index()
        {
            var result = _add.GetAllRegistrations();
            return View("View",result);
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                var result = _add.GetById(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            var result = new Registration();
            return View("Register", result);
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration value)
        {
            var result = _add.Login(value);

            try
            {
                if (result == true)
                {
                    _add.Insert(value);
                    return Redirect("/Login/Index");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _add.GetById(id);
                return View("Edit", result);
            }
            catch
            {
                return View("Error");
            }
            
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Registration value)
        {
            try
            {
                _add.Update(id, value);
                var result = _add.GetAllRegistrations();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                var result= _add.GetById(id);
                return View("Delete", result);
            }
            catch
            {
                return View("Error");
            }
            
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebyid(long RegistrationId)
        {
            try
            {
                _add.Delete(RegistrationId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
