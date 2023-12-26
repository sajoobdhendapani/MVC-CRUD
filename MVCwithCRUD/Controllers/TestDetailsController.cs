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
            var Detail = TstdetObj.ReadByNumberSP(id);
            return View("Details",Detail);
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
                
                if (ModelState.IsValid)
                {
                    if (val.StartDate < DateTime.Now)
                    {
                        ModelState.AddModelError("StratDate", "Start date must be greater than today date");
                        return View("Create", val);
                    }
                    TstdetObj.InsertSP(val);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Create", val);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: TestDetailsController1/Edit/5
        public ActionResult Edit(int id)
        {
            var Detail = TstdetObj.ReadByNumberSP(id);
            return View("Edit",Detail);
        }

        // POST: TestDetailsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TestDetail det)
        {
            try
            {
                TstdetObj.UpdateSP(id,det);
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
            var Delete = TstdetObj.ReadByNumberSP(id);
            return View("Delete",Delete);
        }

        // POST: TestDetailsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TstdetObj.DeleteSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
