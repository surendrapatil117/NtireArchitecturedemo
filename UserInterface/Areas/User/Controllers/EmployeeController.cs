﻿using BusinessLogicLayer;
using ObjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.App_data;

namespace UserInterface.Areas.User.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private EmployeeBs objBs;
        private CityBs myobj;

        private IExceptionLogging _IExceptionLogging;

        public EmployeeController()
        {
            objBs = new EmployeeBs();
            myobj = new CityBs();
           _IExceptionLogging = ExceptionLogging.GetInstant;
        }
        //singletone design pattern for exception logging
        protected override void OnException(ExceptionContext filterContext)
        {
            _IExceptionLogging.SendErrorToText(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            TempData["ErrorMsg"] = "Something goes Wrong" + filterContext.Exception.Message;
            // RedirectToAction("Create");
            this.View("Error").ExecuteResult(this.ControllerContext);
        }



       
        // GET: User/Employee
        //[HttpPost]
        //public ActionResult Index(string searchtext)
        //{
        //    if (!string.IsNullOrEmpty(searchtext))
        //    {
        //        var employee = objBs.GetEmployeedata(searchtext);
        //        return View(employee);
        //    }
        //    else {

        //        return Json(new { result = "No result Found", JsonRequestBehavior.AllowGet });
        //    }

        //}
        //public ActionResult Index(string SortOrder, string SortBy, int PageNumber = 1)
        //{
        //    ViewBag.SortOrder = SortOrder;
        //    ViewBag.SortBy = SortBy;
        //    List<Employee> employee = objBs.GetAll();
        //    employee= objBs.ApplySorting(SortOrder, SortBy, employee);
        //    employee= ApplyPagination(employee, PageNumber);
        //    return View(employee);
        //}
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        [Authorize(Roles = "Admin,Viewer")]
        public ActionResult Index(string searchtext, string SortOrder, string SortBy, int PageNumber = 1)
        {
           
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
           List<Employee> employee = objBs.GetAll();
            if (searchtext != null)
            {
                employee = objBs.GetEmployeedata(searchtext).ToList();
                employee= objBs.ApplySorting(SortOrder, SortBy, employee);
                employee = ApplyPagination(employee, PageNumber);
            }
            else {
                employee= objBs.ApplySorting(SortOrder, SortBy, employee);
                employee = ApplyPagination(employee, PageNumber);

            }


            return View(employee);
        }
       
        public List<Employee> ApplyPagination(List<Employee> employee, int PageNumber = 1)
        {
            employee = employee.Skip((PageNumber - 1) * 5).Take(5).ToList();

            int totalrowcount = objBs.Getrowcount();
            ViewBag.PageNumber = PageNumber;
            ViewBag.totalpage = Math.Ceiling(totalrowcount / 5.0);
            return employee;
        }

        [Authorize(Roles = "Admin,Author")]
        [HttpGet]
        public ActionResult Create()
        {
            Employee emp = new Employee();
            var city= myobj.GetAll();
            // ViewBag.citydata = new SelectList(city, "CityId", "CityName");// city;
            emp.CityList= new SelectList(city, "CityId", "CityName");
            return View(emp);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Create(Employee emp)
        {
            //try {
           // throw new NullReferenceException("Student object is null.");
            emp.Entrydate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (emp.Uploadedinputfile != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(emp.Uploadedinputfile.FileName);
                        string extension = Path.GetExtension(emp.Uploadedinputfile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                        //emp.ImagePath = "~/images/" + filename;
                        emp.ImagePath = "~/Areas/User/images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Areas/User/images/"), filename);
                        emp.Uploadedinputfile.SaveAs(filename);
                    }
                    objBs.Insert(emp);
                    TempData["SuccessMsg"] = "Data Insertd Successfully";
                    return RedirectToAction("Create");
                }
                else
                {
                    return View();
                }


             // }

            //catch(Exception exec) {
            //    TempData["ErrorMsg"] = "Something goes Wrong" + exec.Message;
            //    return RedirectToAction("Create");
            //}

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           Employee emp= objBs.GetbyId(id);

            if (emp.ImagePath==null)
            {
                emp.ImagePath = "~/images/no-image.jpg";
            }
           

            var city = myobj.GetAll();
          //  ViewBag.citydata = new SelectList(city, "CityId", "CityName");
           emp.CityList= new SelectList(city, "CityId", "CityName");
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Boolean result = false;
            var city = myobj.GetAll();
            // ViewBag.citydata = new SelectList(city, "CityId", "CityName");// city;

            if (emp.Uploadedinputfile!=null)
            {
                string filename = Path.GetFileNameWithoutExtension(emp.Uploadedinputfile.FileName);
                string extension = Path.GetExtension(emp.Uploadedinputfile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                //emp.ImagePath = "~/images/" + filename;
                emp.ImagePath = "~/Areas/User/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Areas/User/images/"), filename);
                emp.Uploadedinputfile.SaveAs(filename);

            }
           
            result = objBs.Update(emp);
            if (result)
            {
                TempData["SuccessMsg"] = "Data Updated Successfully";

            }
            else {
                TempData["ErrorMsg"] = "Something Going Wrong";
            }

            return RedirectToAction("Edit", new { id = emp.EmployeeID });


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Boolean delresult = false;
            delresult= objBs.Delete(id);
           
            if (delresult)
            {
                TempData["SuccessMsg"] = "Data Deleted Successfully";
            }
            else {
                TempData["ErrorMsg"] = "Something Going Wrong";

            }
            string url = this.Url.Action("Index", "Employee", new { area="User" });

            return Json(url);
           // return Json(new { success = true, JsonRequestBehavior.AllowGet });
          
           
               
        }
       



    }
}