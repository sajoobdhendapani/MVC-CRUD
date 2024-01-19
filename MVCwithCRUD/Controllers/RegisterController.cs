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
            return View("RegisterPage");
        }
        public ActionResult List()
        {
            var list = _add.GetAllRegistrations();
            return View("View", list);
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
        public ActionResult Authentication(Registration reg)
        {
            try
            {
                var resultreg = _add.Register(reg);
                if(resultreg==true)
                {
                    _add.Insert(reg);
                    return Redirect("/Login/Index");
                }
                else
                {
                    return View("RegisterPage");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create", new Registration());
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration values)
        {


            try
            {
                var resultreg = _add.Register(values);


                if (resultreg == true)
                {
                    _add.Insert(values);

                    var list = _add.GetAllRegistrations();
                    return View("View", list);
                }
                else
                {
                    
                    return View("Create", values);
                }

            }
            catch
            {
                return View("Error");
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
                var list = _add.GetAllRegistrations();
                return View("Edit", list);
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
                var list = _add.GetAllRegistrations();
                return View("Delete", list);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
