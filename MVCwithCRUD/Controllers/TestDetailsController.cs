using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
namespace MVCwithCRUD.Controllers
{
    public class TestDetailsController : Controller
    {
        private readonly ITestDetailsRepostory TstdetObj;
       public TestDetailsController()
        {
            TstdetObj = new TestDetailsRepostory();
        }
        public ActionResult Index()
        {
            var result = TstdetObj.ReadSP();
            return View("list",result);
        }

        // GET: TestDetailsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestDetailsController1/Create
        public ActionResult Create()
        {
            return View("Insert",new TestDetail());
        }

        // POST: TestDetailsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestDetail val)
        {
            try
            {
                TstdetObj.InsertSP(val);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestDetailsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestDetailsController1/Edit/5
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

        // GET: TestDetailsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestDetailsController1/Delete/5
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
