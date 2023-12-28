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
            var result = _tstdetObj.ReadSP();
            return View("list",result);
        }


        // GET: TestDetailsController1/Details/5
        public ActionResult Details(int id)
        {
            var Det = _tstdetObj.ReadByNumberSP(id);
            return View("Details",Det);
        }

        // GET: TestDetailsController1/Create
        public ActionResult Create()
        {
            return View("Create",new TestDetail());
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
                    ModelState.AddModelError("StartDate", "StartDate Must Be Greaterthen");
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
                return View();
            }
        }

        // GET: TestDetailsController1/Edit/5
        public ActionResult Edit(int id)
        {
            var Detail = _tstdetObj.ReadByNumberSP(id);
            return View("Edit",Detail);
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
            var Delete = _tstdetObj.ReadByNumberSP(id);
            return View("Delete",Delete);
        }

        // POST: TestDetailsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebynym(int Id)
        {
            try
            {
                _tstdetObj.DeleteSP(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
