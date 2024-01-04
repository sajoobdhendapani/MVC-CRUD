using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MVCwithCRUD.Controllers
{
    public class Loginkey
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginController : Controller
    {
        private readonly string _userid;
        private readonly string _passcord;

        public  LoginController(IConfiguration configuration)
        {
            _userid = configuration.GetValue <string> ("Login:Username");
            _passcord = configuration.GetValue<string>("Login:Password");
        }
        
        public ActionResult Index()
        {
            return View("Login");
        }

        // GET: LoginController/Details/5
        public ActionResult authentication(Loginkey log)
        {
            try
            {
                if(log.Username == _userid && log.Password == _passcord)
                {
                    return Redirect("/TestDetails/index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email Error");
                    return View("Login");
                }

            }
            catch
            {
                return View("Error");
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
