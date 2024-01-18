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
    public class Loginkey
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginController : Controller
    {
        //private readonly string _userid;
        //private readonly string _passcord;

        //public  LoginController(IConfiguration configuration)
        //{
        //    _userid = configuration.GetValue <string> ("Login:Username");
        //    _passcord = configuration.GetValue<string>("Login:Password");
        //}
        private readonly IRegistrationRepository _reg;
        private readonly string _configuration;
        public LoginController(IRegistrationRepository reg, IConfiguration configuration)
        {
            _reg = reg;
            _configuration = configuration.GetConnectionString("DbConnection");
        }
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Authentication(Loginkey values)
        {
            try
            {
                var resultreg = _reg.Login(values.Username, values.Password);
                if(resultreg== true)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("password", "Invalid Email or Password");
                    return View("Login");
                }
            }
            catch
            {
                return View("Login");
            }
        }


        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

