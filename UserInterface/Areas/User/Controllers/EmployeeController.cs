using BusinessLogicLayer;
using ObjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Areas.User.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeBs objBs;
        public EmployeeController()
        {
            objBs = new EmployeeBs();
        }
        // GET: User/Employee
        [HttpPost]
        public ActionResult Index(string searchtext)
        {
            if (!string.IsNullOrEmpty(searchtext))
            {
                var employee = objBs.GetEmployeedata(searchtext);
                return View(employee);
            }
            else {

                return Json(new { result = "No result Found", JsonRequestBehavior.AllowGet });
            }
              
        }
        public ActionResult Index(string SortOrder, string SortBy,int PageNumber=1)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var employee = objBs.GetAll(SortOrder, SortBy,PageNumber);
            int totalrowcount = objBs.Getrowcount();
            // viewbag.totalpage = Math.Ceiling(db.Employees.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
          ViewBag.totalpage= Math.Ceiling(totalrowcount / 5.0);
            return View(employee);
        }
       
        // [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try {

                emp.Entrydate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    objBs.Insert(emp);
                    TempData["SuccessMsg"] = "Data Insertd Successfully";
                    return RedirectToAction("Create");
                }
                else {
                    return View();
                }


            }
            catch(Exception exec) {
                TempData["ErrorMsg"] = "Something goes Wrong" + exec.Message;
                return RedirectToAction("Create");
            }


           

            
        
        }
    }
}