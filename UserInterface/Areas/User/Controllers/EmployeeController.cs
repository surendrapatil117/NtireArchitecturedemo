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
        public ActionResult Index()
        {
            var employee=objBs.GetAll();

            return View(employee);
        }
       // [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try {
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