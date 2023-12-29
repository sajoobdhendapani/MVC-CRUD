using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
namespace MVCwithCRUD.Controllers 
{
    public class TestDetailsController : Controller
    {
        private readonly ITestDetailsRepostory _tstdetObj;
        private readonly string _connectionString;
       public TestDetailsController(ITestDetailsRepostory result, IConfiguration Configuration)
        {
            _tstdetObj = result;
            _connectionString = Configuration.GetConnectionString("DbConnection");

        }
        public ActionResult Index()
        {
            try
            {
                var result = _tstdetObj.ReadSP();
                return View("list", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: TestDetailsController1/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var Det = _tstdetObj.ReadByNumberSP(id);
                return View("Details", Det);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: TestDetailsController1/Create
        public ActionResult Create()
        {
            try
            {


                return View("Create", new TestDetail());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: TestDetailsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestDetail val)
        {
            try
            {

                if (val.StartDate < DateTime.Today)
                {
                    ModelState.AddModelError("StartDate", "StartDate Must Be Greater To Today");
                    return View("Create", val);
                }
                if (ModelState.IsValid)
                {
                    _tstdetObj.InsertSP(val);
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    return View("Create", val);
                }
                
                
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: TestDetailsController1/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {


                var Detail = _tstdetObj.ReadByNumberSP(id);
                return View("Edit", Detail);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: TestDetailsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TestDetail det)
        {
            try
            {
                if (det.StartDate < DateTime.Today)
                {
                    ModelState.AddModelError("StartDate", "StartDate Must Be Greaterthen");
                    return View("Edit", det);
                }
                if (ModelState.IsValid)
                {
                    _tstdetObj.UpdateSP(id, det);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Edit", det);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: TestDetailsController1/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {


                var Delete = _tstdetObj.ReadByNumberSP(id);
                return View("Delete", Delete);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: TestDetailsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebynym(int id)
        {
            try
            {
                _tstdetObj.DeleteSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
