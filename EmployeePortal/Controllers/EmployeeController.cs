using EmployeePortal.DataAccessLayer;
using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDAL employeeDal=new EmployeeDAL();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees=employeeDal.GetAll().ToList();
            return View(employees);
        }
        //for updating and insert employee
        [HttpGet]
        public ActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Employee emp = employeeDal.Get(id);
                return View(emp);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Employee emp)
        {
            if(ModelState.IsValid)
            {
                if (emp.EmployeeId == 0 || emp.EmployeeId==null)
                {
                    employeeDal.Add(emp);
                    TempData["SuccessMessage"] = "Employee added successfully!";
                }
                else
                {
                    employeeDal.Update(emp);
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult Delete(int? id)
        {
            bool res = false;
            Employee emp = employeeDal.Get(id);
            if (emp == null)
            {
                return Json(res,JsonRequestBehavior.AllowGet);
            }
            else
            {
                res = employeeDal.Delete(id);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}