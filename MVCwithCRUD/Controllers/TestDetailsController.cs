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
        private readonly ITestDetailsRepostory _TstdetObj;
        private readonly string _connectionString;
       public TestDetailsController(ITestDetailsRepostory result, IConfiguration Configuration)
        {
            _TstdetObj = result;
            _connectionString = Configuration.GetConnectionString("DbConnection");

        }
        public ActionResult Index()
        {
            var result = _TstdetObj.ReadSP();
            return View("list",result);
        }

        // GET: TestDetailsController1/Details/5
        public ActionResult Details(int id)
        {
            var Detail = _TstdetObj.ReadByNumberSP(id);
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
                
                
                    _TstdetObj.InsertSP(val);

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
            var Detail = _TstdetObj.ReadByNumberSP(id);
            return View("Edit",Detail);
        }

        // POST: TestDetailsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TestDetail det)
        {
            try
            {
                _TstdetObj.UpdateSP(id,det);
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
            var Delete = _TstdetObj.ReadByNumberSP(id);
            return View("Delete",Delete);
        }

        // POST: TestDetailsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _TstdetObj.DeleteSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
