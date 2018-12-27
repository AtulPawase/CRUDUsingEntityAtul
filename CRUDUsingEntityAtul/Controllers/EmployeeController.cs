using CRUDUsingEntityAtul.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingEntityAtul.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        AtulDatabaseEntities db = new AtulDatabaseEntities();
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var EditRow = db.Employees.Where(model => model.ID == id).FirstOrDefault();
            return View(EditRow);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(Employee emp)
        {
            
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}