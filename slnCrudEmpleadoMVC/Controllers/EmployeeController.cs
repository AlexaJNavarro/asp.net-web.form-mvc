using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using slnCrudEmpleadoMVC.Models;

namespace slnCrudEmpleadoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private bd_AspNETCrudEntities db = new bd_AspNETCrudEntities();
        
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var emp = db.Empleado.Find(id);

            if (emp == null) {
                return HttpNotFound();
            }

            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var emp = db.Empleado.Find(id);

            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var emp = db.Empleado.Find(id);

            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleado = db.Empleado.Find(id);
                    if (empleado == null) {
                        return HttpNotFound();
                    }
                    db.Empleado.Remove(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }
    }
}
